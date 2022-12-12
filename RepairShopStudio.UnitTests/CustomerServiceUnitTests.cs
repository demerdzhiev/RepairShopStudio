using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.EngineType;
using RepairShopStudio.Core.Services;
using RepairShopStudio.Infrastructure.Data;
using RepairShopStudio.Infrastructure.Data.Common;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.UnitTests
{
    [TestFixture]
    public class CustomerServiceUnitTests
    {
        private IRepository repo;
        private ILogger<CustomerService> logger;
        private ICustomerService customerService;
        private ApplicationDbContext applicationDbContext;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("RepairShopDB")
                .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task TestAddCorporateCutomerAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<CustomerService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            customerService = new CustomerService(applicationDbContext, repo, logger);

            var address = new Address()
            {
                Id = 100,
                AddressText = string.Empty,
                ZipCode = string.Empty,
                TownName = string.Empty
            };

            await applicationDbContext.AddAsync(address);

            var customer = new Customer()
            {
                Id = 100,
                Name = string.Empty,
                AddressId = address.Id,
                Email = string.Empty,
                PhoneNumber = string.Empty,
                IsCorporate = false,
                Address = address
            };

            await applicationDbContext.AddAsync(customer);

            var vehicle = new Vehicle()
            {
                Id = 100,
                Make = string.Empty,
                Model = string.Empty,
                LicensePLate = string.Empty,
                Power = 50,
                VinNumber = string.Empty,
                CustomerId = customer.Id,
                FIrstRegistration = DateTime.Today,
                EngineTypeId = 1
            };

            await applicationDbContext.AddAsync(vehicle);
            await applicationDbContext.SaveChangesAsync();

            Assert.That(applicationDbContext.Addresses.Any(a => a.Id == 100), Is.True);
            Assert.That(applicationDbContext.Customers.Any(a => a.Id == 100), Is.True);
            Assert.That(applicationDbContext.Vehicles.Any(a => a.Id == 100), Is.True);
            Assert.That(applicationDbContext.Customers.Any(c => c.AddressId == address.Id), Is.True);
            Assert.That(applicationDbContext.Customers.FirstOrDefault(c => c.Id == customer.Id)?.Vehicles.Any(v => v.Id == vehicle.Id), Is.True);
        }

        [Test]
        public async Task TestAddRegularCutomerAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<CustomerService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            customerService = new CustomerService(applicationDbContext, repo, logger);

            var customer = new Customer()
            {
                Id = 100,
                Name = string.Empty,
                Email = string.Empty,
                PhoneNumber = string.Empty,
                IsCorporate = false
            };

            await applicationDbContext.AddAsync(customer);

            var vehicle = new Vehicle()
            {
                Id = 100,
                Make = string.Empty,
                Model = string.Empty,
                LicensePLate = string.Empty,
                Power = 50,
                VinNumber = string.Empty,
                CustomerId = customer.Id,
                FIrstRegistration = DateTime.Today,
                EngineTypeId = 1
            };

            await applicationDbContext.AddAsync(vehicle);
            await applicationDbContext.SaveChangesAsync();

            Assert.That(applicationDbContext.Customers.Any(a => a.Id == 100), Is.True);
            Assert.That(applicationDbContext.Vehicles.Any(a => a.Id == 100), Is.True);
            Assert.That(applicationDbContext.Customers.FirstOrDefault(c => c.Id == customer.Id)?.Vehicles.Any(v => v.Id == vehicle.Id), Is.True);
        }

        [Test]
        public async Task TestAllEngineTypesAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<CustomerService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            customerService = new CustomerService(applicationDbContext, repo, logger);

            await repo.AddRangeAsync(new List<EngineType>()
            {
                new EngineType() { Id = 100, Name = "" },
                new EngineType() { Id = 103, Name = "" },
                new EngineType() { Id = 105, Name = "" },
                new EngineType() { Id = 102, Name = "" }
            });

            await repo.SaveChangesAsync();
            IEnumerable<EngineTypeViewModel> collection = await customerService.AllEngineTypesAsync();

            //Collect only IDs with value equal or higher than 100 to avoid conflict with seeded objects
            Assert.That(4, Is.EqualTo(collection.Count(c => c.Id >= 100)));
        }

        [Test]
        public async Task TestGetAllAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<CustomerService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            customerService = new CustomerService(applicationDbContext, repo, logger);

            await repo.AddRangeAsync(new List<Customer>()
            {
                new Customer()
                {
                    Id = 200,
                    Name = "",
                    PhoneNumber = "",
                    Email = "",
                    IsCorporate = false

                },new Customer()
                {
                    Id = 201,
                    Name = "",
                    PhoneNumber = "",
                    Email = "",
                    IsCorporate = false

                },new Customer()
                {
                    Id = 202,
                    Name = "",
                    PhoneNumber = "",
                    Email = "",
                    IsCorporate = false
                }
            });

            await repo.SaveChangesAsync();
            var collection = await customerService.GetAllAsync();

            //Collect only IDs with value equal or higher than 100 to avoid conflict with seeded objects
            Assert.That(3, Is.EqualTo(collection.Count(c => c.Id >= 100)));
        }

        [Test]
        public async Task TestGetEngineTypesAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<CustomerService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            customerService = new CustomerService(applicationDbContext, repo, logger);

            await repo.AddRangeAsync(new List<EngineType>()
            {
                new EngineType() { Id = 100, Name = "" },
                new EngineType() { Id = 103, Name = "" },
                new EngineType() { Id = 105, Name = "" },
                new EngineType() { Id = 102, Name = "" }
            });

            await repo.SaveChangesAsync();
            IEnumerable<EngineTypeViewModel> collection = await customerService.AllEngineTypesAsync();

            //Collect only IDs with value equal or higher than 100 to avoid conflict with seeded objects
            Assert.That(4, Is.EqualTo(collection.Count(c => c.Id >= 100)));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}