using GoodsStore.BusinessLogic.Models;
using GoodsStore.BusinessLogic.Services.Interfaces;
using GoodsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStore.BusinessLogic.Services
{
    public class EmailSettings
    {
        public string MailToAddress = "orders@example.com";
        public string MailFromAddress = "gamestore@example.com";
        public bool UseSsl = true;
        public string Username = "MySmtpUsername";
        public string Password = "MySmtpPassword";
        public string ServerName = "smtp.example.com";
        public int ServerPort = 587;
        public bool WriteAsFile = true;
        public string FileLocation = @"d:\goodsstore_emails";
    }
    public class EmailOrderProcessor : IOrderProcessor
    {
        private readonly EmailSettings _emailSettings;
        public EmailOrderProcessor(EmailSettings settings)
        {
            _emailSettings = settings;
        }

        public async Task ProcessOrder(Cart cart, OrderModel shippingInfo)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = _emailSettings.UseSsl;
                smtpClient.Host = _emailSettings.ServerName;
                smtpClient.Port = _emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials
                    = new NetworkCredential(_emailSettings.Username, _emailSettings.Password);

                if (_emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod
                        = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = _emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("Новый заказ")
                    .AppendLine("---")
                    .AppendLine("Товары:");

                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Goods.Price * line.Quantity;
                    body.AppendFormat("{1} - {0}шт., размер - {3} (итого: {2:c})",
                        line.Quantity, line.Goods.Name, subtotal, line.Size.Name);
                    body.AppendLine();
                    body.AppendLine();
                }
                body.AppendFormat("Общая стоимость: {0:c}", cart.ComputeTotalValue())
                    .AppendLine(" ")
                    .AppendLine("Доставка:")
                    .AppendLine(shippingInfo.Name)
                    .AppendLine(shippingInfo.Address)
                    .AppendLine(shippingInfo.City)
                    .AppendLine(shippingInfo.Country)
                    .AppendLine(shippingInfo.Phone)
                    .AppendLine("---")
                    .AppendFormat("Подарочная упаковка: {0}",
                        shippingInfo.GiftWrap ? "Да" : "Нет");

                MailMessage mailMessage = new MailMessage(
                                       _emailSettings.MailFromAddress,	// От кого
                                       _emailSettings.MailToAddress,		// Кому
                                       "Новый заказ отправлен!",		// Тема
                                       body.ToString()); 				// Тело письма

                if (_emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.UTF8;
                }

                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}

