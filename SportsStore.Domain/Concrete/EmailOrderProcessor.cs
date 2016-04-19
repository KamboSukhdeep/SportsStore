using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Abstract;
namespace SportsStore.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "Deepsingh@yopmail.com";
        public string MailFromAddress = "esm.sukhdeep@gmail.com";
        public bool UseSSL = true;
        public string UserName = "esm.sukhdeep";
        public string Password = "";
        public string ServerName = "gmail.smtp.com";
        public int ServerPort = 587;
        public bool WriteAsFile = false;
        public string FileLocation = @"d:\emails";
    }
    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;
        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }
        public void ProcessOrder(Cart cart, ShippingDetails shippingDetails)
        {

        }
    }


}
