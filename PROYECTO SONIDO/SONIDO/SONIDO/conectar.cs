using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace SONIDO
{
    class conectar
    {
        public static String cadConexion = "Server=localhost;Database=faraon;Uid=root;Pwd=1234";
        static MySqlConnection conexion = new MySqlConnection(cadConexion);



        //Registrar una nuevo Paquetes

        public static int Registrar(String Nombre, String Costo, String Descripcion)
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            MySqlCommand registrarPaquetes = new MySqlCommand("insert into paquetes values(0, @Nombre, @Costo, @Descripción)", conexion);
            registrarPaquetes.Parameters.AddWithValue("@Nombre", Nombre);
            registrarPaquetes.Parameters.AddWithValue("@Costo", Costo);
            registrarPaquetes.Parameters.AddWithValue("@DescripciÓn", Descripcion);

            int rA = 0;
            try
            {
      
                rA = registrarPaquetes.ExecuteNonQuery();
                
               
            }
            catch (Exception e)
            {

            }
            conexion.Close();
            return rA;
        }



        //Metodo para cargar los id de los paquetes

        public static void listarPaquetes(ComboBox NComboBox)
        {
            conexion.Open();
            MySqlDataAdapter LlenarC = new MySqlDataAdapter("select id_paq from paquetes", conexion);
            DataSet TablaId = new DataSet();
            LlenarC.Fill(TablaId);
            NComboBox.DataSource = TablaId.Tables[0];
            NComboBox.DisplayMember = "id_paq";
            conexion.Close();
        }
        //Localizar Datos de los paquetes

        public static String[] BuscarPaquetes(int id)
        {
            String[] DatosPaquetes = new String[3];
            conexion.Open();

            MySqlCommand DatosP = new MySqlCommand("select * from paquetes where id_paq=@id", conexion);
            DatosP.Parameters.AddWithValue("@id", id);
            MySqlDataReader DatosEncontradosPaquetes = DatosP.ExecuteReader();
            if (DatosEncontradosPaquetes.Read())
            {
                DatosPaquetes[0] = DatosEncontradosPaquetes["Nombre"].ToString();
                DatosPaquetes[1] = DatosEncontradosPaquetes["Costo"].ToString();
                DatosPaquetes[2] = DatosEncontradosPaquetes["DescripciÓn"].ToString();
            }
            conexion.Close();
            return DatosPaquetes;
        }

        //metodo para modificar Paquetes
        public static int modificarPaquetes(int id_paq, string Nombre, string Costo, string Descripción)
        {
            conexion.Open();
            MySqlCommand actualizarPaquetes = new MySqlCommand("update paquetes set Nombre=@Nombre,Costo=@Costo, Descripción=@Descripción where id_paq=@id_paq", conexion);

            actualizarPaquetes.Parameters.AddWithValue("@Nombre", Nombre);
            actualizarPaquetes.Parameters.AddWithValue("@Costo", Costo);
            actualizarPaquetes.Parameters.AddWithValue("@Descripción", Descripción);
            actualizarPaquetes.Parameters.AddWithValue("@id_paq", id_paq);

            int actualizado = actualizarPaquetes.ExecuteNonQuery();
            conexion.Close();
            return actualizado;


        }

    }


}

