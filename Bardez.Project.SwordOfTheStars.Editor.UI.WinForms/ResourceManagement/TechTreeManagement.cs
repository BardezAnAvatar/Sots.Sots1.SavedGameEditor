using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.Resource_Management;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.User_Controls.Graph;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms
{
    public class TechTreeManagement
    {
        protected AvailableTechnologyTree tree;
        protected List<OverrideTech> overrideTech;
        protected List<JoinedTechnology> joinedTechTree;
        protected Resources resources;
        protected Dictionary<String, Bitmap> spriteDictionary;
        protected readonly Object locker;
        protected const String techTreePath = @"Resources\Lists\MasterTechList.tech";
        protected const String spritesPath = @"Resources\Lists\SpriteTable.csv";
        protected const String overrideTechPath = @"Resources\Lists\OverrideTechTree.txt";
        protected const Int32 controlWidth = 110;
        

        #region Properties
        public AvailableTechnologyTree Tree
        {
            get { return tree; }
            set { tree = value; }
        }

        public List<OverrideTech> OverrideTechnologyList
        {
            get { return overrideTech; }
            set { overrideTech = value; }
        }

        public List<JoinedTechnology> JoinedTechTree
        {
            get { return joinedTechTree; }
            set { joinedTechTree = value; }
        }

        public String TechTreePath
        {
            get { return techTreePath; }
        }

        public String SpritesPath
        {
            get { return spritesPath; }
        }

        public String OverrideTechPath
        {
            get { return overrideTechPath; }
        }

        public Resources Resources
        {
            get { return resources; }
            set { resources = value; }
        } 
        #endregion

        
        /// <summary>Default constructor</summary>
        public TechTreeManagement()
        {
            this.tree = null;
            this.resources = null;
            this.locker = new Object();
            this.overrideTech = new List<OverrideTech>();
            this.spriteDictionary = new Dictionary<String, Bitmap>();
        }

        /// <summary>Destructor</summary>
        ~TechTreeManagement()
        {
            lock(this.locker)
            {
                //doing it below throws an error on dispose
                List<String> keys = this.spriteDictionary.Keys.ToList<String>();

                foreach (String key in keys)
                {
                    if (this.spriteDictionary[key] != null)
                    {
                        this.spriteDictionary[key].Dispose();
                        this.spriteDictionary[key] = null;
                    }
                }
            }
        }
        
        public void ReadMasterTechList()
        {
            if (tree == null)
            {
                this.tree = new AvailableTechnologyTree();
                using (FileStream file = new FileStream(techTreePath, FileMode.Open, FileAccess.Read))
                {
                    this.tree.ReadFromStream(file);
                }

                this.tree.CalculateNodeHeights();
            }
        }

        public void ReadResources()
        {
            lock (this.locker)
            {
                //set up resource directories
                Resources.SetUpDirectories();

                //ensure prerequisite files exist
                this.resources = new Resources();
                this.resources.EnsurePrimaryResourcesExist();

                //read tech sprites
                List<TechSprite> spriteList = TechSpriteTable.ReadFromFile(spritesPath);

                //read master tech tree
                this.ReadMasterTechList();

                //read override tech settings
                this.overrideTech = OverrideTechList.ReadFromFile(overrideTechPath);

                this.joinedTechTree =
                    (from masterTech in this.tree.Technologies
                     join newOverrideTech in this.overrideTech on masterTech.Name equals newOverrideTech.Name into joinedTech
                     join sprite in spriteList on masterTech.Name equals sprite.Tech into joinedSprite
                     from tech in joinedTech.DefaultIfEmpty(OverrideTech.Default)
                     from newSprite in joinedSprite.DefaultIfEmpty(TechSprite.Default)
                     select new JoinedTechnology(masterTech.Name, tech.Family ?? masterTech.Family, tech.Group ?? masterTech.Group, tech.GroupNumber, tech.FriendlyName, tech.Depth, tech.Position, (tech.OverrideImagePath == null || tech.OverrideImagePath == String.Empty) ? newSprite.ZipArchivePath : tech.OverrideImagePath, tech.Description, masterTech.Requires, masterTech.Allows)
                    ).ToList();

                foreach (JoinedTechnology tech in this.joinedTechTree)
                {
                    //ensure that the sprite resource exists
                    this.resources.EnsureSecondaryResourceExists(tech.ImagePath);

                    this.spriteDictionary.Add(tech.ImagePath, LoadBitmap(Resources.DirectoryResourcesAdd + tech.ImagePath));
                }
            }
        }

        //Joined Tech List
        public void PopulateGraph(Graph GraphTechTree)
        {
            lock (this.locker)
            {
                /* Roots, Bloody Roots */
                List<JoinedTechnology> roots = (from t in this.joinedTechTree where t.Depth == 0 select t).ToList<JoinedTechnology>();

                Int32 currentWidth = 0;
                for (Int32 i = 0; i < roots.Count; ++i)
                {
                    Int32 maxHeight = (from t in this.joinedTechTree where t.Family == roots[i].Family select t.Depth).Max();

                    Int32 totalWidth =
                        (from a in
                             (from t in this.joinedTechTree group t by new { t.Family, t.GroupNumber, t.Depth } into newGroup where newGroup.Key.Family == roots[i].Family && newGroup.Key.GroupNumber > 0 orderby newGroup.Key.GroupNumber select new { Family = newGroup.Key.Family, Group = newGroup.Key.GroupNumber, Depth = newGroup.Key.Depth, Position = newGroup.Max(p => p.Position) })
                         group a by new { a.Family, a.Group } into anotherGroup
                         orderby anotherGroup.Key.Family, anotherGroup.Key.Group
                         select new { anotherGroup.Key.Family, anotherGroup.Key.Group, Width = anotherGroup.Max(p => p.Position) }
                        ).Select(item => item.Width).Sum(); ;


                    List<JoinedTechnology> nodes = new List<JoinedTechnology>();
                    nodes.Add(roots[i]);
                    AttachToGraph(roots[i].Family, maxHeight, totalWidth, 0, currentWidth, nodes, GraphTechTree);
                    currentWidth += (controlWidth * totalWidth + 100);
                }

                GraphTechTree.Balance();
                GraphTechTree.AttachNodes();
            }
        }

        //Joined Tech List
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Family"></param>
        /// <param name="TreeHeight"></param>
        /// <param name="TreeWidth"></param>
        /// <param name="CurrentHeight"></param>
        /// <param name="CurrentLeftmostX"></param>
        /// <param name="Parents"></param>
        /// <param name="GraphTechTree"></param>
        /// <remarks>
        ///     Perhaps this should be locked on locker; the recursive nature of this method, however, noticablly slows down
        ///     the application load. I believe that I should simply note that this is <em>implicitly</em> locked
        ///     by PopulateGraph, and that it does need to be locked, but the precondition is that the caller
        ///     needs to already be locked on locker.
        /// </remarks>
        protected void AttachToGraph(String Family, Int32 TreeHeight, Int32 TreeWidth, Int32 CurrentHeight, Int32 CurrentLeftmostX, List<JoinedTechnology> Parents, Graph GraphTechTree)
        {
            Int32 width = controlWidth * TreeWidth;

            //select the maximum width, grouped by the Family and GroupNumber
            //SELECT Family, GroupNumber, Depth
            //FROM this.joinedTechTree
            //WHERE Family = Parents[0].Family && newGroup.Key.GroupNumber > 0
            //GROUP BY Family, GroupNumber, Depth
            var y =
                from a in
                    (from t in this.joinedTechTree group t by new { t.Family, t.GroupNumber, t.Depth } into newGroup where newGroup.Key.Family == Parents[0].Family && newGroup.Key.GroupNumber > 0 select new { Family = newGroup.Key.Family, Group = newGroup.Key.GroupNumber, Depth = newGroup.Key.Depth, Position = newGroup.Max(p => p.Position) })
                group a by new { a.Family, a.Group } into anotherGroup
                orderby anotherGroup.Key.Family, anotherGroup.Key.Group
                select new { anotherGroup.Key.Group, Width = anotherGroup.Max(colWidth => colWidth.Position) };

            //get the width for each "group", given its place in the family
            //join to the above results to get widths to the left of these, add personal width for total
            #region LINQ old Way
            //List<TreeColumn> GroupWidths =
            //    (from b in y
            //     from c in y
            //     where b.Group.CompareTo(c.Group) > 0
            //     group c by b.Group into groupie
            //     select new TreeColumn(groupie.Key, groupie.Sum(p => p.Width))).Union
            //    (from b in y where b.Group == 1 select new TreeColumn(1, 0)).OrderBy(o => o.Group).ToList<TreeColumn>();
            #endregion

            //speed up?
            var lst = y.ToList();
            List<TreeColumn> GroupWidths = new List<TreeColumn>();
            GroupWidths.Add(new TreeColumn(1, 0));

            for (Int32 i = 0; i < lst.Count; ++i)
            {
                TreeColumn next = new TreeColumn(lst[i].Group, 0);
                for (Int32 j = 0; j < lst.Count; ++j)
                {
                    if (lst[j].Group < lst[i].Group)
                        next.Position += lst[j].Width;
                }
                GroupWidths.Add(next);
            }
            GroupWidths = GroupWidths.OrderBy(o => o.Group).ToList<TreeColumn>();



            //attach parents
            for (Int32 i = 0; i < Parents.Count; ++i)
            {
                ////commented out the below for preloading of the images
                //get matching image record
                //String spriteResourcePath = Parents[i].ImagePath ?? this.spriteList[0].ZipArchivePath;  //default
                //ensure that the sprite resource exists
                //this.resources.EnsureSecondaryResourceExists(spriteResourcePath);

                TechTreeGraphNodeBitmap node = new TechTreeGraphNodeBitmap(Parents[i], this.spriteDictionary[Parents[i].ImagePath]);
                Point position = node.Location;

                if (Parents[i].GroupNumber == 0)
                    position.X = (((width / (Parents.Count + 1)) + 20) * (i + 1)) - 20 + CurrentLeftmostX;
                else
                {
                    Int32 xPos = (from g in GroupWidths join p in Parents on g.Group equals p.GroupNumber where p.Name == Parents[i].Name select g.Position).First();

                    position.X = CurrentLeftmostX + (controlWidth * (xPos + (Parents[i].Position - 1)));
                }

                position.Y = (120 * CurrentHeight) + 10;
                node.Location = position;
                GraphTechTree.Nodes.Add(node);
            }

            //attach the edges
            foreach (JoinedTechnology node in Parents)
            {
                foreach (AvailableTechnologyConnection conn in node.Allows)
                {
                    List<JoinedTechnology> dest = (from tech in this.joinedTechTree where tech.Name == conn.NewTech && tech.Family == Family select tech).ToList<JoinedTechnology>();
                    foreach (JoinedTechnology destNode in dest)
                        GraphTechTree.Edges.Add(new GraphEdge(node.Name, destNode.Name));
                }
            }

            //get children
            List<JoinedTechnology> orderedChildren = new List<JoinedTechnology>();
            while (orderedChildren.Count == 0 && CurrentHeight < 15)
            {
                ++CurrentHeight;
                orderedChildren = (from tech in this.joinedTechTree where tech.Depth == CurrentHeight && tech.Family == Family orderby tech.GroupNumber, tech.Position select tech).ToList<JoinedTechnology>();

                if (orderedChildren.Count > 0)
                {
                    AttachToGraph(Family, TreeHeight, TreeWidth, CurrentHeight, CurrentLeftmostX, orderedChildren, GraphTechTree);
                    break;
                }
            }
        }

        protected static List<T> MakeList<T>(T item)
        {
            return new List<T>();
        }

        public static Bitmap LoadBitmap(String TechImagePath)
        {
            //Code pulled here from TechTreeGraphNodeBitmap.cs, as this can be public static, and
            //  I plan to pull the code there that even calls this in the first place.
            Bitmap image = null;

            if (TechImagePath.EndsWith(".tga"))
            {
                //http://www.codeproject.com/KB/graphics/TargaImage.aspx
                image = Paloma.TargaImage.LoadTargaImage(TechImagePath);
            }
            else
                image = new Bitmap(TechImagePath);


            return image;
        }
    }

    public class TreeColumn
    {
        protected Int32 group, position;

        public Int32 Group
        {
            get { return group; }
            set { group = value; }
        }

        public Int32 Position
        {
            get { return position; }
            set { position = value; }
        }

        /// <summary>Default constructor</summary>
        public TreeColumn()
        {
        }

        /// <summary>Default constructor</summary>
        public TreeColumn(Int32 Column, Int32 StartPosition)
        {
            this.group = Column;
            this.position = StartPosition;
        }
    }
}