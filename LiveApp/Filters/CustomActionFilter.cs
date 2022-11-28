using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveApp.Filters
{
    public class CustomActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("\n\n\n\nCustomActionFilter OnActionExecuting method");
            Console.WriteLine("After starting \n\n\n\n");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("\n\n\n\nBefore Ending");
            Console.WriteLine("CustomActionFilter OnActionExecuted method\n\n\n\n");
        }

    }
}
