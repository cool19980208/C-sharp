using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core1
{
    [Table("T_Cats")]
   public class Cat
    {
        public long Id { get; set; }//主键

        [Required]//不可为空
        [MaxLength(22)]//最大长度为20
        public string Name { get; set; }
    }
}
