using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Exceptions.HttpProblemDetails;

public class ValidationProblemDetails : ProblemDetails
{
    List<string> Errors { get; set; }
    public ValidationProblemDetails(List<string> errors)
    {
        Title = "Validation Exception";
        Status = StatusCodes.Status404NotFound;
        Errors = errors;
    }
}
