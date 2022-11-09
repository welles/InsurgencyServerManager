using System.ComponentModel;

namespace InsurgencyServerManager.Data;

public enum ModType
{
    [Description("Vanilla")]
    Vanilla = 0,

    [Description("Full Conversion")]
    FullConversion = 1,

    [Description("Functionality")]
    Functionality = 2,

    [Description("Map")]
    Map = 3
}
