using Mango.Web.Models; // Importing the Models namespace from the Mango.Web project
using Mango.Web.Service.IService; // Importing the IService namespace from the Mango.Web.Service project
using Microsoft.AspNetCore.Mvc.ModelBinding; // Importing the ModelBinding namespace from ASP.NET Core MVC
using Newtonsoft.Json; // Importing the Json namespace from Newtonsoft for JSON serialization and deserialization
using System; // Importing the System namespace for basic functionalities
using System.Net;
using System.Net.Http.Json; // Importing the Json namespace from System.Net.Http for JSON-related HTTP functionalities
using System.Text; // Importing the Text namespace for text encoding functionalities
using static Mango.Web.Utility.SD; // Importing static members from the SD class in Mango.Web.Utility namespace

namespace Mango.Web.Service // Defining the namespace for the service
{
    public class BaseService : IBaseService // Defining the BaseService class that implements the IBaseService interface
    {
        private readonly IHttpClientFactory _httpClientFactory; // Declaring a private readonly field for IHttpClientFactory

        public BaseService(IHttpClientFactory httpClientFactory) // Constructor for BaseService class
        {
            _httpClientFactory = httpClientFactory; // Initializing the _httpClientFactory field with the provided IHttpClientFactory instance
        }

        public async Task<ResponceDTOs?> SendAsync(RequestDTOs requestDTOs) // Asynchronous method to send an HTTP request
        {
            try // Start of try block to catch exceptions
            {
                HttpClient client = _httpClientFactory.CreateClient("MangoAPI"); // Creating an HttpClient instance using the IHttpClientFactory
                HttpRequestMessage message = new(); // Creating a new HttpRequestMessage instance
                message.Headers.Add("Accept", "application/json"); // Adding an Accept header to the request to accept JSON responses
                message.RequestUri = new Uri(requestDTOs.Url); // Setting the request URI from the RequestDTOs object

                if (requestDTOs.Data != null) // Checking if there is data to be sent in the request
                {
                    // Serializing the data to JSON and setting it as the content of the request
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDTOs.Data), Encoding.UTF8, "application/json");
                }

                HttpResponseMessage? apiResponce = null; // Declaring a variable to hold the HTTP response


                switch (requestDTOs.ApiType)
                {
                    case ApiType.Post:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.Delete:
                        message.Method = HttpMethod.Delete;
                        break;
                    case ApiType.Put:
                        message.Method = HttpMethod.Put;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                apiResponce = await client.SendAsync(message);

                switch (apiResponce.StatusCode) // Switch statement to handle different HTTP status codes
                {
                    #region HttpStatusCode // Region for HTTP status code handling
                   
                    #endregion // End of region for HTTP status code handling
                    #region HttpStatusCode1
                   
                    case System.Net.HttpStatusCode.BadRequest:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Bad Request"
                        };
                    case System.Net.HttpStatusCode.Unauthorized:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Unauthorized"
                        };
                    case System.Net.HttpStatusCode.PaymentRequired:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Payment Required"
                        };
                    case System.Net.HttpStatusCode.Forbidden:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Forbidden"
                        };
                    case System.Net.HttpStatusCode.NotFound:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Not Found"
                        };
                    case System.Net.HttpStatusCode.MethodNotAllowed:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Method Not Allowed"
                        };
                    case System.Net.HttpStatusCode.NotAcceptable:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Not Acceptable"
                        };
                    case System.Net.HttpStatusCode.ProxyAuthenticationRequired:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Proxy Authentication Required"
                        };
                    case System.Net.HttpStatusCode.RequestTimeout:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Request Timeout"
                        };
                    case System.Net.HttpStatusCode.Conflict:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Conflict"
                        };
                    case System.Net.HttpStatusCode.Gone:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Gone"
                        };
                    case System.Net.HttpStatusCode.LengthRequired:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Length Required"
                        };
                    case System.Net.HttpStatusCode.PreconditionFailed:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Precondition Failed"
                        };
                    case System.Net.HttpStatusCode.RequestEntityTooLarge:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Request Entity Too Large"
                        };
                    case System.Net.HttpStatusCode.RequestUriTooLong:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Request-URI Too Long"
                        };
                    case System.Net.HttpStatusCode.UnsupportedMediaType:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Unsupported Media Type"
                        };
                    case System.Net.HttpStatusCode.RequestedRangeNotSatisfiable:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Requested Range Not Satisfiable"
                        };
                    case System.Net.HttpStatusCode.ExpectationFailed:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Expectation Failed"
                        };
                    case System.Net.HttpStatusCode.MisdirectedRequest:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Misdirected Request"
                        };
                    case System.Net.HttpStatusCode.UnprocessableEntity:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Unprocessable Entity"
                        };
                    case System.Net.HttpStatusCode.Locked:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Locked"
                        };
                    case System.Net.HttpStatusCode.FailedDependency:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Failed Dependency"
                        };
                    case System.Net.HttpStatusCode.UpgradeRequired:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Upgrade Required"
                        };
                    case System.Net.HttpStatusCode.PreconditionRequired:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Precondition Required"
                        };
                    case System.Net.HttpStatusCode.TooManyRequests:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Too Many Requests"
                        };
                    case System.Net.HttpStatusCode.RequestHeaderFieldsTooLarge:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Request Header Fields Too Large"
                        };
                    case System.Net.HttpStatusCode.UnavailableForLegalReasons:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Unavailable For Legal Reasons"
                        };
                    case System.Net.HttpStatusCode.InternalServerError:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Internal Server Error"
                        };
                    case System.Net.HttpStatusCode.NotImplemented:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Not Implemented"
                        };
                    case System.Net.HttpStatusCode.BadGateway:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Bad Gateway"
                        };
                    case System.Net.HttpStatusCode.ServiceUnavailable:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Service Unavailable"
                        };
                    case System.Net.HttpStatusCode.GatewayTimeout:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Gateway Timeout"
                        };
                    case System.Net.HttpStatusCode.HttpVersionNotSupported:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "HTTP Version Not Supported"
                        };
                    case System.Net.HttpStatusCode.VariantAlsoNegotiates:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Variant Also Negotiates"
                        };
                    case System.Net.HttpStatusCode.InsufficientStorage:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Insufficient Storage"
                        };
                    case System.Net.HttpStatusCode.LoopDetected:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Loop Detected"
                        };
                    case System.Net.HttpStatusCode.NotExtended:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Not Extended"
                        };
                    case System.Net.HttpStatusCode.NetworkAuthenticationRequired:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Network Authentication Required"
                        };
                    #endregion
                    default: // Default case for handling other status codes
                        var apiContent = await apiResponce.Content.ReadAsStringAsync(); // Reading the response content as a string
                        var apiResponceDTOs = JsonConvert.DeserializeObject<ResponceDTOs>(apiContent); // Deserializing the response content to ResponceDTOs
                        return apiResponceDTOs; // Returning the deserialized response
                }
            }
            catch (Exception ex) // Catch block to handle exceptions
            {
                var dto = new ResponceDTOs // Creating a new ResponceDTOs object to hold the error information
                {
                    Message = ex.Message.ToString(), // Setting the error message
                    IsSuccess = false // Indicating that the request was not successful
                };
                return dto; // Returning the error response
            }
        }
    }
}

