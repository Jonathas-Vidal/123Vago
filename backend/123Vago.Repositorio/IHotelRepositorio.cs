using _123Vago.Dominio;

namespace _123Vago.Repositorio
{
    public interface IHotelRepositorio
    {
        void salvar(Hotel hotel);
        IEnumerable<Hotel> Listar();
        Hotel ObterPorId(int id);
        void Remover(Hotel hotel);
        void Atualizar(Hotel hotel);
    }
}
