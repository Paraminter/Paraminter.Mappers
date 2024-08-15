namespace Paraminter.Mappers;

using Paraminter.Arguments.Models;
using Paraminter.Commands;
using Paraminter.Cqs.Handlers;
using Paraminter.Mappers.Commands;
using Paraminter.Mappers.Queries;
using Paraminter.Parameters.Models;

using System;

/// <summary>Associates individual arguments with parameters through mapped associators.</summary>
/// <typeparam name="TParameter">The type representing the parameters.</typeparam>
/// <typeparam name="TArgumentData">The type representing data about the arguments.</typeparam>
public sealed class MappingIndividualAssociator<TParameter, TArgumentData>
    : ICommandHandler<IAssociateIndividualArgumentCommand<TParameter, TArgumentData>>
    where TParameter : IParameter
    where TArgumentData : IArgumentData
{
    private readonly IQueryHandler<IGetMappedIndividualArgumentAssociatorQuery<TParameter>, ICommandHandler<IAssociateIndividualMappedArgumentCommand<TArgumentData>>> Mapper;

    /// <summary>Instantiates an associator of individual arguments with parameters through mapped associators.</summary>
    /// <param name="mapper">Maps parameters to associators.</param>
    public MappingIndividualAssociator(
        IQueryHandler<IGetMappedIndividualArgumentAssociatorQuery<TParameter>, ICommandHandler<IAssociateIndividualMappedArgumentCommand<TArgumentData>>> mapper)
    {
        Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    void ICommandHandler<IAssociateIndividualArgumentCommand<TParameter, TArgumentData>>.Handle(
        IAssociateIndividualArgumentCommand<TParameter, TArgumentData> command)
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        var mappingCommand = GetMappedIndividualArgumentAssociatorQueryFactory.Create(command.Parameter);
        var associateMappedCommand = AssociateIndividualMappedArgumentCommandFactory.Create(command.ArgumentData);

        var associator = Mapper.Handle(mappingCommand);

        associator.Handle(associateMappedCommand);
    }
}
