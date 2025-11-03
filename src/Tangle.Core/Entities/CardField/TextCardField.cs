using Tangle.Core.Enums;

namespace Tangle.Core.Entities.CardField;

/// <summary>
/// Represents a card field that holds a text value.
/// </summary>
public class TextCardField : ICardField
{
    /// <summary>
    /// Internal storage for the text value.
    /// </summary>
    private string? _value;

    /// <summary>
    /// Gets or sets the name of the card field.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the value of the card field.
    /// Setting the value removes any newline characters.
    /// </summary>
    public string? Value
    {
        get => _value;
        set => SetValue(value);
    }

    /// <summary>
    /// Sets the value of the card field, removing newline characters.
    /// </summary>
    /// <param name="value">The string value to store.</param>
    private void SetValue(string? value)
    {
        _value = value?.Replace(Environment.NewLine, string.Empty);
    }

    /// <summary>
    /// Gets the type of this card field, which is always <see cref="CardFieldType.Text"/>.
    /// </summary>
    public CardFieldType Type => CardFieldType.Text;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="TextCardField"/> class with a specified name.
    /// </summary>
    /// <param name="name">The name of the card field.</param>
    public TextCardField(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TextCardField"/> class with a specified name and value.
    /// </summary>
    /// <param name="name">The name of the card field.</param>
    /// <param name="value">The initial text value of the card field.</param>
    public TextCardField(string name, string value) : this(name)
    {
        Value = value;
    }
}