using System;
using VRSite.Api.Common.WebApiBase.Exceptions.Contracts;

namespace VRSite.Api.Common.WebApiBase.Exceptions
{
    public class UnauthorizedException: ExceptionBase, IUnauthorizedException
    {
        /// <inheritdoc cref="IUnauthorizedException.User"/>
        /// <summary>
        /// Пользователь
        /// </summary>
        public string User { get; set; }

        /// <inheritdoc cref="ExceptionBase"/>
        /// <summary>
        /// Инициализировать объект экземпляра <see cref="UnauthorizedException"/>
        /// </summary>
        public UnauthorizedException() : this("Ошибка авторизации")
        {
        }

        /// <inheritdoc cref="ExceptionBase"/>
        /// <summary>
        /// Инициализировать объект экземпляра <see cref="UnauthorizedException"/>
        /// </summary>
        /// <param name="message"></param>
        public UnauthorizedException(string message) : this("Undefined", message)
        {
        }

        /// <inheritdoc cref="ExceptionBase"/>
        /// <summary>
        /// Инициализировать объект экземпляра <see cref="UnauthorizedException"/>
        /// </summary>
        /// <param name="user">Юзер</param>
        /// <param name="message">Сообщение</param>
        public UnauthorizedException(string user, string message) : base(message)
        {
            User = user;
        }

        /// <inheritdoc cref="ExceptionBase"/>
        /// <summary>
        /// Инициализировать объект экземпляра <see cref="UnauthorizedException"/>
        /// </summary>
        /// <param name="user">Юзер</param>
        /// <param name="message"></param>
        /// <param name="statusId"></param>
        public UnauthorizedException(string user, string message, Guid statusId) : base(message, statusId)
        {
            User = user;
            StatusId = statusId;
        }
        
        
    }
}