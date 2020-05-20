using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jonny.AllDemo.EntityFrameworkCore.Models
{
    
    public class Users
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(4)]
        public int Age { get; set; }
        [MaxLength(12)]
        public string Name { get; set; }
        
        [StringLength(200)]
        public string Like { get; set; }

        public Gender Gender { get; set; }
        public bool IsActive { get; set; }

        [Column(TypeName="datetime")]
        public DateTime CreationTime { get; set; }
        public double Udouble { get; set; }
        public float Ufloat { get; set; }
        public decimal Udecimal { get; set; }
        public uint Uuint { get; set; }
        public long Ulong { get; set; }
        public ulong Uulong { get; set; }
        public Int16 UInt16 { get; set; }
        public Int32 UInt32 { get; set; }
        public Int64 UInt64 { get; set; }
        public UInt16 UuInt16 { get; set; }
        public UInt32 UuInt32 { get; set; }
        public UInt64 UuInt64 { get; set; }      
        public byte Ubyte { get; set; }        
        public char Uchar { get; set; }

        public Company Company { get; set; }

        //[ForeignKey("FK_User_Company")]
        //public int? CompanyId { get; set; }
    }
    public enum Gender
    {
        UnKnow,
        Male,
        Female,        
    }
}
