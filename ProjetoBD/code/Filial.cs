public class Filial
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Tipo { get; set; } // 'empresa' ou 'filial'

    public Filial(int id, string nome, string endereco, string tipo)
    {
        Id = id;
        Nome = nome;
        Endereco = endereco;
        Tipo = tipo;
    }

    public new string ToString()
    {
        return $"ID: {Id}, Nome: {Nome}, Endereço: {Endereco}, Tipo: {Tipo}";
    }
}
