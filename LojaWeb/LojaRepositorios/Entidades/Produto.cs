﻿namespace LojaRepositorios.Entidades
{
    public class Produto : ModeloBase
    {
        public string Nome { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}
