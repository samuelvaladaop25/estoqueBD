public class Fornecedor
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Contato { get; set; }
    public string Endereco { get; set; }

    public Fornecedor(int id, string nome, string contato, string endereco)
    {
        Id = id;
        Nome = nome;
        Contato = contato;
        Endereco = endereco;
    }

    public void ToString
    {
        Console.WriteLine($"ID: {Id}, Nome: {Nome}, Contato: {Contato}, Endereço: {Endereco}");
    }
}
