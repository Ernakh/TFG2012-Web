using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Data;

/*
        CREATE SEQUENCE usuarios_sequencia;

        create table usuarios
        (
            id integer DEFAULT nextval('usuarios_sequencia') NOT NULL,
            nome char(60) NOT NULL,
            email char(60) NOT NULL,
            login char(60) NOT NULL,
            senha char(60) NOT NULL,
            gerente bit NOT NULL,
            primary key (id)
        );
 
 * 
 * CREATE TABLE categorias (
id integer unique NOT NULL,
descricao text
);

-- Crio a sequência
CREATE SEQUENCE categorias_sequencia
INCREMENT BY 1
NO MAXVALUE
NO MINVALUE
CACHE 1;

-- Relaciona a sequência com a coluna da tabela
ALTER SEQUENCE categorias_sequencia OWNED BY categorias.id;
ALTER TABLE categorias ALTER COLUMN id SET DEFAULT nextval('categorias_sequencia'::regclass);
 * 
 * 
 * 
 * 
 * 
 * CREATE TABLE locais (
id integer unique NOT NULL,
nome text
);

-- Crio a sequência
CREATE SEQUENCE locais_sequencia
INCREMENT BY 1
NO MAXVALUE
NO MINVALUE
CACHE 1;

-- Relaciona a sequência com a coluna da tabela
ALTER SEQUENCE locais_sequencia OWNED BY locais.id;
ALTER TABLE locais ALTER COLUMN id SET DEFAULT nextval('locais_sequencia'::regclass);



-- Crio a tabela
CREATE TABLE coordenadas (
id integer NOT NULL,
fk_local integer references locais(id),
longitude real not null,
latitude real not null
);

-- Crio a sequência
CREATE SEQUENCE coordenadas_sequencia
INCREMENT BY 1
NO MAXVALUE
NO MINVALUE
CACHE 1;

-- Relaciona a sequência com a coluna da tabela
ALTER SEQUENCE coordenadas_sequencia OWNED BY coordenadas.id;
ALTER TABLE coordenadas ALTER COLUMN id SET DEFAULT nextval('coordenadas_sequencia'::regclass);

 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
CREATE TABLE produto_categorias (
id integer unique NOT NULL,
fk_categoria integer references categorias(id)
);

-- Crio a sequência
CREATE SEQUENCE produto_categorias_sequencia
INCREMENT BY 1
NO MAXVALUE
NO MINVALUE
CACHE 1;

-- Relaciona a sequência com a coluna da tabela
ALTER SEQUENCE produto_categorias_sequencia OWNED BY produto_categorias.id;
ALTER TABLE produto_categorias ALTER COLUMN id SET DEFAULT nextval('produto_categorias_sequencia'::regclass);

 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
CREATE TABLE produto_locais (
id integer unique NOT NULL,
fk_local integer references locais(id)
);

-- Crio a sequência
CREATE SEQUENCE produto_locais_sequencia
INCREMENT BY 1
NO MAXVALUE
NO MINVALUE
CACHE 1;

-- Relaciona a sequência com a coluna da tabela
ALTER SEQUENCE produto_locais_sequencia OWNED BY produto_locais.id;
ALTER TABLE produto_locais ALTER COLUMN id SET DEFAULT nextval('produto_locais_sequencia'::regclass);

 * 

 * 
 * 
 */

namespace TFG___Web
{
    public class Banco
    {
        public NpgsqlConnection Conecta()
        {
            string conexao = "Server=localhost;Port=5432;User Id=postgres;Password=postgresql;Database=TFG;";
            NpgsqlConnection cn = new NpgsqlConnection(conexao);
            cn.Open();
            return cn;
        }

        public void Desconecta(NpgsqlConnection cn)
        {
            if (cn.State == ConnectionState.Open)
                cn.Close();
        }

        public DataSet executeQuery(string sql)
        {
            try
            {
                NpgsqlCommand sqlComm = new NpgsqlCommand(sql, Conecta());
                sqlComm.ExecuteNonQuery();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sqlComm);

                DataSet ds = new DataSet();
                da.Fill(ds);

                Desconecta(sqlComm.Connection);

                return ds;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        internal int UsuarioAutenticado(string login, string senha)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = Conecta();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from usuarios where login = @login and senha = @senha ";
            cmd.Parameters.Add("@login", login);
            cmd.Parameters.Add("@senha", senha);

            NpgsqlDataReader reader = null;
            reader = cmd.ExecuteReader();
            
            try
            {
                while (reader.Read())
                {
                    return int.Parse(reader.GetValue(0).ToString());
                }

                return 0;
            } 
            catch
            {
                return 0;
            }
            finally
            {
                reader.Close();
                Desconecta(cmd.Connection);
            }
        }

        internal bool EhGerente(int id_user)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = Conecta();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select gerente from usuarios where id = @user ";
            cmd.Parameters.Add("@user", id_user);

            NpgsqlDataReader reader = null;
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    if (reader.GetValue(0).ToString() == "0")
                        return false;
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                reader.Close();
                Desconecta(cmd.Connection);
            }
        }

        internal bool CadastraUsuario(string nome, string email, string login, string senha, bool gerente)
        {
            NpgsqlTransaction transac = null;

            NpgsqlConnection con = null;

            Banco bd = new Banco();
            NpgsqlCommand command = new NpgsqlCommand();
            con = Conecta();
            transac = con.BeginTransaction();

            command.Connection = con;
            command.Transaction = transac;

            string sql = "insert into usuarios(nome, email, login, senha, gerente) values (@nome,@email,@login,@senha,@gerente)";
            
            command.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar);
            command.Parameters.Add("@email", NpgsqlTypes.NpgsqlDbType.Varchar);
            command.Parameters.Add("@login", NpgsqlTypes.NpgsqlDbType.Varchar);
            command.Parameters.Add("@senha", NpgsqlTypes.NpgsqlDbType.Varchar);
            command.Parameters.Add("@gerente", NpgsqlTypes.NpgsqlDbType.Bit);

            command.Parameters["nome"].Value = nome;
            command.Parameters["email"].Value = email;
            command.Parameters["login"].Value = login;
            command.Parameters["senha"].Value = senha;
            command.Parameters["gerente"].Value = gerente;//==true?"1":"0";

            command.CommandText = sql;

            try
            {
                command.ExecuteNonQuery();
                transac.Commit();
                return true;
            }
            catch
            {
                transac.Rollback();
                return false;
            }
            finally
            {
                Desconecta(command.Connection);
            }
        }

        internal bool CadastraCategorias(string nome)
        {
            NpgsqlTransaction transac = null;

            NpgsqlConnection con = null;

            Banco bd = new Banco();
            NpgsqlCommand command = new NpgsqlCommand();
            con = Conecta();
            transac = con.BeginTransaction();

            command.Connection = con;
            command.Transaction = transac;

            string sql = "insert into categorias(descricao) values (@nome)";

            command.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Text);

            command.Parameters["nome"].Value = nome;

            command.CommandText = sql;

            try
            {
                command.ExecuteNonQuery();
                transac.Commit();
                return true;
            }
            catch
            {
                transac.Rollback();
                return false;
            }
            finally
            {
                Desconecta(command.Connection);
            }
        }

        internal void DeletaCoordenadas(int id_local)
        {
            NpgsqlTransaction transac = null;
            NpgsqlConnection con = null;

            Banco bd = new Banco();
            NpgsqlCommand command = new NpgsqlCommand();
            con = Conecta();
            transac = con.BeginTransaction();

            command.Connection = con;
            command.Transaction = transac;

            string sql = "delete from coordenadas where fk_local = @id";

            command.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer);
            command.Parameters["id"].Value = id_local;

            command.CommandText = sql;

            try
            {
                command.ExecuteNonQuery();
                transac.Commit();
            }
            catch
            {
                transac.Rollback();
            }
            finally
            {
                Desconecta(command.Connection);
            }
        }

        internal bool CadastraLocal(string local, List<string> coordenadas)
        {
            NpgsqlTransaction transac = null;
            NpgsqlConnection con = null;

            Banco bd = new Banco();
            NpgsqlCommand command = new NpgsqlCommand();
            con = Conecta();
            transac = con.BeginTransaction();

            command.Connection = con;
            command.Transaction = transac;

            string sql = "insert into locais(nome) values (@nome);select currval('locais_sequencia');";

            command.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Text);
            command.Parameters["nome"].Value = local;

            command.CommandText = sql;

            try
            {
                int id = int.Parse(command.ExecuteScalar().ToString());

                foreach (string item in coordenadas)
                {
                    NpgsqlCommand command2 = new NpgsqlCommand();

                    command2.Connection = con;
                    command2.Transaction = transac;

                    string sql2 = "insert into coordenadas(fk_local, latitude, longitude) values (@local, @lat, @long)";

                    command2.Parameters.Add("@local", NpgsqlTypes.NpgsqlDbType.Integer);
                    command2.Parameters.Add("@lat", NpgsqlTypes.NpgsqlDbType.Real);
                    command2.Parameters.Add("@long", NpgsqlTypes.NpgsqlDbType.Real);
                    command2.Parameters["local"].Value = id;
                    command2.Parameters["lat"].Value = item.Substring(0, item.LastIndexOf(';'));
                    command2.Parameters["long"].Value = item.Substring(item.LastIndexOf(';') + 1);

                    command2.CommandText = sql2;

                    command2.ExecuteNonQuery();
                }

                transac.Commit();
                return true;
            }
            catch
            {
                transac.Rollback();
                return false;
            }
            finally
            {
                Desconecta(command.Connection);
            }
        }

        internal int gravaProduto(string p, string p_2, string p_3)
        {
            int x = 0;

            NpgsqlTransaction transac = null;

            NpgsqlConnection con = null;

            Banco bd = new Banco();
            NpgsqlCommand command = new NpgsqlCommand();
            con = Conecta();
            transac = con.BeginTransaction();

            command.Connection = con;
            command.Transaction = transac;

            string sql = "insert into produtos(nome, descricao, valor) values (@nome, @descricao, @valor);select currval('produtos_sequencia');";

            command.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Text);
            command.Parameters.Add("@descricao", NpgsqlTypes.NpgsqlDbType.Text);
            command.Parameters.Add("@valor", NpgsqlTypes.NpgsqlDbType.Double);

            command.Parameters["nome"].Value = p;
            command.Parameters["descricao"].Value = p_2;
            command.Parameters["valor"].Value = p_3;

            command.CommandText = sql;

            try
            {
                x = int.Parse(command.ExecuteScalar().ToString());
                transac.Commit();
            }
            catch
            {
                transac.Rollback();
            }
            finally
            {
                Desconecta(command.Connection);
            }

            return x;
        }

        internal void cadastraPxC(int x, int item)
        {
            NpgsqlTransaction transac = null;

            NpgsqlConnection con = null;

            Banco bd = new Banco();
            NpgsqlCommand command = new NpgsqlCommand();
            con = Conecta();
            transac = con.BeginTransaction();

            command.Connection = con;
            command.Transaction = transac;

            string sql = "insert into produto_categorias(id, fk_categoria) values (@p, @c)";

            command.Parameters.Add("@p", NpgsqlTypes.NpgsqlDbType.Integer);
            command.Parameters.Add("@c", NpgsqlTypes.NpgsqlDbType.Integer);

            command.Parameters["p"].Value = x;
            command.Parameters["c"].Value = item;

            command.CommandText = sql;

            try
            {
                command.ExecuteNonQuery();
                transac.Commit();
            }
            catch
            {
                transac.Rollback();
            }
            finally
            {
                Desconecta(command.Connection);
            }
        }

        internal void cadastraPxL(int x, int item)
        {
            NpgsqlTransaction transac = null;

            NpgsqlConnection con = null;

            Banco bd = new Banco();
            NpgsqlCommand command = new NpgsqlCommand();
            con = Conecta();
            transac = con.BeginTransaction();

            command.Connection = con;
            command.Transaction = transac;

            string sql = "insert into produto_locais(id, fk_local) values (@p, @l)";

            command.Parameters.Add("@p", NpgsqlTypes.NpgsqlDbType.Integer);
            command.Parameters.Add("@l", NpgsqlTypes.NpgsqlDbType.Integer);

            command.Parameters["p"].Value = x;
            command.Parameters["l"].Value = item;

            command.CommandText = sql;

            try
            {
                command.ExecuteNonQuery();
                transac.Commit();
            }
            catch
            {
                transac.Rollback();
            }
            finally
            {
                Desconecta(command.Connection);
            }
        }
    }
}