namespace Canteen.API.Contracts.Common
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public List<string> Errors { get; } = new List<string>();
        public DateTime Timestamp { get; set; }

        public void AddError(string errorMessage)
        {
            Errors.Add(errorMessage);
        }
    }
}
