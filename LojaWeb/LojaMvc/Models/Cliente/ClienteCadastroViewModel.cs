using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LojaMvc.Models.Cliente
{
    public class ClienteCadastroViewModel
    {
        [Required(ErrorMessage = "Campo nome deve ser preenchido")]
        [MinLength(6, ErrorMessage = "Nome deve conter no mínimo 6 caracteres")]
        [MaxLength(100, ErrorMessage = "Nome deve conter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Campo CPF deve ser preenchido")]
        [RegularExpression("[0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2}", ErrorMessage = "CPF deve seguir o seguinte formato 012.345.678-90")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo data de Nascimento deve ser preenhcida")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo estado deve ser preenchido")]
        [MinLength(2, ErrorMessage = "Estado deve conter no mínimo 2 caracteres")]
        [MaxLength(2, ErrorMessage = "Estado deve conter no máximo 2 caracteres")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Campo cidade deve ser preenchido")]
        [MinLength(3, ErrorMessage = "Cidade deve conter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "Cidade deve conter no máximo 100 caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo bairro deve ser preenchido")]
        [MinLength(3, ErrorMessage = "Bairro deve conter no mínimo 3 caracteres")]
        [MaxLength(40, ErrorMessage = "Bairro deve conter no máximo 40 caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo CEP deve ser preenchido")]
        [RegularExpression("[0-9]{5}-[0-9]{3}", ErrorMessage = "89070-100")]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Campo Logradouro deve ser preenchido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Logradouro deve conter no mínimo 3 e no máximo 50 caracteres")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo Número deve ser preenchido")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Número deve conter no mínimo 1 e no máximo 10 caracteres")]
        [Display(Name = "Número")]
        public string Numero { get; set; }

        public string? Complemento { get; set; }
    }
}
