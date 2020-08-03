using Lib.Abstractions;
using System.Collections.Generic;

namespace Lib
{
    public class SuperheroService
    {
        private readonly IAvengerRepository _avengerRepository;
        private readonly ILogger _logger;
        public SuperheroService(IAvengerRepository avengerRepository, ILogger logger)
        {
            _avengerRepository = avengerRepository;
            _logger = logger;
        }
        public IEnumerable<Hero> GetAvengers()
        {
            //Logger logger = new Logger();
            _logger.Log("Calling SuperheroService.GetAvengers.");

            //AvengerRepository avengerRepository = new AvengerRepository();
            var avengers = _avengerRepository.FetchAll();

            _logger.Log("SuperheroService.GetAvengers called.");

            return avengers;
        }

        public Hero GetAvenger(string name)
        {
            //Logger logger = new Logger();
            _logger.Log("Calling SuperheroService.GetAvenger('{0}').", name);

            //AvengerRepository avengerRepository = new AvengerRepository();
            var avenger = _avengerRepository.Fetch(name);

            _logger.Log("SuperheroService.GetAvenger('{0}') called.", name);

            return avenger;
        }
    }
}
