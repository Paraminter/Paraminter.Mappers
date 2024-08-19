namespace Paraminter.Mappers;

using Moq;

using Paraminter.Arguments.Models;
using Paraminter.Commands;
using Paraminter.Cqs.Handlers;
using Paraminter.Mappers.Commands;
using Paraminter.Mappers.Queries;
using Paraminter.Parameters.Models;

using System;
using System.Linq.Expressions;

using Xunit;

public sealed class Handle
{
    [Fact]
    public void NullCommand_ThrowsArgumentNullException()
    {
        var fixture = FixtureFactory.Create<IParameter, IArgumentData>();

        var result = Record.Exception(() => Target(fixture, null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidCommand_MapsAndAssociates()
    {
        var parameter = Mock.Of<IParameter>();
        var argumentData = Mock.Of<IArgumentData>();

        Mock<IAssociateSingleArgumentCommand<IParameter, IArgumentData>> commandMock = new();

        commandMock.Setup(static (command) => command.Parameter).Returns(parameter);
        commandMock.Setup(static (command) => command.ArgumentData).Returns(argumentData);

        Mock<ICommandHandler<IAssociateSingleMappedArgumentCommand<IArgumentData>>> mappedAssociatorMock = new();

        var fixture = FixtureFactory.Create<IParameter, IArgumentData>();

        fixture.MapperMock.Setup(static (mapper) => mapper.Handle(It.IsAny<IGetMappedSingleArgumentAssociatorQuery<IParameter>>())).Returns(mappedAssociatorMock.Object);

        Target(fixture, commandMock.Object);

        fixture.MapperMock.Verify(GetMappedAssociatorExpression<IParameter, IArgumentData>(parameter), Times.Once());

        mappedAssociatorMock.Verify(AssociateMappedExpression(argumentData), Times.Once());
    }

    private static Expression<Action<IQueryHandler<IGetMappedSingleArgumentAssociatorQuery<TParameter>, ICommandHandler<IAssociateSingleMappedArgumentCommand<TArgumentData>>>>> GetMappedAssociatorExpression<TParameter, TArgumentData>(
        TParameter parameter)
        where TParameter : IParameter
        where TArgumentData : IArgumentData
    {
        return (handler) => handler.Handle(It.Is(MatchGetMappedAssociatorCommand(parameter)));
    }

    private static Expression<Action<ICommandHandler<IAssociateSingleMappedArgumentCommand<TArgumentData>>>> AssociateMappedExpression<TArgumentData>(
        TArgumentData argumentData)
        where TArgumentData : IArgumentData
    {
        return (associator) => associator.Handle(It.Is(MatchAssociateMappedCommand(argumentData)));
    }

    private static Expression<Func<IGetMappedSingleArgumentAssociatorQuery<TParameter>, bool>> MatchGetMappedAssociatorCommand<TParameter>(
        TParameter parameter)
        where TParameter : IParameter
    {
        return (query) => ReferenceEquals(parameter, query.Parameter);
    }

    private static Expression<Func<IAssociateSingleMappedArgumentCommand<TArgumentData>, bool>> MatchAssociateMappedCommand<TArgumentData>(
        TArgumentData argumentData)
        where TArgumentData : IArgumentData
    {
        return (command) => ReferenceEquals(argumentData, command.ArgumentData);
    }

    private static void Target<TParameter, TArgumentData>(
        IFixture<TParameter, TArgumentData> fixture,
        IAssociateSingleArgumentCommand<TParameter, TArgumentData> command)
        where TParameter : IParameter
        where TArgumentData : IArgumentData
    {
        fixture.Sut.Handle(command);
    }
}
