using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.Models
{


    [Table("Kisiler")]
    public class Kisi
    {
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string Ad { get; set; }

        [Required, MaxLength(30)]
        public string Soyad { get; set; }

        public virtual PersonelBilgi PersonelBilgi { get; set; }
    }
}
