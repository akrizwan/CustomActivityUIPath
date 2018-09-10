using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CustomActivity
{
    [Designer(typeof(SendEmailDesigner))]
    public class SendEmail : NativeActivity
    {
        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<string> Host { get; set; }

        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<string> From { get; set; }

        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<string> To { get; set; }
        
        [DefaultValue(null)]
        public InArgument<string> Subject { get; set; }
        
        [DefaultValue(null)]
        public InArgument<string> Body { get; set; }

        [DefaultValue(null)]
        public InArgument<string> AttachmentLink { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(Host.Get(context));

            mail.From = new MailAddress(From.Get(context));
            foreach (string str in To.Get(context).Split(';'))
            {
                mail.To.Add(str);
            }
            mail.Subject = Subject.Get(context);
            mail.Body = Body.Get(context);

            Attachment attachment;
            if (AttachmentLink.Get(context) != null)
            {
                attachment = new Attachment(AttachmentLink.Get(context));
                mail.Attachments.Add(attachment);
            }
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential(@"itcinfotech\28199", "welcome@123");
            //SmtpServer.EnableSsl = true;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Send(mail);
            /////
        }
    }
}
