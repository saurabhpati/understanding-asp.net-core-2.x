﻿using System;
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

        }

        public Task Add(ProposalModel model)
        {
            model.Id = proposals.Max(p => p.Id) + 1;
            proposals.Add(model);

            return Task.CompletedTask;
        }

        public Task<IEnumerable<ProposalModel>> GetAll(int conferenceId)
        {
            return Task.Run(() => proposals.AsEnumerable());
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
