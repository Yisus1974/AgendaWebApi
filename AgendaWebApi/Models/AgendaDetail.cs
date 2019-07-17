using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaWebApi.Models
{
    public class AgendaDetail
    {
        [Key]
        public int AgendaId { get; set; }
        [Required]
        [Column(TypeName="varchar(80)")]
        public string Nombre { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime FechNac { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Telefono { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Celular { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string email { get; set; }
        [Required]
        [Column(TypeName = "varchar(500)")]
        public string Direccion { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        public bool Estatus { get; set; }

    }
}
