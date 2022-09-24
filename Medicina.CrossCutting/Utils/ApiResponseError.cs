namespace Medicina.CrossCutting.Utils
{
    public class ApiResponseError
    {
        public string ErrorMessage { get; private set; }
        public ApiResponseError(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
