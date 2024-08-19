namespace Paraminter.Mappers.Queries;

using Paraminter.Cqs;

/// <summary>Represents a query for an associator of single arguments with specific parameters.</summary>
/// <typeparam name="TParameter">The type representing the parameters.</typeparam>
public interface IGetMappedSingleArgumentAssociatorQuery<out TParameter>
    : IQuery
{
    /// <summary>The parameter.</summary>
    public abstract TParameter Parameter { get; }
}
