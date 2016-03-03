using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colletions
{
    /// <summary>
    /// Collection Interface
    /// </summary>
    public interface Collection
    {
        /// <summary>
        /// Add method: add an object by value
        /// </summary>
        /// <param name="value">received object to add inside the collection</param>
        void add(Object value);

        /// <summary>
        /// Remove method: remove an object by value
        /// </summary>
        /// <param name="value">received object to remove an element of the collection</param>
        /// <returns>The object that was removed</returns>
        Object remove(Object value);

        /// <summary>
        /// Size method: indicates you the number of elements that have the collection
        /// </summary>
        /// <returns>An integer</returns>
        int size();

        /// <summary>
        /// isEmpty method: indicates you if the collection is empty or not (0 elements)
        /// </summary>
        /// <returns>A boolean, true if is empty or false if not</returns>
        Boolean isEmpty();
    }
}
