﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.Entidades;

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class Cabinas : Form
    {
        Viaje viaje;
        
        public Cabinas(Int32 idViaje)
        {
            InitializeComponent();
            this.viaje = (new SQL.SqlViaje()).getViaje(idViaje);
            List<Cabina> cabinas = (new SQL.SqlViaje()).buscarCabinasDisponibles(idViaje);
            DataTable tablaCabinas = new DataTable();
            tablaCabinas.Columns.Add("codCabina");
            tablaCabinas.Columns.Add("Piso");
            tablaCabinas.Columns.Add("Numero");
            tablaCabinas.Columns.Add("codTipo");
            tablaCabinas.Columns.Add("Tipo de cabina");

            grilla.DataSource = tablaCabinas;
            grilla.Columns["codCabina"].Visible = false;
            grilla.Columns["codTipo"].Visible = false;

            foreach (Cabina cabina in cabinas)
            {
                tablaCabinas.Rows.Add(new Object[] { 
                    cabina.codCabina, 
                    cabina.piso, 
                    cabina.numero, 
                    cabina.codTipo, 
                    cabina.tipoCabina().nombre
                });
            }
        }
    }
}
