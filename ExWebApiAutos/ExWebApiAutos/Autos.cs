using System;
using System.Collections.Generic;

namespace ExWebApiAutos
{
    public partial class Autos
    {
        public Guid Id { get; set; }
        public string Color { get; set; }
        public string AnioFab { get; set; }
        public string NroPlaca { get; set; }
        public string NroAsientos { get; set; }
        public byte EsMeca { get; set; }
        public byte EsFull { get; set; }
        public string Marca { get; set; }
    }
}
