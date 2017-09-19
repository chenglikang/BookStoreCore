using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class User
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Key]
        [StringLength(36)]
        public string UserId { get; set; }

        /// <summary>
        /// 登陆ID 唯一
        /// </summary>
        [StringLength(200)]
        public string LoginId { get; set; }

        /// <summary>
        /// 用户分组ID
        /// </summary>
        [StringLength(36)]
        public string GroupID { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        [StringLength(200)]
        public string UserName { get; set; }

        [StringLength(200)]
        public string Password { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [StringLength(200)]
        public string Avatar { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [StringLength(10)]
        public string Gender { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        
        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

    }
}
