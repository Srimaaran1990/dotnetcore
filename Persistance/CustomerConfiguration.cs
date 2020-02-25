using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DotnetCore.Business.Entities;

namespace Chinook.Data
{
    internal class CustomerConfiguration
    {
        private EntityTypeBuilder<Customer> entityTypeBuilder;

        public CustomerConfiguration(EntityTypeBuilder<Customer> entityTypeBuilder)
        {
            this.entityTypeBuilder = entityTypeBuilder;
        }
    }
}