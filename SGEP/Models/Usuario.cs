using System.ComponentModel.DataAnnotations;

namespace SGEP.Models
{
    public class Usuario
    {
        [Key]
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public CargoUsuario Cargo { get; set; }

        private string _telefone
        {
          get
          {
            return _telefone;
          }
          set
          {
            if (ValidadorDeEntrada.VerificarTelefone (value))
              Telefone = value;
          }
        }
        public string Telefone { get; set; }

        private string _email;
        public string Email
        {
             get
             {
                 return _email;
             }
             set
             {
                if (ValidadorDeEntrada.VerificarEmail (value))
                    _email = value;
             }
        }

        public Usuario(string login, string senha, string nome, CargoUsuario cargo, string telefone, string email){
            Login = login;
            Senha = senha;
            Nome = nome;
            Cargo = cargo;
            Telefone = telefone;
            Email = email;
        }


    }
}
