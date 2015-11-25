using System;

namespace July.Common.Infrastructure.Contract
{
    public interface IDataModel
    {
        void SetUpdateProperties(Guid userId);
        void SetCreateProperties(Guid userId, Guid organizationId);
    }
}