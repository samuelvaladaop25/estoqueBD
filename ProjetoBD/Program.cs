using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ProjetoBD {

    class Program
    {
        // String de conexão com o banco de dados
        static string connectionString = "Server=sql10.freesqldatabase.com;Database=sql10747220;User=sql10747220;Password=X6uMffvNxE;";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====== Sistema de Gerenciamento de Estoque ======");
                Console.WriteLine("1. Gerenciar Filiais");
                Console.WriteLine("2. Gerenciar Produtos");
                Console.WriteLine("3. Gerenciar Fornecedores");
                Console.WriteLine("4. Gerenciar Estoque");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");

                int opcaoPrincipal;
                if (!int.TryParse(Console.ReadLine(), out opcaoPrincipal) || opcaoPrincipal < 1 || opcaoPrincipal > 5)
                {
                    Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                if (opcaoPrincipal == 5) break;  // Encerrar o programa

                // Submenu para CRUD
                Console.Clear();
                Console.WriteLine("1. Criar");
                Console.WriteLine("2. Ler/Listar");
                Console.WriteLine("3. Atualizar");
                Console.WriteLine("4. Deletar");
                Console.Write("Escolha a operação: ");

                int operacao;
                if (!int.TryParse(Console.ReadLine(), out operacao) || operacao < 1 || operacao > 4)
                {
                    Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                // Executa a operação conforme a escolha
                switch (opcaoPrincipal)
                {
                    case 1: MenuFilial(operacao); break;
                    case 2: MenuProduto(operacao); break;
                    case 3: MenuFornecedor(operacao); break;
                    case 4: MenuEstoque(operacao); break;
                }

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
                Console.ReadKey();
            }
        }

        // ---------- MENU PARA FILIAL ----------
        static void MenuFilial(int operacao)
        {
            switch (operacao)
            {
                case 1:
                    Console.Write("Nome da filial: ");
                    string nome = Console.ReadLine();
                    Console.Write("Endereço: ");
                    string endereco = Console.ReadLine();
                    Console.Write("Tipo (empresa/filial): ");
                    string tipo = Console.ReadLine();
                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine());
                    CreateFilial(new Filial(id, nome, endereco, tipo));

                    break;
                case 2:
                    var filiais = ReadFiliais();
                    foreach (var filial in filiais) Console.WriteLine(filial.ToString());
                    break;
                case 3:
                    Console.Write("ID da filial para atualizar: ");
                    id = int.Parse(Console.ReadLine());
                    Console.Write("Novo nome: ");
                    string novoNome = Console.ReadLine();
                    Console.Write("Novo endereço: ");
                    string novoEndereco = Console.ReadLine();
                    Console.Write("Novo tipo (empresa/filial): ");
                    string novoTipo = Console.ReadLine();
                    UpdateFilial(new Filial(id, novoNome, novoEndereco, novoTipo));
                    break;
                case 4:
                    Console.Write("ID da filial para deletar: ");
                    int idDeletar = int.Parse(Console.ReadLine());
                    DeleteFilial(idDeletar);
                    break;
            }
        }

        static void MenuProduto(int operacao)
        {
            switch (operacao)
            {
                case 1:
                    Console.Write("Descrição do produto: ");
                    string descricao = Console.ReadLine();
                    Console.Write("Categoria: ");
                    string categoria = Console.ReadLine();
                    Console.Write("Fornecedor: ");
                    string fornecedor = Console.ReadLine();
                    Console.Write("ID: ");
                    int idP = int.Parse(Console.ReadLine());
                    CreateProduto(new Produto(idP, descricao, categoria, fornecedor));
                    break;

                case 2:
                    var produtos = ReadProdutos();
                    foreach (var produto in produtos)
                        Console.WriteLine(produto.ToString());
                    break;

                case 3:
                    Console.Write("ID do produto para atualizar: ");
                    int idAtualizar = int.Parse(Console.ReadLine()); 
                    Console.Write("Nova descrição: ");
                    string novaDescricao = Console.ReadLine();
                    Console.Write("Nova categoria: ");
                    string novaCategoria = Console.ReadLine();
                    Console.Write("Novo fornecedor: ");
                    string novoFornecedor = Console.ReadLine();
                    UpdateProduto(new Produto(idAtualizar, novaDescricao, novaCategoria, novoFornecedor));
                    break;

                case 4:
                    Console.Write("ID do produto para deletar: ");
                    int idDeletar = int.Parse(Console.ReadLine());
                    DeleteProduto(idDeletar);
                    break;
            }
        }


        // ---------- MENU PARA FORNECEDOR ----------
        static void MenuFornecedor(int operacao)
        {
            switch (operacao)
            {
                case 1:
                    Console.Write("Nome do fornecedor: ");
                    string nome = Console.ReadLine();
                    Console.Write("Contato: ");
                    string contato = Console.ReadLine();
                    Console.Write("Endereço: ");
                    string endereco = Console.ReadLine();
                    Console.Write("ID: ");
                    int idF = int.Parse(Console.ReadLine());
                    CreateFornecedor(new Fornecedor(idF, nome, contato, endereco));
                    break;

                case 2:
                    var fornecedores = ReadFornecedores();
                    foreach (var fornecedor in fornecedores)
                        Console.WriteLine(fornecedor.ToString());
                    break;

                case 3:
                    Console.Write("ID do fornecedor para atualizar: ");
                    int idAtualizar = int.Parse(Console.ReadLine());
                    Console.Write("Novo nome: ");
                    string novoNome = Console.ReadLine();
                    Console.Write("Novo contato: ");
                    string novoContato = Console.ReadLine();
                    Console.Write("Novo endereço: ");
                    string novoEndereco = Console.ReadLine();
                    UpdateFornecedor(new Fornecedor(idAtualizar, novoNome, novoContato, novoEndereco));
                    break;

                case 4:
                    Console.Write("ID do fornecedor para deletar: ");
                    int idDeletar = int.Parse(Console.ReadLine());
                    DeleteFornecedor(idDeletar);
                    break;
            }
        }


        // ---------- MENU PARA ESTOQUE ----------
        static void MenuEstoque(int operacao)
        {
            switch (operacao)
            {
                case 1: // Criar estoque
                    Console.Write("ID do estoque: ");
                    int idE = int.Parse(Console.ReadLine());
                    Console.Write("ID do produto: ");
                    int produtoId = 0;
                    while (!int.TryParse(Console.ReadLine(), out produtoId) || produtoId <= 0)
                    {
                        Console.Write("ID inválido. Por favor, insira um valor positivo: ");
                    }

                    Console.Write("ID da localização (filial): ");
                    int localizacaoId = 0;
                    while (!int.TryParse(Console.ReadLine(), out localizacaoId) || localizacaoId <= 0)
                    {
                        Console.Write("ID inválido. Por favor, insira um valor positivo: ");
                    }

                    Console.Write("Quantidade: ");
                    decimal quantidade = 0;
                    while (!decimal.TryParse(Console.ReadLine(), out quantidade) || quantidade <= 0)
                    {
                        Console.Write("Quantidade inválida. Por favor, insira um valor positivo: ");
                    }

                    Console.Write("Número do fornecedor: ");
                    string numeroFornecedor = Console.ReadLine();

                    Console.Write("Número do lote: ");
                    string numeroLote = Console.ReadLine();

                    // Definir data de entrada e validade
                    DateTime dataEntrada = DateTime.Now;

                    Console.Write("Data de validade (yyyy-MM-dd): ");
                    DateTime dataValidade;
                    while (!DateTime.TryParse(Console.ReadLine(), out dataValidade))
                    {
                        Console.Write("Data inválida. Por favor, insira uma data válida (yyyy-MM-dd): ");
                    }

                    CreateEstoque(new Estoque(idE, produtoId, localizacaoId, quantidade, numeroFornecedor, numeroLote, dataEntrada, dataValidade));


                    break;

                case 2: // Ler estoques
                    var estoques = ReadEstoque();
                    if (estoques.Count == 0)
                    {
                        Console.WriteLine("Nenhum estoque encontrado.");
                    }
                    else
                    {
                        foreach (var estoque in estoques)
                            Console.WriteLine(estoque.ToString());
                    }
                    break;

                case 4: // Deletar estoque
                    Console.Write("ID do estoque para deletar: ");
                    int idDeletar = 0;
                    while (!int.TryParse(Console.ReadLine(), out idDeletar) || idDeletar <= 0)
                    {
                        Console.Write("ID inválido. Por favor, insira um valor válido: ");
                    }
                    DeleteEstoque(idDeletar);
                    break;
            }
        }




        // ---------- CRUD PARA FILIAL ----------
        static void CreateFilial(Filial filial)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO empresas_filiais (nome, endereco, tipo) VALUES (@nome, @endereco, @tipo)";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome", filial.Nome);
                cmd.Parameters.AddWithValue("@endereco", filial.Endereco);
                cmd.Parameters.AddWithValue("@tipo", filial.Tipo);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Filial adicionada com sucesso.");
            }
        }

        static List<Filial> ReadFiliais()
        {
            var filiais = new List<Filial>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM empresas_filiais";
                var cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        filiais.Add(new Filial(
                            Convert.ToInt32(reader["id"]),
                            reader["nome"].ToString(),
                            reader["endereco"].ToString(),
                            reader["tipo"].ToString()
                        ));
                    }
                }
            }
            return filiais;
        }

        static void UpdateFilial(Filial filial)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE empresas_filiais 
                         SET nome = @nome, endereco = @endereco, tipo = @tipo 
                         WHERE id = @id";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", filial.Id);
                cmd.Parameters.AddWithValue("@nome", filial.Nome);
                cmd.Parameters.AddWithValue("@endereco", filial.Endereco);
                cmd.Parameters.AddWithValue("@tipo", filial.Tipo);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Filial atualizada com sucesso.");
            }
        }

        static void DeleteFilial(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM empresas_filiais WHERE id = @id";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Filial deletada com sucesso.");
            }
        }

        // ---------- CRUD PARA PRODUTO ----------
        static void CreateProduto(Produto produto)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO produtos (descricao, categoria, fornecedor) VALUES (@descricao, @categoria, @fornecedor)";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@categoria", produto.Categoria);
                cmd.Parameters.AddWithValue("@fornecedor", produto.Fornecedor);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Produto adicionado com sucesso.");
            }
        }

        static List<Produto> ReadProdutos()
        {
            var produtos = new List<Produto>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM produtos";
                var cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        produtos.Add(new Produto(
                            Convert.ToInt32(reader["id"]),
                            reader["descricao"].ToString(),
                            reader["categoria"].ToString(),
                            reader["fornecedor"].ToString()
                        ));
                    }
                }
            }
            return produtos;
        }

        static void UpdateProduto(Produto produto)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE produtos 
                         SET descricao = @descricao, categoria = @categoria, fornecedor = @fornecedor 
                         WHERE id = @id";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", produto.Id);
                cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@categoria", produto.Categoria);
                cmd.Parameters.AddWithValue("@fornecedor", produto.Fornecedor);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Produto atualizado com sucesso.");
            }
        }

        static void DeleteProduto(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM produtos WHERE id = @id";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Produto deletado com sucesso.");
            }
        }

        // ---------- CRUD PARA FORNECEDOR ----------
        static void CreateFornecedor(Fornecedor fornecedor)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO fornecedores (nome, contato, endereco) VALUES (@nome, @contato, @endereco)";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome", fornecedor.Nome);
                cmd.Parameters.AddWithValue("@contato", fornecedor.Contato);
                cmd.Parameters.AddWithValue("@endereco", fornecedor.Endereco);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Fornecedor adicionado com sucesso.");
            }
        }

        static List<Fornecedor> ReadFornecedores()
        {
            var fornecedores = new List<Fornecedor>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM fornecedores";
                var cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fornecedores.Add(new Fornecedor(
                            Convert.ToInt32(reader["id"]),
                            reader["nome"].ToString(),
                            reader["contato"].ToString(),
                            reader["endereco"].ToString()
                        ));
                    }
                }
            }
            return fornecedores;
        }

        static void UpdateFornecedor(Fornecedor fornecedor)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE fornecedores 
                         SET nome = @nome, contato = @contato, endereco = @endereco 
                         WHERE id = @id";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", fornecedor.Id);
                cmd.Parameters.AddWithValue("@nome", fornecedor.Nome);
                cmd.Parameters.AddWithValue("@contato", fornecedor.Contato);
                cmd.Parameters.AddWithValue("@endereco", fornecedor.Endereco);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Fornecedor atualizado com sucesso.");
            }
        }

        static void DeleteFornecedor(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM fornecedores WHERE id = @id";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Fornecedor deletado com sucesso.");
            }
        }


        // ---------- CRUD PARA ESTOQUE ----------
        static void CreateEstoque(Estoque estoque)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO estoque (produto_id, localizacao_id, quantidade, numero_fornecedor, numero_lote, data_fabricacao, data_validade) 
                             VALUES (@produtoId, @localizacaoId, @quantidade, @numeroFornecedor, @numeroLote, @dataFabricacao, @dataValidade)";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@produtoId", estoque.ProdutoId);
                cmd.Parameters.AddWithValue("@localizacaoId", estoque.LocalizacaoId);
                cmd.Parameters.AddWithValue("@quantidade", estoque.Quantidade);
                cmd.Parameters.AddWithValue("@numeroFornecedor", estoque.NumeroFornecedor);
                cmd.Parameters.AddWithValue("@numeroLote", estoque.NumeroLote);
                cmd.Parameters.AddWithValue("@dataFabricacao", estoque.DataFabricacao);
                cmd.Parameters.AddWithValue("@dataValidade", estoque.DataValidade);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Registro de estoque adicionado com sucesso.");
            }
        }

        static List<Estoque> ReadEstoque()
        {
            var estoques = new List<Estoque>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM estoque";
                var cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        estoques.Add(new Estoque(
                            Convert.ToInt32(reader["id"]),
                            Convert.ToInt32(reader["produto_id"]),
                            Convert.ToInt32(reader["localizacao_id"]),
                            Convert.ToDecimal(reader["quantidade"]),
                            reader["numero_fornecedor"].ToString(),
                            reader["numero_lote"].ToString(),
                            Convert.ToDateTime(reader["data_fabricacao"]),
                            Convert.ToDateTime(reader["data_validade"])
                        ));
                    }
                }
            }
            return estoques;
        }

        static void UpdateEstoque(Estoque estoque)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE estoque 
                         SET produto_id = @produtoId, localizacao_id = @localizacaoId, quantidade = @quantidade,
                             numero_fornecedor = @numeroFornecedor, numero_lote = @numeroLote,
                             data_fabricacao = @dataFabricacao, data_validade = @dataValidade 
                         WHERE id = @id";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", estoque.Id);
                cmd.Parameters.AddWithValue("@produtoId", estoque.ProdutoId);
                cmd.Parameters.AddWithValue("@localizacaoId", estoque.LocalizacaoId);
                cmd.Parameters.AddWithValue("@quantidade", estoque.Quantidade);
                cmd.Parameters.AddWithValue("@numeroFornecedor", estoque.NumeroFornecedor);
                cmd.Parameters.AddWithValue("@numeroLote", estoque.NumeroLote);
                cmd.Parameters.AddWithValue("@dataFabricacao", estoque.DataFabricacao);
                cmd.Parameters.AddWithValue("@dataValidade", estoque.DataValidade);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Estoque atualizado com sucesso.");
            }
        }

        static void DeleteEstoque(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM estoque WHERE id = @id";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Registro de estoque deletado com sucesso.");
            }
        }
    }

    }
