public class Estoque
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public int LocalizacaoId { get; set; }
    public decimal Quantidade { get; set; }
    public string NumeroFornecedor { get; set; }
    public string NumeroLote { get; set; }
    public DateTime DataFabricacao { get; set; }
    public DateTime DataValidade { get; set; }

    public Estoque(int id, int produtoId, int localizacaoId, decimal quantidade, string numeroFornecedor, string numeroLote, DateTime dataFabricacao, DateTime dataValidade)
    {
        Id = id;
        ProdutoId = produtoId;
        LocalizacaoId = localizacaoId;
        Quantidade = quantidade;
        NumeroFornecedor = numeroFornecedor;
        NumeroLote = numeroLote;
        DataFabricacao = dataFabricacao;
        DataValidade = dataValidade;
    }

    public void ToString()
    {
        Console.WriteLine($"ID: {Id}, ProdutoID: {ProdutoId}, LocalizaçãoID: {LocalizacaoId}, Quantidade: {Quantidade}, " +
                          $"Número Fornecedor: {NumeroFornecedor}, Número Lote: {NumeroLote}, " +
                          $"Data Fabricação: {DataFabricacao.ToShortDateString()}, Data Validade: {DataValidade.ToShortDateString()}");
    }
}
