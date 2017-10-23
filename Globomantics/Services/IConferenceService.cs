using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.Services
{
    public interface IConferenceService
    {

        Task Add(ConferenceModel model);

        Task<IEnumerable<ConferenceModel>> GetAll();

        Task<ConferenceModel> GetByID(int id);

        Task<StatisticModel> GetStatistics();

    }
}
