using System;
using Geometrie.DAL;

namespace Geometrie.BLL
{
    public class Cercle : IForme
    {
        public int? Id { get; private set; }
        public Point Centre { get; private set; }
        public double Rayon { get; private set; }

        public Cercle(Point centre, double rayon)
        {
            Centre = centre;
            Rayon = rayon;
        }

        public Cercle(int id, Point centre, double rayon)
        {
            Id = id;
            Centre = centre;
            Rayon = rayon;
        }

        public double CalculerPerimetre() => 2 * Math.PI * Rayon;

        public double CalculerAire() => Math.PI * Math.Pow(Rayon, 2);


        public override string ToString()
        {
            return $"Cercle [Id={Id}, Centre=({Centre}), Rayon={Rayon:F2}, Périmètre={CalculerPerimetre():F2}, Aire={CalculerAire():F2}]";
        }
        public Cercle_DAL ToDAL()
        {
            return new Cercle_DAL
            (
                Id,
                Centre.ToDAL(),
                Rayon
            );

        }
    }
}
