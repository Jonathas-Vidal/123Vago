namespace _123Vago.Dominio
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quarto { get; set; }
        public string Localizacao { get; set; }
        public string Descricao { get; set; }

        public Hotel() { }

        public Hotel(string nome, int quarto, string localizacao, string descricao)
        {
            Nome = nome;
            Quarto = quarto;
            Localizacao = localizacao;
            Descricao = descricao;
        }

        public bool Disponivel()
        {
            return Quarto >= 1;
        }
    }
}

