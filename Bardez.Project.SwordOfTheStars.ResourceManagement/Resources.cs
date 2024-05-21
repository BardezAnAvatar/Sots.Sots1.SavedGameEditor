﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bardez.Project.Configuration;
using Bardez.Project.SwordOfTheStars.IO.Pathfinding;
using Bardez.Project.SwordOfTheStars.IO.Pathfinding.Physical;
using Ionic.Zip;

namespace Bardez.Project.SwordOfTheStars.ResourceManagement
{
    public class Resources(Pathfinder pathfinder) : IDisposable
    {
        public const String DirectoryResources = "Resources";
        public const String DirectoryResourcesAdd = @"Resources\";
        public const String DirectoryTechTree = @"Resources\TechTree";
        public const String DirectoryLists = @"Resources\Lists";
        public const String DirectoryAvatars = @"Resources\Avatars";
        public const String DirectoryBadges = @"Resources\Badges";
        protected const String slash = @"\";
        protected static String resourceGob = String.Empty;

        protected Ionic.Zip.ZipFile zip = null;


        /// <summary>Destructor</summary>
        ~Resources()
        {
            //CleanZip();
        }

        public void Dispose()
        {
            CleanZip();
        }


        protected void CleanZip()
        {
            if (this.zip != null)
            {
                this.zip.Dispose();
                this.zip = null;
            }
        }

        public String ResourceGobPath
        {
            get
            {
                if (string.IsNullOrEmpty(resourceGob))
                    InitializeGobPath();
                
                return resourceGob;
            }
            set { resourceGob = value; }
        }

        private void InitializeGobPath()
        {
            if (ConfigurationHandler.GetBoolSettingValue("Registry.SotsPath.Lookup", false))
                resourceGob = pathfinder.DeriveSotsPath() + @"\sots.gob";
            else
                resourceGob = ConfigurationHandler.GetSettingValue("Registry.SotsPath.HardCoded");
        }

        public static Boolean DirectoryStructureExists()
        {
            Boolean exists = false;
            if (Directory.Exists(DirectoryResources))
            {
                if  (Directory.Exists(DirectoryLists) &&
                    Directory.Exists(DirectoryAvatars) &&
                    Directory.Exists(DirectoryBadges) &&
                    Directory.Exists(DirectoryTechTree))
                    exists = true;
            }

            return exists;
        }

        public static Boolean ResourceExists(String Resource)
        {
            return File.Exists(Resource);
        }

        public static void SetUpDirectories()
        {
            if (!DirectoryStructureExists())
            {
                if (! Directory.Exists(DirectoryResources))
                    Directory.CreateDirectory(DirectoryResources);

                if (! Directory.Exists(DirectoryLists))
                    Directory.CreateDirectory(DirectoryLists);

                if (! Directory.Exists(DirectoryAvatars))
                    Directory.CreateDirectory(DirectoryAvatars);

                if (! Directory.Exists(DirectoryBadges))
                    Directory.CreateDirectory(DirectoryBadges);

                if (!Directory.Exists(DirectoryTechTree))
                    Directory.CreateDirectory(DirectoryTechTree);
            }
        }

        public void OpenZipFile()
        {
            this.zip = new ZipFile(this.ResourceGobPath);
        }

        public void EnsurePrimaryResourcesExist()
        {
            ZipEntry masterTech, spriteTable;
            FileInfo masterInfo, spriteInfo;

            if (this.zip == null)
                OpenZipFile();
            
            masterTech = (from e in zip.Entries where e.FileName == @"TechTree/MasterTechList.tech" select e).First<ZipEntry>();
            spriteTable = (from e in zip.Entries where e.FileName == @"GUI/SpriteTable.csv" select e).First<ZipEntry>();

            if (! (File.Exists(DirectoryLists + @"\MasterTechList.tech") && File.Exists(DirectoryLists + @"\SpriteTable.csv")
                    && (masterInfo = new FileInfo(DirectoryLists + @"\MasterTechList.tech")).Length == masterTech.UncompressedSize
                    && (spriteInfo = new FileInfo(DirectoryLists + @"\SpriteTable.csv")).Length == spriteTable.UncompressedSize)
                )
            {
                if (!File.Exists(DirectoryLists + @"\MasterTechList.tech") || new FileInfo(DirectoryLists + @"\MasterTechList.tech").Length != masterTech.UncompressedSize)
                {
                    using (FileStream file = new FileStream(DirectoryLists + @"\MasterTechList.tech", FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        masterTech.Extract(file);
                    }
                }

                if (!File.Exists(DirectoryLists + @"\SpriteTable.csv"))
                {
                    using (FileStream file = new FileStream(DirectoryLists + @"\SpriteTable.csv", FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        spriteTable.Extract(file);
                    }
                }
            }
        }

        public void EnsureSecondaryResourceExists(String Resource)
        {
            String resourceZipName = Resource.Replace('\\', '/');
            ZipEntry spriteEntry = null;
            FileInfo spriteInfo;
            
            if (this.zip == null)
                OpenZipFile();

            //spriteEntry = (from e in zip.Entries where e.FileName.Equals(resourceZipName, StringComparison.CurrentCultureIgnoreCase) select e).First<ZipEntry>();

            List<ZipEntry> entries = this.zip.Entries.ToList<ZipEntry>();
            for (Int32 i = 0; i < entries.Count; ++i)
            {
                if (entries[i].FileName.Equals(resourceZipName, StringComparison.CurrentCultureIgnoreCase))
                {
                    spriteEntry = entries[i];
                    break;
                }
            }

            if (!(File.Exists(@"Resources\" + Resource) && (spriteInfo = new FileInfo(@"Resources\" + Resource)).Length == spriteEntry.UncompressedSize))
            {
                using (FileStream file = new FileStream(@"Resources\" + Resource, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    ZipEntry entry = (from e in zip.Entries where e.FileName.ToLower() == resourceZipName.ToLower() select e).First<ZipEntry>();
                    entry.Extract(file);
                }
            }
        }
    }
}