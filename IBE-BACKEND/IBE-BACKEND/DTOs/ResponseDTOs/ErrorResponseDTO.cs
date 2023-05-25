namespace IBE_BACKEND.DTOs.ResponseDTOs
{
    public class ErrorResponseDTO
    {
        public string Message { get; set; }
        public string Path { get; set; }
        public int StatusCode { get; set; }
        public DateTime TimeStamp;

        public ErrorResponseDTO(string message, string path, int statusCode, DateTime timeStamp)
        {
            Message = message;
            Path = path;
            StatusCode = statusCode;
            TimeStamp = timeStamp;
        }
    }
}
