using System.Collections.Immutable;
using System.Windows.Forms;

namespace Stubbs.HellDivers2Strats.Core
{
    public class StratagemDefinition
    {
        public StratagemDefinition(string id, string displayName, ImmutableArray<Keys> sequence)
        {
            Id = id;
            DisplayName = displayName;
            Sequence = sequence;
        }

        public string Id { get; }

        public string DisplayName { get; }

        public ImmutableArray<Keys> Sequence { get; }

        public override string ToString() => DisplayName;
    }
}
