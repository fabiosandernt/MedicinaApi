using Medicina.Domain.Exame;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Repository.Mapping
{
    public class AsoMapping : IEntityTypeConfiguration<Aso>
    {
        public void Configure(EntityTypeBuilder<Aso> builder)
        {
            builder.ToTable("Aso");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.TipoExame).IsRequired();
            builder.Property(x => x.Imagem).IsRequired();                     
        
        }
    }
}
