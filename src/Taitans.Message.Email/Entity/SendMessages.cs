using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taitans.Message.Email.Entity
{
    /// <summary>
    /// 邮件发送信息类
    /// </summary>
    public class SendMessages
    {
        /// <summary>
        /// 收件人的姓名
        /// </summary>
        public string RecipientName { get; set; }
        /// <summary>
        /// 收件人的电子邮件地址
        /// </summary>
        public string Recipient { get; set; }
        /// <summary>
        /// 电子邮件的主题
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 电子邮件的内容
        /// </summary>
        public string Body { get; set; }
    }
}
