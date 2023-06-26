using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace İdentityServer.extenition
{
    public static class ModelStateExtentions
    {
        public static void AddModelErrorList(this ModelStateDictionary modelstate, List<string> errors)
        {
            errors.ForEach(x =>
            {
                modelstate.AddModelError(string.Empty, x);
            });
        }
    }
}
