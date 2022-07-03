using HRManagement.Application.Models;
using System.Threading.Tasks;

namespace HRManagement.Application.Contracts.Identity
{
	public interface IAuthenticationService
	{
		Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
	}
}
