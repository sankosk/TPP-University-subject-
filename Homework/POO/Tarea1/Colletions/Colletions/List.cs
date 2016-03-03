using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colletions
{
    /// <summary>
    /// List Interface - Implements collection interface
    /// </summary>
    public interface List : Collection
    {
        /// <summary>
        /// Add method: you can add an element by index
        /// </summary>
        /// <param name="index">Integer that indicates you  the position where you want to add the element</param>
        /// <param name="value">An object you want to add inside the list</param>
        void add(int index, Object value);

        /// <summary>
        /// Remove by Index method: allows you to remove an element by his position
        /// </summary>
        /// <param name="index">Integer representing the position of the element</param>
        /// <returns>The object you removed</returns>
        Object removeByIndex(int index);

        /// <summary>
        /// indexOf Method: Allos you to know in wich position is an element
        /// </summary>
        /// <param name="value">The object you want to know his position</param>
        /// <returns>An integer representing the position of the element</returns>
        int indexOf(Object value);

        /// <summary>
        /// Get method: Allows you to get an element by his position
        /// </summary>
        /// <param name="index">The position o the element you want to get</param>
        /// <returns>An object/element you want to get</returns>
        Object get(int index);

        /// <summary>
        /// Set method: Allows you to set the value of an element in an specific position
        /// </summary>
        /// <param name="index">The position of the element</param>
        /// <param name="value">The element/object you want to set</param>
        void set(int index, Object value);
    }
}
