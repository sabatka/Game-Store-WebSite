using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Site_TrabalhoM17
{
    public class BaseDados
    {
        private static BaseDados instance;
        public static BaseDados Instance
        {
            get
            {
                if (instance == null)
                    instance = new BaseDados();
                return instance;
            }
        }
        private string strLigacao;
        private SqlConnection ligacaoBD;
        public BaseDados()
        {
            //ligação à bd
            strLigacao = ConfigurationManager.ConnectionStrings["sql"].ToString();
            ligacaoBD = new SqlConnection(strLigacao);
            ligacaoBD.Open();
        }
        ~BaseDados()
        {
            try
            {
                ligacaoBD.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #region Funções genéricas

        public DataTable DevolveConsulta(string sql)
        {
            SqlCommand comando = new SqlCommand(sql, ligacaoBD);
            DataTable registos = new DataTable();
            SqlDataReader dados = comando.ExecuteReader();
            registos.Load(dados);
            registos.Dispose();
            comando.Dispose();
            return registos;
        }
        public DataTable DevolveConsulta(string sql, List<SqlParameter> parametros)
        {
            SqlCommand comando = new SqlCommand(sql, ligacaoBD);
            DataTable registos = new DataTable();
            comando.Parameters.AddRange(parametros.ToArray());
            SqlDataReader dados = comando.ExecuteReader();
            registos.Load(dados);
            registos.Dispose();
            comando.Dispose();
            return registos;
        }


        public DataTable DevolveConsulta(string sql, List<SqlParameter> parametros, SqlTransaction transacao)
        {
            SqlCommand comando = new SqlCommand(sql, ligacaoBD);
            comando.Transaction = transacao;
            DataTable registos = new DataTable();
            comando.Parameters.AddRange(parametros.ToArray());
            SqlDataReader dados = comando.ExecuteReader();
            registos.Load(dados);
            registos.Dispose();
            comando.Dispose();
            return registos;
        }

        //executar comando
        public bool ExecutaComando(string sql)
        {
            try
            {
                SqlCommand comando = new SqlCommand(sql, ligacaoBD);
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception erro)
            {
                Debug.WriteLine(erro.Message);
                return false;
            }
            return true;
        }
        public bool ExecutaComando(string sql, List<SqlParameter> parametros)
        {
            try
            {
                SqlCommand comando = new SqlCommand(sql, ligacaoBD);
                comando.Parameters.AddRange(parametros.ToArray());
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception erro)
            {
                Console.Write(erro.Message);
                //throw erro;
                return false;
            }
            return true;
        }
        public bool ExecutaComando(string sql, List<SqlParameter> parametros, SqlTransaction transacao)
        {
            try
            {
                SqlCommand comando = new SqlCommand(sql, ligacaoBD);
                comando.Parameters.AddRange(parametros.ToArray());
                comando.Transaction = transacao;
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception erro)
            {
                Console.Write(erro.Message);
                return false;
            }
            return true;
        }
        #endregion
        #region utilizadores
        public bool RegistarUtilizador(string nome, string email, string password, string morada, string nif)
        {
            string sql = "INSERT INTO Utilizadores(nome,email,password,morada,nif,estado,perfil) ";
            sql += "VALUES (@nome,@email,HASHBYTES('SHA2_512',@password),@morada,@nif,@estado,@perfil)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=SqlDbType.VarChar,Value=nome },
                new SqlParameter() {ParameterName="@email",SqlDbType=SqlDbType.VarChar,Value=email },
                new SqlParameter() {ParameterName="@password",SqlDbType=SqlDbType.VarChar,Value=password },
                new SqlParameter() {ParameterName="@morada",SqlDbType=SqlDbType.VarChar,Value=morada },
                new SqlParameter() {ParameterName="@nif",SqlDbType=SqlDbType.VarChar,Value=nif },
                new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value=1 },
                new SqlParameter() {ParameterName="perfil",SqlDbType=SqlDbType.Int,Value=1 },
            };
            return ExecutaComando(sql, parametros);
        }
        public bool RegistarUtilizador(string nome, string email, string password, string morada, string nif, int perfil)
        {
            string sql = "INSERT INTO Utilizadores(nome,email,password,morada,nif,estado,perfil) ";
            sql += "VALUES (@nome,@email,HASHBYTES('SHA2_512',@password),@morada,@nif,@estado,@perfil)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=SqlDbType.VarChar,Value=nome },
                new SqlParameter() {ParameterName="@email",SqlDbType=SqlDbType.VarChar,Value=email },
                new SqlParameter() {ParameterName="@password",SqlDbType=SqlDbType.VarChar,Value=password },
                new SqlParameter() {ParameterName="@morada",SqlDbType=SqlDbType.VarChar,Value=morada },
                new SqlParameter() {ParameterName="@nif",SqlDbType=SqlDbType.VarChar,Value=nif },
                new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value=1 },
                new SqlParameter() {ParameterName="perfil",SqlDbType=SqlDbType.Int,Value=1 },
            };
            return ExecutaComando(sql, parametros);
        }
        public bool RegistarUtilizador(string nome, string email, string password, string morada, string nif, int estado, int perfil)
        {
            string sql = "INSERT INTO Utilizadores(nome,email,password,morada,nif,estado,perfil) ";
            sql += "VALUES (@nome,@email,HASHBYTES('SHA2_512',@password),@morada,@nif,@estado,@perfil)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=SqlDbType.VarChar,Value=nome },
                new SqlParameter() {ParameterName="@email",SqlDbType=SqlDbType.VarChar,Value=email },
                new SqlParameter() {ParameterName="@password",SqlDbType=SqlDbType.VarChar,Value=password },
                new SqlParameter() {ParameterName="@morada",SqlDbType=SqlDbType.VarChar,Value=morada },
                new SqlParameter() {ParameterName="@nif",SqlDbType=SqlDbType.VarChar,Value=nif },
                new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value=estado},
                new SqlParameter() {ParameterName="perfil",SqlDbType=SqlDbType.Int,Value=perfil}
            };
            return ExecutaComando(sql, parametros);
        }
        public void AtualizarUtilizador(int id, string nome, string email, string morada, string nif)
        {
            string sql = @"UPDATE utilizadores SET email=@email,nome=@nome,morada=@morada,nif=@nif 
                            WHERE id=@id";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@email",SqlDbType=SqlDbType.VarChar,Value=email },
                new SqlParameter() {ParameterName="@nome",SqlDbType=SqlDbType.VarChar,Value=nome },
                new SqlParameter() {ParameterName="@morada",SqlDbType=SqlDbType.VarChar,Value=morada },
                new SqlParameter() {ParameterName="@nif",SqlDbType=SqlDbType.VarChar,Value=nif },
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id },
            };
            ExecutaComando(sql, parametros);
        }
        public DataTable DevolveDadosUtilizador(int id)
        {
            string sql = "SELECT * FROM utilizadores WHERE id=@id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id }
            };
            DataTable dados = DevolveConsulta(sql, parametros);
            return dados;
        }
        public int EstadoUtilizador(int id)
        {
            string sql = "SELECT estado FROM utilizadores WHERE id=@id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id }
            };
            DataTable dados = DevolveConsulta(sql, parametros);
            return int.Parse(dados.Rows[0][0].ToString());
        }
        public void AtivarDesativarUtilizador(int id)
        {
            int estado = EstadoUtilizador(id);
            if (estado == 0) estado = 1;
            else estado = 0;
            string sql = "UPDATE utilizadores SET estado = @estado WHERE id=@id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Bit,Value=estado },
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id }
            };
            ExecutaComando(sql, parametros);
        }
        public DataTable VerificarLogin(string email, string password)
        {
            string sql = "SELECT * FROM Utilizadores WHERE email=@email AND ";
            sql += "password=HASHBYTES('SHA2_512',@password) AND estado=1";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@email",SqlDbType=SqlDbType.VarChar,Value=email },
                new SqlParameter() {ParameterName="@password",SqlDbType=SqlDbType.VarChar,Value=password }
            };
            DataTable utilizador = DevolveConsulta(sql, parametros);
            if (utilizador == null || utilizador.Rows.Count == 0)
                return null;
            return utilizador;
        }

        public DataTable ListaUtilizadoresDisponiveis()
        {
            string sql = "SELECT id,nome,email,morada,nif,estado,perfil FROM utilizadores where perfil=1";
            return DevolveConsulta(sql);
        }
        public DataTable ListaTodosUtilizadores()
        {
            string sql = "SELECT id, email,nome, morada, nif,  estado, perfil FROM utilizadores";
            return DevolveConsulta(sql);
        }
        public bool RemoverUtilizador(int id)
        {
            string sql = "DELETE FROM Utilizadores WHERE id=@id";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value= id},
            };
            return ExecutaComando(sql, parametros);
        }
        public void RecuperarPassword(string email, string guid)
        {
            string sql = "UPDATE utilizadores set linkRecuperar=@link WHERE email=@email";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@email",SqlDbType=SqlDbType.NVarChar,Value=email },
                new SqlParameter() {ParameterName="@link",SqlDbType=SqlDbType.NVarChar,Value=guid },
            };
            ExecutaComando(sql, parametros);
        }
        public void AtualizarPassword(string guid, string password)
        {
            string sql = "UPDATE Utilizadores SET password=HASHBYTES('SHA2_512',@password),estado=1,linkRecuperar=null WHERE linkRecuperar=@link";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@password",SqlDbType=SqlDbType.VarChar,Value=password},
                new SqlParameter() {ParameterName="@link",SqlDbType=SqlDbType.VarChar,Value=guid },
            };
            ExecutaComando(sql, parametros);
        }

        public DataTable DevolveDadosUtilizador(string email)
        {
            string sql = "SELECT * FROM utilizadores WHERE email=@email";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@email",SqlDbType=SqlDbType.NVarChar,Value=email }
            };
            DataTable dados = DevolveConsulta(sql, parametros);
            return dados;
        }
        #endregion

        #region livros
        public DataTable PesquisaJogosPeloNome(string nome)
        {

            string sql = "SELECT * FROM Jogos WHERE nome like @jogo";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@jogo",SqlDbType=SqlDbType.NVarChar,Value="%"+nome+"%"}
            };
            return DevolveConsulta(sql, parametros);
        }
        public DataTable ListaJogos()
        {
            string sql = "SELECT * FROM Jogos";
            return DevolveConsulta(sql);
        }
        public DataTable ListaJogosDisponiveis()
        {
            string sql = "SELECT * FROM Jogos WHERE estado=1";
            return DevolveConsulta(sql);
        }
        public DataTable DevolveDadosJogo(int id_jogo)
        {
            string sql = "SELECT * FROM Jogos WHERE id_jogo=@id_jogo";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id_jogo",SqlDbType=SqlDbType.Int,Value=id_jogo }
            };
            return DevolveConsulta(sql,parametros);
        }
        public DataTable ListaLivrosComPrecoInferior(int id_jogo)
        {
            string sql = "SELECT * FROM Jogos where preco<=(select preco from jogos where id_jogo=@id_jogo)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id_jogo",SqlDbType=SqlDbType.Int,Value=id_jogo }
            };
            return DevolveConsulta(sql, parametros);
        }

        public void Compra(string produtos, int id_utilizador)
        {
            string produtosSemBug = produtos.Remove(produtos.Length - 1);
            string[] produtosArray = produtosSemBug.Split(',');

            foreach (var item in produtosArray)
            {
                RemoveStock(int.Parse(item));
            }
            string sql = "INSERT INTO Compras(id_utilizador,produtos) VALUES (@id_utilizador,@produtos)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id_utilizador",SqlDbType=SqlDbType.Int,Value=id_utilizador },
                new SqlParameter() {ParameterName="@produtos",SqlDbType=SqlDbType.NVarChar,Value=produtosSemBug }
            };
            ExecutaComando(sql, parametros);
        }

        public DataTable GetProdutosCarrinho(int id)
        {
            string sql = "SELECT * FROM Jogos WHERE id_jogo = @id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id}
            };
            DataTable dados = DevolveConsulta(sql, parametros);
            return dados;
        }

        public void RemoveStock(int id)
        {
            DataTable dados = DevolveDadosJogo(id);

            int stock = int.Parse(dados.Rows[0]["stock"].ToString()) - 1;
            string sql = "UPDATE Jogos SET stock=@stock WHERE id_jogo=@id";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value= id},
                new SqlParameter() {ParameterName="@stock",SqlDbType=SqlDbType.Int,Value= stock}
            };
            ExecutaComando(sql, parametros);
        }

        public int AdicionarJogo(string nome, decimal preco, string descricao, decimal avaliacao, string so, string empresa, int stock, int ano, int estado,string tag)
        {
            string sql = "INSERT INTO Jogos (nome,preco,descricao,avaliacao,sistema_operativo,empresa,stock,ano,estado) VALUES ";
            sql += "(@nome,@preco,@descricao,@avaliacao,@so,@empresa,@stock,@ano,@estado,@tag);SELECT CAST(SCOPE_IDENTITY() AS INT);";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=SqlDbType.NVarChar,Value = nome},
                new SqlParameter() {ParameterName="@preco",SqlDbType=SqlDbType.Decimal,Value = preco},
                new SqlParameter() {ParameterName="@descricao",SqlDbType=SqlDbType.NVarChar,Value = descricao},
                new SqlParameter() {ParameterName="@avaliacao",SqlDbType=SqlDbType.Decimal,Value = avaliacao},
                new SqlParameter() {ParameterName="@so",SqlDbType=SqlDbType.NVarChar,Value = so},
                new SqlParameter() {ParameterName="@empresa",SqlDbType=SqlDbType.NVarChar,Value = empresa},
                new SqlParameter() {ParameterName="@stock",SqlDbType=SqlDbType.Int,Value = stock},
                new SqlParameter() {ParameterName="@ano",SqlDbType=SqlDbType.Int,Value= ano},
                new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value= estado},
                new SqlParameter() {ParameterName="@tag",SqlDbType=SqlDbType.Text,Value= tag }
            };
            SqlCommand comando = new SqlCommand(sql, ligacaoBD);
            comando.Parameters.AddRange(parametros.ToArray());
            int id = (int)comando.ExecuteScalar();
            comando.Dispose();
            return id;
        }

        public void RemoverJogo(int id_jogo)
        {
            string sql = "DELETE FROM Jogos WHERE id_jogo=@id_jogo";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id_jogo",SqlDbType=SqlDbType.Int,Value=id_jogo }
            };
            ExecutaComando(sql, parametros);
        }
        public void AtualizaJogo(int id_jogo, string nome, decimal preco, string descricao, decimal avaliacao, DateTime data, string so, string empresa, int stock, int ano, int estado,string tag)
        {
            string sql = "UPDATE Jogos SET nome=@nome,preco=@preco,descricao=@descricao,avaliacao=@avaliacao,data_registo=@data_registo,sistema_operativo=@so,empresa=@empresa,stock=@stock,ano=@ano,estado=@estado,tag=@tag";
            sql += " WHERE id_jogo=@id_jogo;";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=SqlDbType.NVarChar,Value= nome},
                new SqlParameter() {ParameterName="@preco",SqlDbType=SqlDbType.Decimal,Value= preco},
                new SqlParameter() {ParameterName="@descricao",SqlDbType=SqlDbType.NVarChar,Value=descricao },
                new SqlParameter() {ParameterName="@avaliacao",SqlDbType=SqlDbType.Decimal,Value=avaliacao },
                new SqlParameter() {ParameterName="@data_registo",SqlDbType=SqlDbType.DateTime,Value=data},
                new SqlParameter() {ParameterName="@so",SqlDbType=SqlDbType.NVarChar,Value=so},
                new SqlParameter() {ParameterName="@empresa",SqlDbType=SqlDbType.NVarChar,Value= empresa},
                new SqlParameter() {ParameterName="@stock",SqlDbType=SqlDbType.Int,Value=stock},
                new SqlParameter() {ParameterName="@ano",SqlDbType=SqlDbType.Int,Value=ano},
                new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value=estado},
                new SqlParameter() {ParameterName="@id_jogo",SqlDbType=SqlDbType.Int,Value=id_jogo},
                new SqlParameter() {ParameterName="@tag",SqlDbType=SqlDbType.Text,Value=tag }
            };
            ExecutaComando(sql, parametros);
        }
        #endregion
        public DataTable ListaEmprestimosPorConcluir()
        {
            string sql = "SELECT * FROM Emprestimos where estado=1";
            return DevolveConsulta(sql);
        }
        public DataTable listaTodosEmprestimos()
        {
            string sql = "SELECT * FROM Emprestimos";
            return DevolveConsulta(sql);
        }
        public DataTable ListaTodosEmprestimosComNomes()
        {
            string sql = @"SELECT nemprestimo,livros.nome as nomeLivro,utilizadores.nome as nomeLeitor,data_emprestimo,data_devolve,emprestimos.estado
                        FROM Emprestimos inner join livros on emprestimos.nlivro=livros.nlivro
                        inner join utilizadores on emprestimos.idutilizador=utilizadores.id";
            return DevolveConsulta(sql);
        }
        public DataTable ListaTodosEmprestimosPorConcluirComNomes()
        {
            string sql = @"SELECT nemprestimo,livros.nome as nomeLivro,utilizadores.nome as nomeLeitor,data_emprestimo,data_devolve,emprestimos.estado
                        FROM Emprestimos inner join livros on emprestimos.nlivro=livros.nlivro
                        inner join utilizadores on emprestimos.idutilizador=utilizadores.id where emprestimos.estado=1";
            return DevolveConsulta(sql);
        }
        public DataTable ListaTodosEmprestimos(int nleitor)
        {
            string sql = "SELECT * FROM Emprestimos Where idutilizador=@idutilizador";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idutilizador",SqlDbType=SqlDbType.Int,Value=nleitor }
            };
            return DevolveConsulta(sql, parametros);
        }
        public DataTable ListaTodosEmprestimosComNomes(int nleitor)
        {
            string sql = @"SELECT nemprestimo,livros.nome as nomeLivro,utilizadores.nome as nomeLeitor,data_emprestimo,data_devolve,emprestimos.estado
                        FROM Emprestimos inner join livros on emprestimos.nlivro=livros.nlivro
                        inner join utilizadores on emprestimos.idutilizador=utilizadores.id Where idutilizador=@idutilizador";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idutilizador",SqlDbType=SqlDbType.Int,Value=nleitor }
            };
            return DevolveConsulta(sql, parametros);
        }

        public DataTable ListaEmprestimosPorConcluir(int nleitor)
        {
            string sql = "SELECT * FROM Emprestimos Where idutilizador=@idutilizador and estado=0";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idutilizador",SqlDbType=SqlDbType.Int,Value=nleitor }
            };
            return DevolveConsulta(sql, parametros);
        }
        public DataTable ListaTodosEmprestimosPorConcluirComNomes(int nleitor)
        {
            string sql = @"SELECT nemprestimo,livros.nome as nomeLivro,utilizadores.nome as nomeLeitor,data_emprestimo,data_devolve,emprestimos.estado
                        FROM Emprestimos inner join livros on emprestimos.nlivro=livros.nlivro
                        inner join utilizadores on emprestimos.idutilizador=utilizadores.id where idutilizador=@idutilizador and emprestimos.estado=1";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idutilizador",SqlDbType=SqlDbType.Int,Value=nleitor }
            };
            return DevolveConsulta(sql, parametros);
        }
        public DataTable ListaEmprestimosAtrasados()
        {
            string sql = "SELECT * FROM Emprestimos where data_devolve<getdate()";
            return DevolveConsulta(sql);
        }

        public DataTable ListarJogosAcao()
        {
            string sql = "SELECT id_jogo,nome,preco FROM Jogos WHERE tag like '%Ação%'";
            return DevolveConsulta(sql);
        }

        public DataTable ListarJogosAventura()
        {
            string sql = "SELECT id_jogo,nome,preco FROM Jogos WHERE tag like '%Aventura%'";
            return DevolveConsulta(sql);
        }

        public DataTable ListarJogosCasual()
        {
            string sql = "SELECT id_jogo,nome,preco FROM Jogos WHERE tag like '%Casual%'";
            return DevolveConsulta(sql);
        }

        public DataTable ListarJogosIndie()
        {
            string sql = "SELECT id_jogo,nome,preco FROM Jogos WHERE tag like '%Indie%'";
            return DevolveConsulta(sql);
        }

        public DataTable ListarJogosMMO()
        {
            string sql = "SELECT id_jogo,nome,preco FROM Jogos WHERE tag like '%MMO%'";
            return DevolveConsulta(sql);
        }

        public DataTable ListarJogosCorrida()
        {
            string sql = "SELECT id_jogo,nome,preco FROM Jogos WHERE tag like '%Corrida%'";
            return DevolveConsulta(sql);
        }

        public DataTable ListarJogosRPG()
        {
            string sql = "SELECT id_jogo,nome,preco FROM Jogos WHERE tag like '%RPG%'";
            return DevolveConsulta(sql);
        }

        public DataTable ListarJogosEstrategia()
        {
            string sql = "SELECT id_jogo,nome,preco FROM Jogos WHERE tag like '%Estratégia%'";
            return DevolveConsulta(sql);
        }

        public DataTable ListarDemos()
        {
            string sql = "SELECT id_jogo,nome,preco FROM Jogos WHERE tag like '%Demo%'";
            return DevolveConsulta(sql);
        }

        public DataTable ListarFreeToPlay()
        {
            string sql = "SELECT id_jogo,nome,preco FROM Jogos WHERE tag like '%ftp%'";
            return DevolveConsulta(sql);
        }

        public void AdicionarEmprestimo(int nlivro, int nleitor, DateTime dataDevolve)
        {
            string sql = "SELECT * FROM livros WHERE nlivro=@nlivro";
            List<SqlParameter> parametrosBloquear = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nlivro",SqlDbType=SqlDbType.Int,Value=nlivro }
            };
            //iniciar transação
            SqlTransaction transacao = ligacaoBD.BeginTransaction(IsolationLevel.Serializable);
            DataTable dados = DevolveConsulta(sql, parametrosBloquear, transacao);

            try
            {
                //alterar estado do livro
                sql = "UPDATE Livros SET estado=@estado WHERE nlivro=@nlivro";
                List<SqlParameter> parametrosUpdate = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@nlivro",SqlDbType=SqlDbType.Int,Value=nlivro },
                    new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value=0 },
                };
                ExecutaComando(sql, parametrosUpdate, transacao);
                //registar empréstimo
                sql = @"INSERT INTO Emprestimos(nlivro,idutilizador,data_emprestimo,data_devolve,estado) 
                            VALUES (@nlivro,@idutilizador,@data_emprestimo,@data_devolve,@estado)";
                List<SqlParameter> parametrosInsert = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@nlivro",SqlDbType=SqlDbType.Int,Value=nlivro },
                    new SqlParameter() {ParameterName="@idutilizador",SqlDbType=SqlDbType.Int,Value=nleitor },
                    new SqlParameter() {ParameterName="@data_emprestimo",SqlDbType=SqlDbType.Date,Value=DateTime.Now.Date},
                    new SqlParameter() {ParameterName="@data_devolve",SqlDbType=SqlDbType.Date,Value=dataDevolve },
                    new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value=1 },
                };
                ExecutaComando(sql, parametrosInsert, transacao);
                //concluir transação
                transacao.Commit();
            }
            catch
            {
                transacao.Rollback();
            }
            dados.Dispose();
        }
        /// <summary>
        /// Termina um empréstimo e altera o estado do livro
        /// </summary>
        public void ConcluirEmprestimo(int nemprestimo)
        {
            DataTable dadosEmprestimo = DevolveDadosEmprestimo(nemprestimo);
            int nlivro = int.Parse(dadosEmprestimo.Rows[0]["nlivro"].ToString());
            string sql = "SELECT * FROM livros WHERE nlivro=@nlivro";
            List<SqlParameter> parametrosBloquear = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nlivro",SqlDbType=SqlDbType.Int,Value=nlivro }
            };
            //iniciar transação
            SqlTransaction transacao = ligacaoBD.BeginTransaction(IsolationLevel.Serializable);
            DataTable dados = DevolveConsulta(sql, parametrosBloquear, transacao);

            try
            {
                //alterar estado do livro
                sql = "UPDATE Livros SET estado=@estado WHERE nlivro=@nlivro";
                List<SqlParameter> parametrosUpdate = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@nlivro",SqlDbType=SqlDbType.Int,Value=nlivro },
                    new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value=1 },
                };
                ExecutaComando(sql, parametrosUpdate, transacao);
                //terminar empréstimo
                sql = @"UPDATE Emprestimos SET estado=@estado WHERE nemprestimo=@nemprestimo";
                List<SqlParameter> parametrosInsert = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@nemprestimo",SqlDbType=SqlDbType.Int,Value=nemprestimo },
                    new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value=0 },
                };
                ExecutaComando(sql, parametrosInsert, transacao);
                //concluir transação
                transacao.Commit();
            }
            catch
            {
                transacao.Rollback();
            }
            dados.Dispose();
        }
        public DataTable DevolveDadosEmprestimo(int nemprestimo)
        {
            string sql = "SELECT * FROM emprestimos WHERE nemprestimo=@nemprestimo";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nemprestimo",SqlDbType=SqlDbType.Int,Value=nemprestimo }
            };
            return DevolveConsulta(sql, parametros);
        }
    }
}