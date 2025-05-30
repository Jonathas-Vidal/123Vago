using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _123Vago.Servico
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Quarto { get; set; }
        public string Localizacao { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }

}
