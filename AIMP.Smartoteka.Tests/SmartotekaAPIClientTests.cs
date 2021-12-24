using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AIMP.Smartoteka.Tests
{
    using System;
    using System.Threading.Tasks;
    using global::Smartoteka.API.Clients;
    using global::Smartoteka.API.DTOs;

    [TestClass]
    public class SmartotekaAPIClientTests
    {
        private string _baseUrl = "https://localhost:44383/";
        private SmartotekaAPIClient SmartotekaApiClient => new SmartotekaAPIClient(_baseUrl);

        [TestMethod]
        public async Task GetMessagesAsyncByDefaultTest()
        {
            var result = await SmartotekaApiClient.GetMessagesAsync(Guid.Empty, "", 0);

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual("User not found", result.DisplayMessage);
        }

        [TestMethod]
        public async Task RegisterAsyncTest()
        {
            var guid = Guid.NewGuid();

            var registerRequest = new RegisterRequest()
            {
                Email = guid + "email@free.ru",
                Login = guid + "free",
                ExtId = guid + "test",
                ProductType = ProductType.AIMPExt,
                Version = "0.1.0"
            };

            var result = await SmartotekaApiClient.RegisterAsync(registerRequest);

            Assert.IsTrue(result.IsSuccess);

            Assert.IsTrue(Guid.TryParse(result.Result + "", out var requestGuid), "Should get guid");
        }

        [TestMethod]
        public async Task LoginAsyncTest()
        {
            var guid = Guid.NewGuid();

            var registerRequest = new RegisterRequest()
            {
                Email = guid + "email@free.ru",
                Login = guid + "free",
                ExtId = guid + "test",
                ProductType = ProductType.AIMPExt,
                Version = "0.1.0"
            };


            var registerResult = await SmartotekaApiClient.RegisterAsync(registerRequest);

            Assert.IsTrue(registerResult.IsSuccess);
            Guid.TryParse(registerResult.Result + "", out var registerGuid);

            var loginRequest = new LoginRequest()
            {
                Email = guid + "email@free.ru",
                Login = guid + "free",
                ExtId = guid + "test",
                ProductType = ProductType.AIMPExt,
                Version = "0.1.0"
            };

            var loginResult = await SmartotekaApiClient.LoginAsync(loginRequest);

            Assert.IsTrue(loginResult.IsSuccess);
            Assert.IsTrue(Guid.TryParse(loginResult.Result + "", out var loginGuid), "Should get guid");

            Assert.AreEqual(registerGuid, loginGuid, "Register and login should return equal guid");
        }

        [TestMethod]
        public async Task GetMessagesAsyncTest()
        {
            var guid = Guid.NewGuid();

            var registerRequest = new RegisterRequest()
            {
                Email = guid + "email@free.ru",
                Login = guid + "free",
                ExtId = guid + "test",
                ProductType = ProductType.AIMPExt,
                Version = "0.1.0"
            };


            var registerResult = await SmartotekaApiClient.RegisterAsync(registerRequest);

            Assert.IsTrue(registerResult.IsSuccess);
            Guid.TryParse(registerResult.Result + "", out var registerGuid);

            
            var loginResult = await SmartotekaApiClient.GetMessagesAsync(registerGuid, registerRequest.ExtId, (int)registerRequest.ProductType);

            Assert.IsTrue(loginResult.IsSuccess);
            Assert.IsTrue(string.IsNullOrEmpty(loginResult.DisplayMessage));
        }
    }
}