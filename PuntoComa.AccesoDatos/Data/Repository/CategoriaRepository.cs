﻿using PuntoComa.AccesoDatos.Data.Repository.IRepository;
using PuntoComa.Data;
using PuntoComa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoComa.AccesoDatos.Data.Repository
{
    internal class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoriaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Categoria categoria)
        {
            var objDesdeDb = _db.Categoria.FirstOrDefault(s => s.Id == categoria.Id);
            objDesdeDb.Nombre = categoria.Nombre;
            objDesdeDb.Orden = categoria.Orden;

            _db.SaveChanges();
        }

    }

}