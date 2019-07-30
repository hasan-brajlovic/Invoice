using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class InvoiceDetail
    {

        [Key]
        [Required]
        public int Fid { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(16)")]
        public string BrojFakture { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Datum { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Dobavljac { set; get; }
        
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Adresa { get; set; }     
       
        public double CijenaFakture { get; set; }

        public ICollection<Stavke> Stavke { get; set; }
    }


}
