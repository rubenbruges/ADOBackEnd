using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace AdoClienteBack
{
    public class TipoIdentificacion
    {

        public int CodTipoIdentificacion { get; set; }
        public String DescripcionIdentificacion { get; set; } = String.Empty;
    }
}
