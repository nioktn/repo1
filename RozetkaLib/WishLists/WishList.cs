using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System.Collections.Generic;

namespace RozetkaLib
{
    public class WishList
    {
        private readonly AndroidDriver<AndroidElement> driver;
        private readonly By _wishedProductsList = By.XPath("//*[contains(@resource-id, 'ua.com.rozetka.shop:id/wishlist_rv_list')]/android.widget.FrameLayout");
        private readonly By _btnCatalog = By.XPath("//*[contains(@resource-id, 'ua.com.rozetka.shop:id/empty_base_btn_button')]");
        private readonly By _emptyTitle = By.XPath("//*[contains(@resource-id, 'ua.com.rozetka.shop:id/empty_base_tv_title')]");

        public IList<AndroidElement> WishedProductsList { get => driver.FindElements(_wishedProductsList); }
        public AndroidElement BtnCatalog { get => driver.FindElement(_btnCatalog); }
        public AndroidElement EmptyTitle { get => driver.FindElement(_emptyTitle); }

        public WishList(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public bool IsEmpty()
        {
            return EmptyTitle.Text.Contains("Этот список пуст") && ElemHelper.IsElementExists(driver, _btnCatalog);
        }
    }
}
