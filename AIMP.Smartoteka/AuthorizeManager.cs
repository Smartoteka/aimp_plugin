namespace AIMP.Smartoteka
{
    using System;
    using System.Threading.Tasks;
    using global::Smartoteka.API.Clients;
    using global::Smartoteka.API.DTOs;

    public class AuthorizeManager
    {
        private static RegisterRequest ToRegisterRequest(LoginRequest loginRequest)
        {
            return new RegisterRequest()
            {
                Email = loginRequest.Email,
                ExtId = loginRequest.ExtId,
                Login = loginRequest.Login,
                ProductType = loginRequest.ProductType,
                Version = loginRequest.Version
            };
        }

        public static async Task<Guid?> getUUID(SmartotekaAPIClient smartotekaApiClient, string compUid, string version)
        {
            var loginRequest = new LoginRequest()
            {
                Email = compUid + "@free.ru",
                Login = compUid,
                ExtId = compUid,
                ProductType = ProductType.AIMPExt,
                Version = version
            };

            var loginResponse = await smartotekaApiClient.LoginAsync(loginRequest);

            if (loginResponse.IsSuccess)
            {
                Guid.TryParse(loginResponse.Result + "", out var registerUUID);

                return registerUUID;
            }

            if (loginResponse.DisplayMessage.Contains("User not found"))
            {
                var registerRequest = ToRegisterRequest(loginRequest);

                var registerResponse = await smartotekaApiClient.RegisterAsync(registerRequest);

                if (registerResponse.IsSuccess)
                {
                    Guid.TryParse(registerResponse.Result + "", out var registerUUID);

                    return registerUUID;
                }
            }

            return null;
        }
    }
}