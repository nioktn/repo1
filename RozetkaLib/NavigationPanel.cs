using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Support.UI;

namespace RozetkaLib
{
    public class NavigationPanel
    {
        private readonly AndroidDriver<AndroidElement> driver;
        private readonly By _btnMain = By.Id("ua.com.rozetka.shop:id/graph_home");
        private readonly By _btnCatalog = By.Id("ua.com.rozetka.shop:id/graph_fatMenu");
        private readonly By _btnCart = By.Id("ua.com.rozetka.shop:id/graph_cart");
        private readonly By _btnWishLists = By.Id("ua.com.rozetka.shop:id/graph_wishlists");
        private readonly By _btnMore = By.Id("ua.com.rozetka.shop:id/graph_more");

        private readonly By _btnNavPage = By.XPath("//android.widget.ImageButton[@content-desc='Перейти вверх']");
        private readonly By _navPanel = By.Id("ua.com.rozetka.shop:id/rv_menu");
        private readonly By _btnSignIn = MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"Вход\")");
        private readonly By _btnSignUp = MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"Регистрация\")");
        private readonly By _btnShare = MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"Акции\")");
        private readonly By _btnDiscount = MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"Скидки\")");
        private readonly By _btnPersonalData = MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"Личные данные\")");
        private readonly By _btnWaitList = MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"Лист ожиданий\")");
        private readonly By _btnOrders = MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"Мои заказы\")");
        private readonly By _btnComparison = MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"Сравнение\")");
        private readonly By _btnWatched = MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"Просмотренные\")");
        private readonly By _btnFeedback = MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"Обратная связь\")");
        private readonly By _btnInfo = MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"Информация\")");
        
        
        public AndroidElement BtnMain { get => driver.FindElement(_btnMain); }
        public AndroidElement BtnCatalog { get => driver.FindElement(_btnCatalog); }
        public AndroidElement BtnCart { get => driver.FindElement(_btnCart); }
        
        public AndroidElement BtnWaitList { get => driver.FindElement(_btnWaitList); }
        public AndroidElement BtnMore { get => driver.FindElement(_btnMore); }
        
        
        public AndroidElement BtnSignIn { get => driver.FindElement(_btnSignIn); }
        public AndroidElement BtnSignUp { get => driver.FindElement(_btnSignUp); }
        
        public AndroidElement BtnPersonalData { get => driver.FindElement(_btnPersonalData); }
        public AndroidElement BtnWishLists { get => driver.FindElement(_btnWishLists); }
        public AndroidElement BtnOrders { get => driver.FindElement(_btnOrders); }
        public AndroidElement BtnComparison { get => driver.FindElement(_btnComparison); }
        public AndroidElement BtnWatched { get => driver.FindElement(_btnWatched); }

        public NavigationPanel(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public CatalogPage OpenCatalogPage()
        {
            BtnCatalog.Click();
            CatalogPage catPage = new CatalogPage(driver);
            return catPage;
        }

        public CatalogPage OpenCatalogPage(WebDriverWait wait)
        {
            wait.Until(d => ElemHelper.IsElementVisible(driver, _btnCatalog));
            BtnCatalog.Click();
            var catPage = new CatalogPage(driver);
            return catPage;
        }

        public bool IsNavigationPanelOpened()
        {
            return ElemHelper.IsElementVisible(driver, _btnMain);
        }

        public void Close()
        {
            if (IsNavigationPanelOpened())
            {
                ISendsKeyEvents sendsKey = driver;
                sendsKey.PressKeyCode(AndroidKeyCode.Back);
            }
        }

        public void Open()
        {
            driver.FindElement(_btnNavPage).Click();
        }

        // public NavigationPanel Open(WebDriverWait wait)
        // {
            // wait.Until((d) => ElemHelper.IsElementVisible(d, _btnNavPage));
            // driver.FindElement(_btnNavPage).Click();
            // wait.Until((d) => ElemHelper.IsElementVisible(d, _navPanel));
            // return this;
        // }

        public NavigationPanel OpenMore(WebDriverWait wait)
        {
            wait.Until(d => ElemHelper.IsElementVisible(driver, _btnMore));
            BtnMore.Click();
            return this;
        }
        
        public WishListsPage OpenWishLists()
        {
            ElemHelper.ScrollToElement(driver, "Списки желаний");
            BtnWishLists.Click();
            WishListsPage whLsPg = new WishListsPage(driver);
            return whLsPg;
        }

        public WishListsPage OpenWishLists(WebDriverWait wait)
        {
            wait.Until(d => ElemHelper.IsElementVisible(driver, _btnWishLists));
            BtnWishLists.Click();
            var whLsPg = new WishListsPage(driver);
            return whLsPg;
        }

        public CartPage OpenCart()
        {
            BtnCart.Click();
            var crtPage = new CartPage(driver);
            return crtPage;
        }

        public CartPage OpenCart(WebDriverWait wait)
        {
            wait.Until(d => ElemHelper.IsElementVisible(driver, _btnCart));
            BtnCart.Click();
            var cartPage = new CartPage(driver);
            return cartPage;
        }

        public LoginPage OpenLoginPage()
        {
            BtnSignIn.Click();
            return new LoginPage(driver);
        }

        public LoginPage OpenLoginPage(WebDriverWait wait)
        {
            // ElemHelper.ScrollToElement(driver, "Вход");
            wait.Until(d => ElemHelper.IsElementVisible(driver, _btnSignIn));
            BtnSignIn.Click();
            return new LoginPage(driver);
        }
    }
}
