using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace RozetkaLib
{
    public class SortPanel
    {
        private readonly AndroidDriver<AndroidElement> driver;
        private readonly By _rbtnCheapExpensive = By.XPath("//android.widget.RadioGroup/android.widget.RadioButton[1]");
        private readonly By _rbtnExpensiveCheap = By.XPath("//android.widget.RadioGroup/android.widget.RadioButton[2]");
        private readonly By _rbtnPopular = By.XPath("//android.widget.RadioGroup/android.widget.RadioButton[3]");
        private readonly By _rbtNovelty = By.XPath("//android.widget.RadioGroup/android.widget.RadioButton[4]");
        private readonly By _rbtnShares = By.XPath("//android.widget.RadioGroup/android.widget.RadioButton[5]");
        private readonly By _rbtnByRate = By.XPath("//android.widget.RadioGroup/android.widget.RadioButton[6]");

        public AndroidElement RbtnCheapExpensive { get => driver.FindElement(_rbtnCheapExpensive); }
        public AndroidElement RbtnExpensiveCheap { get => driver.FindElement(_rbtnExpensiveCheap); }
        public AndroidElement RbtnPopular { get => driver.FindElement(_rbtnPopular); }
        public AndroidElement RbtNovelty { get => driver.FindElement(_rbtNovelty); }
        public AndroidElement RbtnShares { get => driver.FindElement(_rbtnShares); }
        public AndroidElement RbtnByRate { get => driver.FindElement(_rbtnByRate); }

        public SortPanel(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public bool IsOpened()
        {
            return ElemHelper.IsElementVisible(driver, _rbtnExpensiveCheap);
        }
    }
}
