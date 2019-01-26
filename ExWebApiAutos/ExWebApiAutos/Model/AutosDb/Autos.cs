using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExWebApiAutos.Model.AutosDb
{
    public partial class Autos
    {
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("color")]
        [StringLength(20)]
        public string Color { get; set; }
        [Required]
        [Column("anio_fab")]
        [StringLength(4)]
        public string AnioFab { get; set; }
        [Required]
        [Column("nro_placa")]
        [StringLength(6)]
        public string NroPlaca { get; set; }
        [Required]
        [Column("nro_asientos")]
        [StringLength(2)]
        public string NroAsientos { get; set; }
        [Column("es_meca")]
        public byte EsMeca { get; set; }
        [Column("es_full")]
        public byte EsFull { get; set; }
        [Required]
        [Column("marca")]
        [StringLength(50)]
        public string Marca { get; set; }
    }
}
