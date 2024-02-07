

namespace UsersTests
{
    public class UserControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        public readonly HttpClient _user;
        public UserControllerIntegrationTests(TestingWebAppFactory<Program> factory)
        {
            _user = factory.CreateClient();
        }
        [Fact]
        public async Task Create_WhenCalled_ReturnsCreateForm()
        {
            var response = await _user.GetAsync("/Home/Create");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Пожалуйста, введите данные нового пользователя", responseString);
        }
    }

}