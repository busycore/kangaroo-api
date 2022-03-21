using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kangaroo_api.Domains.Users.Models

{
    [Table("users")]
    public class User
    {

        public User()
        {

        }
        public User(int id, String name, String email, String password)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.password = password;

        }
        [Column("user_id")]
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Column("user_name")]
        [MaxLength(100)]
        [Required]
        public String name { get; set; } = string.Empty;

        [Column("user_email")]
        [MaxLength(50)]
        [Required]
        public String email { get; set; } = string.Empty;

        [Column("user_password")]
        [MaxLength(20)]
        [Required]
        public String password { get; set; } = string.Empty;
    }
}