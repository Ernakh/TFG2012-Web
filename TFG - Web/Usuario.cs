using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFG___Web
{
    public class Usuario
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        private string senha;

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        private bool gerente;

        public bool Gerente
        {
            get { return gerente; }
            set { gerente = value; }
        }
    }
}