using Tangle.Core.Enums;

namespace Tangle.Core.Entities.CardField;

/// <summary>
/// Represents a generic card field with a value and a type.
/// </summary>
public interface ICardField
{
    /// <summary>
    /// The name of field.
    /// Unique in card
    /// </summary>
    string Name { get; set; }
    
    /// <summary>
    /// Gets or sets the value of the card field as a string.
    /// Implementations may parse or format this value internally as needed.
    /// </summary>
    string? Value { get; set; }

    /// <summary>
    /// Gets the type of the card field.
    /// </summary>
    CardFieldType Type { get; }
}