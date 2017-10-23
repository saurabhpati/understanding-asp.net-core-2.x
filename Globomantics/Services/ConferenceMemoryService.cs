using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.Services
{
    public class ConferenceMemoryService: IConferenceService
    {

        private readonly List<ConferenceModel> conferences = new List<ConferenceModel>();

        public ConferenceMemoryService()
        {

        }

        public Task Add(ConferenceModel model)
        {
            model.Id = conferences.Max(c => c.Id) + 1;
            conferences.Add(model);

            return Task.CompletedTask;
        }

        public Task<IEnumerable<ConferenceModel>> GetAll()
        {
            return Task.Run(() => conferences.AsEnumerable());
        }

        public Task<ConferenceModel> GetByID(int id)
        {
            return Task.Run(() => conferences.First(c => c.Id == id));
        }

        public Task<StatisticModel> GetStatistics()
        {
            return Task.Run(() =>
           {
               return new StatisticModel
               {
                   NumberOfAttendees = conferences.Sum(c => c.AttendeeTotal),
                   AverageConferenceAttendees = (int)conferences.Average(c => c.AttendeeTotal)
               };
           });
        }

    }
}
