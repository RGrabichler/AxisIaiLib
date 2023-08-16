using System;

using AxisIaiLibrary;

using Vortex.Adapters.Connector.Tc3.Adapter;

namespace AxisIaiLib
{
    public class Entry
    {
        public static readonly string AmsId = "5.103.231.236.1.1";

        public static AxisIaiLibTwinController Plc { get; } =
            new AxisIaiLibTwinController(Tc3ConnectorAdapter.Create(AmsId, 852, true));
    }
}
