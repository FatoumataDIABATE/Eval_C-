using System;
using Xunit;
using Geometrie.BLL;
using Geometrie.DAL;

namespace Geometrie.Tests
{
    public class CercleTests
    {
        [Fact]
        public void CalculerPerimetre_ShouldReturnCorrectValue()
        {
            // Arrange
            var centre = new Point { X = 0, Y = 0 };
            var rayon = 5;
            var cercle = new Cercle(centre, rayon);

            // Act
            var perimetre = cercle.CalculerPerimetre();

            // Assert
            Assert.Equal(2 * Math.PI * rayon, perimetre, precision: 2);
        }

        [Fact]
        public void CalculerAire_ShouldReturnCorrectValue()
        {
            // Arrange
            var centre = new Point { X = 0, Y = 0 };
            var rayon = 5;
            var cercle = new Cercle(centre, rayon);

            // Act
            var aire = cercle.CalculerAire();

            // Assert
            Assert.Equal(Math.PI * Math.Pow(rayon, 2), aire, precision: 2);
        }

        [Fact]
        public void ToDAL_ShouldReturnCercleDALWithSameProperties()
        {
            // Arrange
            var centre = new Point { X = 2, Y = 3 };
            var rayon = 10;
            var cercle = new Cercle(1, centre, rayon);

            // Act
            var cercleDAL = cercle.ToDAL();

            // Assert
            Assert.Equal(cercle.Id, cercleDAL.Id);
            Assert.Equal(cercle.Centre.X, cercleDAL.Centre.X);
            Assert.Equal(cercle.Centre.Y, cercleDAL.Centre.Y);
            Assert.Equal(cercle.Rayon, cercleDAL.Rayon);
        }

        [Fact]
        public void ToString_ShouldReturnCorrectStringRepresentation()
        {
            // Arrange
            var centre = new Point { X = 2, Y = 3 };
            var rayon = 5.5;
            var cercle = new Cercle(1, centre, rayon);

            // Act
            var result = cercle.ToString();

            // Assert
            var expected = $"Cercle [Id=1, Centre=(X=2.00, Y=3.00), Rayon=5.50, Périmètre={2 * Math.PI * rayon:F2}, Aire={Math.PI * Math.Pow(rayon, 2):F2}]";
            Assert.Equal(expected, result);
        }
    }
}
