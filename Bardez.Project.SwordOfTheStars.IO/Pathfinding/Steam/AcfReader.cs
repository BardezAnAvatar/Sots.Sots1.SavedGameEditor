using System.IO;
using System.Linq;

namespace Bardez.Project.SwordOfTheStars.IO.Pathfinding.Steam;

/// <summary>Reads an instance of Valve's ACF files</summary>
/// <remarks>Sourced from: https://stackoverflow.com/a/42876399/1375931</remarks>
public class AcfReader
{
    public string FileLocation { get; private set; }

    public AcfReader(string FileLocation)
    {
        if (File.Exists(FileLocation))
            this.FileLocation = FileLocation;
        else
            throw new FileNotFoundException("Error", FileLocation);
    }

    public bool CheckIntegrity()
    {
        string Content = File.ReadAllText(FileLocation);
        int quote = Content.Count(x => x == '"');
        int braceleft = Content.Count(x => x == '{');
        int braceright = Content.Count(x => x == '}');

        return ((braceleft == braceright) && (quote % 2 == 0));
    }

    public AcfStruct AcfFileToStruct()
    {
        return AcfFileToStruct(File.ReadAllText(FileLocation));
    }

    private AcfStruct AcfFileToStruct(string RegionToReadIn)
    {
        AcfStruct ACF = new AcfStruct();
        int LengthOfRegion = RegionToReadIn.Length;
        int CurrentPos = 0;
        while (LengthOfRegion > CurrentPos)
        {
            int FirstItemStart = RegionToReadIn.IndexOf('"', CurrentPos);
            if (FirstItemStart == -1)
                break;
            int FirstItemEnd = RegionToReadIn.IndexOf('"', FirstItemStart + 1);
            CurrentPos = FirstItemEnd + 1;
            string FirstItem = RegionToReadIn.Substring(FirstItemStart + 1, FirstItemEnd - FirstItemStart - 1);

            int SecondItemStartQuote = RegionToReadIn.IndexOf('"', CurrentPos);
            int SecondItemStartBraceleft = RegionToReadIn.IndexOf('{', CurrentPos);
            if (SecondItemStartBraceleft == -1 || SecondItemStartQuote < SecondItemStartBraceleft)
            {
                int SecondItemEndQuote = RegionToReadIn.IndexOf('"', SecondItemStartQuote + 1);
                string SecondItem = RegionToReadIn.Substring(SecondItemStartQuote + 1, SecondItemEndQuote - SecondItemStartQuote - 1);
                CurrentPos = SecondItemEndQuote + 1;
                ACF.SubItems.Add(FirstItem, SecondItem);
            }
            else
            {
                int SecondItemEndBraceright = RegionToReadIn.NextEndOf('{', '}', SecondItemStartBraceleft + 1);
                AcfStruct ACFS = AcfFileToStruct(RegionToReadIn.Substring(SecondItemStartBraceleft + 1, SecondItemEndBraceright - SecondItemStartBraceleft - 1));
                CurrentPos = SecondItemEndBraceright + 1;
                ACF.SubACF.Add(FirstItem, ACFS);
            }
        }

        return ACF;
    }
}