using System;
using System.Drawing;

namespace Bardez.Project.SwordOfTheStars.UI.Abstractions.TechTree.Graph
{
    public interface IBitmapLoader
    {
        Bitmap LoadBitmap(String TechImagePath);
    }
}
