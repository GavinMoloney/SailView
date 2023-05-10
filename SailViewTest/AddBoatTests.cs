using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using SailView.Data;
using SailView.Pages;
using SailView.Services;

namespace SailViewTest
{
    public class AddBoatTests : TestContext
    {


        public AddBoatTests()
        {
            // Register MudBlazor services
            Services.AddMudServices();
            //Services.AddSingleton(new NavigationManagerMock());

            // Register in-memory database context
            Services.AddDbContextFactory<SailAppDbContext>();

            // Register boat service
            Services.AddSingleton<BoatService>();
            JSInterop.SetupVoid("mudPopover.connect", _ => true);
            JSInterop.SetupVoid("mudKeyInterceptor.connect", _ => true);

        }

        [Fact]
        public void RendersAddBoatComponentCorrectly()
        {
            // Arrange
            var cut = RenderComponent<AddBoats>();

            // Assert
            cut.HasComponent<AddBoats>();
            cut.Find("h1").MarkupMatches("<h1>Add Boat to Database</h1>");
        }

        //error
        //[Fact]
        //public void SubmitFormWithValidBoatDetails()
        //{
        //    // Arrange
        //    var cut = RenderComponent<AddBoats>();
        //    var boatService = Services.GetRequiredService<BoatService>();
        //    JSInterop.SetupVoid("mudPopover.connect", _ => true);

        //    // Act
        //    cut.FindComponents<MudTextField<string>>().First(mudTextField => mudTextField.Instance.Label == "Boat Name").Instance.Value = "Test Boat";
        //    cut.FindComponents<MudTextField<string>>().First(mudTextField => mudTextField.Instance.Label == "Sail Number").Instance.Value = "12345";
        //    cut.Find("div.mud-select").Click();
        //    cut.FindAll("div.mud-list-item").First().Click();
        //    var submitButton = cut.Find("button[type=submit]");
        //    submitButton.ClickAsync(new MouseEventArgs());

        //    // Assert
        //    Assert.True(boatService.GetAllBoats().Any(b => b.BoatName == "Test Boat" && b.SailNumber == "12345"));
        //}

        [Fact]
        public void AddComponentTextFieldBindings()
        {
            // Arrange
            var cut = RenderComponent<AddBoats>();

            // Act
            var textFields = cut.FindComponents<MudTextField<string>>().ToList();
            var boatNameTextField = textFields.First(x => x.Instance.Label == "Boat Name");
            var sailNumberTextField = textFields.First(x => x.Instance.Label == "Sail Number");
            //var boatTypeSelect = cut.FindComponent<MudSelect<string>>(x => x.Instance.Label == "Boat Class");


            // Assert
            Assert.Null(boatNameTextField.Instance.Value);
            Assert.Null(sailNumberTextField.Instance.Value);
            // Assert.Null(boatTypeSelect.Instance.Value); 
        }

        //Error
        //[Fact]
        //public async Task AddBoatComponentSubmitValidForm()
        //{
        //    // Arrange
        //    var navigationManager = new MockNavigationManager();
        //    var boatService = new BoatService();
        //    var snackbar = new MockSnackbar();
        //    Services.AddSingleton<NavigationManager>(navigationManager);
        //    Services.AddSingleton<ISnackbar>(snackbar);

        //    // Act
        //    var cut = RenderComponent<AddBoats>();
        //    var textFields = cut.FindComponents<MudTextField<string>>().ToList();
        //    var boatNameTextField = textFields.First(x => x.Instance.Label == "Boat Name");
        //    var sailNumberTextField = textFields.First(x => x.Instance.Label == "Sail Number");
        //    var boatTypeSelect = cut.FindComponents<MudSelect<string>>().First(x => x.Instance.Label == "Boat Class");

        //    boatNameTextField.Instance.Value = "Test Boat";
        //    sailNumberTextField.Instance.Value = "1234";
        //    boatTypeSelect.Instance.Value = "Sloop";

        //    await cut.InvokeAsync(() => cut.Instance.HandleSubmit(new EditContext(new BoatDetails())));

        //    // Assert
        //    Assert.Single(boatService.GetAllBoats());
        //    Assert.Equal("Test Boat", boatService.GetAllBoats().First().BoatName);
        //    Assert.Equal("1234", boatService.GetAllBoats().First().SailNumber);
        //    Assert.Equal("Sloop", boatService.GetAllBoats().First().BoatType);
        //    Assert.Equal("/Boats", navigationManager.Uri);
        //    //Assert.Contains(snackbar.Messages, m => m.Message == "Boat is added successfully" && m.Severity == Severity.Success);
        //}

        //Error
        //[Fact]
        //public void AddBoatComponentCancelNavigation()
        //{
        //    var navManagerMock = new MockNavigationManager();
        //    Services.AddSingleton<NavigationManager>(navManagerMock);

        //    var cut = RenderComponent<AddBoats>();
        //    var cancelButton = cut.Find("button[mudbutton[href='Boats']]");

        //    // Act
        //    cancelButton.Click();

        //    // Assert
        //    Assert.Equal("Boats", navManagerMock.Uri);
        //}

        //[Fact]
        //public void SubmitFormWithValidBoatDetails()
        //{
        //    // Arrange
        //    var cut = RenderComponent<AddBoats>();
        //    var boatService = Services.GetRequiredService<BoatService>();
        //    JSInterop.SetupVoid("mudPopover.connect", _ => true);

        //    // Act
        //    //cut.Find("@bind-Value=\"@boatDetails.BoatName\"").Change("Test Boat");
        //    cut.Find("input[label=\"Boat Name\"]").Change("Test Boat");
        //    cut.Find("@bind-Value=\"@boatDetails.SailNumber\"").Change("12345");
        //    cut.Find("div.mud-select").Click();
        //    cut.FindAll("div.mud-list-item").First().Click();
        //    cut.Find("button[type=submit]").Click();

        //    // Assert
        //    Assert.True(boatService.GetAllBoats().Any(b => b.BoatName == "Test Boat" && b.SailNumber == "12345"));
        //}


        //[Fact]
        //public void SubmitFormWithInvalidSailNumber()
        //{
        //    // Arrange
        //    var cut = RenderComponent<AddBoats>();
        //    var boatService = Services.GetRequiredService<BoatService>();

        //    // Add a boat with the same sail number to simulate a non-unique sail number
        //    boatService.AddBoat(new BoatDetails { BoatName = "Existing Boat", SailNumber = "12345" });

        //    // Act
        //    cut.Find("#boatDetails_BoatName").Change("Test Boat");
        //    cut.Find("#boatDetails_SailNumber").Change("12345");
        //    cut.Find("div.mud-select").Click();
        //    cut.FindAll("div.mud-list-item").First().Click();
        //    cut.Find("button[type=submit]").Click();

        //    // Assert
        //    var sailNumberError = cut.Find("div.mud-text-danger");
        //    Assert.NotNull(sailNumberError);
        //    Assert.Equal("Sail Number must be unique", sailNumberError.TextContent.Trim());
        //}
    }
}
