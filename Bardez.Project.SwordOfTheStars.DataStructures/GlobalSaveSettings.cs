using System;
using System.Collections.Generic;
using System.Text;

namespace Bardez.Project.SwordOfTheStars.DataStructures
{
    internal static class GlobalSaveSettings
    {
        /// <summary>This member indicates the number of turns in the current save file</summary>
        private static Int32 numberOfTurns = 1;

        /// <summary>This member indicates the number of players in the current save file</summary>
        private static Int32 numberOfPlayers = 1;

        /// <summary>This member indicates the number of players in the current save file</summary>
        private static Int32 numberOfSystems = 1;



        /// <summary>This member indicates the number of turns in the current save file</summary>
        public static Int32 NumberOfTurns
        {
            get { return numberOfTurns; }
            set { numberOfTurns = value; }
        }

        /// <summary>This member indicates the number of players in the current save file</summary>
        public static Int32 NumberOfPlayers
        {
            get { return numberOfPlayers; }
            set { numberOfPlayers = value; }
        }

        /// <summary>This member indicates the number of players in the current save file</summary>
        public static Int32 NumberOfSystems
        {
            get { return numberOfSystems; }
            set { numberOfSystems = value; }
        }
    }
}