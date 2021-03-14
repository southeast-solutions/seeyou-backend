using System.Threading.Tasks;
using Domain.Request.Auth;
using Domain.Response.Auth;

namespace Domain.Contracts
{
    public interface IAuthService
    {
        Task<RegisterResponse> Register(RegisterRequest request);
        Task<LoginResponse> Login(LoginRequest request);
        Task<VerifyRegisterResponse> VerifyRegister(VerifyRegisterRequest request);
        Task<ResetPasswordResponse> ResetPassword(ResetPasswordRequest request);
        Task<ConfirmResetPasswordResponse> ConfirmResetPassword(ConfirmResetPasswordRequest request);
    }
}