namespace Paraminter.Mappers.Queries;

using Paraminter.Parameters.Models;

internal static class GetMappedSingleArgumentAssociatorQueryFactory
{
    public static IGetMappedSingleArgumentAssociatorQuery<TParameter> Create<TParameter>(
        TParameter parameter)
        where TParameter : IParameter
    {
        return new GetMappedIndividualArgumentAssociatorQuery<TParameter>(parameter);
    }

    private sealed class GetMappedIndividualArgumentAssociatorQuery<TParameter>
        : IGetMappedSingleArgumentAssociatorQuery<TParameter>
        where TParameter : IParameter
    {
        private readonly TParameter Parameter;

        public GetMappedIndividualArgumentAssociatorQuery(
            TParameter parameter)
        {
            Parameter = parameter;
        }

        TParameter IGetMappedSingleArgumentAssociatorQuery<TParameter>.Parameter => Parameter;
    }
}
