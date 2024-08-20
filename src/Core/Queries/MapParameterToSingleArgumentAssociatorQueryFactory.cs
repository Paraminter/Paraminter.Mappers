namespace Paraminter.Mappers.Queries;

using Paraminter.Parameters.Models;

internal static class MapParameterToSingleArgumentAssociatorQueryFactory
{
    public static IMapParameterToSingleArgumentAssociatorQuery<TParameter> Create<TParameter>(
        TParameter parameter)
        where TParameter : IParameter
    {
        return new MapParameterToSingleArgumentAssociatorQuery<TParameter>(parameter);
    }

    private sealed class MapParameterToSingleArgumentAssociatorQuery<TParameter>
        : IMapParameterToSingleArgumentAssociatorQuery<TParameter>
        where TParameter : IParameter
    {
        private readonly TParameter Parameter;

        public MapParameterToSingleArgumentAssociatorQuery(
            TParameter parameter)
        {
            Parameter = parameter;
        }

        TParameter IMapParameterToSingleArgumentAssociatorQuery<TParameter>.Parameter => Parameter;
    }
}
