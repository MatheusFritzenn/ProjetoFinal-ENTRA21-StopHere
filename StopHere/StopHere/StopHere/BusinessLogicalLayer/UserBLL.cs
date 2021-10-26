using BusinessLogicalLayer.Extensions;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Responses;
using BusinessLogicalLayer.Validations;
using DataInfrastructure;
using Entities;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BusinessLogicalLayer 
{
    public class UserBLL : IUserService
    {
        IMaps maps;
        public UserBLL(IMaps iMapsService)
        {
            maps = iMapsService;
        }

        public async Task<SingleResponse<User>> Disable(int id)
        {
            try
            {
                using (StopHereDBContext db = new StopHereDBContext())
                {
                    User user = await db.Users.FindAsync(id);
                    if (user == null)
                    {
                        return FactoryResponse.NotFoundSingleResponse<User>("Usuario não encontrada.");
                    }
                    user.Ativo = false;
                    await db.SaveChangesAsync();
                    return FactoryResponse.SuccessSingleResponse<User>(user, "Conta desativada.");

                }
            }
            catch (Exception ex)
            {
                return FactoryResponse.FailureSingleResponse<User>(ex);
            }
        }

        public async Task<SingleResponse<User>> Authenticate(AuthenticateRequest request)
        {
            try
            {
                using (StopHereDBContext db = new StopHereDBContext())
                {
                    request.Senha = CommonExtension.HashPassword(request.Senha);
                    User user = await db.Users.FirstOrDefaultAsync(u => u.Email == request.Email && u.Senha == request.Senha);
                    if (user == null)
                    {
                        return FactoryResponse.FailureSingleResponse<User>("Usuário e/ou senha inválidos.");
                    }
                    if (!user.Ativo)
                    {
                        return FactoryResponse.FailureSingleResponse<User>("Usuário desativado");
                    }
                    return FactoryResponse.SuccessSingleResponse<User>(user);
                }
            }
            catch (Exception ex)
            {
                return FactoryResponse.FailureSingleResponse<User>(ex);
            }
        }


        public async Task<Response> CreateLegalPersonAsync(LegalPerson lp)
        {
            try
            {
                lp.Senha = CommonExtension.HashPassword(lp.Senha);
                lp.InscricaoEstadual = lp.InscricaoEstadual.ClearMask();
                lp.CNPJ = lp.CNPJ.ClearMask();
                lp.CEP = lp.CEP.ClearMask();
                lp.Telefone = lp.Telefone.ClearMask();
                lp.Numero = lp.Numero.ClearMask();
                ValidationResult result = new LegalPersonValidation(true).Validate(lp);

                Response response = CommonExtension.ToResponse(result);
                if (!response.Success)
                {
                    return response;
                }

                using (StopHereDBContext db = new StopHereDBContext())
                {
                    LegalPerson empresaCadastrada = await db.LegalPersons.FirstOrDefaultAsync(u => u.Email == lp.Email);
                    if (empresaCadastrada != null)
                    {
                        return FactoryResponse.FailureResponse("Usuário já cadastrado.");
                    }
                    lp.Ativo = true;
                    db.Users.Add(lp);
                    await db.SaveChangesAsync();
                    return FactoryResponse.SuccessResponse("Usuário cadastrado com sucesso.");
                }
            }
            catch (Exception ex)
            {
                return FactoryResponse.FailureResponse(ex);
            }
        }

        public async Task<Response> CreateNaturalPersonAsync(NaturalPerson np)
        {
            try
            {
                np.Senha = CommonExtension.HashPassword(np.Senha);
                np.CPF = np.CPF.ClearMask();
                np.Telefone = np.Telefone.ClearMask();
                np.Numero = np.Numero.ClearMask();
                np.CEP = np.CEP.ClearMask();
                ValidationResult result = new NaturalPersonValidation(true).Validate(np);

                Response response = CommonExtension.ToResponse(result);
                if (!response.Success)
                {
                    return response;
                }

                using (StopHereDBContext db = new StopHereDBContext())
                {
                    NaturalPerson pessoa = await db.NaturalPersons.FirstOrDefaultAsync(u => u.Email == np.Email);
                    if (pessoa != null)
                    {
                        return FactoryResponse.FailureResponse("Usuário já cadastrado.");
                    }
                    np.Ativo = true;
                    db.Users.Add(np);
                    await db.SaveChangesAsync();
                    return FactoryResponse.SuccessResponse("Usuário cadastrado com sucesso.");
                }
            }
            catch (Exception ex)
            {
                return FactoryResponse.FailureResponse(ex);
            }
        }

        public async Task<SingleResponse<LegalPerson>> GetLegalPersonByIdAsync(int userID)
        {
            try
            {
                using (StopHereDBContext db = new StopHereDBContext())
                {
                    LegalPerson legalPerson = await db.LegalPersons.FindAsync(userID);
                    if (legalPerson == null)
                    {
                        return FactoryResponse.NotFoundSingleResponse<LegalPerson>("Empresa não encontrada.");
                    }
                    return FactoryResponse.SuccessSingleResponse<LegalPerson>(legalPerson);
                }
            }
            catch (Exception ex)
            {
                return FactoryResponse.FailureSingleResponse<LegalPerson>(ex);
            }
        }

        public async Task<SingleResponse<NaturalPerson>> GetNaturalPersonByIdAsync(int userID)
        {
            try
            {
                using (StopHereDBContext db = new StopHereDBContext())
                {
                    NaturalPerson naturalPerson = await db.NaturalPersons.FindAsync(userID);
                    if (naturalPerson == null)
                    {
                        return FactoryResponse.NotFoundSingleResponse<NaturalPerson>();
                    }
                    return FactoryResponse.SuccessSingleResponse<NaturalPerson>(naturalPerson);
                }
            }
            catch (Exception ex)
            {
                return FactoryResponse.FailureSingleResponse<NaturalPerson>(ex);
            }
        }

        public async Task<Response> UpdateLegalPersonAsync(LegalPerson lp)
        {
            if (lp.Senha != null)
            {
                lp.Senha = CommonExtension.HashPassword(lp.Senha);
            }

            ValidationResult result = new LegalPersonValidation(false).Validate(lp);

            Response response = result.ToResponse();
            if (!response.Success)
            {
                return response;
            }

            try
            {
                using (StopHereDBContext db = new StopHereDBContext())
                {
                    LegalPerson legalPersonBanco = await db.LegalPersons.FindAsync(lp.ID);
                    legalPersonBanco.NomeFantasia = lp.NomeFantasia;
                    legalPersonBanco.RazaoSocial = lp.RazaoSocial;
                    legalPersonBanco.Telefone = lp.Telefone;
                    if (lp.Senha != null)
                    {
                        legalPersonBanco.Senha = lp.Senha;
                    }
                    legalPersonBanco.CEP = lp.CEP;
                    legalPersonBanco.Cidade = lp.Cidade;
                    legalPersonBanco.Bairro = lp.Bairro;
                    legalPersonBanco.Rua = lp.Rua;
                    legalPersonBanco.Numero = lp.Numero;
                    legalPersonBanco.Email = lp.Email;

                    await db.SaveChangesAsync();
                    return FactoryResponse.SuccessResponse("Empresa editada com sucesso.");
                }
            }
            catch (Exception ex)
            {
                return FactoryResponse.FailureResponse(ex);
            }
        }

        public async Task<Response> UpdateNaturalPersonAsync(NaturalPerson np)
        {
            if (np.Senha != null)
            {
                np.Senha = CommonExtension.HashPassword(np.Senha);

            }

            ValidationResult result = new NaturalPersonValidation(false).Validate(np);

            Response response = result.ToResponse();
            if (!response.Success)
            {
                return response;
            }

            try
            {
                using (StopHereDBContext db = new StopHereDBContext())
                {
                    NaturalPerson naturalPersonBanco = await db.NaturalPersons.FindAsync(np.ID);
                    naturalPersonBanco.Nome = np.Nome;
                    naturalPersonBanco.Telefone = np.Telefone;
                    if (np.Senha != null)
                    {
                        naturalPersonBanco.Senha = np.Senha;
                    }
                    naturalPersonBanco.CEP = np.CEP;
                    naturalPersonBanco.UF = np.UF;
                    naturalPersonBanco.Cidade = np.Cidade;
                    naturalPersonBanco.Bairro = np.Bairro;
                    naturalPersonBanco.Rua = np.Rua;
                    naturalPersonBanco.Numero = np.Numero;
                    naturalPersonBanco.Email = np.Email;
                    await db.SaveChangesAsync();
                    return FactoryResponse.SuccessResponse("Usuário editado com sucesso.");
                }
            }
            catch (Exception ex)
            {
                return FactoryResponse.FailureResponse(ex);
            }
        }
    }
}
