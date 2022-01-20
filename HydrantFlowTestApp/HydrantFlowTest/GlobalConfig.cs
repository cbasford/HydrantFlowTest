using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowTestLibrary.DataAccess;

namespace FlowTestLibrary
{
    public static class GlobalConfig
    {
        public const string PrizesFile = "PrizeModels.csv";
        public const string PeopleFile = "PersonModels.csv";
        public const string TeamFile = "TeamModels.csv";
        public const string TournamentFile = "TournamentModels.csv";
        public const string MatchupFile = "MatchupModels.csv";
        public const string MatchupEntryFile = "MatchupEntryModels.csv";

        public static IDataConnection Connection { get; private set; }
                
        public static void InitializeConnections(DatabaseType db)
        {

            if (db == DatabaseType.Production)
            {
                // TODO - Set up the SQL Connector properly
                SqlConnector prod = new SqlConnector();
                Connection = prod;
            }
            else if (db == DatabaseType.Development)
            {
                // TODO - Set up the SQL Connector properly
                SqlConnector dev = new SqlConnector();
                Connection = dev;
            }
            else if (db == DatabaseType.Home)
            {
                // TODO - Set up the SQL Connector properly
                SqlConnector home = new SqlConnector();
                Connection = home;

            }
        }

        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        } 

        public static string AppKeyLookup(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static string FilePath(string filePath)
        {
            return ConfigurationManager.AppSettings[filePath];
        }

        public static string EpaDll ( string epaDll)
        {
            return ConfigurationManager.AppSettings[epaDll];
        }

        /// <summary>
        /// The name of the epanet file withour the .inp
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string FileName(string fileName)
        {
            return ConfigurationManager.AppSettings[fileName];
        }


    }
}
