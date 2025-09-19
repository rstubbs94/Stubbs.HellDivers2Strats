using System.Collections.Generic;
using SuchByte.MacroDeck.Plugins;
using Stubbs.HellDivers2Strats.Actions;

namespace Stubbs.HellDivers2Strats
{
    public class HellDiversPlugin : MacroDeckPlugin
    {
        public override void Enable()
        {
            Actions = new List<PluginAction>
            {
                new HelldiversStratagemAction(),
            };
        }
    }
}
