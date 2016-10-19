using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taitans.Message.Email
{
    /// <summary>
    /// 邮件接口
    /// </summary>
    public interface IEmail
    {
        /// <summary>
        /// 获取或设置邮件的主题
        /// </summary>
        string Subject { get; set; }

        /// <summary>
        /// 获取或设置邮件的正文内容
        /// </summary>
        string Body { get; set; }

        /// <summary>
        /// 获取或设置发件人的邮件地址
        /// </summary>
        string From { get; set; }

        /// <summary>
        /// 获取或设置发件人的姓名
        /// </summary>
        string FromName { get; set; }

        /// <summary>
        /// 获取或设置收件人的姓名
        /// </summary>
        string RecipientName { get; set; }

        /// <summary>
        /// 获取或设置收件人的邮件地址
        /// </summary>
        string Recipient { get; set; }

        /// <summary>
        /// 获取或设置邮件服务器主机地址
        /// </summary>
        string ServerHost { get; set; }

        /// <summary>
        /// 获取或设置邮件服务器的端口号
        /// </summary>
        int ServerPort { get; set; }

        /// <summary>
        /// 获取或设置SMTP认证时使用的用户名
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// 获取或设置SMTP认证时使用的密码
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// 获取或设置指示邮件正文是否为 Html 格式的值
        /// </summary>
        bool IsBodyHtml { get; set; }

        /// <summary>
        /// 获取电子邮件附件
        /// </summary>
        List<string> Attachment { get; set; }

        /// <summary>
        /// 添加一个收件人的邮箱地址
        /// </summary>
        /// <param name="emailList">联系人列表</param>
        /// <returns></returns>
        bool AddRecipient(params string[] emailList);

        /// <summary>
        /// 添加电子邮件附件
        /// </summary>
        /// <param name="fileList">文件列表</param>
        /// <returns>是否添加成功</returns>
        bool AddAttachment(params string[] fileList);

        /// <summary>
        /// 发送电子邮件
        /// </summary>
        /// <returns>是否发送成功</returns>
        bool Send();
    }
}
