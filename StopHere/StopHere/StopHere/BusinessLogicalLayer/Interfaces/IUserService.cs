using BusinessLogicalLayer.Responses;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Interfaces
{
    public interface IUserService
    {
        Task<Response> CreateNaturalPersonAsync(NaturalPerson np);
        Task<Response> UpdateNaturalPersonAsync(NaturalPerson np);
        Task<SingleResponse<NaturalPerson>> GetNaturalPersonByIdAsync(int userID);

        Task<Response> CreateLegalPersonAsync(LegalPerson lp);
        Task<Response> UpdateLegalPersonAsync(LegalPerson lp);
        Task<SingleResponse<LegalPerson>> GetLegalPersonByIdAsync(int userID);

        Task<SingleResponse<User>> Authenticate(AuthenticateRequest request);

        Task<SingleResponse<User>> Disable(int id);


    }
}
