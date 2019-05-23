using System;
using System.Collections.Generic;
using System.Text;

namespace App_Lembrete.Models
{
    public class Lembrete
    {
        public string Dia { get; set; }
        public string Mes { get; set; }
        public string Ano { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataFinalizacao { get; set; }

    }
}
