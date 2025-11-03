using Tangle.Core.Entities.CardField;
using Tangle.Core.Enums;

namespace Tangle.Core.Entities;

/// <summary>
/// Represents a Card entity, derived from the base <see cref="Entity"/> class.
/// </summary>
public class Card : Entity
{
    /// <summary>
    /// Gets the type of this entity, which is always <see cref="EntityType.Card"/>.
    /// </summary>
    public override EntityType Type => EntityType.Card;

    /// <summary>
    /// Gets the collection of <see cref="ICardField"/> associated with this card.
    /// Each field in this collection has a unique name.
    /// </summary>
    public CardFieldCollection Fields { get; } = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Card"/> class with a default name "Card".
    /// This constructor is protected, intended for use by derived classes or factory methods.
    /// </summary>
    protected Card() : base(nameof(Card)) { }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Card"/> class with the specified name.
    /// This constructor is protected, intended for use by derived classes or factory methods.
    /// </summary>
    /// <param name="name">The name of the card.</param>
    protected Card(string name) : base(name) { }
}