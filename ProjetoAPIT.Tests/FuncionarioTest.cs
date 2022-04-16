using Bogus;
using FluentAssertions;
using Newtonsoft.Json;
using ProjetoAPIT.Services.Models;
using ProjetoAPIT.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjetoAPIT.Tests
{
    public class FuncionarioTest
    {
        [Fact(Skip = "Teste temporariamente suspenso")]
        public async Task<FuncionarioCadastroModel> Test_Funcionario_Cadastrar()
        {
            //Conecta na API e recebe o retorno em client
            var client = HttpClientHelper.Create();

            // Criar os dados que para serem enviados para a API
            var model = new FuncionarioCadastroModel
            {
                Nome = $"Funcionario Testador_{Guid.NewGuid()}"
            };

            // Ao requisiar para a API enviando os dados em JSON (Serializar)
            var content = new StringContent( JsonConvert.SerializeObject(model),
                                             Encoding.UTF8, "application/json"
                                           );

            // Enviamos esses dados para a API e obtemos a resposta
            // PostAsync porque na API o serviço de Cadastramento é POST
            // E o endPoint é api/Funcionario

            // Executar o cadastro
            var response = await client.PostAsync("api/Funcionario", content);

            // Verificar se a API retorna como resposta ==> SUCESSO
            response.StatusCode.Should().Be(HttpStatusCode.Created); // 201 - Criado com sucesso


            // Retorna os dados do Funcionario Cadastrado
            return model;

        }

        [Fact]
        public async Task<FuncionarioCadastroModel> Test_Funcionario_Cadastrar_Bogus()
        {
            //Conecta na API e recebe o retorno em client
            var client = HttpClientHelper.Create();


            // Cadastrar o contato
            var faker = new Faker("pt_BR");

            // Criar os dados que para serem enviados para a API
            var model = new FuncionarioCadastroModel
            {
                Nome = $"{faker.Person.FullName} - via Bogus"
            };

            // Ao requisiar para a API enviando os dados em JSON (Serializar)
            var content = new StringContent(JsonConvert.SerializeObject(model),
                                             Encoding.UTF8, "application/json"
                                           );

            // Enviamos esses dados para a API e obtemos a resposta
            // PostAsync porque na API o serviço de Cadastramento é POST
            // E o endPoint é api/Funcionario

            // Executar o cadastro
            var response = await client.PostAsync("api/Funcionario", content);

            // Verificar se a API retorna como resposta ==> SUCESSO
            response.StatusCode.Should().Be(HttpStatusCode.Created); // 201 - Criado com sucesso


            // Retorna os dados do Funcionario Cadastrado
            return model;

        }

        [Fact]
        public async Task Test_Funcionario_GetAll()
        {
            //conectar na API
            var client = HttpClientHelper.Create();

            //fazendo a requisição para a API
            var response = await client.GetAsync("/All");

            //capturando o retorno da consulta
            var result = JsonConvert.DeserializeObject<List<FuncionarioConsultaModel>>
                (response.Content.ReadAsStringAsync().Result);

            //verificando se a resposta foi OK!
            response.StatusCode.Should().Be(HttpStatusCode.OK); //200 -> OK


            // Obtem a lista de funcionarios
            var funcionarios = result;

            //verificando se a quantidade de registros obtidos na consulta é maior que zero
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(c => c > 1);
        }


        //[Fact]
        [Fact(Skip = "Não implementado")]
        public void Test_Funcionario_GetById()
        {

        }
    }
}
