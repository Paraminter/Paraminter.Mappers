namespace Paraminter.Mappers.Commands;

using Paraminter.Arguments.Models;

internal static class AssociateIndividualMappedArgumentCommandFactory
{
    public static IAssociateIndividualMappedArgumentCommand<TArgumentData> Create<TArgumentData>(
        TArgumentData argumentData)
        where TArgumentData : IArgumentData
    {
        return new AssociateIndividualMappedArgumentCommand<TArgumentData>(argumentData);
    }

    private sealed class AssociateIndividualMappedArgumentCommand<TArgumentData>
        : IAssociateIndividualMappedArgumentCommand<TArgumentData>
        where TArgumentData : IArgumentData
    {
        private readonly TArgumentData ArgumentData;

        public AssociateIndividualMappedArgumentCommand(
            TArgumentData argumentData)
        {
            ArgumentData = argumentData;
        }

        TArgumentData IAssociateIndividualMappedArgumentCommand<TArgumentData>.ArgumentData => ArgumentData;
    }
}
