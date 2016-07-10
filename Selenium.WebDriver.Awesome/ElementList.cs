/*
 * The MIT License (MIT)
 *
 * Copyright (c) 2016 Swen Kooij / Photonios
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights to
 * use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
 * of the Software, and to permit persons to whom the Software is furnished to do
 * so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
 * CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace OpenQA.Selenium.Awesome
{
    /// <summary>
    /// Extensions to <see cref="ReadOnlyCollection{T}"/> to allow searching for an element by its "Text" property.
    /// </summary>
    public static class ElementListExtension
    {
        /// <summary>
        /// Finds and element which "Text" property matches one or more of the specified <paramref name="strings"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements contained in the list.</typeparam>
        /// <param name="list">The list to search in.</param>
        /// <param name="strings">The strings to match.</param>
        /// <returns>An element that matched one of the specified <paramref name="strings"/> or null if none could be found.</returns>
        public static IWebElement FindByText<T>(this ReadOnlyCollection<T> list, params string[] strings) where T : IWebElement
        {
            return list.FirstOrDefault(element => strings.Contains(element.Text));
        }

        /// <summary>
        /// Finds elements which "Text" property matches one or more of the specified <paramref name="strings"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements contained in the list.</typeparam>
        /// <param name="list">The list to search in.</param>
        /// <param name="strings">The strings to match.</param>
        /// <returns>A list of elements that match one or more of the specified <paramref name="strings"/>.</returns>
        public static IEnumerable<T> FindAllByText<T>(this ReadOnlyCollection<T> list, params string[] strings) where T : IWebElement
        {
            return list.Where(element => strings.Contains(element.Text));
        }
    }
}
