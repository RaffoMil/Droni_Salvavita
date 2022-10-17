namespace Droni_Salvavita.Models
{
    public class Drone
    {
        public enum TipoPropulsore {
            PLASMA = 1,
            NUCLEARE = 2,
            ELETTRICO = 3,
        }

        public enum TipoGuida {
            SPERICOLATA = 1,
            CODICEVERDE = 2,
            CODICEGIALLO = 3,
            CODICEROSSO = 4,
        }

        public int Id { get; set; }
        public TimeSpan Duration { get; set; }
        public TipoPropulsore TypePropulsore { get; set; }
        public TipoGuida TypeGuida { get; set; }

    }
}
