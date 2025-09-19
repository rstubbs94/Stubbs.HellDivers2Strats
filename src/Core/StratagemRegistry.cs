using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Stubbs.HellDivers2Strats.Core
{
    public static class StratagemRegistry
    {
        private static readonly ImmutableDictionary<string, StratagemDefinition> Definitions = BuildDefinitions();

        private static ImmutableDictionary<string, StratagemDefinition> BuildDefinitions()
        {
            var builder = ImmutableDictionary.CreateBuilder<string, StratagemDefinition>(StringComparer.OrdinalIgnoreCase);

            foreach (var definition in new[]
            {
                CreateDefinition("MG-43 Machine Gun", Keys.Down, Keys.Left, Keys.Down, Keys.Up, Keys.Right),
                CreateDefinition("APW-1 Anti-Materiel Rifle", Keys.Down, Keys.Left, Keys.Right, Keys.Up, Keys.Down),
                CreateDefinition("M-105 Stalwart", Keys.Down, Keys.Left, Keys.Down, Keys.Up, Keys.Up, Keys.Left),
                CreateDefinition("EAT-17 Expendable Anti-Tank", Keys.Down, Keys.Down, Keys.Left, Keys.Up, Keys.Right),
                CreateDefinition("GR-8 Recoilless Rifle", Keys.Down, Keys.Left, Keys.Right, Keys.Right, Keys.Left),
                CreateDefinition("FLAM-40 Flamethrower", Keys.Down, Keys.Left, Keys.Up, Keys.Down, Keys.Up),
                CreateDefinition("AC-8 Autocannon", Keys.Down, Keys.Left, Keys.Down, Keys.Up, Keys.Up, Keys.Right),
                CreateDefinition("MG-206 Heavy Machine Gun", Keys.Down, Keys.Left, Keys.Up, Keys.Down, Keys.Down),
                CreateDefinition("RL-77 Airburst Rocket Launcher", Keys.Down, Keys.Up, Keys.Up, Keys.Left, Keys.Right),
                CreateDefinition("MLS-4X Commando", Keys.Down, Keys.Left, Keys.Up, Keys.Down, Keys.Right),
                CreateDefinition("RS-422 Railgun", Keys.Down, Keys.Right, Keys.Down, Keys.Up, Keys.Left, Keys.Right),
                CreateDefinition("FAF-14 Spear", Keys.Down, Keys.Down, Keys.Up, Keys.Down, Keys.Down),
                CreateDefinition("StA-X3 W.A.S.P. Launcher", Keys.Down, Keys.Down, Keys.Up, Keys.Down, Keys.Right),
                CreateDefinition("Orbital Gatling Barrage", Keys.Right, Keys.Down, Keys.Left, Keys.Up, Keys.Up),
                CreateDefinition("Orbital Airburst Strike", Keys.Right, Keys.Right, Keys.Right),
                CreateDefinition("Orbital 120mm HE Barrage", Keys.Right, Keys.Right, Keys.Down, Keys.Left, Keys.Right, Keys.Down),
                CreateDefinition("Orbital 380mm HE Barrage", Keys.Right, Keys.Down, Keys.Up, Keys.Up, Keys.Left, Keys.Down, Keys.Down),
                CreateDefinition("Orbital Walking Barrage", Keys.Right, Keys.Down, Keys.Right, Keys.Down, Keys.Right, Keys.Down),
                CreateDefinition("Orbital Laser", Keys.Right, Keys.Down, Keys.Up, Keys.Right, Keys.Down),
                CreateDefinition("Orbital Napalm Barrage", Keys.Right, Keys.Right, Keys.Down, Keys.Left, Keys.Right, Keys.Up),
                CreateDefinition("Orbital Railcannon Strike", Keys.Right, Keys.Up, Keys.Down, Keys.Down, Keys.Right),
                CreateDefinition("Eagle Strafing Run", Keys.Up, Keys.Right, Keys.Right),
                CreateDefinition("Eagle Airstrike", Keys.Up, Keys.Right, Keys.Down, Keys.Right),
                CreateDefinition("Eagle Cluster Bomb", Keys.Up, Keys.Right, Keys.Down, Keys.Down, Keys.Right),
                CreateDefinition("Eagle Napalm Airstrike", Keys.Up, Keys.Right, Keys.Down, Keys.Up),
                CreateDefinition("LIFT-850 Jump Pack", Keys.Down, Keys.Up, Keys.Up, Keys.Down, Keys.Up),
                CreateDefinition("Eagle Smoke Strike", Keys.Up, Keys.Right, Keys.Up, Keys.Down),
                CreateDefinition("Eagle 110mm Rocket Pods", Keys.Up, Keys.Right, Keys.Up, Keys.Left),
                CreateDefinition("Eagle 500kg Bomb", Keys.Up, Keys.Right, Keys.Down, Keys.Down, Keys.Down),
                CreateDefinition("M-102 Fast Recon Vehicle", Keys.Left, Keys.Down, Keys.Right, Keys.Down, Keys.Right, Keys.Down, Keys.Up),
                CreateDefinition("Orbital Precision Strike", Keys.Right, Keys.Right, Keys.Up),
                CreateDefinition("Orbital Gas Strike", Keys.Right, Keys.Right, Keys.Down, Keys.Right),
                CreateDefinition("Orbital EMS Strike", Keys.Right, Keys.Right, Keys.Left, Keys.Down),
                CreateDefinition("Orbital Smoke Strike", Keys.Right, Keys.Right, Keys.Down, Keys.Up),
                CreateDefinition("E/MG-101 HMG Emplacement", Keys.Down, Keys.Up, Keys.Left, Keys.Right, Keys.Right, Keys.Left),
                CreateDefinition("FX-12 Shield Generator Relay", Keys.Down, Keys.Down, Keys.Left, Keys.Right, Keys.Left, Keys.Right),
                CreateDefinition("A/ARC-3 Tesla Tower", Keys.Down, Keys.Up, Keys.Right, Keys.Up, Keys.Left, Keys.Right),
                CreateDefinition("E/GL-21 Grenadier Battlement", Keys.Down, Keys.Right, Keys.Down, Keys.Left, Keys.Right),
                CreateDefinition("MD-6 Anti-Personnel Minefield", Keys.Down, Keys.Left, Keys.Up, Keys.Right),
                CreateDefinition("B-1 Supply Pack", Keys.Down, Keys.Left, Keys.Down, Keys.Up, Keys.Up, Keys.Down),
                CreateDefinition("GL-21 Grenade Launcher", Keys.Down, Keys.Left, Keys.Up, Keys.Left, Keys.Down),
                CreateDefinition("LAS-98 Laser Cannon", Keys.Down, Keys.Left, Keys.Down, Keys.Up, Keys.Left),
                CreateDefinition("MD-I4 Incendiary Mines", Keys.Down, Keys.Left, Keys.Left, Keys.Down),
                CreateDefinition("AX/LAS-5 \"Guard Dog\" Rover", Keys.Down, Keys.Up, Keys.Left, Keys.Up, Keys.Right, Keys.Right),
                CreateDefinition("SH-20 Ballistic Shield Backpack", Keys.Down, Keys.Left, Keys.Down, Keys.Down, Keys.Up, Keys.Left),
                CreateDefinition("ARC-3 Arc Thrower", Keys.Down, Keys.Right, Keys.Down, Keys.Up, Keys.Left, Keys.Left),
                CreateDefinition("MD-17 Anti-Tank Mines", Keys.Down, Keys.Left, Keys.Up, Keys.Up),
                CreateDefinition("LAS-99 Quasar Cannon", Keys.Down, Keys.Down, Keys.Up, Keys.Left, Keys.Right),
                CreateDefinition("SH-32 Shield Generator Pack", Keys.Down, Keys.Up, Keys.Left, Keys.Right, Keys.Left, Keys.Right),
                CreateDefinition("MD-8 Gas Mines", Keys.Down, Keys.Left, Keys.Left, Keys.Right),
                CreateDefinition("A/MG-43 Machine Gun Sentry", Keys.Down, Keys.Up, Keys.Right, Keys.Right, Keys.Up),
                CreateDefinition("A/G-16 Gatling Sentry", Keys.Down, Keys.Up, Keys.Right, Keys.Left),
                CreateDefinition("A/M-12 Mortar Sentry", Keys.Down, Keys.Up, Keys.Right, Keys.Right, Keys.Down),
                CreateDefinition("AX/AR-23 \"Guard Dog\"", Keys.Down, Keys.Up, Keys.Left, Keys.Up, Keys.Right, Keys.Down),
                CreateDefinition("A/AC-8 Autocannon Sentry", Keys.Down, Keys.Up, Keys.Right, Keys.Up, Keys.Left, Keys.Up),
                CreateDefinition("A/MLS-4X Rocket Sentry", Keys.Down, Keys.Up, Keys.Right, Keys.Right, Keys.Left),
                CreateDefinition("A/M-23 EMS Mortar Sentry", Keys.Down, Keys.Up, Keys.Right, Keys.Down, Keys.Right),
                CreateDefinition("EXO-45 Patriot Exosuit", Keys.Left, Keys.Down, Keys.Right, Keys.Up, Keys.Left, Keys.Down, Keys.Down),
                CreateDefinition("EXO-49 Emancipator Exosuit", Keys.Left, Keys.Down, Keys.Right, Keys.Up, Keys.Left, Keys.Down, Keys.Up),
                CreateDefinition("TX-41 Sterilizer", Keys.Down, Keys.Left, Keys.Up, Keys.Down, Keys.Left),
                CreateDefinition("AX/TX-13 \"Guard Dog\" Dog Breath", Keys.Down, Keys.Up, Keys.Left, Keys.Up, Keys.Right, Keys.Up),
                CreateDefinition("SH-51 Directional Shield", Keys.Down, Keys.Up, Keys.Left, Keys.Right, Keys.Up, Keys.Up),
                CreateDefinition("E/AT-12 Anti-Tank Emplacement", Keys.Down, Keys.Up, Keys.Left, Keys.Right, Keys.Right, Keys.Right),
                CreateDefinition("A/FLAM-40 Flame Sentry", Keys.Down, Keys.Up, Keys.Right, Keys.Down, Keys.Up, Keys.Up),
                CreateDefinition("B-100 Portable Hellbomb", Keys.Down, Keys.Right, Keys.Up, Keys.Up, Keys.Up),
                CreateDefinition("LIFT-860 Hover Pack", Keys.Down, Keys.Up, Keys.Up, Keys.Down, Keys.Left, Keys.Right),
                CreateDefinition("CQC-1 One True Flag", Keys.Down, Keys.Left, Keys.Right, Keys.Right, Keys.Up),
                CreateDefinition("GL-52 De-Escalator", Keys.Down, Keys.Right, Keys.Up, Keys.Left, Keys.Right),
                CreateDefinition("AX/ARC-3 \"Guard Dog\" K-9", Keys.Down, Keys.Up, Keys.Left, Keys.Up, Keys.Right, Keys.Left),
                CreateDefinition("PLAS-45 Epoch", Keys.Down, Keys.Left, Keys.Up, Keys.Left, Keys.Right),
                CreateDefinition("A/LAS-98 Laser Sentry", Keys.Down, Keys.Up, Keys.Right, Keys.Down, Keys.Up, Keys.Right),
                CreateDefinition("LIFT-182 Warp Pack", Keys.Down, Keys.Left, Keys.Right, Keys.Down, Keys.Left, Keys.Right),
                CreateDefinition("S-11 Speargun", Keys.Down, Keys.Right, Keys.Down, Keys.Left, Keys.Up, Keys.Right),
                CreateDefinition("EAT-700 Expendable Napalm", Keys.Down, Keys.Down, Keys.Left, Keys.Up, Keys.Left),
                CreateDefinition("MS-11 Solo Silo", Keys.Down, Keys.Up, Keys.Right, Keys.Down, Keys.Down),
                CreateDefinition("Reinforce", Keys.Up, Keys.Down, Keys.Right, Keys.Left, Keys.Up),
                CreateDefinition("SoS Beacon", Keys.Up, Keys.Down, Keys.Right, Keys.Up),
                CreateDefinition("Resupply", Keys.Down, Keys.Down, Keys.Up, Keys.Right),
                CreateDefinition("Eagle Rearm", Keys.Up, Keys.Up, Keys.Left, Keys.Up, Keys.Right),
                CreateDefinition("Hellbomb", Keys.Down, Keys.Up, Keys.Left, Keys.Down, Keys.Up, Keys.Right, Keys.Down, Keys.Up)
            })
            {
                builder[definition.Id] = definition;
            }

            return builder.ToImmutable();
        }

        private static StratagemDefinition CreateDefinition(string displayName, params Keys[] sequence)
        {
            var id = Regex.Replace(displayName, "[^A-Za-z0-9]+", "-").Trim('-');
            if (string.IsNullOrWhiteSpace(id))
            {
                id = Guid.NewGuid().ToString("N");
            }

            return new StratagemDefinition(id, displayName, sequence.ToImmutableArray());
        }

        public static StratagemDefinition Default => Definitions.TryGetValue("Reinforce", out var stratagem)
            ? stratagem
            : Definitions.Values.First();

        public static IEnumerable<StratagemDefinition> GetAll() => Definitions.Values.OrderBy(s => s.DisplayName);

        public static bool TryGet(string? id, out StratagemDefinition stratagem)
        {
            if (!string.IsNullOrWhiteSpace(id) && Definitions.TryGetValue(id, out stratagem))
            {
                return true;
            }

            stratagem = Default;
            return false;
        }
    }
}
