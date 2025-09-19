using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormsComboBox = System.Windows.Forms.ComboBox;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using Stubbs.HellDivers2Strats.Core;

namespace Stubbs.HellDivers2Strats.Configuration
{
    public partial class StratagemActionConfigControl : ActionConfigControl
    {
        private readonly PluginAction _macroDeckAction;
        private readonly WinFormsComboBox _stratagemComboBox = new();

        public StratagemActionConfigControl(PluginAction macroDeckAction)
        {
            _macroDeckAction = macroDeckAction;
            InitializeComponent();
            PopulateControls();
        }

        private void PopulateControls()
        {
            var config = StratagemActionConfig.Resolve(_macroDeckAction.Configuration);

            _stratagemComboBox.Items.Clear();
            foreach (var stratagem in StratagemRegistry.GetAll().OrderBy(x => x.DisplayName))
            {
                _stratagemComboBox.Items.Add(stratagem);
            }

            var selected = _stratagemComboBox.Items
                .OfType<StratagemDefinition>()
                .FirstOrDefault(x => string.Equals(x.Id, config.StratagemId, StringComparison.OrdinalIgnoreCase))
                ?? StratagemRegistry.Default;

            _stratagemComboBox.SelectedItem = selected;
        }

        public override bool OnActionSave()
        {
            if (_stratagemComboBox.SelectedItem is not StratagemDefinition selected)
            {
                return false;
            }

            var config = new StratagemActionConfig
            {
                StratagemId = selected.Id,
            };

            _macroDeckAction.Configuration = config.Serialize();
            _macroDeckAction.ConfigurationSummary = selected.DisplayName;

            return true;
        }
    }

    public partial class StratagemActionConfigControl
    {
        private void InitializeComponent()
        {
            SuspendLayout();

            var stratagemLabel = new Label
            {
                AutoSize = true,
                Location = new Point(20, 20),
                Name = "labelStratagem",
                Text = "Stratagem",
            };

            _stratagemComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _stratagemComboBox.FormattingEnabled = true;
            _stratagemComboBox.Location = new Point(20, 45);
            _stratagemComboBox.Name = "comboStratagem";
            _stratagemComboBox.Size = new Size(260, 23);

            Controls.Add(stratagemLabel);
            Controls.Add(_stratagemComboBox);

            Name = nameof(StratagemActionConfigControl);
            Size = new Size(320, 110);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
