using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ConfSys.Shared.Core.Api;

public enum ActionResponseStatusCode
{
    [Display(Name = "Success Action")]
    Success = 200,

    [Display(Name = "An error has been occured")]
    ServerError = 500,

    [Display(Name = "Parameters are invalid.")]
    BadRequest = 400,

    [Display(Name = "Not found")]
    NotFound = 404,

    [Display(Name = "unauthorize user")]
    UnAuthorized = 401,

    [Display(Name = "the request has been banned.")]
    Forbidden = 403,

    [Display(Name = "Redirect")]
    Redirect = 302,
}