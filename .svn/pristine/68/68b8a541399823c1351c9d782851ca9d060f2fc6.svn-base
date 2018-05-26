using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.Base;

namespace Myzj.OPC.UI.Portal.Models.DomainModels
{
    public class TestDetail
    {
        //非空验证
        [Required]
        [Display(Name = "编号")]
        public int SpreadId { get; set; }

        //输入字符数的验证
        [Required(ErrorMessage = "请输入密码")]
        [StringLength(100, ErrorMessage = "{0}必须至少包含{2}个字符", MinimumLength = 6)]
        //[StringLength(100, ErrorMessage = "{0}必须至少包含{2}个字符", MinimumLength = 6),Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        //两个字段是否一致
        [Display(Name = "确认密码")]
        [DataType(DataType.Password), Required]
        [Compare("Password", ErrorMessage = "密码和确认不匹配")]
        public string ConfirmPassword { get; set; }

        //必须是时间格式
        [Display(Name = "创建时间"), Required]
        [DataType(DataType.DateTime, ErrorMessage = "日期格式不正确")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "站点")]
        public AppEnum.SpreadSite Site { get; set; }

        //取值范围
        //[Range(1,3,ErrorMessage = "超出范围"),Required]
        public AppEnum.ActivityStatus Status { get; set; }

        //邮箱验证
        [Display(Name = "电子邮箱"), Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "邮箱地址不正确")]
        public string Email { get; set; }

        //手机号码验证
        [Display(Name = "手机号码1"), Required]
        [RegularExpression(@"[1[3|4|5|8][0-9]\d{4,8}$]", ErrorMessage = "手机号码格式不正确")]
        public string Phone { get; set; }

        [Display(Name = "手机号码2")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "手机号码格式不正确"), Required]
        public string Type { get; set; }
    }
}