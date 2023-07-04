using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeiroProjetoWF
{
    public partial class TelaCadastro : Form
    {
        public TelaCadastro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexao db = new Conexao();
            db.Conectar();

            Aluno aluno = new Aluno();
            Usuario usuario = new Usuario();
            aluno.Nome = textBox1.Text;
            aluno.Idade = int.Parse(textBox2.Text);
            aluno.DataNascimento = DateTime.Parse(textBox3.Text);
            aluno.Sexo = textBox4.Text;
            aluno.Telefone = textBox5.Text;
            usuario.Senha = textBox6.Text;
            usuario.Email = textBox7.Text;
            aluno.Curso = comboBox1.Text;

            var retorno = db.CadastrarUsuario(usuario, aluno);

            MessageBox.Show(retorno);

            this.Hide();
        }
    }
}