namespace _123Vago.Servico
{
    public interface IHotelServico
    {
        void Adicionar(HotelDto hotelDto);
        bool Remover(int id);
        bool Atualizar(int id, HotelDto hotelDto);
        HotelDto? BuscarPorId(int id);

        IEnumerable<HotelDto> Listar();
    }
}
