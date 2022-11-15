namespace GolestanTestProject.Models
{
    public class WebApiResponse
    {
        public bool HasError { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }

        public List<string> Warning { get; set; } = new List<string>();
        public object LogChanges { get; set; }
        public object Data { get; set; }
    }
}
