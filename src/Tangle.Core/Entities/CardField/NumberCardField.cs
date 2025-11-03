using System.Globalization;
using Tangle.Core.Enums;

namespace Tangle.Core.Entities.CardField;

/// <summary>
/// Represents a card field that holds a numeric value.
/// </summary>
public class NumberCardField : ICardField
{
    /// <summary>
    /// Internal storage for the numeric value.
    /// </summary>
    private float? _value = null!;

    /// <summary>
    /// Name of field
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Gets or sets the value as a string.
    /// Setting the value will parse the string to a float.
    /// </summary>
    public string? Value
    {
        get => _value.ToString();
        set => SetValue(value);
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="NumberCardField"/> class with no value.
    /// </summary>
    /// <param name="name">The name of field</param>
    public NumberCardField(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NumberCardField"/> class with a nullable float value.
    /// </summary>
    /// <param name="name">The name of field</param>
    /// <param name="value">The numeric value to store.</param>
    public NumberCardField(string name, float? value) : this(name)
    {
        _value = value;
    }

    /// <summary>
    /// Parses the string input and sets the numeric value.
    /// </summary>
    /// <param name="value">The string representation of the number.</param>
    /// <exception cref="FormatException">Thrown when the string cannot be parsed to a float.</exception>
    private void SetValue(string? value)
    {
        // If the string is null or whitespace, set the value to null.
        if (string.IsNullOrWhiteSpace(value))
        {
            _value = null;
        }
        
        // Attempt to parse using the invariant culture (e.g., "1234.56").
        if (float.TryParse(value, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out var result))
        {
            _value = result;
            return;
        }
        
        // Attempt to parse using the current culture (e.g., "1.234,56" in some locales).
        if (float.TryParse(value, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out result))
        {
            _value = result;
            return;
        }

        // If parsing fails, throw a FormatException with a descriptive message.
        string message = string.Format(ExceptionMessage.InvalidFormatNumberMessage, value);
        throw new FormatException(message);
    }

    /// <summary>
    /// Gets the type of the card field.
    /// </summary>
    public CardFieldType Type => CardFieldType.Number;

    /// <summary>
    /// Returns the string representation of the numeric value.
    /// </summary>
    /// <returns>The numeric value as a string, or null if no value is set.</returns>
    public override string? ToString()
    {
        return Value;
    }
}
