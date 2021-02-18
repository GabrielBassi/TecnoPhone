﻿using ApiCelulares.DAL.Interfaces;
using ApiCelulares.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.DAL.Repositorio
{
    public class RepositorioTipoEquipo : RepositorioGenerico<TipoEquipo, DbCelulares>, IRepositorioTipoEquipo
    {

        public RepositorioTipoEquipo(DbCelulares pContext) : base(pContext)
        {

        }
    }
}