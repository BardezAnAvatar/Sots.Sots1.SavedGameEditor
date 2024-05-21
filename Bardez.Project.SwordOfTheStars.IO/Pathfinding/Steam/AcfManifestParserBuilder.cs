namespace Bardez.Project.SwordOfTheStars.IO.Pathfinding.Steam;

/// <summary>Builder class for <see cref="IAcfParser" /></summary>
public class AcfManifestParserBuilder : IAcfManifestParserBuilder
{
    /// <summary>Builds a <see cref="IAcfParser" /> instance for a specified <paramref name="path" /></summary>
    /// <param name="path">Path to the ACF manifest file</param>
    /// <returns>An <see cref="IAcfParser" /> instance for <paramref name="path" />.</returns>
    public IAcfParser BuildParser(string path)
    {
        return new AcfReader(path);
    }
}
