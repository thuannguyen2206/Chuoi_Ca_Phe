using Common.Constants;
using DataAccess.Entities;
using Microsoft.Extensions.Configuration;
using Repositories;
using SendGrid;
using SendGrid.Helpers.Mail;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly IUnitOfWork _uow;
        private readonly IConfiguration _configuration;

        public EmailService(IUnitOfWork uow, IConfiguration configuration)
        {
            _uow = uow;
            _configuration = configuration;
        }

        public bool ConfirmEmail(string token, string email)
        {
            var TokenRepo = _uow.GetRepository<TokenConfirm>();
            var userRepo = _uow.GetRepository<User>();

            var checkToken = TokenRepo.Single(x => x.IsValid && x.Email == email && x.Token == token);
            var user = userRepo.QueryCondition(x => x.Email == email && x.IsActive && !x.IsDelete).FirstOrDefault();

            if (checkToken != null && user != null)
            {
                if (DateTime.Compare(DateTime.Now, checkToken.ExpireTime) <= 0) // not expired yet
                {
                    checkToken.IsValid = false;
                    checkToken.DateModified = DateTime.Now;

                    user.EmailConfirmed = true;

                    userRepo.Update(user);
                    TokenRepo.Update(checkToken);
                    _uow.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool AddTokenConfirm(string email, string token)
        {
            try
            {
                var entity = new TokenConfirm()
                {
                    Email = email,
                    ExpireTime = DateTime.Now.AddHours(SystemConstants.ExpireTimeConfirmEmail),
                    IsValid = true,
                    Token = token,
                    DateCreated = DateTime.Now
                };
                _uow.GetRepository<TokenConfirm>().Insert(entity);
                //_uow.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task SendEmailSendgridAsync(string toEmail, string content, string subject = null, string plainText = null)
        {
            string apiKey = _configuration["SendGrid:Key"];
            string fromEmail = _configuration["SendGrid:FromEmail"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(fromEmail, "NordaShop");
            var to = new EmailAddress(toEmail, "User");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainText, content);
            await client.SendEmailAsync(msg);
        }

        public async Task SendEmailSmtpAsync(string toEmail, string content, string subject = null)
        {
            string fromEmail = _configuration["Smtp:FromEmail"];
            string myPasswordEmail = _configuration["Smtp:PasswordEmail"];
            string displayMyEmail = "NordaShop";

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(fromEmail, displayMyEmail, Encoding.UTF8);
            mailMessage.To.Add(new MailAddress(toEmail));
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = content;

            SmtpClient client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail, myPasswordEmail)
            };

            await client.SendMailAsync(mailMessage);
        }

        public bool ConfirmToken(string token, string email)
        {
            var TokenRepo = _uow.GetRepository<TokenConfirm>();
            var userRepo = _uow.GetRepository<User>();

            var checkToken = TokenRepo.Single(x => x.IsValid && x.Email == email && x.Token == token);
            var user = userRepo.QueryCondition(x => x.Email == email && x.IsActive && !x.IsDelete).FirstOrDefault();

            if (checkToken != null && user != null)
            {
                if (DateTime.Compare(DateTime.Now, checkToken.ExpireTime) <= 0) // not expired yet
                {
                    return true;
                }
                else
                {
                    checkToken.IsValid = false;
                    checkToken.DateModified = DateTime.Now;
                    TokenRepo.Update(checkToken);
                    _uow.SaveChanges();
                    return false;
                }
            }
            return false;
        }

        public string BuildBodyEmail(string urlTemplate, Dictionary<string, string> contentReplace)
        {
            string directory = Directory.GetCurrentDirectory();
            var pathLayout = string.Format("{0}{1}", directory, EmailConstants.LayoutPath);

            var mainContentPath = string.Format("{0}{1}", directory, urlTemplate);

            string layoutContent = File.ReadAllText(pathLayout);

            string mainContent = File.ReadAllText(mainContentPath);

            var body = layoutContent.Replace(EmailConstants.MainContent, mainContent);

            foreach (var item in contentReplace)
            {
                body = body.Replace(item.Key, item.Value);
            }

            return body;
        }

    }
}
