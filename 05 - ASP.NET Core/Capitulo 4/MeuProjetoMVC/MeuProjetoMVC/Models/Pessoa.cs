﻿
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MeuProjetoMVC.Models
{
    public class Pessoa
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public bool EstaValidoParaSalvar(ModelStateDictionary modelState)
        {
            // validando campo nome
            if(string.IsNullOrEmpty(Nome)) 
            {
                modelState.AddModelError(nameof(Nome),"O campo nome é obrigatório");
            }
            else if(Nome.Length > 100)
            {

                modelState.AddModelError(nameof(Nome), "O campo nome deve ter no máximo 100 caracteres");
            }
            // validando campo CPF
            if (string.IsNullOrEmpty(Cpf))
            {
                modelState.AddModelError(nameof(Cpf), "O campo CPF é obrigatório");
            }
            else if (Cpf.Length < 14)
            {

                modelState.AddModelError(nameof(Cpf), "O campo CPF está inválido");
            }
            // validando campo Email
            if(!string.IsNullOrEmpty(Email) && !Email.Contains("@")) 
            {
                modelState.AddModelError(nameof(Email), "O Email está inválido");
            }
            if (string.IsNullOrEmpty(Telefone))
            {
                modelState.AddModelError(nameof(Telefone), "O campo Telefone é obrigatório");
            }
            else if (Telefone.Length < 30)
            {
                modelState.AddModelError(nameof(Telefone), "O campo Telefone está inválido");
            }


            return modelState.IsValid;
        }
    }
}
