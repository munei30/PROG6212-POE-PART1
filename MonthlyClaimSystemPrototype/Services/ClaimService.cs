using System;
using System.Collections.Generic;
using System.Linq;
using MonthlyClaimSystemPrototype.Models;

namespace MonthlyClaimSystemPrototype.Services
{
    public class ClaimService
    {
        private readonly List<Claim> _claims = new();

        public void AddClaim(Claim claim)
        {
            if (claim == null)
                throw new ArgumentNullException(nameof(claim));

            if (claim.ClaimID == 0)
                claim.ClaimID = _claims.Count + 1;

            _claims.Add(claim);
        }

        public List<Claim> GetAll()
        {
            return _claims;
        }

        public List<Claim> GetPending()
        {
            return _claims.Where(c => c.Status == ClaimStatus.Pending).ToList();
        }

        public bool ApproveClaim(int id)
        {
            var claim = _claims.FirstOrDefault(c => c.ClaimID == id);
            if (claim == null)
                return false;

            claim.Status = ClaimStatus.Approved;
            return true;
        }

        public bool RejectClaim(int id)
        {
            var claim = _claims.FirstOrDefault(c => c.ClaimID == id);
            if (claim == null)
                return false;

            claim.Status = ClaimStatus.Rejected;
            return true;
        }
    }
}
