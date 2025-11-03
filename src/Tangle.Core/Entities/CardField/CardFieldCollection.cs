using System;
using System.Collections;
using System.Collections.Generic;
using Tangle.Core.Enums;

namespace Tangle.Core.Entities.CardField
{
    /// <summary>
    /// A collection of <see cref="ICardField"/> with unique names.
    /// </summary>
    public class CardFieldCollection : ICollection<ICardField>
    {
        /// <summary>
        /// Internal dictionary to store fields by their unique name.
        /// </summary>
        private readonly Dictionary<string, ICardField> _fields = new();

        /// <summary>
        /// Gets the number of fields in the collection.
        /// </summary>
        public int Count => _fields.Count;

        /// <summary>
        /// Gets a value indicating whether the collection is read-only.
        /// Always returns false.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Adds a new <see cref="ICardField"/> to the collection.
        /// Throws an <see cref="ArgumentException"/> if a field with the same name already exists.
        /// </summary>
        /// <param name="item">The field to add.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="item"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if a field with the same name already exists.</exception>
        public void Add(ICardField item)
        {
            if (!_fields.TryAdd(item.Name, item))
            {
                string message = string.Format(ExceptionMessage.FieldExistsInCollectionMessage, item.Name);
                throw new ArgumentException(message);
            }
        }

        /// <summary>
        /// Removes the specified <see cref="ICardField"/> from the collection.
        /// </summary>
        /// <param name="item">The field to remove.</param>
        /// <returns>True if the field was removed; otherwise, false.</returns>
        public bool Remove(ICardField item)
        {
            return _fields.Remove(item.Name);
        }

        /// <summary>
        /// Removes a field from the collection by its name.
        /// </summary>
        /// <param name="name">The name of the field to remove.</param>
        /// <returns>True if the field was removed; otherwise, false.</returns>
        public bool Remove(string name)
        {
            return _fields.Remove(name);
        }

        /// <summary>
        /// Clears all fields from the collection.
        /// </summary>
        public void Clear() => _fields.Clear();

        /// <summary>
        /// Determines whether the collection contains the specified <see cref="ICardField"/>.
        /// </summary>
        /// <param name="item">The field to locate.</param>
        /// <returns>True if the field exists; otherwise, false.</returns>
        public bool Contains(ICardField item)
        {
            return _fields.ContainsKey(item.Name);
        }

        /// <summary>
        /// Determines whether the collection contains a field with the specified name.
        /// </summary>
        /// <param name="name">The name of the field to locate.</param>
        /// <returns>True if the field exists; otherwise, false.</returns>
        public bool Contains(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            return _fields.ContainsKey(name);
        }

        /// <summary>
        /// Copies the fields of the collection to an array, starting at the specified array index.
        /// </summary>
        /// <param name="array">The array to copy the fields into.</param>
        /// <param name="arrayIndex">The zero-based index in the array at which copying begins.</param>
        public void CopyTo(ICardField[] array, int arrayIndex) => _fields.Values.CopyTo(array, arrayIndex);

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator for the collection.</returns>
        public IEnumerator<ICardField> GetEnumerator() => _fields.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _fields.Values.GetEnumerator();

        /// <summary>
        /// Gets the <see cref="ICardField"/> with the specified name.
        /// </summary>
        /// <param name="name">The name of the field to get.</param>
        /// <returns>The field with the specified name, or null if not found.</returns>
        public ICardField? this[string name] => _fields.GetValueOrDefault(name);
    }
}
