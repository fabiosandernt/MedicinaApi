using Medicina.CrossCutting.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Domain.Cadastro.Repository
{
    public interface IEmpresaRepository: IRepository<Empresa>
    {
        Task<IEnumerable<Empresa>> ObterTodasEmpresas();
        Task<IEnumerable<Empresa>> ObterTodasEmpresasPorCnpj(string parametro);
            
    }
}
