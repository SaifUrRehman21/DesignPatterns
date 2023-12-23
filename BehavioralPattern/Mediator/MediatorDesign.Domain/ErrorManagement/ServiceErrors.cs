namespace MediatorDesign.Domain.ErrorManagement
{
    public class ServiceErrors
    {
        public string Code { get; private set; } = default!;
        public string Description { get; private set; } = default!;

        public ServiceErrors(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}
