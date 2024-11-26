using Tril_3.Dtos;

namespace Tril_3.Repostorys.Cinema
{
    public interface ICinemaRepo
    {
        public void AddAllCinema(CinemaDto2 dto);
        public List<CinemaDto2> GetAllCinema();
        public CinemaDto2 GetCinemaById(int id);
        public void update(CinemaDto2 dto, int id);
    }
}
