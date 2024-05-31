using System;

using StandardLibGema;

using Vortex.Adapters.Connector.Tc3.Adapter;

namespace StandardLibGema
{
    public class Entry
    {
        public static readonly string AmsId = "39.235.213.61.1.1";

        public static StandardLibGemaTwinController Plc { get; } =
            new StandardLibGemaTwinController(Tc3ConnectorAdapter.Create(AmsId, 852, true));
    }
}
