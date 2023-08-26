using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LojaMvc.Models.Produto
{
    public class ProdutoEditarViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Nome { get; set; }
        [Display(Name="Preço Unitário")]
        public decimal PrecoUnitario { get; set; }
    }
}
