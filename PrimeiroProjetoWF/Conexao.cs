using System.Data;
using System.Data.SqlClient;

namespace PrimeiroProjetoWF
{
    public class Conexao
    {
        public SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=JovemProgramador;Data Source=WIN-ECVB8NSIDFL\\SQLEXPRESS");
        public void Conectar()
        {
            conn.Open();
        }
        public void Desconectar()
        {
            conn.Close();
        }

        public bool BuscarUsuario(string Email, string Senha)
        {
            string sql = $"SELECT * FROM Usuario WHERE Email = '{Email}' and senha = '{Senha}'";
            SqlCommand comando = new SqlCommand(sql, conn);

            var retorno = comando.ExecuteReader();

            if (retorno.Read())
                return true;

            return false;
        }
        public List<Aluno> BuscarAlunos()
        {
            string sql = "select Nome, Idade, DataNascimento, Sexo, Telefone, Curso from Aluno";
            SqlCommand comando = new SqlCommand(sql, conn);

            List<Aluno> aluno = new List<Aluno>();

            using (var reader = comando.ExecuteReader())
            {
                //cria um leitor do ADO.Net
                while (reader.Read())
                {
                    //vai lendo cada item do resultado do select
                    //retorna sob demanda cada item encontrado
                    var nomeDb = reader.GetString(reader.GetOrdinal("Nome"));
                    var idadeDb = reader.GetInt32(reader.GetOrdinal("Idade"));
                    var dataNascimentoDb = reader.GetDateTime(reader.GetOrdinal("DataNascimento"));
                    var sexoDb = reader.GetString(reader.GetOrdinal("Sexo"));
                    var telefoneDb = reader.GetString(reader.GetOrdinal("Telefone"));
                    var cursoDb = reader.GetString(reader.GetOrdinal("Curso"));

                    aluno.Add(new Aluno()
                    {
                        Nome = nomeDb,
                        Idade = idadeDb,
                        DataNascimento = dataNascimentoDb,
                        Sexo = sexoDb,
                        Telefone = telefoneDb,
                        Curso = cursoDb,
                    });
                }
                return aluno;
            }
        }
        public string CadastrarUsuario(Usuario usuario, Aluno aluno)
        {
            string sql = $"INSERT INTO Usuario (Email, Senha) VALUES ('{usuario.Email}', '{usuario.Senha}')"
                + $"INSERT INTO Aluno (Nome, Idade, DataNascimento, Sexo, Telefone, Curso) VALUES ('{aluno.Nome}', '{aluno.Idade}', '{aluno.DataNascimento}', '{aluno.Sexo}', '{aluno.Telefone}', '{aluno.Curso}')";
            SqlCommand comando = new SqlCommand(sql, conn);

            comando.ExecuteNonQuery();

            return "Aluno cadastrado com sucesso!";
        }
    }
}