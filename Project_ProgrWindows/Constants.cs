using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Project_ProgrWindows
{
    public static class Constants
    {
        /// <summary>
        /// Database name.
        /// </summary>
        public static String DATABASE_NAME = ConfigurationManager.AppSettings["name"];

        /// <summary>
        /// Database used.
        /// </summary>
        public static String DATABASE_USER = ConfigurationManager.AppSettings["user"];

        /// <summary>
        /// Database password.
        /// </summary>
        public static String DATABASE_PASSWORD = ConfigurationManager.AppSettings["password"];

        /// <summary>
        /// Database host.
        /// </summary>
        public static String DATABASE_HOST = ConfigurationManager.AppSettings["host"];

        /// <summary>
        /// Database port.
        /// </summary>
        public static String DATABASE_PORT = ConfigurationManager.AppSettings["port"];

        /// <summary>
        /// Current version.
        /// </summary>
        public static float APP_VERSION = 0.1f;
    }
}
