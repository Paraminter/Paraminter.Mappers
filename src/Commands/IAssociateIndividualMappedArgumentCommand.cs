﻿namespace Paraminter.Mappers.Commands;

using Paraminter.Arguments.Models;
using Paraminter.Cqs;

/// <summary>Represents a command to associate an argument with some parameter.</summary>
/// <typeparam name="TArgumentData">The type representing data about the arguments.</typeparam>
public interface IAssociateIndividualMappedArgumentCommand<out TArgumentData>
    : ICommand
    where TArgumentData : IArgumentData
{
    /// <summary>Data about the argument.</summary>
    public abstract TArgumentData ArgumentData { get; }
}
