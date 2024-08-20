namespace Paraminter.Mappers.Queries;

using Paraminter.Cqs;

/// <summary>Represents a query to map a parameter to an associator of arguments with that parameter.</summary>
/// <typeparam name="TParameter">The type representing the parameter.</typeparam>
public interface IMapParameterToSingleArgumentAssociatorQuery<out TParameter>
    : IQuery
{
    /// <summary>The parameter.</summary>
    public abstract TParameter Parameter { get; }
}
