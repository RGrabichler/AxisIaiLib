using Vortex.Adapters.Connector.Tc3.Adapter;

namespace AxisIaiLibExample
{
    public class Entry
    {
        public static readonly string AmsId = "5.103.231.236.1.1";

        public static AxisIaiLibExampleTwinController Plc { get; } =
            new AxisIaiLibExampleTwinController(Tc3ConnectorAdapter.Create(AmsId, 851, true));
    }
}
