using System;
using System.Collections.Generic;
using System.Linq;
using automationsrc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace automationtests
{
	[TestClass]
	public class HomePageFeature
	{
		[TestInitialize]
		public void init()
		{
			Driver.Initialize();
		}

		[TestMethod]
		[Obsolete]
		public void ShouldBeAbleToLogin()
		{
			InitialPage.GoTo();
			var subscribeLocator = By.XPath("//span[contains(@class, 'title') and text() = 'Subscribe to Gogroopie']");

			var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
			wait.Until(ExpectedConditions.ElementIsVisible(subscribeLocator));

			Assert.IsTrue(InitialPage.IsAt(), "Failed to load tha page.");
			Assert.IsTrue(InitialPage.IsAtSubscribeToGogroopie(Driver.Instance, subscribeLocator), "Not at subscribe screen.");
		}

		[TestMethod]
		[Obsolete]
		public void ShouldBeAbleToGoToProductsAndAssertDropdown()
		{
			InitialPage.GoTo();

			var Xbutton = Driver.Instance.FindElement(By.ClassName("close"));
			Xbutton.Click();


			var products = Driver.Instance.FindElement(By.XPath("//a[@href='/products/']"));
			IJavaScriptExecutor jse = (IJavaScriptExecutor)Driver.Instance;
			jse.ExecuteScript("arguments[0].click();", products);

			var dropdown = By.XPath("//*[@class='dropdown-selection-title ng-binding' and contains(text(),'Selected')]");
			var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
			wait.Until(ExpectedConditions.ElementIsVisible(dropdown));
			var actualvalue = GetText(Driver.Instance, dropdown);
			Assert.AreEqual(actualvalue, "Selected");
		}

		[TestMethod]
		[Obsolete]
		public void ShouldBeAbleToBuyDeal()
		{
			InitialPage.GoTo();

			var closebutton = Driver.Instance.FindElement(By.ClassName("close"));
			closebutton.Click();

			var firstdeal = Driver.Instance.FindElement(By.XPath("//img[@data-priority = '1']"));
			IJavaScriptExecutor jse = (IJavaScriptExecutor)Driver.Instance;
			jse.ExecuteScript("arguments[0].click();", firstdeal);

			var buynow = By.XPath("//div[@class='deal-page-container clear-fix']//a[contains(text(), 'Buy Now')]");
			var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
			wait.Until(ExpectedConditions.ElementIsVisible(buynow));
			var buy = Driver.Instance.FindElement(buynow);
			jse.ExecuteScript("arguments[0].click();", buy);

			var newcustomer = By.XPath("//ul//li[text()[contains(.,'New customer')]]");
			wait.Until(ExpectedConditions.ElementIsVisible(newcustomer));
			var actualvalue = GetText(Driver.Instance, newcustomer);
			Assert.AreEqual(actualvalue, "NEW CUSTOMER");
		}

		public static string GetText(IWebDriver driver, By locator)
		{
			return driver.FindElement(locator).Text;
		}

		[TestCleanup]
		public void CleanUp()
		{
			//Driver.Instance.Quit();
		}
	}
}
