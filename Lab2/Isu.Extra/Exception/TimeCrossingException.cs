using Isu.Extra.Entites;

namespace Isu.Extra.Exception;

public class TimeCrossingException : SystemException
{
    public TimeCrossingException(OgnpGroup ognpGroup)
        : base($"Crossing lesson with OGNP group {ognpGroup}")
    {
    }
}