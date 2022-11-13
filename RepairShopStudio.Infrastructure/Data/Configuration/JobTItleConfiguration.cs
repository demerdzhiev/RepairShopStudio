using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Infrastructure.Data.Configuration
{
    internal class JobTItleConfiguration : IEntityTypeConfiguration<JobTitle>
    {
        public void Configure(EntityTypeBuilder<JobTitle> builder)
        {
            builder.HasData(CreateJobTItle());
        }

        private List<JobTitle> CreateJobTItle()
        {
            var jobTitles = new List<JobTitle>();

            var managerJobTitle = new JobTitle()
            {
                Id = "3bb29f58-330b-47d7-8c88-66e47a5fd4aa",
                Name = "Manager"
            };

            jobTitles.Add(managerJobTitle);


            var mechanicJobTitle = new JobTitle()
            {
                Id = "093fd016-778f-4043-b72e-827c1834c4e2",
                Name = "Mechanic"
            };

            jobTitles.Add(mechanicJobTitle);


            var adviserJobTitle = new JobTitle()
            {
                Id = "16afcac4-cb26-4c2e-9586-7cc4c2fab81c",
                Name = "Service adviser"
            };

            jobTitles.Add(adviserJobTitle);

            return jobTitles;
        }
    }
}
