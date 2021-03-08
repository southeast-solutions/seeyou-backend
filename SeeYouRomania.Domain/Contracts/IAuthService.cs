using System.Threading.Tasks;
using Domain.Request;
using Domain.Request.Auth;
using Domain.Response;

namespace Domain.Contracts
{
    public interface IAuthService
    {
        Task<RegisterResponse> Register(RegisterRequest request);
        Task<LoginResponse> Login(LoginRequest request);
        Task<VerifyRegisterResponse> VerifyRegister(VerifyRegisterRequest request);
        Task<ResetPasswordResponse> ResetPassword(ResetPasswordRequest request);
        Task<ConfirmResetPasswordResponse> ConfirmResetPassword(ConfirmResetPasswordRequest request);
        Task DeleteUser(DeleteAuthUserRequest request);
    }
}