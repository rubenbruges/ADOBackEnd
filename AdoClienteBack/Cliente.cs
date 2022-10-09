using System.Reflection.Metadata;

namespace AdoClienteBack
{
    public class Cliente
    {
        public int TipoIdentificacíon { get; set; }
        public int NumeroIdentificacion { get; set; }
        public String Nombre { get; set; } = String.Empty;
        public String Apellido { get; set; } = String.Empty;
        public String Direccion { get; set; } = String.Empty;
        public String Genero { get; set; } = String.Empty;
        public int EstadoDelSistema { get; set; }

    }
}
