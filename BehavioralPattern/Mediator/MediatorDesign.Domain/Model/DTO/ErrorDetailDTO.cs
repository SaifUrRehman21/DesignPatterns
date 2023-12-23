using Newtonsoft.Json;

namespace MediatorDesign.Domain.Model.DTO
{
    public class ErrorDetailDTO
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
