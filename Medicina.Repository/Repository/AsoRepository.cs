﻿using Medicina.Domain.Aso;
using Medicina.Domain.Aso.Repository;
using Medicina.Repository.Context;
using Medicina.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Repository.Repository
{
    public class AsoRepository : Repository<Aso>, IAsoRepository
    {
        public AsoRepository(MedicinaContext context) : base(context)
        {
        }
    }
}
