namespace Domain.Models
{
    public sealed class Veiculo
    {
        public int Id { get; private set; }
        public string Placa { get; private set; }
        public string Montadora { get; private set; }
        public string Modelo { get; private set; }

        public Veiculo(int id, string placa, string montadora, string modelo)
        {
            Id = id;
            Placa = placa;
            Montadora = montadora;
            Modelo = modelo;
        }
    }
}
