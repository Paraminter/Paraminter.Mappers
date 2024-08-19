namespace Paraminter.Mappers.Commands;

using Paraminter.Arguments.Models;

internal static class AssociateSingleMappedArgumentCommandFactory
{
    public static IAssociateSingleMappedArgumentCommand<TArgumentData> Create<TArgumentData>(
        TArgumentData argumentData)
        where TArgumentData : IArgumentData
    {
        return new AssociateSingleMappedArgumentCommand<TArgumentData>(argumentData);
    }

    private sealed class AssociateSingleMappedArgumentCommand<TArgumentData>
        : IAssociateSingleMappedArgumentCommand<TArgumentData>
        where TArgumentData : IArgumentData
    {
        private readonly TArgumentData ArgumentData;

        public AssociateSingleMappedArgumentCommand(
            TArgumentData argumentData)
        {
            ArgumentData = argumentData;
        }

        TArgumentData IAssociateSingleMappedArgumentCommand<TArgumentData>.ArgumentData => ArgumentData;
    }
}
