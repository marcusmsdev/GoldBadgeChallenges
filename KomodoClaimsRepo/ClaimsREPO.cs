using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeClaimsTwoRepo
{
    public class ClaimsREPO
    {
        private readonly Queue<Claim> _claimsQueue = new Queue<Claim>();

        public bool AddClaimToQueue(Claim claim)
        {
            if (claim is null)
            {
                return false;
            }
            else
            {
                _claimsQueue.Enqueue(claim);
                return true;
            }
        }
        public bool RemoveClaimFromQueue()
        {
            if (_claimsQueue is null || _claimsQueue.Count == 0)
            {
                return false;
            }
            else
            {
                Claim remove = _claimsQueue.Dequeue();
                return true;
            }
        }

        public Queue<Claim> GetClaimsQueue()
        {
            return _claimsQueue;
        }
    }
}
