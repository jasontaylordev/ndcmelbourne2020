using CaWorkshop.Application.TodoLists.Commands.CreateTodoList;
using CaWorkshop.Infrastructure.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CaWorkshop.Application.UnitTests.TodoLists.Commands.CreateTodoList
{
    public class CreateTodoListCommandTests : TestFixture
    {
        private readonly ApplicationDbContext _context;

        public CreateTodoListCommandTests()
        {
            _context = base.Context;
        }

        [Fact]
        public async Task Handle_ShouldPersistTodoList()
        {
            // Arrange
            var command = new CreateTodoListCommand
            {
                Title = "Bucket List"
            };

            var handler = new CreateTodoListCommandHandler(_context);

            // Act
            var id = await handler.Handle(command,
                CancellationToken.None);

            // Assert
            var entity = _context.TodoLists.Find(id);

            entity.ShouldNotBeNull();
            entity.Title.ShouldBe(command.Title);
        }
    }
}