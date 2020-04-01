using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using System;
using TDD.Original.Web.Utils;

namespace TDD.Original.Web.Models
{
    public class Cliente 
    {
        public Cliente(string nome, string cpf, DateTime dataNascimento, string endereco)
        {
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
            Endereco = endereco;
            AcimaTrintaAnos = dataNascimento.Date <= DateTime.Now.AddYears(-30).Date;
        }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Endereco { get; private set; }
        public bool AcimaTrintaAnos { get; private set; }
        public ValidationResult ValidationResult { get; protected set; }

        public bool EhValida()
        {
            ValidationResult = new ClienteValidacao().Validate(this);
            return ValidationResult.IsValid;
        }
    }
    
    public class ClienteValidacao : AbstractValidator<Cliente>
    {
        public ClienteValidacao()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo nome não deve ser vázio")
                .Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres");

            RuleFor(x => x.CPF.RemoverCaracteresEspeciais())
                .NotEmpty().WithMessage("O campo CPF não deve ser vázio")
                .Length(11).WithMessage("O CPF deve ter entre 11 digitos");

            RuleFor(x => x.DataNascimento)
                .NotEmpty().WithMessage("O campo data de nascimento nao pode estar vazio");

            RuleFor(x => x.Endereco)
                .NotEmpty().WithMessage("O campo endereco não deve ser vázio")
                .Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres");
        }
    }
}
