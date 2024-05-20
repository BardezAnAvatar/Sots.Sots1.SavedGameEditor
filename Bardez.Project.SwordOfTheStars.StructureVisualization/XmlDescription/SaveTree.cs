using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Bardez.Project.SwordOfTheStars.StructureVisualization.XmlDescription
{
    public class SaveTreeNode
    {
        private const Int32 Marker = unchecked((Int32)0xBEEFBEEF);

        public SaveTreeNode parent;
        public Byte[] self;
        public List<SaveTreeNode> children;

        public SaveTreeNode()
        {
            parent = null;
            self = null;
            children =  new List<SaveTreeNode>();
        }

        public SaveTreeNode(SaveTreeNode parent)
        {
            this.parent = parent;
            self = null;
            children = new List<SaveTreeNode>();
        }

        public void AttachXmlNode(XmlDocument document, XmlNode parent)
        {
            if( (this.self != null && this.self.Length > 0) || (this.children.Count > 0))
            {
                String NodeName = "Element";
                if (this.self != null && this.self.Length > 4)
                {
                    if ((NodeName = GetName()) == null)
                        NodeName = "Element";   //reset;
                }


                XmlNode node = document.CreateElement(NodeName);
                node = parent.AppendChild(node);

                if (children.Count > 0)
                {
                    XmlNode selfdata = document.CreateElement("Element");
                    selfdata.InnerText = this.self == null ? String.Empty : BitConverter.ToString(self);
                    node.AppendChild(selfdata);
                }
                else
                    node.InnerText = this.self == null ? String.Empty : BitConverter.ToString(self);


                foreach (SaveTreeNode child in children)
                    child.AttachXmlNode(document, node);

                node = parent.AppendChild(node);
            }
        }

        public XmlDocument ToXmlDocument()
        {
            XmlDocument document = new XmlDocument();
            XmlElement root = document.CreateElement("SaveGame");
            document.InsertBefore(document.CreateXmlDeclaration("1.0", "utf-8", null), document.DocumentElement);
            document.AppendChild(root);

            AttachXmlNode(document, root);
            return document;
        }

        public String GetName()
        {
            String name = null;

            Int32 readLen = 0;
            readLen = BitConverter.ToInt32(this.self, 0);

            //sanity check
            if (readLen > 0 && this.self.Length > readLen + 4)
            {
                name = Encoding.ASCII.GetString(this.self, 4, readLen).Replace(".", "noDescription");

                //truncate;
                this.self = ByteSubArray(this.self, readLen + 4);
            }

            return name;
        }

        public static Byte[] ByteSubArray(Byte[] source, Int32 startIndex)
        {
            Byte[] temp = new Byte[source.Length - startIndex];
            Array.Copy(source, startIndex, temp, 0, temp.Length);
            return temp;
        }
    }

    public static class SaveTree
    {
        private const Int32 Marker = unchecked((Int32)0xBEEFBEEF);
        private const String FileLocation = @"C:\Code\Tinkering\test\Space Olympics.sav.dat";

        public static SaveTreeNode ReadTree(Stream source)
        {
            SaveTreeNode head = new SaveTreeNode(), working = head, parent = null, tempNode;

            List<Byte> bytes = new List<Byte>();
            Byte[] temp = new Byte[4];
            Int32 readSize = 0, offset = 0;
            while (source.Position < source.Length)
            {
                readSize = source.Read(temp, offset, 4 - offset);
                if (readSize == 4)
                {
                    offset = 0;

                    if (BitConverter.ToInt32(temp, 0) == Marker)
                    {
                        if (working.self != null)
                        {
                            tempNode = new SaveTreeNode(working);
                            tempNode.self = bytes.ToArray();
                            working.children.Add(tempNode);
                            tempNode = null;
                        }
                        else
                            working.self = bytes.ToArray();

                        bytes.Clear();
                        bytes.Add(temp[0]);
                        bytes.Add(temp[1]);
                        bytes.Add(temp[2]);
                        bytes.Add(temp[3]);

                        parent = working;
                        working = new SaveTreeNode(parent);
                        parent.children.Add(working);
                    }
                    else if (BitConverter.ToInt32(temp, 0) == ~Marker)
                    {
                        bytes.Add(temp[0]);
                        bytes.Add(temp[1]);
                        bytes.Add(temp[2]);
                        bytes.Add(temp[3]);

                        if (working.self == null)
                            working.self = bytes.ToArray();
                        else
                        {
                            tempNode = new SaveTreeNode(working);
                            tempNode.self = bytes.ToArray();
                            working.children.Add(tempNode);
                            tempNode = null;
                        }

                        bytes.Clear();

                        working = working.parent;
                        parent = parent.parent;
                    }
                    else
                    {
                        bytes.Add(temp[0]);
                        bytes.Add(temp[1]);
                        bytes.Add(temp[2]);
                        bytes.Add(temp[3]);
                    }
                }
                else
                {
                    offset = readSize;
                }
            }

            return head;
        }

        public static void ReadSave()
        {
            SaveTreeNode tree;
            using (FileStream source = new FileStream(FileLocation, FileMode.Open, FileAccess.Read))
            {
                tree = ReadTree(source);
            }

            //traverse tree
            XmlDocument document = tree.ToXmlDocument();

            document.Save(FileLocation + ".xml");

            //using (FileStream destination = new FileStream(FileLocation + ".xml", FileMode.Create, FileAccess.Write))
            //{
            //    XmlTextWriter writer = new XmlTextWriter(destination, Encoding.UTF8);
            //    document.WriteContentTo(writer);
            //}
        }
    }
}

#region Deprecated Code
////read 4 bytes.
//tempInt = BitConverter.ToInt32(temp, 0);

//if (tempInt == Marker)
//{
//}
//else if (tempInt == ~Marker)
//{
//}
//else if (tempInt > 0)
//{
//    //check next x bytes
//    lookaheadBuffer = new Byte[tempInt + (tempInt % 4)];
//    source.Read(lookaheadBuffer, 0, lookaheadBuffer.Length);
//    foreach (Byte b in lookaheadBuffer)
//        tempBytes.Add(b);

//    //read after that for marker
//    lookaheadBuffer = new Byte[4];
//    source.Read(lookaheadBuffer, offset, 4);
//}
#endregion