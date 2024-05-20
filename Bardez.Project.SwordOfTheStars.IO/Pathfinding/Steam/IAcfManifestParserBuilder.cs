namespace Bardez.Project.SwordOfTheStars.IO.Pathfinding.Steam
{
    public interface IAcfManifestParserBuilder
    {
        IAcfParser BuildParser(string path);
    }
}