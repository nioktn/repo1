using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using RozetkaLib;

namespace RozetkaTests
{
    public class SearchTests : BaseTest
    {
        private const string ExpectedEmptySearchTitle = "Вы ещё ничего не искали";
        private const string ExpectedNotFoundSearchTitle = "Ничего не найдено";

        static object[] ValildSearchQueryParameters =
        {
            new object[] {"Apple iPhone 12"},
            new object[] {"Samsung Galaxy S10"},
            new object[] {"MacBook Pro 16"},
            new object[] {"245162509"}
        };

        static object[] NotValildSearchQueryParameters =
        {
            new object[] {"NotFoundTestNotFoundTest"},
            new object[] {"NotValidQueryNotValidQuery"},
            new object[] {"DumbTextDumbTextDumbText"}
        };


        [Test]
        public void Test_EmptySearchOpen()
        {
            var searchPage = new SearchPage(driver);

            var actualSearchPageTitleValue = searchPage
                .OpenSearch(wait)
                .GetSearchTitle(wait);
            StringAssert.AreEqualIgnoringCase(ExpectedEmptySearchTitle, actualSearchPageTitleValue);
        }

        [Test, TestCaseSource(nameof(NotValildSearchQueryParameters))]
        public void Test_SearchNotFound(string searchQuery)
        {
            var searchPage = new SearchPage(driver);

            searchPage
                .OpenSearch(wait)
                .EnterSearchQuery(searchQuery, wait);

            var actualSearchPageTitleValue = searchPage.GetSearchTitle(wait);
            StringAssert.AreEqualIgnoringCase(ExpectedNotFoundSearchTitle, actualSearchPageTitleValue);
        }

        [Test, TestCaseSource(nameof(ValildSearchQueryParameters))]
        public void Test_SearchValidQuery(string searchQuery)
        {
            var searchPage = new SearchPage(driver);

            searchPage
                .OpenSearch(wait)
                .EnterSearchQuery(searchQuery, wait);
            Thread.Sleep(2000);

            var productListPage = new ProductsListPage(driver);
            var foundProductsList = productListPage.GetAvailableProducts(wait);
            CollectionAssert.IsNotEmpty(foundProductsList);
        }
    }
}