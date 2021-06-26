namespace VRSite.Api.Common.WebApiBase.Exceptions.Contracts
{
    /// <summary>
    /// Исключение для не авторизованного пользователя
    /// </summary>
    public interface IUnauthorizedException
    {
        /// <summary>
        /// Логин юзера
        /// </summary>
        string User { get; set; }
    }
}