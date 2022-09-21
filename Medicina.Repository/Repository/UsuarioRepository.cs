using Medicina.Domain.Account;
using Medicina.Domain.Account.Repository;
using Medicina.Repository.Context;
using Medicina.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Repository.Repository
{
    public class UsuarioRepository: Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(MedicinaContext context): base(context)
        {

        }
    }
}
