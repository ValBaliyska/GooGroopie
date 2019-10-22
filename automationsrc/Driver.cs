using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace automationsrc
{
	public class Driver
	{
		public static IWebDriver Instance { get; internal set; }

		public static void Initialize()
		{
			Instance = new ChromeDriver();
		}
	}
}