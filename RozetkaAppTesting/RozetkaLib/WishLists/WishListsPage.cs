using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace RozetkaLib
{
    public class WishListsPage
    {
        private readonly AndroidDriver<AndroidElement> driver;
        private By _wishListsList = By.XPath("//android.widget.FrameLayout[2]/android.support.v7.widget.RecyclerView/android.widget.LinearLayout");

        public IList<AndroidElement> WishListsList { get => driver.FindElements(_wishListsList); }

        public WishListsPage(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public WishList OpenGuestWishList(WebDriverWait wait)
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(_wishListsList));
            WishListsList[0].Click();
            return new WishList(driver);
        }
    }
}
