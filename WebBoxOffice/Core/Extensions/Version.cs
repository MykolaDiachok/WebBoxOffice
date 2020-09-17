using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebBoxOffice.Core.Extensions
{
    public static class Version
    {
        /// <summary>
        /// GetVersion
        /// </summary>
        /// <returns></returns>
        public static string GetVersion() => $"{ThisAssembly.Git.SemVer.Major}.{ThisAssembly.Git.SemVer.Minor}.{ThisAssembly.Git.Commits}-{ThisAssembly.Git.Branch}+{ThisAssembly.Git.Commit}";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetAppVersion() => typeof(Program)
            .GetTypeInfo()
            .Assembly
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
            ?.InformationalVersion;
    }
}
