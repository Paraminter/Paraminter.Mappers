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
        var result = Target(Mock.Of<IQueryHandler<IGetMappedIndividualArgumentAssociatorQuery<IParameter>, ICommandHandler<IAssociateIndividualMappedArgumentCommand<IArgumentData>>>>());

        Assert.NotNull(result);
    }

    private static MappingIndividualAssociator<TParameter, TArgumentData> Target<TParameter, TArgumentData>(
        IQueryHandler<IGetMappedIndividualArgumentAssociatorQuery<TParameter>, ICommandHandler<IAssociateIndividualMappedArgumentCommand<TArgumentData>>> mapper)
        where TParameter : IParameter
        where TArgumentData : IArgumentData
    {
        return new MappingIndividualAssociator<TParameter, TArgumentData>(mapper);
    }
}
