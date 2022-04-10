using System;
using System.IO;
using System.Reflection;

namespace Swarm
{
    public class Agent
    {
        public static int Initialize(string unused)
        {
            // AppDomain.CurrentDomain.AssemblyResolve += Current_Resolver;

            AppDomain.CurrentDomain.SetData("APPBASE", Directory.GetCurrentDirectory());

            return 0;
        }

        static Assembly Current_Resolver(object sender, ResolveEventArgs args)
        {
            if (args.Name.Contains("AInterface"))
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "AInterface.dll");

                return Assembly.LoadFrom(path);
            }

            return null;
        }
    }
}
