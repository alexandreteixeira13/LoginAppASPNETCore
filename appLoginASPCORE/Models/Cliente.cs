using System.ComponentModel.DataAnnotations;

namespace appLoginASPCORE.Models
{
    public class Cliente
    {
        //PK
        [Display(Name = "Código", Description = "Código.")]
        public int Id { get; set; }

        [Display(Name = "Nome completo", Description = "Nome e sobrenome.")]
        [Required(ErrorMessage = "A o nome completo é obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Nascimento")]
        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime Nascimento { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "O sexo é obrigatório.")]
        [StringLength(1, ErrorMessage = "Deve conter 1 caracter")]
        public string Sexo { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        public string CPF { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "O celular é obrigatório.")]
        public string Telefone { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "O email é obrigatório.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string? Email { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A senha deve conter entre 6 e 10 caracteres.")]
        public string Senha { get; set; }

        [Display(Name = "Situação")]
        public string? Situacao { get; set; }
    }
}
