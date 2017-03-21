using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;
using LaunchPad.Data;

namespace LaunchPad
{
    public static class Unity
    {
        static Unity()
        {
            var container = new UnityContainer();
        }
    }
}