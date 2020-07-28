using AutoMapper;
using CaWorkshop.Infrastructure.Persistence;
using System;

namespace CaWorkshop.Application.UnitTests
{
    public class TestFixture : IDisposable
    {
        // Setup 
        public TestFixture()
        {
            Context = DbContextFactory.Create();
            Mapper = MapperFactory.Create();
        }

        public ApplicationDbContext Context { get; }

        public IMapper Mapper { get; }

        // Cleanup
        public void Dispose()
        {
            DbContextFactory.Destroy(Context);
        }
    }
}