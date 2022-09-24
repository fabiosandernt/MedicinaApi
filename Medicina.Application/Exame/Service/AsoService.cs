﻿using AutoMapper;
using Medicina.Application.Exame.Dto;
using Medicina.Domain.Exame.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Application.Exame.Service
{
    public class AsoService: IAsoService
    {
        private readonly IAsoRepository asoRepository;
        private readonly IMapper mapper;

        public AsoService(IAsoRepository asoRepository, IMapper mapper)
        {
            this.asoRepository = asoRepository;
            this.mapper = mapper;
        }

        public async Task<AsoOutputDto> Criar(AsoInputDto dto)
        {
            var aso = this.mapper.Map<Medicina.Domain.Exame.Aso>(dto);

            await this.asoRepository.Save(aso);

            return this.mapper.Map<AsoOutputDto>(aso);

        }

        public async Task<AsoOutputDto> Deletar(AsoInputDto dto)
        {
            var aso = this.mapper.Map<Medicina.Domain.Exame.Aso>(dto);

            await this.asoRepository.Delete(aso);

            return this.mapper.Map<AsoOutputDto>(aso);

        }

        public async Task<AsoOutputDto> Atualizar(AsoInputDto dto)
        {
            var aso = this.mapper.Map<Medicina.Domain.Exame.Aso>(dto);

            await this.asoRepository.Update(aso);

            return this.mapper.Map<AsoOutputDto>(aso);

        }

        public async Task<List<AsoOutputDto>> ObterTodos()
        {
            var aso = await this.asoRepository.GetAll();

            return this.mapper.Map<List<AsoOutputDto>>(aso);
        }

        public async Task<AsoOutputDto> ObterPorId(Guid id)
        {
            var aso = await this.asoRepository.Get(id);

            return this.mapper.Map<AsoOutputDto>(aso);

        }
    }
}