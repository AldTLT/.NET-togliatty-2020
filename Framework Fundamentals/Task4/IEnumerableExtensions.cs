using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// IEnumerable extension class contains UniqueInOrder method.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// The extension method returns sequence without any elements with the same
        /// value next to each other and preserving the original order of elements.
        /// </summary>
        /// <param name="source">Sequence that implements IEnumerable.</param>
        /// <returns>IEnumerable without any elements with the same
        /// value next to each other</returns>
        public static IEnumerable UniqueInOrder(this IEnumerable source)
        {
            var sourceEnumerator = source.GetEnumerator();
            var first = true;

            if (sourceEnumerator.MoveNext())
            {
                var current = sourceEnumerator.Current;
                do
                {
                    var element = sourceEnumerator.Current;

                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        if (current.Equals(element))
                        {
                            continue;
                        }
                    }

                    current = element;
                    yield return element;
                }
                while (sourceEnumerator.MoveNext());
            }
        }
    }
}
