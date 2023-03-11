using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinnerApp.Application.Dtos.Authentication
{ 
    public record AuthenticationResult(
    Guid Id,
    string FirstName,
    string LastName,
    string Password,
    string Email,
    string Token
       );
}
