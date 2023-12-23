using System.Globalization;

namespace MediatorDesign.Domain.ErrorManagement
{
    public class ServiceResult
    {
        private static readonly ServiceResult _success = new ServiceResult { Succeeded = true };

        public bool Succeeded { get; protected set; } = true;

        protected readonly List<ServiceErrors> _errors = new List<ServiceErrors>();
        public IEnumerable<ServiceErrors> Errors => _errors;

        internal ServiceResult() { }

        public static ServiceResult Failed(params ServiceErrors[] errors)
        {
            ServiceResult identityResult = new ServiceResult
            {
                Succeeded = false
            };
            if (errors != null)
            {
                identityResult._errors.AddRange(errors);
            }

            return identityResult;
        }

        public static ServiceResult Failed(List<ServiceErrors>? errors)
        {
            ServiceResult identityResult = new ServiceResult
            {
                Succeeded = false
            };
            if (errors != null)
            {
                identityResult._errors.AddRange(errors);
            }

            return identityResult;
        }

        public static ServiceResult Failed(ServiceErrors error)
        {
            ServiceResult identityResult = new ServiceResult
            {
                Succeeded = false
            };
            if (error != null)
            {
                identityResult._errors.Add(error);
            }

            return identityResult;
        }

        public override string ToString()
        {
            if (!Succeeded)
            {
                return string.Format(CultureInfo.InvariantCulture, "{0} : {1}", "Failed", string.Join(",", Errors.Select((x) => x.Code).ToList()));
            }

            return "Succeeded";
        }
    }

    public class ServiceResult<T> : ServiceResult where T : class
    {
        public T Data { get; private set; } = default!;

        private ServiceResult() { }

        public ServiceResult(T data)
        {
            Data = data;
        }

        public static ServiceResult<T> Failed(params ServiceErrors[] errors)
        {
            ServiceResult<T> identityResult = new ServiceResult<T>
            {
                Succeeded = false
            };
            if (errors != null)
            {
                identityResult._errors.AddRange(errors);
            }

            return identityResult;
        }

        public static ServiceResult<T> Failed(List<ServiceErrors>? errors)
        {
            ServiceResult<T> identityResult = new ServiceResult<T>
            {
                Succeeded = false
            };
            if (errors != null)
            {
                identityResult._errors.AddRange(errors);
            }

            return identityResult;
        }

        public static ServiceResult<T> Failed(ServiceErrors error)
        {
            ServiceResult<T> identityResult = new ServiceResult<T>
            {
                Succeeded = false
            };
            if (error != null)
            {
                identityResult._errors.Add(error);
            }

            return identityResult;
        }
    }
}
