using System;

namespace VRSite.Api.Common.WebApiBase.Messages
{
    /// <summary>
    /// Структура для обработки ошибки
    /// </summary>
    [Serializable]
    public class ErrorApiResponse
    {
        /// <summary>
        /// Идентификатор ошибки
        /// </summary>
        public Guid ExceptionId { get; set; }

        /// <summary>
        /// Сообщение для пользователя
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Настоящее сообщение
        /// </summary>
        public string ExceptionMessage { get; set; }

        /// <summary>
        /// СтекТрейс
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        /// Детали ошибки
        /// </summary>
        public object Details { get; set; }
    }
}
