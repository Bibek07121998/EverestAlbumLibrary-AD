using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EverestAlbumLibrary.Models
{
    public class AlbumStockDetails
    {
        [Key]
        public int Id { get; set; }
        public DateTime AddedDate { get; set; }
        public int AlbumId { get; set; }
        [ForeignKey("AlbumId")]
        public virtual Album Album { get; set; }

    }
}