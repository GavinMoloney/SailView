using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using SailView.Data;
using SailView.Pages;
using SailView.Services;

namespace SailViewTest
{
    public class AddIndividualOneDesignRaceTests : TestContext
    {
        public AddIndividualOneDesignRaceTests()
        {
            // Register MudBlazor services
            Services.AddMudServices();

            // Register in-memory database context
            Services.AddDbContextFactory<SailAppDbContext>();

            // Register boat service
            Services.AddSingleton<BoatService>();
            Services.AddSingleton<RaceService>();
            //Services.AddSingleton<RaceService>(new MockRaceService());
            Services.AddSingleton<IDialogService>(new MockDialogService());
            Services.AddSingleton<ISnackbar>(new MockSnackbar());
            Services.AddSingleton<NavigationManager>(new MockNavigationManager());
            JSInterop.SetupVoid("mudPopover.connect", _ => true);
            JSInterop.SetupVoid("mudKeyInterceptor.connect", _ => true);
        }

        [Fact]
        public void NewRaceComponentRendersCorrectly()
        {
            // Arrange
            var cut = RenderComponent<NewRace>();

            // Assert
            cut.Find("h1").TextContent.MarkupMatches("New One Design Race");
        }

        [Fact]
        public void NewRaceComponentHasButtons()
        {
            // Arrange
            var cut = RenderComponent<NewRace>();

            var buttons = cut.FindAll("button");
            Assert.Equal(8, buttons.Count);
        }

        [Fact]
        public void RaceComponentInitialTextFieldBindings()
        {
            var cut = RenderComponent<NewRace>();

            var textField = cut.FindComponent<MudTextField<string>>();
            Assert.Null(textField.Instance.Value);
        }
    }



}
