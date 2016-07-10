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

using OpenQA.Selenium.Internal;

namespace OpenQA.Selenium.Awesome
{
    /// <summary>
    /// Defines extensions on the <see cref="IWebElement"/> interface for HTML5 drag and drop.
    /// </summary>
    public static class DragAndDropExtension
    {
        /// <summary>
        /// Indicates whether the script was injected already.
        /// </summary>
        /// <remarks>The script should only be injected once.</remarks>
        private static bool scriptWasInjected = false;

        /// <summary>
        /// Drags this element onto <paramref name="targetElement"/>.
        /// </summary>
        /// <param name="sourceElement">The element to drag on top of <paramref name="targetElement"/>.</param>
        /// <param name="targetElement">The element to drag <paramref name="sourceElement"/> to.</param>
        public static void DragTo<T>(this T sourceElement, T targetElement) where T : IWebElement, IWrapsDriver
        {
            IWebDriver driver = (sourceElement as IWrapsDriver).WrappedDriver;
            sourceElement.DragTo(targetElement, driver);
        }

        /// <summary>
        /// Drags this element onto <paramref name="targetElement">.
        /// </summary>                
        /// <param name="sourceElement">The element to drag on top of <paramref name="targetElement"/>.</param>
        /// <param name="driver">The driver to execute the action on.</param>
        /// <param name="targetElement">The element to drag <paramref name="sourceElement"/> to.</param>
        public static void DragTo(this IWebElement sourceElement, IWebElement targetElement, IWebDriver driver)
        {
            IJavaScriptExecutor executor = driver as IJavaScriptExecutor;

            if (!scriptWasInjected)
            {
                executor.ExecuteScript(Resources.DragAndDropScript);
                scriptWasInjected = true;
            }

            executor.ExecuteScript(
                "DndSimulator.simulate(arguments[0], arguments[1]);",
                sourceElement,
                targetElement
            );
        }
    }
}