using ScaleControl.Models.Interfaces;

namespace ScaleControl.Core
{
    public class TicketNumberGenerator
    {
        private readonly IWeighingRepository _repository;

        public TicketNumberGenerator(IWeighingRepository repository)
        {
            _repository = repository;
        }

        public string Generate(string stationNo)
        {
            return _repository.GenerateTicketNo(stationNo);
        }
    }
}
