using Onix.Application.Common.Result;

namespace Onix.Application.Utilities
{
    public static class BusinessRules
    {
        public static IResult RunBusiness(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return null;
        }
    }
}
