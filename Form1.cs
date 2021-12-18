using CriptografiaSimetricaAndAssimetrica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desafio03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Cadastrar(object sender, EventArgs e)
        {
            Simetrica a = new Simetrica();

            if (!string.IsNullOrWhiteSpace(Nome.Text) && !string.IsNullOrWhiteSpace (Email.Text) && Senha.Text == Repetirsenha.Text)
            {
                var db = new BandoDados();
                var sqlCommand = new SqlCommand();
                sqlCommand.CommandText = @"INSERT INTO [dbo].[Usuario]([nome],[email],[senha])VALUES (@nome, @email, @senha); SELECT SCOPE_IDENTITY(); ";
                sqlCommand.Parameters.AddWithValue("@nome", Nome.Text);
                sqlCommand.Parameters.AddWithValue("@email", Email.Text);
                sqlCommand.Parameters.AddWithValue("@senha", a.EncryptData(Senha.Text, "123"));
                db.Executar(sqlCommand);
                MessageBox.Show("Cadastrado com sucesso!");
            }
            else
            {
                MessageBox.Show("As informações estão incorretas. Tente novamente!");

            }

        }

        private void Acessar(object sender, EventArgs e)
        {
            Simetrica a = new Simetrica();

            var db = new BandoDados();
            var sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"select * from Usuario where email = @email and senha = @senha ";
            sqlCommand.Parameters.AddWithValue("@email", emaillogin.Text);
            sqlCommand.Parameters.AddWithValue("@senha", a.EncryptData(senhalogin.Text, "123"));

            if ((db.Consulta(sqlCommand).Rows.Count==0))

            {
                MessageBox.Show("As informações estão incorretas. Tente novamente!");

            }

            else
            {
                MessageBox.Show("Logado com sucesso!");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var db = new BandoDados();
            var sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"select * from Usuario";
            dataGridView1.DataSource = db.Consulta(sqlCommand);

        }
    }
}
