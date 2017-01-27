using ModuloCongresso.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCongresso.Infra.Data.Context
{
    public class ContextInitializer : DropCreateDatabaseIfModelChanges<ModuloCongressoContext>
    {
        protected override void Seed(ModuloCongressoContext context)
        {
            var profissoes = new List<Profissao>
            {
                new Profissao { Nome = "Administrador" },
                new Profissao { Nome = "Contador" },
                new Profissao { Nome = "Engenheiro de Pesca" },
                new Profissao { Nome = "Engenheiro Civil" },
                new Profissao { Nome = "Programador" },
                new Profissao { Nome = "Analista de Sistemas" },
                new Profissao { Nome = "Engenheiro de Software" },
                new Profissao { Nome = "Médico" },
                new Profissao { Nome = "Advogado" },
                new Profissao { Nome = "Juiz" },
                new Profissao { Nome = "Pedreiro" },
                new Profissao { Nome = "Atendente" },
                new Profissao { Nome = "Politico" },
                new Profissao { Nome = "Corretor" },
                new Profissao { Nome = "Taxista" },
                new Profissao { Nome = "Aeromoça" },
                new Profissao { Nome = "Motorista" },
                new Profissao { Nome = "Carteiro" },
                new Profissao { Nome = "Gerente" },
                new Profissao { Nome = "Dentista" }
            };

            var produtos = new List<Produto>
            {
                new Produto { Descricao = "Automóvel Particular" },
                new Produto { Descricao = "Moto" },
                new Produto { Descricao = "Taxi" },
                new Produto { Descricao = "Caminhão" },
                new Produto { Descricao = "Ônibus" },
                new Produto { Descricao = "Frota" }
            };

            //Tabela: PerguntasProduto precisa ser inicializada via script

            var pais = new List<PaisResidencia>
            {
                new PaisResidencia { Nome = "Brasil" },
                new PaisResidencia { Nome = "Eua" },
                new PaisResidencia { Nome = "Argentina" },
                new PaisResidencia { Nome = "Portugal" },
                new PaisResidencia { Nome = "França" },
                new PaisResidencia { Nome = "Outros" }
            };

            var marcas = new List<Marca>
            {
                new Marca { Nome = "Fiat", Imagem = null },
                new Marca { Nome = "Chevrolet" , Imagem = null },
                new Marca { Nome = "Hyundai" , Imagem = null },
                new Marca { Nome = "Ford" , Imagem = null },
                new Marca { Nome = "BMW" , Imagem = null },
                new Marca { Nome = "Mercedes" , Imagem = null },
                new Marca { Nome = "Nissan" , Imagem = null },
                new Marca { Nome = "Toyota" , Imagem = null },
                new Marca { Nome = "Lexus" , Imagem = null },
                new Marca { Nome = "Ferrari" , Imagem = null },
                new Marca { Nome = "Citroen" , Imagem = null },
                new Marca { Nome = "Volkswagem", Imagem = null }
            };

            //var modelos = new List<Modelo>
            //{
            //    new Modelo { Nome = "Uno Vivace", Descricao = "Attractive 1.0 8V EVO Flex", Combustivel = Combustivel.Alcool.ToString(), AnoFabricacao = "2015", Garantia = 12, Valor = 37590, Marca = marcas.Single(m => m.Nome == "Fiat")},
            //    new Modelo { Nome = "Punto Hatch", Descricao = "Attractive 1.4 8V Flex", Combustivel = Combustivel.Flex.ToString(), AnoFabricacao = "2016", Garantia = 36, Valor = 47590, Marca = marcas.Single(m => m.Nome == "Fiat")},
            //    new Modelo { Nome = "Grand Siena", Descricao = "1.4 8V Tetrafuel", Combustivel = Combustivel.Flex.ToString(), AnoFabricacao = "2015", Garantia = 12, Valor = 43570, Marca = marcas.Single(m => m.Nome == "Fiat")},
            //    new Modelo { Nome = "Novo Fiesta Hatch", Descricao = "1.5 16V Flex", Combustivel = Combustivel.Flex.ToString(), AnoFabricacao = "2015", Garantia = 12, Valor = 48000, Marca = marcas.Single(m => m.Nome == "Ford")},
            //    new Modelo { Nome = "Novo Fiesta Hatch", Descricao = "Titanium 1.6 16V Flex Aut", Combustivel = Combustivel.Flex.ToString(), AnoFabricacao = "2015", Garantia = 12, Valor = 58000, Marca = marcas.Single(m => m.Nome == "Ford")}
            //};

            context.SaveChanges();
        }
    }
}
