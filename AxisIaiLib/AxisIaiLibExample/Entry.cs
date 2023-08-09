using Vortex.Adapters.Connector.Tc3.Adapter;

namespace AxisIaiLibExample
{
    public class Entry
    {
        public static readonly string AmsId = "192.168.4.1.1.1";

        public static AxisIaiLibExampleTwinController Plc { get; } =
            new AxisIaiLibExampleTwinController(Tc3ConnectorAdapter.Create(AmsId, 851, true));
    }
}
