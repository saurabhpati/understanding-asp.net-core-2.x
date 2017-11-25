using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.Services
{
    public class ProposalMemoryService : IProposalService
    {

        private readonly List<ProposalModel> proposals = new List<ProposalModel>();

        public ProposalMemoryService()
        {
            proposals.Add(new ProposalModel
            {
                Id = 1,
                ConferenceId = 1,
                Speaker = "Roland Guijt",
                Title = "Understanding ASP.NET Core Security"
            });
            proposals.Add(new ProposalModel
            {
                Id = 2,
                ConferenceId = 2,
                Speaker = "John Reynolds",
                Title = "Starting Your Developer Career"
            });
            proposals.Add(new ProposalModel
            {
                Id = 3,
                ConferenceId = 2,
                Speaker = "Stan Lipens",
                Title = "ASP.NET Core TagHelpers"
            });
        }

        public Task Add(ProposalModel model)
        {
            model.Id = proposals.Max(p => p.Id) + 1;
            proposals.Add(model);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Gets all proposals for a partuclar conference.
        /// </summary>
        /// <param name="conferenceId">The conference id for which the proposals are required.</param>
        /// <returns>Enumerale of all proposals in a particular conference.</returns>
        public Task<IEnumerable<ProposalModel>> GetAll(int conferenceId)
        {
            return Task.Run(() => 
            {
                return this.proposals.Where(proposal => proposal.ConferenceId.Equals(conferenceId));
            });
        }

        public Task<ProposalModel> Approve(int proposalId)
        {
            return Task.Run(() =>
            {
                var proposal = proposals.First(p => p.Id == proposalId);
                proposal.Approved = true;

                return proposal;
            });
        }

    }
}
