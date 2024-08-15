namespace Paraminter.Mappers;

using Moq;

using Paraminter.Arguments.Models;
using Paraminter.Commands;
using Paraminter.Cqs.Handlers;
using Paraminter.Mappers.Commands;
using Paraminter.Mappers.Queries;
using Paraminter.Parameters.Models;

internal interface IFixture<TParameter, TArgumentData>
    where TParameter : IParameter
    where TArgumentData : IArgumentData
{
    public abstract ICommandHandler<IAssociateIndividualArgumentCommand<TParameter, TArgumentData>> Sut { get; }

    public abstract Mock<IQueryHandler<IGetMappedIndividualArgumentAssociatorQuery<TParameter>, ICommandHandler<IAssociateIndividualMappedArgumentCommand<TArgumentData>>>> MapperMock { get; }
}
