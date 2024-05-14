using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms
{
    public class OffsetNode
    {
        public Int64 OnSet;
        public Int64 Offset;
        public OffsetNode parent;
        public List<OffsetNode> children;
        public String Name;

        public OffsetNode()
        {
            OnSet = -1;
            Offset = -1;
            parent = null;
            children = new List<OffsetNode>();
            Name = String.Empty;
        }

        public OffsetNode(OffsetNode ParentNode)
        {
            OnSet = -1;
            Offset = -1;
            parent = ParentNode;
            children = new List<OffsetNode>();
            Name = String.Empty;
        }

        public void AttachXmlNode(XmlDocument document, XmlNode parent)
        {
            String NodeName = this.Name ?? "Structure";
            if(NodeName == "." || NodeName == String.Empty)
                NodeName = "Structure";

            XmlNode node = document.CreateElement(NodeName);
            XmlAttribute attr = document.CreateAttribute("OnSet");
            attr.Value = String.Format("0x{0:X}", this.OnSet);      //hex?
            node.Attributes.Append(attr);
            attr = document.CreateAttribute("OffSet");
            attr.Value = String.Format("0x{0:X}", this.Offset);     //hex?
            node.Attributes.Append(attr);

            foreach (OffsetNode child in children)
                child.AttachXmlNode(document, node);

            node = parent.AppendChild(node);
        }

        public XmlDocument ToXmlDocument()
        {
            XmlDocument document = new XmlDocument();
            XmlElement root = document.CreateElement("SaveGame");
            document.InsertBefore(document.CreateXmlDeclaration("1.0", "utf-8", null), document.DocumentElement);
            document.AppendChild(root);

            foreach (OffsetNode child in children)
                child.AttachXmlNode(document, root);
            return document;
        }
    }

    public static class SaveFileOffsetCollector
    {
        private const Int32 Marker = unchecked((Int32)0xBEEFBEEF);
        private const String FileLocation = @"C:\Code\Tinkering\test\work after play 35.sav.inflate.dat";
        //private const String FileLocation = @"D:\test\kill them all.sav.inflate.dat";

        public static void collectOffsets()
        {
            OffsetNode root = new OffsetNode();
            root.Name = "SaveGame";
            OffsetNode parent = root, working = new OffsetNode(root);
            
            using (FileStream source = new FileStream(FileLocation, FileMode.Open, FileAccess.Read))
            {
                Byte[] buffer = new Byte[4], windowBuffer = new Byte[0];
                Int32 lastReadWidth;

                while (source.Position < source.Length)
                {
                    lastReadWidth = source.Read(buffer, 0, 4);
                    Int32 readData = BitConverter.ToInt32(buffer, 0);

                    if (source.Position < 84)
                    {
                        Byte[] temp = windowBuffer;
                        windowBuffer = new Byte[windowBuffer.Length + 4];
                        Array.Copy(temp, windowBuffer, temp.Length);
                        windowBuffer[windowBuffer.Length - 4] = buffer[0];
                        windowBuffer[windowBuffer.Length - 3] = buffer[1];
                        windowBuffer[windowBuffer.Length - 2] = buffer[2];
                        windowBuffer[windowBuffer.Length - 1] = buffer[3];
                    }
                    else
                    {
                        Byte[] temp = windowBuffer;
                        windowBuffer = new Byte[80];
                        Array.Copy(temp, 4, windowBuffer, 0, 76);
                        windowBuffer[76] = buffer[0];
                        windowBuffer[77] = buffer[1];
                        windowBuffer[78] = buffer[2];
                        windowBuffer[79] = buffer[3];
                    }


                    if (readData == Marker)
                    {
                        working.Name = FindNameInWindow(windowBuffer);
                        working.OnSet = source.Position - 4;
                        parent.children.Add(working);
                        parent = working;
                        working = new OffsetNode(parent);
                    }
                    else if (readData == ~Marker)
                    {
                        //back out of this node
                        parent.Offset = source.Position - 4;
                        parent = parent.parent;
                        working = new OffsetNode(parent);
                    }
                }

                //to XML
                XmlDocument document = root.ToXmlDocument();
                document.Save(FileLocation + ".xml");
            }
        }

        private static String FindNameInWindow(Byte[] Window)
        {
            String foundString = null, tempString = null;
            Int32 StartIndex = Window.Length - 8, readLen;

            while (true)
            {
                if (StartIndex < 0 || foundString != null)
                    break;

                readLen = BitConverter.ToInt32(Window, StartIndex);
                if ( (readLen <= Window.Length - (StartIndex + 4)) && readLen > 0 )   //if 1-4, then it could work on first run if 1-8, on second, etc.
                {
                    tempString = Encoding.ASCII.GetString(Window, StartIndex + 4, readLen);

                    if (tempString.Length == readLen && IsValidString(tempString))
                        foundString = tempString;
                }

                StartIndex -= 4;
            }


            return foundString;
        }

        private static Boolean IsValidString(String Test)
        {
            Boolean runningTally = true;

            for (Int32 index = 0; index < Test.Length; index++)
            {
                Char temp = Test[index];
                if (!(Char.IsPunctuation(temp) || Char.IsLetterOrDigit(temp) || Char.IsSeparator(temp)))
                {
                    runningTally = false;
                    break;
                }
            }

            return runningTally;
        }
    }
}