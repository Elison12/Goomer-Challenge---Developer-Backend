using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoomerChallenger.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoomerChallenger.Infra.Data.Mapping
{
    public class PratoMap : IEntityTypeConfiguration<Prato>
    {
        public void Configure(EntityTypeBuilder<Prato> builder)
        {
            builder.ToTable("Prato");

            builder.Ignore(x => x.Id);
            builder.Ignore(x => x.Errors);
            builder.Ignore(x => x.Isvalid);

            builder.HasKey(x => x.IdPrato);
        }
    }
}
