# Selenium.WebDriver.Awesome
This library intends to provide awesome object extensions to Selenium's .NET bindings.

At this moment it contains:

* Support for HTML5 Drag and Drop

This package is on NuGet:

https://www.nuget.org/packages/Selenium.WebDriver.Awesome/

## Add to your project
Simply add a new NuGet dependency:

	Install-Package Selenium.WebDriver.Awesome

## Using
### HTML5 Drag and Drop

This feature depends on:

	https://github.com/Photonios/JS-DragAndDrop-Simulator

(It is included in this project, no need to do anything with it).

#### Example usage

The extension is on `IWebElement`:

	using OpenQA.Selenium.Awesome;

	IWebElement sourceElement = ...
	IWebElement targetElement = ...

	sourceElement.DragTo(targetElement);

In case you are using `EventFiringWebDriver` or anything else where your elements aren't actually `IWebElement` instances, you can manually specify the driver:

	sourceElement.DragTo(targetElement, this.Driver);