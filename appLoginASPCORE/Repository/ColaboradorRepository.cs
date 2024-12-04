using appLoginASPCORE.Models;
using appLoginASPCORE.Models.Constants;
using appLoginASPCORE.Repository.Contract;
using MySql.Data.MySqlClient;
using System.Data;

namespace appLoginASPCORE.Repository
{
    public class ColaboradorRepository : IColaboradorRepository
    {

        private readonly string _conexaoMySQL;

        public ColaboradorRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }
        public void Atualizar(Colaborador colaborador)
        {
            string Tipo = ColaboradorTipoConstant.Comum;
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("update Colaborador set Nome = @Nome, Email = @Email, Senha = @Senha, Tipo = @Tipo where Id = @Id ", conexao);

                cmd.Parameters.Add("@Id", MySqlDbType.VarChar).Value = colaborador.Id;
                cmd.Parameters.Add("@Nome   ", MySqlDbType.VarChar).Value = colaborador.Nome;
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = colaborador.Email;
                cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = colaborador.Senha;
                cmd.Parameters.Add("@Tipo", MySqlDbType.VarChar).Value = colaborador.Tipo;
            }
        }

        public void AtualizarSenha(Colaborador colaborador)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Colaborador colaborador)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into Colaborador (Nome, Email, Senha, Tipo) " + " values (Nome, @Email, @Senha, @Tipo) ", conexao);


                cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = colaborador.Nome;
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = colaborador.Email;
                cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = colaborador.Senha;
                cmd.Parameters.Add("@Tipo", MySqlDbType.VarChar).Value = colaborador.Tipo;

                cmd.ExecuteNonQuery();
                conexao.Close();    
            }
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public Colaborador Login(string Email, string Senha)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("Select * from Colaborador where Email = @Email and Senha = @Senha", conexao);

                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = Email;
                cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = Senha;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Colaborador colaborador = new Colaborador();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    colaborador.Id = (Int32)(dr["id"]);
                    colaborador.Nome = (string)(dr["Nome"]);
                    colaborador.Email = (string)(dr["Email"]);
                    colaborador.Senha = (string)(dr["Senha"]);
                    colaborador.Tipo = (string)(dr["Tipo"]);
                }
                return colaborador;
            }
        }

        public Colaborador ObterColaborador(int id)
        {
            using (var conexao =  new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Colaborador where Id=@Id", conexao);
                cmd.Parameters.AddWithValue("@Id", id);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                MySqlDataReader dr;

                Colaborador colaborador = new Colaborador();

                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    colaborador.Id = (Int32)(dr["id"]);
                    colaborador.Nome = (string)(dr["Nome"]);
                    colaborador.Nome = (string)(dr["Email"]);
                    colaborador.Nome = (string)(dr["Senha"]);
                    colaborador.Nome = (string)(dr["Tipo"]);
                }
                return colaborador;
            }
        }

        public List<Colaborador> ObterColaboradorPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Colaborador> ObterTodosColaborados()
        {
            List<Colaborador> colablist = new List<Colaborador>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from colaborador", conexao);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                conexao.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    colablist.Add(
                        new Colaborador
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            Nome = (string)(dr["Nome"]),
                            Email = (string)(dr["Email"]),
                            Tipo= (string)(dr["Tipo"]),
                            Senha = (string)(dr["Senha"]),
                        });
                }
                return colablist;
            }
        }
    }
}
