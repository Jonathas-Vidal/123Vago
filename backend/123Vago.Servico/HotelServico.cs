using _123Vago.Dominio;
using _123Vago.Repositorio;

namespace _123Vago.Servico
{
    public class HotelServico : IHotelServico
    {
        private readonly IHotelRepositorio _repositorio;

        public HotelServico(IHotelRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Adicionar(HotelDto hotelDto)
        {
            var hotel = new Hotel(hotelDto.Nome, hotelDto.Quarto, hotelDto.Localizacao, hotelDto.Descricao);
            _repositorio.salvar(hotel);
        }

        public IEnumerable<HotelDto> Listar()
        {
            return _repositorio.Listar().Select(hotel => new HotelDto
            {
                Id = hotel.Id,
                Nome = hotel.Nome,
                Quarto = hotel.Quarto,
                Localizacao = hotel.Localizacao,
                Descricao = hotel.Descricao

            });
        }
        public bool Remover(int id)
        {
            var hotel = _repositorio.ObterPorId(id);
            if (hotel == null) return false;

            _repositorio.Remover(hotel);
            return true;
        }

        public bool Atualizar(int id, HotelDto dto)
        {
            var hotel = _repositorio.ObterPorId(id);
            if (hotel == null) return false;

            hotel.Nome = dto.Nome;
            hotel.Quarto = dto.Quarto;
            hotel.Localizacao = dto.Localizacao;
            hotel.Descricao = dto.Descricao;

            _repositorio.Atualizar(hotel);
            return true;
        }


        public HotelDto? BuscarPorId(int id)
        {
            var hotel = _repositorio.ObterPorId(id);
            if (hotel == null) return null;

            return new HotelDto
            {
                Id = hotel.Id,
                Nome = hotel.Nome,
                Quarto = hotel.Quarto,
                Localizacao = hotel.Localizacao,
                Descricao = hotel.Descricao
            };
        }
    }
}
