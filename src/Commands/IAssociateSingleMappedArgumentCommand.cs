namespace Paraminter.Mappers.Commands;

using Paraminter.Arguments.Models;
using Paraminter.Cqs;

/// <summary>Represents a command to associate a single argument with a specific parameter.</summary>
/// <typeparam name="TArgumentData">The type representing data about the arguments.</typeparam>
public interface IAssociateSingleMappedArgumentCommand<out TArgumentData>
    : ICommand
    where TArgumentData : IArgumentData
{
    /// <summary>Data about the argument.</summary>
    public abstract TArgumentData ArgumentData { get; }
}
