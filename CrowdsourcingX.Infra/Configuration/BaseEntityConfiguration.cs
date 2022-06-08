using CrowdsourcingX.Infra.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdsourcingX.Infra.Configuration
{
    public static class BaseEntityConfiguration
    {
        public static void ConfigureBase<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : BaseEntity
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.Active).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.UpdatedDate).HasDefaultValueSql("GETDATE()");
        }
    }
}
