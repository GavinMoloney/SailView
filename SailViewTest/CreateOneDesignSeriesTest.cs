using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using SailView.Data;
using SailView.Data.Models;
using SailView.Pages;
using SailView.Services;

namespace SailViewTest
{
    public class CreateOneDesignSeriesTest : TestContext
    {
        public CreateOneDesignSeriesTest()
        {
            // Register MudBlazor services
            Services.AddMudServices();

            // Register in-memory database context
            Services.AddDbContextFactory<SailAppDbContext>();
            Services.AddSingleton<RaceService>();
            Services.AddSingleton<ResultService>();
            Services.AddSingleton<IDialogService>(new MockDialogService());
            Services.AddSingleton<ISnackbar>(new MockSnackbar());
            var customMockNavigationManager = new MockNavigationManager();
            customMockNavigationManager.SetUri("http://localhost/");
            customMockNavigationManager.SetBaseUri("http://localhost/");

            Services.AddSingleton<NavigationManager>(new MockNavigationManager());
            JSInterop.SetupVoid("mudPopover.connect", _ => true);
            JSInterop.SetupVoid("mudKeyInterceptor.connect", _ => true);
        }

        [Fact]
        public void ComponentRendersCorrectly()
        {
            var cut = RenderComponent<NewRaceSeries>();

            var header = cut.Find("h3");
            Assert.Equal("New One Design Race Series", header.TextContent);

        }
        [Fact]
        public void TextFieldAndSelectComponentsAreRendered()
        {
            var cut = RenderComponent<NewRaceSeries>();

            cut.FindComponent<MudTextField<string>>();
            cut.FindComponent<MudSelect<Races>>();
        }

        [Fact]
        public void CreateButtonIsRenderedAndHasCorrectText()
        {
            var cut = RenderComponent<NewRaceSeries>();

            var createButton = cut.Find("button.mud-button");
            Assert.Equal("Create", createButton.TextContent);
        }

        [Fact]
        public void CancelButtonIsRenderedAndHasCorrectTextAndHref()
        {
            var cut = RenderComponent<NewRaceSeries>();

            var cancelButton = cut.Find("a.mud-button");
            Assert.Equal("Cancel", cancelButton.TextContent);
            Assert.Equal("seriesresults", cancelButton.GetAttribute("href"));
        }

        [Fact]
        public void MudSelectItemsRenderedForRacesWithOneBoatType()
        {
            var cut = RenderComponent<NewRaceSeries>();

            var raceService = Services.GetService<RaceService>();
            int expectedItemCount = raceService.GetAllRaces().Count(race => cut.Instance.TestHasOneBoatType(race));

            var mudSelect = cut.FindComponent<MudSelect<Races>>();
            var mudSelectItems = mudSelect.FindComponents<MudSelectItem<Races>>();

            Assert.Equal(expectedItemCount, mudSelectItems.Count);
        }

        //Error
        //[Fact]
        //public async Task CreateSeriesMethodWorksCorrectly()
        //{
        //    var cut = RenderComponent<NewRaceSeries>();

        //    var resultService = Services.GetService<ResultService>();
        //    var seriesName = "Test Series";
        //    cut.Instance.TestSeries.Name = seriesName;
        //    cut.Instance.TestSelectedRaces.AddRange(new List<Races> { /* Add some test races here */ });

        //    await cut.InvokeAsync(() => cut.Instance.TestCreateSeries());

        //    var createdSeries = resultService.GetSeriesByName(seriesName);
        //    Assert.NotNull(createdSeries);
        //    Assert.Equal(seriesName, createdSeries.Name);
        //    Assert.Equal(cut.Instance.TestSelectedRaces.Count, createdSeries.Races.Count);
        //}



    }
}
