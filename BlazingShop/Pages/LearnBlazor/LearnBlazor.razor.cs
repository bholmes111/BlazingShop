using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingShop.Pages.LearnBlazor
{
    public class LearnBlazorBase : ComponentBase
    {
        protected string welcomeText = "Time to learn Blazor!";
        protected string name = "Spark";

        protected void getName()
        {
            name = "EventName";
        }
    }
}
