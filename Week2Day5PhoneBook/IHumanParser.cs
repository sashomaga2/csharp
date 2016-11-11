using System.Collections.Generic;

namespace JSONSerialization
{
    public interface IHumanParser
    {
        List<IHuman> ParseHumans(IReader reader);
    }
}