using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace SailViewTest
{
    public class LoginPageTest : TestContext
    {
        private readonly MockAuthenticationStateProvider _authStateProvider;
        public LoginPageTest()
        {
            _authStateProvider = new MockAuthenticationStateProvider();
            Services.AddSingleton<AuthenticationStateProvider>(serviceProvider => _authStateProvider);
        }

        [Fact]
        public async Task LoginForm_Submit_ValidCredentials_LoginSuccess()
        {
            //// Arrange
            //var loginPage = RenderComponent<LoginPage>();
            //var loginForm = loginPage.FindComponent<LoginForm>();
            //var loginButton = loginForm.Find("button");
            //var emailInput = loginForm.Find("input[type=email]");
            //var passwordInput = loginForm.Find("input[type=password]");

            //// Act
            //emailInput.Input("");
        }
    }
}
