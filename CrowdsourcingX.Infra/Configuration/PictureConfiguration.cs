using CrowdsourcingX.Infra.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdsourcingX.Infra.Configuration
{
    public class PictureConfiguration
    {
        public PictureConfiguration(EntityTypeBuilder<Picture> builder)
        {
            builder.ConfigureBase();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.UserId).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.Pictures).HasForeignKey(x => x.UserId);
        }
    }
}
