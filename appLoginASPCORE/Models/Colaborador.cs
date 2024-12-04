using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace appLoginASPCORE.Models
{
    public class Colaborador
    {
        [Display(Name = "Código", Description = "Código.")]
        [ValidateNever]
        public int Id { get; set; }

        [Display(Name = "Nome completo", Description = "Nome e sobrenome.")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "O email não é válido.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 10 caracteres")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Senha { get; set; }

        // TIPO ColaboradorTipoConstant

        [Display(Name = "Tipo")]
        public string? Tipo { get; set; }
    }
  
}
