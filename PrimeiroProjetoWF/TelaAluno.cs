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
    public partial class TelaAluno : Form
    {
        public TelaAluno()
        {
            InitializeComponent();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void TelaAluno_Load(object sender, EventArgs e)
        {
            Conexao db = new Conexao();
            db.Conectar();
            var alunos = db.BuscarAlunos();
            dataGridView1.DataSource = alunos;
        }
    }
}