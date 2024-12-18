using Geometrie.DTO;

namespace Geometrie.API.DTO
{
    public class Cercle_DTO
    {
        public int? Id { get; set; }
        public Point_DTO Centre { get; set; }
        public double Rayon { get; set; }
    }
}

