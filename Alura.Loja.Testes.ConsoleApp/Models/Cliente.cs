﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual Endereco Endereco { get; set; }

        public override string ToString()
        {
            string endereco = $"{Endereco.Logradouro}, nº {Endereco.Numero}{(Endereco.Complemento != null ? ", " + Endereco.Complemento : "")} - {Endereco.Bairro}, {Endereco.Cidade}";
            return $"Cliente [Nome: {Nome}, Endereço: {endereco}]";
        }

    }
}
