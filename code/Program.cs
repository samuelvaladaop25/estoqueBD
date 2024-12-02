using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

class Program
{
    // String de conexão com o banco de dados
    static string connectionString = "Server=sql10.freesqldatabase.com;Database=sql10747220;User=sql10747220;Password=sua_senha;";

    static void Main(string[] args)
    {       
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
