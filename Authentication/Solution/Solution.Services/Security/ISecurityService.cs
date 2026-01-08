using ErrorOr;
using Solution.Domain.Models.Requests.Security;
using Solution.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Services.Security;

public interface ISecurityService
{
    Task<ErrorOr<TokenResponseModel>> LoginAsync(LoginRequestModel model);
    Task<ErrorOr<Success>> RegisterAsync(RegisterRequestModel model);
}

