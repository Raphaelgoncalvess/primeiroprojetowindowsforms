namespace PrimeiroProjetoWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Conectar com o banco de dados
            Conexao db = new Conexao();
            db.Conectar();

            Usuario usuario = new Usuario();
            usuario.Email = textBox1.Text;
            usuario.Senha = textBox2.Text;

            //Buscar usuário e senha do banco de dados
            var retorno = db.BuscarUsuario(usuario.Email, usuario.Senha);

            if (!retorno)
                MessageBox.Show("Email ou senha incorreto!");

            if (retorno)
            {
                MessageBox.Show("Bem vindo!");

                TelaAluno telaaluno = new TelaAluno();
                telaaluno.Show();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TelaCadastro telacadastro = new TelaCadastro();
            telacadastro.Show();
        }
    }
}