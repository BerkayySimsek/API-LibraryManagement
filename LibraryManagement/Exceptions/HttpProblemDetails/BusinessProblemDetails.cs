using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Exceptions.HttpProblemDetails;

public class BusinessProblemDetails : ProblemDetails
{
    public BusinessProblemDetails(string message)
    {
        Title = "Business Exception";
        Status = StatusCodes.Status400BadRequest;
        Detail = message;
    }
}
