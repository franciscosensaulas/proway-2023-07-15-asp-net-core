using System.ComponentModel.DataAnnotations;

namespace LojaMvc.Models.Produto
{
    public class ProdutoCadastroViewModel
    {
        public string Nome { get; set; }
        [Display(Name = "Preço Unitário")]
        public decimal PrecoUnitario { get; set; }
    }
}
