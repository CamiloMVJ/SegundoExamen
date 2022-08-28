namespace SegundoExamen
{
    public partial class Form1 : Form
    {
        int cNiño, cAdulto, cTercera;


        private void buttRegistrar_Click(object sender, EventArgs e)
        {
            double tNiño = 0, tAdulto = 0, tTercera = 0;
            String rangoEdad = txtRangoEdad.Text;
            int cantidad = int.Parse(txtCantidad.Text);
            String categoria = txtCategoria.Text;
            double precio = double.Parse(txtPrecio.Text);
            double descuento = 0;
            double subtotal;
            double totalSinDes = 0;
            switch (categoria)
            {
                case "Niño": descuento = 0.2; cNiño += cantidad; break;
                case "Adulto": descuento = 0.05; cAdulto += cantidad; break;
                case "Tercera edad": descuento = 0.1; cTercera += cantidad; break;
            }
            subtotal = (cantidad * precio) - (descuento * (cantidad * precio));
            ListViewItem info = new ListViewItem(categoria);
            info.SubItems.Add(cantidad.ToString());
            info.SubItems.Add(precio.ToString());
            info.SubItems.Add((precio * cantidad).ToString());
            info.SubItems.Add((descuento * 100).ToString());
            info.SubItems.Add(subtotal.ToString());
            lvDatos.Items.Add(info);


            for (int i = 0; i < lvDatos.Items.Count; i++)//Importe
            {
                if (lvDatos.Items[i].SubItems[0].Text != "")
                {
                    if (lvDatos.Items[i].SubItems[0].Text == "Niño")
                        tNiño += double.Parse(lvDatos.Items[i].SubItems[5].Text);
                    if (lvDatos.Items[i].SubItems[0].Text == "Adulto")
                        tAdulto += double.Parse(lvDatos.Items[i].SubItems[5].Text);
                    if (lvDatos.Items[i].SubItems[0].Text == "Tercera edad")
                        tTercera += double.Parse(lvDatos.Items[i].SubItems[5].Text);
                }
            }
            lvEstadisticas.Items.Clear();
            String[] estadisticas = new string[4];
            ListViewItem fila;
            estadisticas[0] = "Boletos para niños";
            estadisticas[1] = cNiño.ToString();
            estadisticas[2] = tNiño.ToString();
            estadisticas[3] = ((tNiño * 100 / 80) - tNiño).ToString();
            fila = new ListViewItem(estadisticas);
            lvEstadisticas.Items.Add(fila);

            estadisticas[0] = "Boletos para adultos";
            estadisticas[1] = cAdulto.ToString();
            estadisticas[2] = tAdulto.ToString();
            estadisticas[3] = ((tAdulto * 100 / 95) - tAdulto).ToString();
            fila = new ListViewItem(estadisticas);
            lvEstadisticas.Items.Add(fila);

            estadisticas[0] = "Boletos para tercera edad";
            estadisticas[1] = cTercera.ToString();
            estadisticas[2] = tTercera.ToString();
            estadisticas[3] = ((tTercera * 100 / 90) - tTercera).ToString();
            fila = new ListViewItem(estadisticas);
            lvEstadisticas.Items.Add(fila);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            String rango = txtRangoEdad.Text;
            switch (rango)
            {
                case "03-12": txtCategoria.Text = "Niño"; txtPrecio.Text = "10"; break;
                case "13-59": txtCategoria.Text = "Adulto"; txtPrecio.Text = "25"; break;
                case ">60": txtCategoria.Text = "Tercera edad"; txtPrecio.Text = "15"; break;
            }
        }
        private void buttSalir_Click(object sender, EventArgs e)
        {
            DialogResult salir = MessageBox.Show("¿Esta seguro que quiere salir?", "Control de boletos", MessageBoxButtons.YesNo,
                                                                                                        MessageBoxIcon.Question);
            if (salir == DialogResult.Yes)
                this.Close();
        }
    }
}