using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;
using OpenQA.Selenium.Remote;
using System;

namespace CalcExample
{
    class Calculator
    {
        public int number1 { get; set; }
        public int number2 { get; set; }

        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string CalculatorAppId = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";

        public  WindowsDriver<WindowsElement> session;

        public void SetupCalc()
        {
            if (session == null)
            {
                DesiredCapabilities appCapabilities = new DesiredCapabilities();
                appCapabilities.SetCapability("app", CalculatorAppId);
                appCapabilities.SetCapability("deviceName", "WindowsPC");

                session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);

                Assert.IsNotNull(session);
                session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
            }
        }

        public void TearDown()
        {
            if (session != null)
            {
                session.Quit();
                session = null;
            }
        }


        // public string[] numLettre;

        public List<string> GetStringValue(int num)
        {
            List<int> numList = new List<int>();
            
            numList = GetIntArray(num);

            return GetLetters(numList);
        }

        // Cette fonction va séparer un chiffre en plusieur nombres
        // Example 2048 = 2, 0, 4, 8
        private List<int> GetIntArray(int num)
        {
            List<int> listOfInts = new List<int>();
            while (num > 0)
            {
                listOfInts.Add(num % 10);
                num = num / 10;
            }
            listOfInts.Reverse();
            return listOfInts;
        }

        // Cette fonction va
        List<string> GetLetters(List<int> nums)
        {
            List<string> numLettre = new List<string>();
            var numValue = string.Empty;
            for (int i = 0; i < nums.Count; i++)
            {
                numValue += ConvertNum(nums[i]);
                numLettre.Add(numValue);
                numValue = "";
            }
            return numLettre;
        }

        // Cette fonction va convertir les nombres en string
        // Example 6 = "six"
        private string ConvertNum(int num)
        {
            switch (num)
            {
                case 0:
                    return "Zero";
                case 1:
                    return "One";
                case 2:
                    return "Two";
                case 3:
                    return "Three";
                case 4:
                    return "Four";
                case 5:
                    return "Five";
                case 6:
                    return "Six";
                case 7:
                    return "Seven";
                case 8:
                    return "Eight";
                case 9:
                    return "Nine";

                default:
                    return "Zero";
            }
        }
    }
}
