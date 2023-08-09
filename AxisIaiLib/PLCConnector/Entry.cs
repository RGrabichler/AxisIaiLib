using System;
using Vortex.Adapters.Connector.Tc3.Adapter;

namespace PLCConnector
{
    public class Entry
    {
        public static readonly string AmsId = "192.168.4.1.1.1";

        public static PLC.PLCTwinController Plc { get; } =
            new PLC.PLCTwinController(Tc3ConnectorAdapter.Create(AmsId, 851, true));
    }
}
