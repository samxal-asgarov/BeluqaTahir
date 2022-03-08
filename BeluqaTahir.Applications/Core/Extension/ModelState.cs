using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BeluqaTahir.Applications.Core.Extension
{
    static public partial class Extension
    {
        //Create commands isvalid yoxlamaq ucun yazilib.
        static public bool ModelStateValid(this IActionContextAccessor action)
        {
            return action.ActionContext.ModelState.IsValid;
        }
    }
}
