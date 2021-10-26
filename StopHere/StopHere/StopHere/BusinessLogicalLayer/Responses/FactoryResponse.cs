using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Responses
{
    public class FactoryResponse
    {
        //
        //----->                                               *** Response ***
        //

        /// <summary>
        /// Instancia um objeto de resposta padronizado para informar que a operação foi realizada com sucesso.
        /// </summary>
        /// <returns>Retorna um objeto do tipo response com a propriedade success = true e uma mensagem padrão (Operação realizada com sucesso.) </returns>
        public static Response SuccessResponse()
        {
            Response response = new Response
            {
                Success = true,
                Message = "Operação realizada com sucesso."
            };
            return response;
        }
        /// <summary>
        /// Instancia um objeto de resposta padronizado para informar que a operação foi realizada com sucesso, aceita uma mensagem ao seu critério como parametro.
        /// </summary>
        /// <param name="message">Personalize sua mensagem de sucesso</param>
        /// <returns>Retorna um objeto do tipo response com a propriedade success = true , e a mensagem inserida no parametro.</returns>
        public static Response SuccessResponse(string message)
        {
            Response response = new Response
            {
                Success = true,
                Message = message
            };
            return response;
        }
        /// <summary>
        /// Instancia um objeto de resposta padronizado para informar que a operação não teve êxito, fracassou. 
        /// </summary>
        /// <returns>Retorna um objeto do tipo response com a propriedade success = false e uma mensagem padrão (Erro no banco de dados contate o administrador.)</returns>
        public static Response FailureResponse()
        {
            Response response = new Response
            {
                Success = false,
                Message = "Erro no banco de dados contate o administrador."
            };

            return response;
        }
        /// <summary>
        /// Instancia um objeto de resposta padronizado para informar que a operação não teve êxito, fracassou. 
        /// </summary>
        /// <param name="message">Personalize sua mensagem de falha</param>
        /// <returns>Retorna um objeto do tipo response com a propriedade success = false , e a mensagem inserida no parametro.</returns>
        public static Response FailureResponse(string message)
        {
            Response response = new Response
            {
                Success = false,
                Message = message
            };
            return response;
        }
        /// <summary>
        /// Instancia um objeto de resposta padronizado para informar que a operação não teve êxito, fracassou, contem detalhes do erro ocorrido.
        /// </summary>
        /// <param name="ex">Informe a exception</param>
        /// <returns>Retorna um objeto do tipo response com a propriedade success = false , a ExceptionError, a StackTrace e uma mensagem padrão (Erro no banco de dados contate o administrador).</returns>
        public static Response FailureResponse(Exception ex)
        {
            Response response = new Response();
            response.Success = false;
            response.ExceptionError = ex.Message;
            response.StackTrace = ex.StackTrace;
            response.Message = "Erro no banco de dados contate o administrador.";

            return response;
        }

        //
        //----->                                         *** SingleResponse ***                          
        //

        /// <summary>
        /// Instancia um objeto de resposta padronizado para informar que a operação foi realizada com sucesso, aceita um objeto como parametro.
        /// </summary>
        /// <typeparam name="T">Classe do objeto em uso.</typeparam>
        /// <param name="item">Objeto do mesmo tipo que o typeparam.</param>
        /// <returns>Retorna um objeto do tipo SingleResponse com a propriedade success = true , item = objeto inserido no parametro e mensagem = Operação realizada com sucesso.</returns>
        public static SingleResponse<T> SuccessSingleResponse<T>(T item)
        {
            SingleResponse<T> response = new SingleResponse<T>();
            response.Success = true;
            response.Message = "Operação realizada com sucesso.";
            response.Item = item;
            return response;
        }

        /// <summary>
        /// Instancia um objeto de resposta padronizado para informar que a operação foi realizada com sucesso, aceita um objeto e uma mensagem como parametro.
        /// </summary>
        /// <typeparam name="T">Classe do objeto em uso.</typeparam>
        /// <param name="item">>Objeto do mesmo tipo que o typeparam.</param>
        /// <param name="message">Personalize sua mensagem de sucesso.</param>
        /// <returns>Retorna um objeto do tipo SingleResponse com a propriedade success = true , item e mensagem inseridas como parametro.</returns>
        public static SingleResponse<T> SuccessSingleResponse<T>(T item, string message)
        {
            SingleResponse<T> response = new SingleResponse<T>();
            response.Success = true;
            response.Message = message;
            response.Item = item;
            return response;
        }
        /// <summary>
        /// Instancia um objeto de resposta padronizado para informar que a operação foi realizada sem êxito, fracassou, aceita uma mensagem como parametro.
        /// </summary>
        /// <typeparam name="T">Classe do objeto em uso.</typeparam>
        /// <param name="message">Personalize sua mensagem de falha.</param>
        /// <returns>Retorna um objeto do tipo SingleResponse com a propriedade success = false, item = null e a mensagem inserida como parametro.</returns>
        public static SingleResponse<T> FailureSingleResponse<T>(string message)
        {
            SingleResponse<T> response = new SingleResponse<T>();
            response.Success = false;
            response.Message = message;
            return response;
        }

        /// <summary>
        /// Instancia um objeto de resposta padronizado para informar que a operação foi realizada sem êxito, fracassou, aceita uma Exception como parametro.
        /// </summary>
        /// <typeparam name="T">Classe do objeto em uso.</typeparam>
        /// <param name="ex">Informe a Exception</param>
        /// <returns>Retorna um objeto do tipo SingleResponse com a propriedade success = false, item = null, ExceptionError, StackTrace e uma mensagem padrão (Erro no banco de dados contate o administrador).</returns>
        public static SingleResponse<T> FailureSingleResponse<T>(Exception ex)
        {
            SingleResponse<T> response = new SingleResponse<T>();
            response.Success = false;
            response.ExceptionError = ex.Message;
            response.StackTrace = ex.StackTrace;
            response.Message = "Erro no banco de dados contate o administrador.";
            return response;
        }
        /// <summary>
        /// Instancia um objeto de resposta padronizado para informar que a operação foi realizada sem êxito, fracassou.
        /// </summary>
        /// <typeparam name="T">Classe do objeto em uso.</typeparam>
        /// <returns>Retorna um objeto do tipo SingleResponse com a propriedade success = false, item = null, e uma mensagem padrão (Registro não encontrado).</returns>
        public static SingleResponse<T> NotFoundSingleResponse<T>()
        {
            SingleResponse<T> response = new SingleResponse<T>();
            response.Success = false;
            response.Message = "Registro não encontrado.";
            return response;
        }
        /// <summary>
        /// Instancia um objeto de resposta padronizado para informar que a operação foi realizada sem êxito, fracassou.
        /// </summary>
        /// <typeparam name="T">Classe do objeto em uso.</typeparam>
        /// <param name="message"></param>
        /// <returns>Retorna um objeto do tipo SingleResponse com a propriedade success = false, item = null, e a mensagem passada por parametro.</returns>
        public static SingleResponse<T> NotFoundSingleResponse<T>(string message)
        {
            SingleResponse<T> response = new SingleResponse<T>();
            response.Success = false;
            response.Message = message;
            return response;
        }

        //
        //----->                                           *** DataResponse ***
        //

        /// <summary>
        /// Instancia um objeto de resposta padronizado para informar que a operação foi realizada com sucesso, aceita uma lista de objetos como parametro.
        /// </summary>
        /// <typeparam name="T">Classe do objeto em uso.</typeparam>
        /// <param name="list">Lista de objetos do mesmo tipo que o typeparam.</param>
        /// <returns>Retorna um objeto do tipo DataResponse com a propriedade Success = true, Data = lista de objetos passados como parametro e Message = Operação realizada com sucesso.</returns>
        public static DataResponse<T> SuccessDataResponse<T>(List<T> list)
        {
            DataResponse<T> response = new DataResponse<T>();
            response.Success = true;
            response.Message = "Operação realizada com sucesso.";
            response.Data = list;
            return response;
        }
        /// <summary>
        /// Instancia um objeto de resposta padronizado para informar que a operação foi realizada com sucesso, aceita uma lista de objetos e uma mensagem de sucesso como parametro.
        /// </summary>
        /// <typeparam name="T">Classe do objeto em uso.</typeparam>
        /// <param name="list">Lista de objetos do mesmo tipo que o typeparam.</param>
        /// <param name="message">Personalize sua mensagem de sucesso.</param>
        /// <returns>Retorna um objeto do tipo DataResponse com a propriedade Success = true, Data = lista de objetos, e a mensagem passada por parametro.</returns>
        public static DataResponse<T> SuccessDataResponse<T>(List<T> list, string message)
        {
            DataResponse<T> response = new DataResponse<T>();
            response.Success = true;
            response.Message = message;
            response.Data = list;
            return response;
        }

        /// <summary>
        /// Instancia um objeto de resposta padronizado para informar que a operação foi realizada sem êxito, fracassou, aceita uma Exception como parametro.
        /// </summary>
        /// <typeparam name="T">Classe do objeto em uso.</typeparam>
        /// <param name="ex">Informe a Exception</param>
        /// <returns>Retorna um objeto do tipo DataResponse com a propriedade Success = false, Data = lista de objetos null, ExceptionError, StackTrace e uma mensagem padrão (Erro no banco de dados contate o administrador).</returns>
        public static DataResponse<T> FailureDataResponse<T>(Exception ex)
        {
            DataResponse<T> response = new DataResponse<T>();
            response.Success = false;
            response.ExceptionError = ex.Message;
            response.StackTrace = ex.StackTrace;
            response.Message = "Erro no banco de dados contate o administrador";
            response.Data = new List<T>();
            return response;
        }
        /// <summary>
        /// Instancia um objeto de resposta padronizado para informar que a operação foi realizada sem êxito, fracassou.
        /// </summary>
        /// <typeparam name="T">Classe do objeto em uso.</typeparam>
        /// <returns>Retorna um objeto do tipo DataResponse com a propriedade Success = false, Data = lista de objetos null, e uma mensagem padrão (Erro no banco de dados contate o administrador).</returns>
        public static DataResponse<T> FailureDataResponse<T>()
        {
            DataResponse<T> response = new DataResponse<T>();
            response.Success = false;
            response.Message = "Erro no banco de dados contate o administrador";
            response.Data = new List<T>();
            return response;
        }
        /// <summary>
        /// Instancia um objeto de resposta padronizado para informar que a operação foi realizada sem êxito, fracassou, aceita uma Exception e uma mensagem como parametro.
        /// </summary>
        /// <typeparam name="T">Classe do objeto em uso.</typeparam>
        /// <param name="ex">Informe a Exception</param>
        /// <param name="message">Personalize sua mensagem de falha.</param>
        /// <returns>Retorna um objeto do tipo DataResponse com a propriedade Success = false, Data = lista de objetos null, ExceptionError, StackTrace e a mensagem passada por parametro.</returns>
        public static DataResponse<T> FailureDataResponse<T>(Exception ex, string message)
        {
            DataResponse<T> response = new DataResponse<T>();
            response.Success = false;
            response.ExceptionError = ex.Message;
            response.StackTrace = ex.StackTrace;
            response.Message = message;
            response.Data = new List<T>();
            return response;
        }
        /// <summary>
        /// Instancia um objeto de resposta padronizado para informar que a operação foi realizada sem êxito, fracassou, aceita uma mensagem como parametro.
        /// </summary>
        /// <typeparam name="T">Classe do objeto em uso.</typeparam>
        /// <param name="message">Personalize sua mensagem de falha.</param>
        /// <returns></returns>
        public static DataResponse<T> FailureDataResponse<T>(string message)
        {
            DataResponse<T> response = new DataResponse<T>();
            response.Success = false;
            response.Message = message;
            response.Data = new List<T>();
            return response;
        }
        /// <summary>
        /// Instancia um objeto de resposta padronizado para informar que a operação foi realizada sem êxito, fracassou.
        /// </summary>
        /// <typeparam name="T">Classe do objeto em uso.</typeparam>
        /// <returns>Retorna uma lista de objetos do tipo DataResponse com a propriedade Success = false, Data = null, e uma mensagem padrão (Registro não encontrado).</returns>
        public static DataResponse<T> NotFoundDataResponse<T>()
        {
            DataResponse<T> response = new DataResponse<T>();
            response.Success = false;
            response.Message = "Registros não encontrados.";
            response.Data = new List<T>();
            return response;
        }
    }
}

