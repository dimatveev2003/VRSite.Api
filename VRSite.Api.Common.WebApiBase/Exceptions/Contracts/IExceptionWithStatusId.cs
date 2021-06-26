using System;

namespace VRSite.Api.Common.WebApiBase.Exceptions.Contracts
{
    public interface IExceptionWithStatusId
    {
        /// <summary>
        /// Код события
        /// </summary>
        Guid StatusId { get; set; }
    }
}
