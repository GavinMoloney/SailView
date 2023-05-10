using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using SailView.Data;
using SailView.Services;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace SailViewTest
{
    public class MockBoatService : BoatService
    {
        public MockBoatService(IDbContextFactory<SailAppDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }

    public class MockRaceService : RaceService
    {

        public MockRaceService(IDbContextFactory<SailAppDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }

    public class MockDialogService : IDialogService
    {
        public event Action<IDialogReference> OnDialogInstanceAdded;
        public event Action<IDialogReference, DialogResult> OnDialogCloseRequested;

        public void Close(DialogReference dialog)
        {
            throw new NotImplementedException();
        }

        public void Close(DialogReference dialog, DialogResult result)
        {
            throw new NotImplementedException();
        }

        public IDialogReference CreateReference()
        {
            throw new NotImplementedException();
        }

        public IDialogReference Show<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TComponent>() where TComponent : ComponentBase
        {
            throw new NotImplementedException();
        }

        public IDialogReference Show<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TComponent>(string title) where TComponent : ComponentBase
        {
            throw new NotImplementedException();
        }

        public IDialogReference Show<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TComponent>(string title, DialogOptions options) where TComponent : ComponentBase
        {
            throw new NotImplementedException();
        }

        public IDialogReference Show<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TComponent>(string title, DialogParameters parameters) where TComponent : ComponentBase
        {
            throw new NotImplementedException();
        }

        public IDialogReference Show<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TComponent>(string title, DialogParameters parameters, DialogOptions options) where TComponent : ComponentBase
        {
            throw new NotImplementedException();
        }

        public IDialogReference Show([DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] Type component)
        {
            throw new NotImplementedException();
        }

        public IDialogReference Show([DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] Type component, string title)
        {
            throw new NotImplementedException();
        }

        public IDialogReference Show([DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] Type component, string title, DialogOptions options)
        {
            throw new NotImplementedException();
        }

        public IDialogReference Show([DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] Type component, string title, DialogParameters parameters)
        {
            throw new NotImplementedException();
        }

        public IDialogReference Show([DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] Type component, string title, DialogParameters parameters, DialogOptions options)
        {
            throw new NotImplementedException();
        }

        public Task<IDialogReference> ShowAsync<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TComponent>() where TComponent : ComponentBase
        {
            throw new NotImplementedException();
        }

        public Task<IDialogReference> ShowAsync<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TComponent>(string title) where TComponent : ComponentBase
        {
            throw new NotImplementedException();
        }

        public Task<IDialogReference> ShowAsync<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TComponent>(string title, DialogOptions options) where TComponent : ComponentBase
        {
            throw new NotImplementedException();
        }

        public Task<IDialogReference> ShowAsync<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TComponent>(string title, DialogParameters parameters) where TComponent : ComponentBase
        {
            throw new NotImplementedException();
        }

        public Task<IDialogReference> ShowAsync<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TComponent>(string title, DialogParameters parameters, DialogOptions options) where TComponent : ComponentBase
        {
            throw new NotImplementedException();
        }

        public Task<IDialogReference> ShowAsync([DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] Type component)
        {
            throw new NotImplementedException();
        }

        public Task<IDialogReference> ShowAsync([DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] Type component, string title)
        {
            throw new NotImplementedException();
        }

        public Task<IDialogReference> ShowAsync([DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] Type component, string title, DialogOptions options)
        {
            throw new NotImplementedException();
        }

        public Task<IDialogReference> ShowAsync([DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] Type component, string title, DialogParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task<IDialogReference> ShowAsync([DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] Type component, string title, DialogParameters parameters, DialogOptions options)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> ShowMessageBox(string title, string message, string yesText = "OK", string noText = null, string cancelText = null, DialogOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> ShowMessageBox(string title, MarkupString markupMessage, string yesText = "OK", string noText = null, string cancelText = null, DialogOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> ShowMessageBox(MessageBoxOptions messageBoxOptions, DialogOptions options = null)
        {
            throw new NotImplementedException();
        }
    }

    public class MockSnackbar : ISnackbar
    {
        // Implement the methods from the ISnackbar or leave them empty if not needed for testing
        public IEnumerable<Snackbar> ShownSnackbars => throw new NotImplementedException();

        public SnackbarConfiguration Configuration => throw new NotImplementedException();

        public event Action OnSnackbarsUpdated;

        public Snackbar Add(string message, Severity severity = Severity.Normal, Action<SnackbarOptions> configure = null, string key = "")
        {
            throw new NotImplementedException();
        }

        public Snackbar Add(RenderFragment message, Severity severity = Severity.Normal, Action<SnackbarOptions> configure = null, string key = "")
        {
            throw new NotImplementedException();
        }

        public Snackbar Add<T>(Dictionary<string, object> componentParameters = null, Severity severity = Severity.Normal, Action<SnackbarOptions> configure = null, string key = "") where T : IComponent
        {
            throw new NotImplementedException();
        }

        public Snackbar AddNew(Severity severity, string message, Action<SnackbarOptions> configure)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Remove(Snackbar snackbar)
        {
            throw new NotImplementedException();
        }
    }

    public class MockNavigationManager : NavigationManager
    {
        public void SetUri(string uri)
        {
            Uri = uri;
        }

        public void SetBaseUri(string baseUri)
        {
            BaseUri = baseUri;
        }


        protected override void NavigateToCore(string uri, bool forceLoad)
        {

        }
    }

    public class MockAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal _user;

        public MockAuthenticationStateProvider()
        {
            SetAnonymousUser();
        }

        public void SetAuthenticatedUser(string userName)
        {
            var identity = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, userName)
        }, "mockAuthenticationType");
            _user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public void SetAnonymousUser()
        {
            _user = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(_user));
        }
    }
}
