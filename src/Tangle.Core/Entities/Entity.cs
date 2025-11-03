using Tangle.Core.Entities.CardField;
using Tangle.Core.Enums;

namespace Tangle.Core.Entities;

/// <summary>
/// Represents a base entity with a unique identifier, name, and type.
/// This class is abstract and intended to be inherited by specific entity types.
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// Gets the unique identifier for this entity.
    /// It is automatically generated when the entity is created.
    /// </summary>
    public Guid Uid { get; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets the name of the entity.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets the type of the entity.
    /// Must be implemented by derived classes.
    /// </summary>
    public abstract EntityType Type { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Entity"/> class with the specified name.
    /// </summary>
    /// <param name="name">The name of the entity.</param>
    protected Entity(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Returns the string representation of the entity, which is its name.
    /// </summary>
    /// <returns>The name of the entity.</returns>
    public override string ToString()
    {
        return Name;
    }
}