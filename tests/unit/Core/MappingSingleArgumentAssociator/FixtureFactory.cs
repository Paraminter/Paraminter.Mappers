﻿namespace Paraminter.Mappers;

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
        Mock<IQueryHandler<IGetMappedSingleArgumentAssociatorQuery<TParameter>, ICommandHandler<IAssociateSingleMappedArgumentCommand<TArgumentData>>>> mapperMock = new();

        MappingSingleArgumentAssociator<TParameter, TArgumentData> sut = new(mapperMock.Object);

        return new Fixture<TParameter, TArgumentData>(sut, mapperMock);
    }

    private sealed class Fixture<TParameter, TArgumentData>
        : IFixture<TParameter, TArgumentData>
        where TParameter : IParameter
        where TArgumentData : IArgumentData
    {
        private readonly ICommandHandler<IAssociateSingleArgumentCommand<TParameter, TArgumentData>> Sut;

        private readonly Mock<IQueryHandler<IGetMappedSingleArgumentAssociatorQuery<TParameter>, ICommandHandler<IAssociateSingleMappedArgumentCommand<TArgumentData>>>> MapperMock;

        public Fixture(
            ICommandHandler<IAssociateSingleArgumentCommand<TParameter, TArgumentData>> sut,
            Mock<IQueryHandler<IGetMappedSingleArgumentAssociatorQuery<TParameter>, ICommandHandler<IAssociateSingleMappedArgumentCommand<TArgumentData>>>> mapperMock)
        {
            Sut = sut;

            MapperMock = mapperMock;
        }

        ICommandHandler<IAssociateSingleArgumentCommand<TParameter, TArgumentData>> IFixture<TParameter, TArgumentData>.Sut => Sut;

        Mock<IQueryHandler<IGetMappedSingleArgumentAssociatorQuery<TParameter>, ICommandHandler<IAssociateSingleMappedArgumentCommand<TArgumentData>>>> IFixture<TParameter, TArgumentData>.MapperMock => MapperMock;
    }
}
