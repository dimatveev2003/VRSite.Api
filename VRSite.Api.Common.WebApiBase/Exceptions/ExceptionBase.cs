using System;
using VRSite.Api.Common.WebApiBase.Exceptions.Contracts;

namespace VRSite.Api.Common.WebApiBase.Exceptions
{
    public class ExceptionBase : Exception, IExceptionWithStatusId
    {
        /// <inheritdoc cref="IExceptionWithStatusId.StatusId"/>
        /// <summary>
        /// Событие
        /// </summary>
        public Guid StatusId { get; set; }

        /// <inheritdoc cref="Exception(string)"/>
        /// <summary>
        /// Инициализировать исключение
        /// </summary>
        /// <param name="message">Сообщение</param>
        public ExceptionBase(string message) : base(message)
        {
            StatusId = Guid.NewGuid();
        }

        /// <inheritdoc cref="Exception(string)"/>
        /// <summary>
        /// Инициализировать исключение
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="statusId"></param>
        public ExceptionBase(string message, Guid statusId) : base(message)
        {
            StatusId = statusId;
        }
    }
}
