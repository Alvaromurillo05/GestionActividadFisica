namespace GestionActividadFisica
{
    public partial class FormularioPrincipal : Form
    {
        public FormularioPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new FormularioEvaluacionActividadFisica();
            childForm.Show();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void btnEvualuacionActividadFisica_Click(object sender, EventArgs e)
        {
            var form = new FormularioEvaluacionActividadFisica();
            form.ShowDialog();
        }
    }
}
