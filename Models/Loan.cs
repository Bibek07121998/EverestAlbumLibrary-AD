using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EverestAlbumLibrary.Models
{
    public class Loan
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime IssuedDate { get; set; }
        [Required]
        public DateTime ReturnedDate { get; set; }
        public int MemberId { get; set; }
        [Required]
        public int AlbumId { get; set; }

        [ForeignKey("MemberId")]
        public virtual Member Members { get; set; }

        [ForeignKey("AlbumId")]
        public virtual Album Albums { get; set; }
    }
}