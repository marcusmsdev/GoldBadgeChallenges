using ChallengeBadgesThreeREPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges.UI

{
    public class BadgeRepo
    {
        private readonly Dictionary<int, List<string>> _dictionaryBadge = new Dictionary<int, List<string>>();

        public bool AddBadgeToDictionary(Badge badge)
        {
            if (badge is null)
            {
                return false;
            }
            else
            {
                _dictionaryBadge.Add(badge.BadgeID, badge.DoorsAccessible);
                return true;
            }
        }

        public bool AddDoorToBadge(int badgeID, string doorToAdd)
        {
            int initialDoorCount;

            if (IsBadgeIDPresent(badgeID) is false)
            {
                return false;
            }
            else
            {
                initialDoorCount = _dictionaryBadge[badgeID].Count;

                _dictionaryBadge[badgeID].Add(doorToAdd);

                return _dictionaryBadge[badgeID].Count > initialDoorCount;
            }
        }

        public bool RemoveDoorFromBadge(int badgeID, string doorToRemove)
        {
            int initialDoorCount;

            if (IsBadgeIDPresent(badgeID) is false && IsDoorPresent(badgeID, doorToRemove) is false)
            {
                return false;
            }
            else
            {
                initialDoorCount = _dictionaryBadge[badgeID].Count;

                _dictionaryBadge[badgeID].Remove(doorToRemove);

                return _dictionaryBadge[badgeID].Count < initialDoorCount;
            }
        }

        public bool RemoveAllDoorsFromBadge(int badgeID)
        {
            if (IsBadgeIDPresent(badgeID) is false)
            {
                return false;
            }
            else
            {
                _dictionaryBadge[badgeID].Clear();

                return _dictionaryBadge[badgeID].Count == 0;
            }
        }

        public bool IsBadgeIDPresent(int badgeID)
        {
            if (_dictionaryBadge.ContainsKey(badgeID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsDoorPresent(int badgeID, string door)
        {
            if (_dictionaryBadge.ContainsKey(badgeID) && _dictionaryBadge[badgeID].Contains(door))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Dictionary<int, List<string>> GetListOfBadges()
        {
            return _dictionaryBadge;
        }
    }
}