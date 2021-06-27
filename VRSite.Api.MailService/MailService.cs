using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using VRSite.Api.Common.Configurations.Contracts;
using VRSite.Api.MailService.Contracts;
using VRSite.Api.MailService.Models;

namespace VRSite.Api.MailService
{
    public class MailService : IMailService
    {
        private readonly IConfigurationAppManager _configurationAppManager;

        public MailService(IConfigurationAppManager configurationAppManager)
        {
            _configurationAppManager = configurationAppManager;
        }

        public async Task SendRegistrationMail(UserModel model)
        {
            var message = $"Спасибо за регистрацию на нашем сайте! Ваш логин в системе: {model.Login}";
            var bodyBuilder = new BodyBuilder();

            bodyBuilder.HtmlBody = "<h1>Вы успешно зарегистрированы!</h1>" +
                                   $"<p>{message}</p>";

            await SendEmailAsync(model.Email, "Успешная регистрация", bodyBuilder.ToMessageBody());
        }

        public async Task SendOrderCreatedMailToManager(UserModel user, CreatedOrderModel model)
        {
            var header = $"<h1>На сайте виртуального практикума был оформлен заказ!</h1>";

            var messageHtml = "<p>" +
                              "Был оформлен новый заказ!<br>" +
                              $"Номер заказа: {model.OrderId}<br>" +
                              $"Идентификатор клиента: {user.Id}<br>" +
                              $"Имя клиента: {user.OrganizationName}<br>" +
                              $"Электронная почта клиента: {user.Email}<br>" +
                              $"Количество позиций в заказе: {model.CountProducts}<br>" +
                              $"Общая сумма заказа: {model.Price}<br>" +
                              $"</p>";

            var bodyBuilder = new BodyBuilder();

            bodyBuilder.HtmlBody = header + messageHtml;

            await SendEmailAsync(_configurationAppManager.AppSettings.ManagerSettings.Email, "Новый заказ", bodyBuilder.ToMessageBody());
        }

        private async Task SendEmailAsync(string emailTo, string subject, MimeEntity body)
        {
            var emailMessage = new MimeMessage();
            
            emailMessage.From.Add(new MailboxAddress("Администрация сайта виртуальных лабораторий", _configurationAppManager.AppSettings.MailSettings.Email));
            emailMessage.To.Add(new MailboxAddress("", emailTo));
            emailMessage.Subject = subject;


            emailMessage.Body = body;

            using (var client = new SmtpClient())
            {
                var server = _configurationAppManager.AppSettings.MailSettings.SmtpServer;
                var port = _configurationAppManager.AppSettings.MailSettings.SmtpPort;

                var emailFrom = _configurationAppManager.AppSettings.MailSettings.Email;
                var pwd = _configurationAppManager.AppSettings.MailSettings.Password;

                await client.ConnectAsync(server, port, true);
                await client.AuthenticateAsync(emailFrom, pwd);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }

        }
    }
}