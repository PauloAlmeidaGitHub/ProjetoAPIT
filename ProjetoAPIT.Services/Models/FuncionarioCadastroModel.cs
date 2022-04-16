using System.ComponentModel.DataAnnotations;
namespace ProjetoAPIT.Services.Models
{
    public class FuncionarioCadastroModel
    {
        [Required(ErrorMessage ="Obrigatório")]
        public string Nome { get; set; }
    }
}
