public class Produto
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public string Categoria { get; set; }
    public string Fornecedor { get; set; }

    public Produto(int id, string descricao, string categoria, string fornecedor)
    {
        Id = id;
        Descricao = descricao;
        Categoria = categoria;
        Fornecedor = fornecedor;
    }

    public void ToString()
    {
        Console.WriteLine($"ID: {Id}, Descrição: {Descricao}, Categoria: {Categoria}, Fornecedor: {Fornecedor}");
    }
}
