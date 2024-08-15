namespace Paraminter.Mappers;

using Moq;

using Paraminter.Arguments.Models;
using Paraminter.Commands;
using Paraminter.Cqs.Handlers;
using Paraminter.Mappers.Commands;
using Paraminter.Mappers.Queries;
using Paraminter.Parameters.Models;

internal static class FixtureFactory
{
    public static IFixture<TParameter, TArgumentData> Create<TParameter, TArgumentData>()
        where TParameter : IParameter
        where TArgumentData : IArgumentData
    {
        Mock<IQueryHandler<IGetMappedIndividualArgumentAssociatorQuery<TParameter>, ICommandHandler<IAssociateIndividualMappedArgumentCommand<TArgumentData>>>> mapperMock = new();

        MappingIndividualAssociator<TParameter, TArgumentData> sut = new(mapperMock.Object);

        return new Fixture<TParameter, TArgumentData>(sut, mapperMock);
    }

    private sealed class Fixture<TParameter, TArgumentData>
        : IFixture<TParameter, TArgumentData>
        where TParameter : IParameter
        where TArgumentData : IArgumentData
    {
        private readonly ICommandHandler<IAssociateIndividualArgumentCommand<TParameter, TArgumentData>> Sut;

        private readonly Mock<IQueryHandler<IGetMappedIndividualArgumentAssociatorQuery<TParameter>, ICommandHandler<IAssociateIndividualMappedArgumentCommand<TArgumentData>>>> MapperMock;

        public Fixture(
            ICommandHandler<IAssociateIndividualArgumentCommand<TParameter, TArgumentData>> sut,
            Mock<IQueryHandler<IGetMappedIndividualArgumentAssociatorQuery<TParameter>, ICommandHandler<IAssociateIndividualMappedArgumentCommand<TArgumentData>>>> mapperMock)
        {
            Sut = sut;

            MapperMock = mapperMock;
        }

        ICommandHandler<IAssociateIndividualArgumentCommand<TParameter, TArgumentData>> IFixture<TParameter, TArgumentData>.Sut => Sut;

        Mock<IQueryHandler<IGetMappedIndividualArgumentAssociatorQuery<TParameter>, ICommandHandler<IAssociateIndividualMappedArgumentCommand<TArgumentData>>>> IFixture<TParameter, TArgumentData>.MapperMock => MapperMock;
    }
}
