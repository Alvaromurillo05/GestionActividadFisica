using GestionActividadFisica;
using Negocio;

namespace GesttionActividadFisica
{
    public partial class FormularioIngreso : Form
    {
        IServicioSeguridad servicioSeguridad = new ServicioSeguridad();
        public FormularioIngreso()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (servicioSeguridad.ValidarUsuario(new Entidades.Usuario() { Clave = txtContraseña.Text, NombreUsuario = txtUsuario.Text }))
            {
                var form = new FormularioPrincipal();
                form.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña no válidos");
            }
        }
    }
}