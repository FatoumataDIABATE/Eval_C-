namespace Geometrie.DAL
{
    public class Cercle_DAL
    {
        public int? Id { get; private set; }
        public Point_DAL Centre { get; private set; }
        public double Rayon { get; private set; }

        public Cercle_DAL(Point_DAL centre, double rayon)
        {
            Centre = centre;
            Rayon = rayon;
        }

        public Cercle_DAL(int? id, Point_DAL centre, double rayon)
        {
            Id = id;
            Centre = centre;
            Rayon = rayon;
        }
    }
}
