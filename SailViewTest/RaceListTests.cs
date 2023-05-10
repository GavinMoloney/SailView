using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using SailView.Data;
using SailView.Data.Models;
using SailView.Pages;
using SailView.Services;

namespace SailViewTest
{
    public class RaceListTests : TestContext
    {
        public RaceListTests()
        {
            // Register MudBlazor services
            Services.AddMudServices();

            // Register in-memory database context
            Services.AddDbContextFactory<SailAppDbContext>();

            // Register boat service
            Services.AddSingleton<BoatService>();
            Services.AddSingleton<RaceService>();
            Services.AddSingleton<ResultService>();


            // Register other services
            // Services.AddSingleton<IJSRuntime>(new Bunit.JSInterop.BunitJSInterop());
            Services.AddSingleton<ExportService>();

            // Set up JSInterop
            JSInterop.SetupVoid("mudPopover.connect", _ => true);
            JSInterop.SetupVoid("mudKeyInterceptor.connect", _ => true);
            JSInterop.SetupVoid("saveAsFile", _ => true);


        }
        [Fact]
        public void ComponentRendersCorrectly()
        {
            // Arrange
            var cut = RenderComponent<RaceList>();

            // Assert
            cut.Find("h1").TextContent.MarkupMatches("Individual One Design Races");
        }

        [Fact]
        public void FilterFunc_WithMatchingSearchString_ReturnsTrue()
        {
            var searchString = "";
            var race = new Races
            {
                Id = 11,
                RaceId = "Sat 8 / 4 / 23 1720 R2"

            };
            var raceList = new RaceList();

            bool result = raceList.FilterFunc(race, searchString);

            Assert.True(result);
        }

        [Fact]
        public void CalculatePosition_WithValidBoatAndRace_ReturnsCorrectPosition()
        {
            var boat1 = new BoatRaces { BoatId = 48, Position = 4 };
            var boat2 = new BoatRaces { BoatId = 51, Position = 3 };
            var race = new Races
            {
                Id = 15,
                BoatRaces = new List<BoatRaces> { boat1, boat2 }
            };
            var raceList = new RaceList();

            int position1 = raceList.CalculatePosition(boat1, race);
            int position2 = raceList.CalculatePosition(boat2, race);

            Assert.Equal(1, position1);
            Assert.Equal(2, position2);
        }

        [Fact]
        public void RaceList_ShouldRenderRaceTable()
        {
            //RaceListTests();
            var raceList = RenderComponent<RaceList>();
            var table = raceList.Find("table");
            Assert.NotNull(table);
        }

        [Fact]
        public void RaceList_ShouldRenderRaceColumns()
        {
            var raceList = RenderComponent<RaceList>();
            var raceColumns = raceList.FindAll("th");
            Assert.Equal(4, raceColumns.Count);
        }

        [Fact]
        public void RaceList_ShouldRenderRaceRows()
        {
            var raceList = RenderComponent<RaceList>();

            var raceRows = raceList.FindAll("tr");
            Assert.Equal(1, raceRows.Count);
        }

        //[Fact]
        //public void FilterFunc1_FilterRaceEntries()
        //{
        //    var races = GetSampleRaces();
        //    var searchString = "SampleRace2";
        //    var cut = RenderComponent<RaceList>(parameters => parameters
        //        .Add(p => p.BoatRaces, races)
        //    );
        //    var table = cut.FindComponent<MudTable<Races>>();

        //    // Act
        //    table.SetParametersAndRender(parameters => parameters
        //        .Add("Filter", new Func<Races, bool>(r => r.RaceId.Contains(searchString)))
        //    );

        //    // Assert
        //    Assert.Single(table.Instance.RowsData, row => row.GetPropertyValue("RaceName").ToString().Contains(searchString));
        //}


        //private IQueryable<Races> GetSampleRaces()
        //{
        //    var options = new DbContextOptionsBuilder<SailAppDbContext>()
        //        .UseInMemoryDatabase(databaseName: "TestDatabase")
        //        .Options;

        //    using var context = new SailAppDbContext(options);
        //    context.BoatRace.Add(new BoatRaces { RaceId = 1, FinishingStatus = "Finished" });
        //    context.BoatRace.Add(new BoatRaces { RaceId = 2, FinishingStatus = "Finished" });
        //    context.SaveChanges();

        //    return (IQueryable<Races>)context.BoatRace;
        //}
    }
}
