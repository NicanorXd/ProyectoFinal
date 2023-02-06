using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Aplicacion.Materiales.Request
{
    public class RegistrarPedidoRequest
    {
        public int idCliente { get; set; }
        public int idMaterial { get; set; }
    }
}
