using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("Usuario")]
    public class Usuario
    {

        [Column("Id")]
        [Display(Name = "ID")]
        public Guid Id { get; set; }


        [Column("Nome")]
        [Display(Name = "Nome")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'-'\s]{1,40}$", ErrorMessage = "Por favor, digite um nome válido.")]
        [Required(ErrorMessage = "O campo 'Nome Completo' é obrigatório.")]
        public String? Nome { get; set; }


        [Column("Email")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "O campo 'Email' é obrigatório.")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Por favor, digite um Email válido.")]
        [EmailAddress(ErrorMessage = "Por favor, digite um nome válido.")]
        public String? Email { get; set; }


        [Column("Data de Nascimento")]
        [Display(Name = "Data_Nascimento")]
        [Required(ErrorMessage = "O campo 'Data de nascimento' é obrigatório.")]
        [DataType(DataType.Date)]
        public DateTime Data_Nascimento { get; set; }


        [Column("Rendimento")]
        [Display(Name = "Rendimento")]
        [Range(0, double.MaxValue, ErrorMessage = "Por favor, digite um valor acima de -1.")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = true)]
        public decimal Rendimento { get; set; }
    }
}

