using CrowdsourcingX.Infra.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdsourcingX.Infra.Configuration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<User> builder)
        {
            builder.ConfigureBase();
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Email).IsRequired();
            builder.Property(t => t.PaymentMethod).IsRequired();
            builder.Property(t => t.Age).IsRequired();
            builder.Property(t => t.Sex).IsRequired();
            builder.Property(t => t.Ethnicity).IsRequired();
            builder.Property(t => t.CountryOfOrigin).IsRequired();
            builder.Property(t => t.CountryOfResidence).IsRequired();
            builder.Property(t => t.Signature).IsRequired();
        }
    }
}
