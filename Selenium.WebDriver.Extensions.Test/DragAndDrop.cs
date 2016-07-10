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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Awesome;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace Selenium.WebDriver.Extensions.Test
{
    [TestClass]
    public class DragAndDrop
    {
        /// <summary>
        /// Gets the path to the "Resources" directory in the root of the project.
        /// </summary>
        public string GetResourcesDirectory()
        {
            return Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                @"..\..\..\Resources"
            );
        }

        /// <summary>
        /// Gets the URI to the web page to be used for testing.
        /// </summary>
        public string GetTestUri()
        {
            string filePath = Path.Combine(this.GetResourcesDirectory(), "draganddrop.html");
            return new Uri(filePath).AbsolutePath;
        }
        
        /// <summary>
        /// Tests whether dragging an element onto another one works correctly.
        /// </summary>
        [TestMethod]
        public void TestDragAndDrop()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(this.GetTestUri());

                IWebElement sourceElement = driver.FindElement(By.Id("source_elem"));
                IWebElement targetElement = driver.FindElement(By.Id("target_elem"));

                sourceElement.DragTo(targetElement);

                Assert.IsNotNull(targetElement.FindElement(By.Id("source_elem")));
            }
        }
    }
}
