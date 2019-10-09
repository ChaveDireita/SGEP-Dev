using System.ComponentModel.DataAnnotations;
using SGEP.Models.Validacao;

namespace SGEP.Models
{
    public class Usuario
    {
        [Key]
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public CargoUsuario Cargo { get; set; }

        private string _telefone;
        public string Telefone
        {
          get
          {
            return _telefone;
          }
          set
          {
            if (ValidadorDeEntrada.VerificarTelefone (value))
              _telefone = value;
          }
        }

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

    }
}
