using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IEmailService
    {
        /// <summary>
        /// Build email body
        /// </summary>
        /// <param name="urlTemplate"></param>
        /// <param name="contentReplace"></param>
        /// <returns></returns>
        string BuildBodyEmail(string urlTemplate, Dictionary<string, string> contentReplace);

        /// <summary>
        /// Send email using SMTP server
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="content"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        Task SendEmailSmtpAsync(string toEmail, string content, string subject = null);

        /// <summary>
        /// Send email using third party SendGrid 
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="content"></param>
        /// <param name="subject"></param>
        /// <param name="plainText"></param>
        /// <returns></returns>
        Task SendEmailSendgridAsync(string toEmail, string content, string subject = null, string plainText = null);

        /// <summary>
        /// Confirm email
        /// </summary>
        /// <param name="token"></param>
        /// <param name="email"></param>
        /// <returns>True if success, ortherwise false</returns>
        bool ConfirmEmail(string token, string email);

        /// <summary>
        /// Confirm token
        /// </summary>
        /// <param name="token"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        bool ConfirmToken(string token, string email);

        /// <summary>
        /// Add token confrim 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="token"></param>
        /// <returns>True if success, ortherwise false</returns>
        bool AddTokenConfirm(string email, string token);
    }
}
