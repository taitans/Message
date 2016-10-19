using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Taitans.Message.Email
{
    /// <summary>
    /// Taitans Email操作类
    /// </summary>
    public class Email : IEmail
    {
        private string _subject;
        private string _body;
        private string _from;
        private string _fromName;
        private string _recipientName;
        private string _serverHost;
        private int _serverPort;
        private string _username;
        private string _password;
        private bool _isBodyHtml;
        private string _recipient;
        private List<string> _attachment = new List<string> { };

        /// <summary>
        /// 初始化一个电子邮件操作类的 <see cref="T:Taitans.Message.Email.Email" /> 实例  
        /// </summary>
        public Email()
        {

        }

        /// <summary>
        /// 初始化一个电子邮件操作类的 <see cref="T:Taitans.Message.Email.Email" /> 实例。
        /// </summary>
        /// <param name="from">发件人的电子邮件地址。</param>
        /// <param name="fromName">发件人的姓名。</param>
        /// <param name="recipient">收件人的电子邮件地址。</param>
        /// <param name="recipientName">收件人的姓名。</param>
        /// <param name="subject">电子邮件的主题。</param>
        /// <param name="body">电子邮件的内容。</param>
        /// <param name="host">电子邮件的服务器地址。</param>
        /// <param name="port">电子邮件的主机端口号。</param>
        /// <param name="username">登录电子邮件服务器的用户名。</param>
        /// <param name="password">登录电子邮件服务器的用户密码。</param>
        /// <param name="isBodyHtml">邮件的正文是否是HTML格式。</param>
        /// <param name="filepath">邮件附件的文件路径</param>
        public Email(string from, string fromName, string recipient, string recipientName, string subject, string body, string host, int port, string username, string password, bool isBodyHtml, string filepath)
        {
            this._from = from;
            this._fromName = fromName;
            this._recipient = recipient;
            this._recipientName = recipientName;
            this._subject = subject;
            this._body = body;
            this._serverHost = host;
            this._serverPort = port;
            this._username = username;
            this._password = password;
            this._isBodyHtml = isBodyHtml;
            if (filepath != null)
            {
                this._attachment.Add(filepath);
            }
           
        }

        /// <summary>
        /// 初始化一个电子邮件操作类的 <see cref="T:Taitans.Message.Email.Email" /> 实例
        /// </summary>
        /// <param name="from">发件人的电子邮件地址</param>
        /// <param name="fromName">发件人的姓名</param>
        /// <param name="recipient">收件人的电子邮件地址</param>
        /// <param name="recipientName">收件人的姓名</param>
        /// <param name="subject">电子邮件的主题</param>
        /// <param name="body">电子邮件的内容</param>
        /// <param name="host">电子邮件的服务器地址</param>
        /// <param name="port">电子邮件的主机端口号</param>
        /// <param name="username">登录电子邮件服务器的用户名</param>
        /// <param name="password">登录电子邮件服务器的用户密码</param>
        /// <param name="isBodyHtml">邮件的正文是否是HTML格式</param>
        public Email(string from, string fromName, string recipient, string recipientName, string subject, string body, string host, int port, string username, string password, bool isBodyHtml)
            : this(from, fromName, recipient, recipientName, subject, body, host, port, username, password, isBodyHtml, null) { }


        /// <summary>
        /// 初始化一个电子邮件操作类的 <see cref="T:Taitans.Message.Email.Email" /> 实例
        /// </summary>
        /// <param name="from">发件人的电子邮件地址</param>
        /// <param name="fromName">发件人的姓名</param>
        /// <param name="recipient">收件人的电子邮件地址</param>
        /// <param name="recipientName">收件人的姓名</param>
        /// <param name="subject">电子邮件的主题</param>
        /// <param name="body">电子邮件的内容</param>
        /// <param name="host">电子邮件的服务器地址</param>
        /// <param name="username">登录电子邮件服务器的用户名</param>
        /// <param name="password">登录电子邮件服务器的用户密码</param>
        public Email(string from, string fromName, string recipient, string recipientName, string subject, string body, string host, string username, string password)
            : this(from, fromName, recipient, recipientName, subject, body, host, 25, username, password, false, null) { }

        /// <summary>
        /// 初始化一个电子邮件操作类的 <see cref="T:Taitans.Message.Email.Email" /> 实例（邮件的正文非HTML格式，端口默认25）。
        /// </summary>
        /// <param name="from">发件人的电子邮件地址</param>
        /// <param name="recipient">收件人的电子邮件地址</param>
        /// <param name="subject">电子邮件的主题</param>
        /// <param name="body">电子邮件的内容</param>
        /// <param name="host">电子邮件的服务器地址</param>
        /// <param name="username">登录电子邮件服务器的用户名</param>
        /// <param name="password">登录电子邮件服务器的用户密码</param>
        public Email(string from, string recipient, string subject, string body, string host, string username, string password)
            : this(from, null, recipient, null, subject, body, host, 25, username, password, false, null) { }

        /// <summary>
        /// 初始化一个电子邮件操作类的 <see cref="T:Taitans.Message.Email.Email" /> 实例（邮件的正文非HTML格式，端口默认25）。
        /// </summary>
        /// <param name="from">发件人的电子邮件地址</param>
        /// <param name="recipient">收件人的电子邮件地址</param>
        /// <param name="subject"></param>
        /// <param name="body">电子邮件的主题</param>
        /// <param name="host">电子邮件的主机端口号</param>
        /// <param name="port">电子邮件的服务器地址</param>
        /// <param name="username">登录电子邮件服务器的用户名</param>
        /// <param name="password">登录电子邮件服务器的用户密码</param>
        public Email(string from, string recipient, string subject, string body, string host, int port, string username, string password)
            : this(from, null, recipient, null, subject, body, host, port, username, password, false, null) { }

        /// <summary>
        /// 获取电子邮件附件
        /// </summary>
        public List<string> Attachment
        {

            get { return _attachment; }
            set { _attachment = value; }
        }

        /// <summary>
        /// 获取或设置邮件的正文内容
        /// </summary>
        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }

        /// <summary>
        /// 获取或设置发件人的邮件地址
        /// </summary>
        public string From
        {
            get { return _from; }
            set { _from = value; }
        }

        /// <summary>
        /// 获取或设置发件人的姓名
        /// </summary>
        public string FromName
        {
            get { return _fromName; }
            set { _fromName = value; }
        }

        /// <summary>
        /// 获取或设置指示邮件正文是否为 Html 格式的值
        /// </summary>
        public bool IsBodyHtml
        {
            get { return _isBodyHtml; }
            set { _isBodyHtml = value; }
        }

        /// <summary>
        /// 获取或设置SMTP认证时使用的密码
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        /// <summary>
        /// 获取或设置收件人的邮件地址
        /// </summary>
        public string Recipient
        {
            get { return _recipient; }
            set { _recipient = value; }
        }

        /// <summary>
        /// 获取或设置收件人的姓名
        /// </summary>
        public string RecipientName
        {
            get { return _recipientName; }
            set { _recipientName = value; }
        }

        /// <summary>
        /// 获取或设置邮件服务器主机地址
        /// </summary>
        public string ServerHost
        {
            get { return _serverHost; }
            set { _serverHost = value; }
        }

        /// <summary>
        /// 获取或设置邮件服务器的端口号
        /// </summary>
        public int ServerPort
        {
            get { return _serverPort; }
            set { _serverPort = value; }
        }

        /// <summary>
        /// 获取或设置邮件的主题
        /// </summary>
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        /// <summary>
        /// 获取或设置SMTP认证时使用的用户名
        /// </summary>
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        /// <summary>
        /// 添加电子邮件附件
        /// </summary>
        /// <param name="fileList"></param>
        /// <returns></returns>
        public bool AddAttachment(params string[] fileList)
        {
            if (fileList.Length > 0)
            {
                foreach (string file in fileList)
                {
                    if (file != null)
                    {
                        this._attachment.Add(file);
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 添加一个收件人的邮箱地址
        /// </summary>
        /// <param name="emailList"></param>
        /// <returns></returns>
        public bool AddRecipient(params string[] emailList)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 发送电子邮件
        /// </summary>
        /// <returns>是否发送成功</returns>
        public bool Send()
        {
            //初始化MailMessage 对象
            MailMessage email = new MailMessage();
            Encoding encoding = Encoding.GetEncoding("utf-8");
            email.From = new MailAddress(From, FromName, encoding);
            email.To.Add(new MailAddress(Recipient, RecipientName));
            email.Subject = Subject;
            email.IsBodyHtml = IsBodyHtml;
            email.Body = Body;
            email.Priority = MailPriority.Normal;
            email.BodyEncoding = encoding;
            if (Attachment.Count > 0)
            {
                foreach (string file in Attachment)
                {
                    email.Attachments.Add(new Attachment(file));
                }
            }

            //初始化 SmtpClient 对象
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ServerHost;
            smtp.Port = ServerPort;
            smtp.Credentials = new NetworkCredential(Username, Password);
            smtp.Timeout = 9999;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            if (smtp.Port != 25)
            {
                smtp.EnableSsl = true;
            }
            try
            {
                smtp.Send(email);
            }
            catch (SmtpException ex)
            {

                string message = ex.Message;
                return false;
            }
            return true;

        }
    }
}
