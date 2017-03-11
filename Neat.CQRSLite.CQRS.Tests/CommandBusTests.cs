using Neat.CQRSLite.Contract.Commands;
using NSubstitute;
using Xunit;

namespace Neat.CQRSLite.CQRS.Tests
{
    public class CommandBusTests
    {
        [Fact]
        public void HappyPath()
        {
            var command = Substitute.For<ICommand>();
            var commandValidator = Substitute.For<ICommandValidator<ICommand>>();
            var commandHandler = Substitute.For<ICommandHandler<ICommand>>();

            var commandBus = new CommandBus(t => commandValidator, t => commandHandler);

            var commandResult = commandBus.Execute(command);

            Assert.True(commandResult.WasSuccessful());
            commandValidator.Received(1).Validate(Arg.Any<ICommand>());
            commandHandler.Received(1).Execute(Arg.Any<ICommand>());
        }

        [Fact]
        public void ValidationErrors()
        {
            var validationsErrors = new[] {new ValidationError("Id", "Value is not valid", -1)};
            var command = Substitute.For<ICommand>();
            var commandValidator = Substitute.For<ICommandValidator<ICommand>>();
            commandValidator.Validate(Arg.Any<ICommand>()).Returns(validationsErrors);
            var commandHandler = Substitute.For<ICommandHandler<ICommand>>();
            var commandBus = new CommandBus(t => commandValidator, t => commandHandler);

            var commandResult = commandBus.Execute(command);

            Assert.False(commandResult.WasSuccessful());
            Assert.Equal(commandResult.ValidationErrors[0], validationsErrors[0]);
            commandValidator.Received(1).Validate(Arg.Any<ICommand>());
            commandHandler.DidNotReceive().Execute(Arg.Any<ICommand>());
        }
    }
}