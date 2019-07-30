using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Stavke
    {

        [Key]
        [Required]
        public int Sid { get; set; }

        [Required]
        [Column(TypeName = "varchar(16)")]
        public string BrojFakture { get; set; }

        public int RedniBrojStavke { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string SifraArtikla { get; set; }


        [Column(TypeName = "varchar(50)")]
        public string NazivArtikla { get; set; }

        public int Fid { get; set; }

        public int Kolicina { get; set; }


        public double JedinicnaCijena { get; set; }
        [ForeignKey ("Fid")]
        public virtual InvoiceDetail Faktura{ get; set; }


    }


}
