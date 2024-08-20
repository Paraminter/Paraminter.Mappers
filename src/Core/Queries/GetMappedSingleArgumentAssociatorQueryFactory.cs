namespace Paraminter.Mappers.Queries;

using Paraminter.Parameters.Models;

internal static class GetMappedSingleArgumentAssociatorQueryFactory
{
    public static IMapParameterToSingleArgumentAssociatorQuery<TParameter> Create<TParameter>(
        TParameter parameter)
        where TParameter : IParameter
    {
        return new GetMappedIndividualArgumentAssociatorQuery<TParameter>(parameter);
    }

    private sealed class GetMappedIndividualArgumentAssociatorQuery<TParameter>
        : IMapParameterToSingleArgumentAssociatorQuery<TParameter>
        where TParameter : IParameter
    {
        private readonly TParameter Parameter;

        public GetMappedIndividualArgumentAssociatorQuery(
            TParameter parameter)
        {
            Parameter = parameter;
        }

        TParameter IMapParameterToSingleArgumentAssociatorQuery<TParameter>.Parameter => Parameter;
    }
}
