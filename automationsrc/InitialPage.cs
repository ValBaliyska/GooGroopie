using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace automationsrc
{
	public class InitialPage
	{
		public static void GoTo()
		{
			Driver.Instance.Navigate().GoToUrl("https://www.gogroopie.com/");
			Driver.Instance.Manage().Window.Maximize();
		}

		[Obsolete]
		public static bool IsAt()
		{
			if(Driver.Instance.Url.Contains("https://www.gogroopie.com/"))
				return true;
			return false;
		}

		[Obsolete]
		public static bool IsAtSubscribeToGogroopie(IWebDriver driver, By locator){
			if (driver.FindElement(locator).Displayed)
				return true;
			return false;
		}
	}
}
