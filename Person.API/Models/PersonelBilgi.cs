using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.Models
{
    
        [Table("PersonelBilgileri")]
        public class PersonelBilgi
        {
            public int Id { get; set; }

            // [ForeignKey("Kisi")] 
            public int KisiId { get; set; }

            [Required]
            public DateTime? GirisTarihi { get; set; }
            public DateTime? CikisTarihi { get; set; }

            [ForeignKey("KisiId")]
            public virtual Kisi Kisi { get; set; }

        }
    
}
