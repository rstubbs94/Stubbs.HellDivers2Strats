using Newtonsoft.Json;
using Stubbs.HellDivers2Strats.Core;

namespace Stubbs.HellDivers2Strats.Configuration
{
    public class StratagemActionConfig
    {
        public string StratagemId { get; set; } = StratagemRegistry.Default.Id;

        [JsonIgnore]
        public static StratagemActionConfig Default => new();

        public static StratagemActionConfig Resolve(string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return Default;
            }

            try
            {
                var config = JsonConvert.DeserializeObject<StratagemActionConfig>(json);
                if (config == null)
                {
                    return Default;
                }

                if (!StratagemRegistry.TryGet(config.StratagemId, out _))
                {
                    config.StratagemId = StratagemRegistry.Default.Id;
                }

                return config;
            }
            catch
            {
                return Default;
            }
        }

        public string Serialize() => JsonConvert.SerializeObject(this);
    }
}
