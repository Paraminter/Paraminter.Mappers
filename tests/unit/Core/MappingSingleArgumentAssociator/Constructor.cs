namespace Paraminter.Mappers;

using Moq;

using Paraminter.Arguments.Models;
using Paraminter.Cqs.Handlers;
using Paraminter.Mappers.Commands;
using Paraminter.Mappers.Queries;
using Paraminter.Parameters.Models;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullMapper_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<IParameter, IArgumentData>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsAssociator()
    {
        var result = Target(Mock.Of<IQueryHandler<IMapParameterToSingleArgumentAssociatorQuery<IParameter>, ICommandHandler<IAssociateSingleMappedArgumentCommand<IArgumentData>>>>());

        Assert.NotNull(result);
    }

    private static MappingSingleArgumentAssociator<TParameter, TArgumentData> Target<TParameter, TArgumentData>(
        IQueryHandler<IMapParameterToSingleArgumentAssociatorQuery<TParameter>, ICommandHandler<IAssociateSingleMappedArgumentCommand<TArgumentData>>> mapper)
        where TParameter : IParameter
        where TArgumentData : IArgumentData
    {
        return new MappingSingleArgumentAssociator<TParameter, TArgumentData>(mapper);
    }
}
