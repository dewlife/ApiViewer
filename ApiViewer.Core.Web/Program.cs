////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Program.cs
//
// summary:	Implements the program class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ApiViewer.Core.Web
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A program. </summary>
    ///
    /// <remarks>   James Coates, 8/26/2017. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class Program
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Main entry-point for this application. </summary>
        ///
        /// <remarks>   James Coates, 8/26/2017. </remarks>
        ///
        /// <param name="args"> The arguments. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Builds web host. </summary>
        ///
        /// <remarks>   James Coates, 8/26/2017. </remarks>
        ///
        /// <param name="args"> The arguments. </param>
        ///
        /// <returns>   An IWebHost. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
