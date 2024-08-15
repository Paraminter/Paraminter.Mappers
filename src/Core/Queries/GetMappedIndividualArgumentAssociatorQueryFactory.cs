namespace Paraminter.Mappers.Queries;

using Paraminter.Parameters.Models;

internal static class GetMappedIndividualArgumentAssociatorQueryFactory
{
    public static IGetMappedIndividualArgumentAssociatorQuery<TParameter> Create<TParameter>(
        TParameter parameter)
        where TParameter : IParameter
    {
        return new GetMappedIndividualArgumentAssociatorQuery<TParameter>(parameter);
    }

    private sealed class GetMappedIndividualArgumentAssociatorQuery<TParameter>
        : IGetMappedIndividualArgumentAssociatorQuery<TParameter>
        where TParameter : IParameter
    {
        private readonly TParameter Parameter;

        public GetMappedIndividualArgumentAssociatorQuery(
            TParameter parameter)
        {
            Parameter = parameter;
        }

        TParameter IGetMappedIndividualArgumentAssociatorQuery<TParameter>.Parameter => Parameter;
    }
}
