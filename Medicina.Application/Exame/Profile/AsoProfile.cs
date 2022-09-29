using Medicina.Application.Exame.Dto;
using Medicina.Domain.Account;
using Medicina.Domain.Cadastro;
using Medicina.Domain.Exame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medicina.Application.Exame.Dto.EmpresaDto;
using static Medicina.Application.Exame.Dto.FuncionarioDto;
using static Medicina.Application.Exame.Dto.UsuarioDto;

namespace Medicina.Application.Exame.Profile
{
    public class AsoProfile: AutoMapper.Profile
    {
        public AsoProfile()
        {
            CreateMap<UsuarioInputDto, Usuario>();

            CreateMap<Usuario, UsuarioOutputDto>();

            CreateMap<EmpresaInputDto, Empresa>();

            CreateMap<Empresa, EmpresaOutputDto>();

            CreateMap<FuncionarioInputDto, Funcionario>();

            CreateMap<Funcionario, FuncionarioOutputDto>();

            CreateMap<AsoInputDto, Aso>();

            CreateMap<Aso, AsoOutputDto>();
        }
    }
}
