using Entidades;
using Negocio;

namespace GestionActividadFisica
{
    public partial class FormularioEvaluacionActividadFisica : Form
    {
        private IServicioEvaluacion servicioEvaluacion;
        private IServicioMaestro servicioMaestro;

        private string primerNombre;
        private string segundoNombre;
        private string primerApellido;
        private string segundoApellido;
        private Sexo sexo;
        private TipoDocumento tipoDocumento;
        private string numeroDocumento;
        private DateTime fechaNacimiento;

        private DateTime fechaEvaluacion;
        private bool antecedenteDiabetes;
        private bool antecedenteCancer;
        private Ciudad ciudadEvaluacion;
        private decimal peso;
        private decimal talla;
        private RegimenAfiliacion RegimenAfiliacion;
        private decimal presionSistolica;
        private decimal presionDiastolica;
        private decimal triceps;
        private decimal biceps;
        private decimal pliegueSubescapular;
        private decimal crestaIliaca;
        private decimal pliegueSupraespinal;
        private decimal pliegueAbdominal;
        private decimal pliegueMuslo;
        private decimal plieguePierna;
        private decimal perimetroCintura;
        private decimal perimetroCadera;
        private decimal perimetroPierna;
        private decimal diametroCodo;
        private decimal diametroRodilla;
        private decimal brazoDescansado;
        private decimal brazoTenso;

        public FormularioEvaluacionActividadFisica()
        {
            InitializeComponent();

            servicioEvaluacion = new ServicioEvaluacion();
            servicioMaestro = new ServicioMaestro();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                primerNombre = txtPrimerNombre.Text;
                segundoNombre = txtSegundoNombre.Text;
                primerApellido = txtPrimerApellido.Text;
                segundoApellido = txtSegundoApellido.Text;
                tipoDocumento = cboTipoDocumento.SelectedItem as TipoDocumento;
                numeroDocumento = txtNumeroDocumento.Text;
                fechaNacimiento = dtpFechaNacimiento.Value;
                sexo = rdbMasculino.Checked ?
                    new Sexo()
                    {
                        Id = (int)Entidades.Enumeraciones.Sexo.Masculino,
                        Nombre = "Masculino"
                    } :
                    new Sexo()
                    {
                        Id = (int)Entidades.Enumeraciones.Sexo.Femenino,
                        Nombre = "Femenino"
                    };

                fechaEvaluacion = dtpFechaEvaluacion.Value;
                antecedenteCancer = chkCancer.Checked;
                ciudadEvaluacion = cboCiudadEvaluacion.SelectedItem as Ciudad;
                decimal.TryParse(txtPeso.Text, out peso);
                decimal.TryParse(txtTalla.Text, out talla);
                decimal.TryParse(txtPresionSistolica.Text, out presionSistolica);
                decimal.TryParse(txtPresionDiastolica.Text, out presionDiastolica);
                decimal.TryParse(txtBiceps.Text, out biceps);
                decimal.TryParse(txtTriceps.Text, out triceps);
                decimal.TryParse(txtPliegueSubescapular.Text, out pliegueSubescapular);
                decimal.TryParse(txtCrestaIliaca.Text, out crestaIliaca);
                decimal.TryParse(txtPliegusupraespinal.Text, out pliegueSupraespinal);
                decimal.TryParse(txtPliegueAbdominal.Text, out pliegueAbdominal);
                decimal.TryParse(txtPliegueMuslo.Text, out pliegueMuslo);
                decimal.TryParse(txtPlieguePierna.Text, out plieguePierna);
                decimal.TryParse(txtPerimetroCintura.Text, out perimetroCintura);
                decimal.TryParse(txtPerimetroCadera.Text, out perimetroCadera);
                decimal.TryParse(txtPerimetroPierna.Text, out perimetroPierna);
                decimal.TryParse(txtDiametroCodo.Text, out diametroCodo);
                decimal.TryParse(txtDiametroRodilla.Text, out diametroRodilla);
                decimal.TryParse(txtBrazoDescansado.Text, out brazoDescansado);
                decimal.TryParse(txtBrazoTenso.Text, out brazoTenso);

                RegimenAfiliacion = new RegimenAfiliacion()
                {
                    Id = rdbContributivo.Checked ? (int)Entidades.Enumeraciones.CondicionEmocional.Alegre :
                         rdSubsidiado.Checked ? (int)Entidades.Enumeraciones.CondicionEmocional.Normal :
                         (int)Entidades.Enumeraciones.CondicionEmocional.Triste
                };

                var evaluacion = new Evaluacion()
                {
                    Persona = new Persona()
                    {
                        PrimerNombre = primerNombre,
                        SegundoNombre = segundoNombre,
                        PrimerApellido = primerApellido,
                        SegundoApellido = segundoApellido,
                        Sexo = sexo,
                        TipoDocumento = tipoDocumento,
                        NumeroDocumento = numeroDocumento,
                        FechaNacimiento = fechaNacimiento
                    },
                    Fecha = fechaEvaluacion,
                    Ciudad = ciudadEvaluacion,
                    AntecendenteCancer = antecedenteCancer,
                    AntecendenteDiabetes = antecedenteDiabetes,
                    Peso = peso,
                    Talla = talla,
                    RegimenAfiliacion = RegimenAfiliacion,
                    PresionSistolica = presionSistolica,
                    PresionDiastolica = presionDiastolica,
                };

                servicioEvaluacion.GuardarEvaluacion(evaluacion);

                var datos = @"Evaluación almacenada correctamente";

                MessageBox.Show(datos, "Datos", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Revise los datos ingresados", "Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarDatos()
        {
            bool datosCorrectos = true;

            erpError.SetError(txtPrimerNombre, null);
            erpError.SetError(txtPrimerApellido, null);
            erpError.SetError(cboTipoDocumento, null);
            erpError.SetError(txtNumeroDocumento, null);
            erpError.SetError(dtpFechaNacimiento, null);
            erpError.SetError(rdbMasculino, null);

            erpError.SetError(dtpFechaEvaluacion, null);
            erpError.SetError(cboCiudadEvaluacion, null);
            erpError.SetError(txtPeso, null);
            erpError.SetError(txtTalla, null);
            erpError.SetError(rdbContributivo, null);
            erpError.SetError(rdSubsidiado, null);
            erpError.SetError(txtPresionDiastolica, null);
            erpError.SetError(txtPresionSistolica, null);

            if (string.IsNullOrEmpty(txtPrimerNombre.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtPrimerNombre, "Debe ingresar el primer nombre");
            }

            if (cboTipoDocumento.SelectedItem == null)
            {
                datosCorrectos = false; erpError.SetError(cboTipoDocumento, "Debe seleccionar el tipo de documento");
            }

            if (string.IsNullOrEmpty(txtNumeroDocumento.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtNumeroDocumento, "Debe ingresar el número de documento");
            }

            if (dtpFechaNacimiento.Value > DateTime.Now)
            {
                datosCorrectos = false;
                erpError.SetError(dtpFechaNacimiento, "La fecha de nacimiento no debe ser mayor a la fecha actual");
            }

            if (!rdbMasculino.Checked && !rdbFemenino.Checked)
            {
                datosCorrectos = false;
                erpError.SetError(rdbMasculino, "Debe seleccionar el sexo");
            }

            if (dtpFechaEvaluacion.Value > DateTime.Now)
            {
                datosCorrectos = false;
                erpError.SetError(dtpFechaEvaluacion, "La fecha de evaluación no debe ser mayor a la fecha actual");
            }

            if (cboCiudadEvaluacion == null)
            {
                datosCorrectos = false; erpError.SetError(cboCiudadEvaluacion, "Debe seleccionar la ciudad de evaluación");
            }

            if (string.IsNullOrEmpty(txtPeso.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtPeso, "Debe ingresar el peso");
            }

            if (string.IsNullOrEmpty(txtTalla.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtTalla, "Debe ingresar la talla");
            }

            if (!rdbContributivo.Checked && !rdSubsidiado.Checked && !rdbTriste.Checked)
            {
                datosCorrectos = false;
                erpError.SetError(rdbContributivo, "Debe indicar el Regimen de Afiliacion");
            }
            if (string.IsNullOrEmpty(txtPresionSistolica.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtPresionSistolica, "Debe ingresar el valor de su Presion Arterial Sistolica en mmHg");
            }
            if (string.IsNullOrEmpty(txtPresionDiastolica.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtPresionDiastolica, "Debe ingresar el valor de su Presion Arterial Diastolica en mmHg");
            }
            if (string.IsNullOrEmpty(txtTriceps.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtTriceps, "Debe ingresar la medida del Pliegue de su Triceps en Mm");
            }
            if (string.IsNullOrEmpty(txtBiceps.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtBiceps, "Debe ingresar la medida del Pliegue de su Biceps en Mm");
            }
            if (string.IsNullOrEmpty(txtPliegueSubescapular.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtPliegueSubescapular, "Debe ingresar la medida del Pliegue Subescapular en Mm");
            }
            if (string.IsNullOrEmpty(txtCrestaIliaca.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtCrestaIliaca, "Debe ingresar la medida del Pliegue de su Cresta Iliaca en Mm");
            }
            if (string.IsNullOrEmpty(txtPliegusupraespinal.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtPliegusupraespinal, "Debe ingresar la medida del Pliegue Supraespinal en Mm");
            }
            if (string.IsNullOrEmpty(txtPliegueAbdominal.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtPliegueAbdominal, "Debe ingresar la medida de su Pliegue de su Abdominal en Mm");
            }
            if (string.IsNullOrEmpty(txtPliegueMuslo.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtPliegueMuslo, "Debe ingresar la medida del Pliegue de su Muslo en Mm");
            }
            if (string.IsNullOrEmpty(txtPlieguePierna.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtPlieguePierna, "Debe ingresar la medida del Pliegue de su Pierna en Mm");
            }
            if (string.IsNullOrEmpty(txtPerimetroCintura.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtPerimetroCintura, "Debe ingresar la medida del Perimetro de su Cintura en Cm");
            }
            if (string.IsNullOrEmpty(txtPerimetroCadera.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtPerimetroCadera, "Debe ingresar la medida del Perimetro de su Cadera en Cm");
            }
            if (string.IsNullOrEmpty(txtPerimetroPierna.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtPerimetroPierna, "Debe ingresar la medida del Perimetro de su Pierna en Cm");
            }
            if (string.IsNullOrEmpty(txtDiametroCodo.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtDiametroCodo, "Debe ingresar la medida del Diametro de su Codo en Cm");
            }
            if (string.IsNullOrEmpty(txtDiametroRodilla.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtDiametroRodilla, "Debe ingresar la medida del Diametro de su Rodilla en Cm");
            }
            if (string.IsNullOrEmpty(txtBrazoDescansado.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtBrazoDescansado, "Debe ingresar el valor de Pliegue de Brazo con su Brazo Descansado en Mm");
            }
            if (string.IsNullOrEmpty(txtBrazoTenso.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtBrazoTenso, "Debe ingresar el valor de Pliegue de Brazo con su Brazo Tenso en Mm");
            }
            if (string.IsNullOrEmpty(txtTestWells.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtTestWells, "Debe ingresar el valor obtenido en el Test de Wells en cm");
            }
            if (string.IsNullOrEmpty(txtSaltoHorizontal.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtSaltoHorizontal, "Debe ingresar el valor Obtenido en el Test de Salto Horizontal en cm");
            }
            if (string.IsNullOrEmpty(txtTestVelocidad.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtTestVelocidad, "Debe ingresar el valor de su Puntaje en el Test de Velocidad 20m en segundos");
            }
            if (string.IsNullOrEmpty(txtSaltoVertical.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtSaltoVertical, "Debe ingresar el valor obtenido en el Test de Salto Vertical en cm");
            }
            if (string.IsNullOrEmpty(txtTestAgilidad.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtTestAgilidad, "Debe ingresar el valor obtenido en el Test de Agilidad en Segundos");
            }
            if (string.IsNullOrEmpty(txtTesAbdominales.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtTesAbdominales, "Debe ingresar el numero de abdominales ");
            }
            if (string.IsNullOrEmpty(txtTestPushUp.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtTestPushUp, "Debe ingresar el valor en el test de Push Up");
            }
            if (string.IsNullOrEmpty(txtPesoBarra.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtPesoBarra, "Debe ingresar el Peso de la Barra en Kg");
            }
            if (string.IsNullOrEmpty(txtPesoTotal.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtPesoTotal, "Debe ingresar el peso total en el Test en Kg");
            }
            if (string.IsNullOrEmpty(txtNroRepeticionesVelocidad.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtNroRepeticionesVelocidad, "Debe ingresar el numero de repeticiones en el Test de Velocidad de 20m");
            }
            if (string.IsNullOrEmpty(txtManoDerechaDinamometria.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtManoDerechaDinamometria, "Debe ingresar el valor de Mano Derecha en el Test de Dinamometria en Kg");
            }
            if (string.IsNullOrEmpty(txtManoIzquierdaDinamometria.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtManoIzquierdaDinamometria, "Debe ingresar el valor de Mano Izquierda en el Test de Dinamometria en Kg");
            }
            if (string.IsNullOrEmpty(txtIntentosTestSentadilla.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtIntentosTestSentadilla, "Debe ingresar el numero de intentos en el Test de Sentadilla");
            }
            if (string.IsNullOrEmpty(txtRepeticionesTestSentadilla.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtRepeticionesTestSentadilla, "Ingrese el numero de Repeticiones en el Test de Sentadilla");
            }
            if (string.IsNullOrEmpty(txtPuntajeResistenciaGeneral.Text))
            {
                datosCorrectos = false;
                erpError.SetError(txtPuntajeResistenciaGeneral, "Ingrese el puntaje de su resistencia General");
            }
            return datosCorrectos;
        }

        private void FormularioEvaluacionActividadFisica_Load(object sender, EventArgs e)
        {
            cboTipoDocumento.DisplayMember = "Nombre";
            cboTipoDocumento.DataSource = servicioMaestro.ObtenerTiposDocumento();

            cboCiudadEvaluacion.DisplayMember = "Nombre";
            cboCiudadEvaluacion.DataSource = servicioMaestro.ObtenerCiudades();
        }

        private void txtTalla_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }

        private void txtPlieguSupraespinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtPresionSistolica_Keypress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtPresionDiastolica_Keypress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtPliegueTriceps_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtBiceps_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtPliegueSubescapular_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtCrestaIliaca_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtPliegueAbdominal_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtPliegueMuslo_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtPlieguePierna_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtPerimetroCintura_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtPerimetroCadera_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtPerimetroPierna_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtDiametroCodo_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtDiametroRodilla_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtBrazoDescansado_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtBrazoTenso_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtTestWells_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtSaltoHorizontal_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtTestVelocidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtSaltoVertical_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtTestAgilidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtTestAbdominales_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtPushUp_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtPesoBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtPesoTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtNroRepeticionesVelocidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtManoDerechaDinamometria_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtManoIzquierdaDinamometria_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtIntestosTestSentadilla_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtRepeticionesTestSentadilla_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void txtPuntajeResistenciaGeneral_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != ',' && caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
