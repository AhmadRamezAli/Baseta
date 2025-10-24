using Baseta.Exceptions;
namespace Baseta.Utils
{


    namespace Baseta.Utils
    {
        public static class ValidationHelper
        {
            public static void ThrowIfNullOrEmpty(string? value, string fieldName)
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new PipeLineException($"{fieldName} cannot be empty.");
            }

            public static void ThrowIfNullOrEmpty<T>(ICollection<T>? list, string fieldName)
            {
                if (list == null || list.Count == 0)
                    throw new PipeLineException($"{fieldName} cannot be empty.");
            }

            public static void ThrowIfLessThanOrEqualToZero(int number, string fieldName)
            {
                if (number <= 0)
                    throw new PipeLineException($"{fieldName} must be greater than zero.");
            }
        }
    }

}
