namespace Paraminter.Mappers;

using Paraminter.Arguments.Models;
using Paraminter.Commands;
using Paraminter.Cqs.Handlers;
using Paraminter.Mappers.Commands;
using Paraminter.Mappers.Queries;
using Paraminter.Parameters.Models;

using System;

/// <summary>Associates single arguments with parameters through mapped associators.</summary>
/// <typeparam name="TParameter">The type representing the parameters.</typeparam>
/// <typeparam name="TArgumentData">The type representing data about the arguments.</typeparam>
public sealed class MappingSingleArgumentAssociator<TParameter, TArgumentData>
    : ICommandHandler<IAssociateSingleArgumentCommand<TParameter, TArgumentData>>
    where TParameter : IParameter
    where TArgumentData : IArgumentData
{
    private readonly IQueryHandler<IMapParameterToSingleArgumentAssociatorQuery<TParameter>, ICommandHandler<IAssociateSingleMappedArgumentCommand<TArgumentData>>> Mapper;

    /// <summary>Instantiates an associator of single arguments with parameters through mapped associators.</summary>
    /// <param name="mapper">Maps parameters to associators.</param>
    public MappingSingleArgumentAssociator(
        IQueryHandler<IMapParameterToSingleArgumentAssociatorQuery<TParameter>, ICommandHandler<IAssociateSingleMappedArgumentCommand<TArgumentData>>> mapper)
    {
        Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    void ICommandHandler<IAssociateSingleArgumentCommand<TParameter, TArgumentData>>.Handle(
        IAssociateSingleArgumentCommand<TParameter, TArgumentData> command)
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        var mappingCommand = GetMappedSingleArgumentAssociatorQueryFactory.Create(command.Parameter);
        var associateMappedCommand = AssociateSingleMappedArgumentCommandFactory.Create(command.ArgumentData);

        var associator = Mapper.Handle(mappingCommand);

        associator.Handle(associateMappedCommand);
    }
}
