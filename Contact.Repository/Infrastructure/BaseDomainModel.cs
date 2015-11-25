using System;
using System.Collections.Generic;
using System.Threading;
using July.Common.Infrastructure.Contract;

namespace July.Common.Infrastructure
{
    [Serializable]
    public abstract class BaseDomainModel<T> : NonAuditableDomainModel<T>, IDomainModel, IDataModel, IValidatable
        where T : BaseDomainModel<T>
    {
        public BaseDomainModel(bool isActive = true)
        {
            IsActive = isActive;
            this.InitializeModel();
        }

        public void SetCreateProperties()
        {
            CustomUserPrincipal principal = Thread.CurrentPrincipal as CustomUserPrincipal;
            IsDeleted = false;
            DateCreated = DateTime.UtcNow;
            DateModified = DateTime.UtcNow;
            if (principal != null)
            {
                CreatedBy = principal.PersonId;
                OrganizationId = principal.OrganizationId;
                ModifiedBy = principal.PersonId;
                CreatedByName = principal.FullName;
                ModifiedByName = principal.FullName;
            }
        }

        private void InitializeModel()
        {
            CustomUserPrincipal principal = Thread.CurrentPrincipal as CustomUserPrincipal;
            IsDeleted = false;
            DateCreated = DateTime.UtcNow;
            DateModified = DateTime.UtcNow;
            if (principal != null)
            {
                CreatedBy = principal.PersonId;
                OrganizationId = principal.OrganizationId;
                ModifiedBy = principal.PersonId;
                CreatedByName = principal.FullName;
                ModifiedByName = principal.FullName;
            }
        }



        /// <summary>
        /// Validates the entity according to it's currently set Validator(s)
        /// Returns true / false if the object is valid and sets the brokenRules with what may be wrong with the entity
        /// </summary>
        /// <param name="brokenRules"></param>
        /// <returns></returns>
        public virtual bool Validate(out IEnumerable<string> brokenRules)
        {
            IValidator<T> validator = Validator.GetValidatorFor(this as T);
            // If we don't find any validators then we can't check it's valid!
            if (validator == null)
            {
                Console.WriteLine("Entity : " + typeof (T) +
                                  " has no validators and is being validated. Consider setting some defaults.");
                brokenRules = new List<String>();
                return true;
            }

            var result = validator.IsValid(this as T);
            brokenRules = validator.BrokenRules(this as T);

            return result;
        }

        public void SetUpdateProperties(Guid userId)
        {
            DateModified = DateTime.UtcNow;
            ModifiedBy = userId;
        }

        public void SetCreateProperties(Guid userId, Guid organizationId)
        {
            DateCreated = DateTime.UtcNow;
            CreatedBy = userId;
            OrganizationId = organizationId;
        }

        public void MarkDeleted(Guid userId)
        {
            IsDeleted = true;
        }
        
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateModified { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public Guid ModifiedBy { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid OrganizationId { get; set; }

        public string ModifiedByName { get; set; }
        public string CreatedByName { get; set; }

        public int skip { get; set; }
        public int take { get; set; }
        public int pageSize { get; set; }
        public int page { get; set; }
        public filter[] filters { get; set; }


        
    }
    public class filter{
        public string field{get;set;}
        public string Operator{get;set;}
        public string value{get;set;}
        public string logic{get;set;}
        
    }
}