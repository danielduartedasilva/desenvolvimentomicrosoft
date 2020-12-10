using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWeb.Models
{
    [Table("Produtos")]
    public class Produto : BaseModel
    {
        [Required(ErrorMessage = "Campo obrigatório!")] //---------------------------------------------------------------------------------------------------------------------------------------------------anotação de campo necessário
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres!")]
        [MinLength(5, ErrorMessage = "Mínimo 5 caracteres!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, 200, ErrorMessage = "Valores entre 1 e 200!")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public double Preco { get; set; }

        public string Imagem { get; set; }

        [ForeignKey("CategoriaId")]//-----------------------------------------------------------------------------------ForeignKey serve para especificar que dentro desse campo iremos utilizar uma chave estrangeira
        public Categoria Categoria { get; set; }

        public int CategoriaId { get; set; } //-------------------------------------------------------------------------para facilitar e otimizar na hora da busca
    }
}
