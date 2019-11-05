using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using TechTalk.SpecFlow;
using System;
using System.Threading;

namespace CalcExample
{
    [Binding]
    public class CalcAdditionTestSteps
    {
        Calculator calc = new Calculator();


        [Given(@"je click sur (.*) pour le preimer chiffre")]
        public void SoitJeClickSurPourLePreimerChiffre(int num)
        {
            calc.SetupCalc();

            calc.number1 = num;
            var buttonNames1 = calc.GetStringValue(num);
            var calcWindow = calc.session.FindElementByName("Calculator");
            for (int i = 0; i < buttonNames1.Count; i++)
            {
                calcWindow.FindElementByName(buttonNames1[i]).Click();
            }
        }
        
        [Given(@"je click sur (.*) pour le deuxième chiffre")]
        public void SoitJeClickSurPourLeDeuxiemeChiffre(int num)
        {
            calc.number2 = num;
            var buttonNames2 = calc.GetStringValue(num);

            var calcWindow = calc.session.FindElementByName("Calculator");
            for (int i = 0; i < buttonNames2.Count; i++)
            {
                calcWindow.FindElementByName(buttonNames2[i]).Click();
            }
        }
        
        [Given(@"je clic sur le bouton Plus")]
        public void SoitJeClicSurLeBoutonPlus()
        {
            var calcWindow = calc.session.FindElementByName("Calculator");
            calcWindow.FindElementByName("Plus").Click();
        }
        
        [Given(@"pour afficher le resultat, je clic sur le bouton Equals")]
        public void SoitPourAfficherLeResultatJeClicSurLeBoutonEquals()
        {
            var calcWindow = calc.session.FindElementByName("Calculator");
            calcWindow.FindElementByName("Equals").Click();
        }
        
        [Then(@"la réponse doit afficher (.*)")]
        public void AlorsLaReponseDoitAfficher(int resultatAttendu)
        {
            Assert.AreEqual(resultatAttendu, calc.number1 + calc.number2);
        }      
    }
}
