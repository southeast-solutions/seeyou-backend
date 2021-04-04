namespace Domain.Response.Abstract
{
    public abstract class FailableTaskResponse
    {
        public bool Success { get; set; }
        public string FailureType { get; set; }
    }
}