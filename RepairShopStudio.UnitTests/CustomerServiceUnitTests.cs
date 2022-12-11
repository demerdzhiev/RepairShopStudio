//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using Moq;
//using RepairShopStudio.Core.Contracts;
//using RepairShopStudio.Core.Services;
//using RepairShopStudio.Infrastructure.Data;
//using RepairShopStudio.Infrastructure.Data.Common;
//using RepairShopStudio.Infrastructure.Data.Models;

//namespace RepairShopStudio.UnitTests
//{
//    [TestFixture]
//    public class CustomerServiceUnitTests
//    {
//        private IRepository repo;
//        private ILogger<CustomerService> logger;
//        private ICustomerService customerService;
//        private ApplicationDbContext applicationDbContext;

//        [SetUp]
//        public void Setup()
//        {
//            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
//                .UseInMemoryDatabase("RepairShopDB")
//                .Options;

//            applicationDbContext = new ApplicationDbContext(contextOptions);

//            applicationDbContext.Database.EnsureDeleted();
//            applicationDbContext.Database.EnsureCreated();
//        }

//        [Test]
//        public async Task TestAddCorporateCutomerAsyncInMemory()
//        {
//            var loggerMock = new Mock<ILogger<CustomerService>>();
//            logger = loggerMock.Object;
//            var repo = new Repository(applicationDbContext);
//            customerService = new CustomerService(applicationDbContext, repo, logger);

//            await applicationDbContext.AddAsync(new Address()
//            {
//                Id = 100,
//                AddressText = string.Empty,
//                ZipCode = string.Empty,
//                TownName = string.Empty
//            });

//            await applicationDbContext.SaveChangesAsync();
//            Assert.That(applicationDbContext.Addresses.Any(a => a.Id == 100), Is.True);

//        }

//        [TearDown]
//        public void TearDown()
//        {
//            applicationDbContext.Dispose();
//        }
//    }
//}