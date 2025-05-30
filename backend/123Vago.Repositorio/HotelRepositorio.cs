using _123Vago.Dominio;

namespace _123Vago.Repositorio
{
    public class HotelRepositorio : IHotelRepositorio
    {
        private readonly AppDbContext _context;
        public HotelRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public void Salvar(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
        }

        public IEnumerable<Hotel> Listar()
        {
            return _context.Hotels.ToList();
        }

        public Hotel ObterPorId(int id)
        {
            return _context.Hotels.FirstOrDefault(h => h.Id == id);
        }

        public void Remover(Hotel hotel)
        {
            _context.Hotels.Remove(hotel);
            _context.SaveChanges();
        }

        public void Atualizar(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            _context.SaveChanges();
        }

        void IHotelRepositorio.salvar(Hotel hotel)
        {
            Salvar(hotel);
        }
    }
}
