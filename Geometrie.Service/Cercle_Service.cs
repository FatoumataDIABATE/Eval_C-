using Geometrie.API.DTO;
using Geometrie.DAL;
using Geometrie.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Geometrie.Service
{
    // Ajouter l'interface IService<Cercle_DTO> au lieu de directement utiliser Cercle_Service
    public class Cercle_Service : IService<Cercle_DTO>
    {
        private readonly GeometrieContext _context;

        public Cercle_Service(GeometrieContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            _context = context;
        }

        public Cercle_DTO Add(Cercle_DTO element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));

            var cercle_DAL = new Cercle_DAL
            {
                Centre = new Point_DAL(element.Centre.X, element.Centre.Y),
                Rayon = element.Rayon
            };
            _context.Cercles.Add(cercle_DAL);
            _context.SaveChanges();
            element.Id = cercle_DAL.Id;

            return element;
        }

        public IService<Cercle_DTO> Delete(Cercle_DTO element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));
            ArgumentNullException.ThrowIfNull(element.Id, nameof(element.Id));

            return Delete(element.Id.Value);
        }

        public IService<Cercle_DTO> Delete(int id)
        {
            var cercle = _context.Cercles.Find(id);
            if (cercle != null)
            {
                _context.Cercles.Remove(cercle);
                _context.SaveChanges();
            }

            return this;
        }

        public IEnumerable<Cercle_DTO> GetAll()
        {
            return _context.Cercles
                .Select(c => new Cercle_DTO
                {
                    Id = c.Id,
                    Centre = new Point_DTO { X = c.Centre.X, Y = c.Centre.Y },
                    Rayon = c.Rayon
                })
                .ToList();
        }

        public Cercle_DTO? GetById(int id)
        {
            var cercle_DAL = _context.Cercles.Find(id);
            if (cercle_DAL == null)
                return null;

            return new Cercle_DTO
            {
                Id = cercle_DAL.Id,
                Centre = new Point_DTO { X = cercle_DAL.Centre.X, Y = cercle_DAL.Centre.Y },
                Rayon = cercle_DAL.Rayon
            };
        }

        public Cercle_DTO Update(Cercle_DTO element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));
            ArgumentNullException.ThrowIfNull(element.Id, nameof(element.Id));

            var cercle_DAL = new Cercle_DAL
            {
                Id = element.Id,
                Centre = new Point_DAL(element.Centre.X, element.Centre.Y),
                Rayon = element.Rayon
            };
            _context.Cercles.Update(cercle_DAL);
            _context.SaveChanges();

            return element;
        }
    }
}
