using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Threading;

namespace RozetkaLib
{
    public class WishListsPage
    {
        private readonly AndroidDriver<AndroidElement> driver;

        private By _wishListsList = By.XPath("//androidx.recyclerview.widget.RecyclerView" +
                                             "[@resource-id='ua.com.rozetka.shop:id/wishlists_rv_list']/androidx.cardview.widget.CardView");

        public IList<AndroidElement> WishListsList
        {
            get => driver.FindElements(_wishListsList);
        }

        public WishListsPage(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public WishList OpenGuestWishList(WebDriverWait wait)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(_wishListsList));
            WishListsList[0].Click();
            Thread.Sleep(3000);
            return new WishList(driver);
        }
    }
}