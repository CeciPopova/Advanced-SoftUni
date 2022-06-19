using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public List<Player> Roster { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public Guild(string name, int capacity)
        {
            Roster = new List<Player>();
            Name = name;
            Capacity = capacity;
        }
        private List<Guild> roster;
        public int Count { get { return Roster.Count; } }
        public void AddPlayer(Player player)
        {
            if (Roster.Count < Capacity)
            {
                Roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            var player = Roster.Find(x => x.Name == name);
            if (player == null)
            {
                return false;
            }
            else
            {
                Roster.Remove(player);
                return true;
            }
        }
        public void PromotePlayer(string name)
        {
            var player = Roster.FirstOrDefault(x => x.Name == name);
            if (player != null && player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            var player = Roster.FirstOrDefault(x => x.Name == name);
            if (player != null && player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string @class)
        {
            Player[] kikedPlayers= Roster.Where(x=>x.Class==@class).ToArray();
            Roster.RemoveAll(x=>x.Class==@class);    
            return kikedPlayers;
        }
        public string Report()
        {
            StringBuilder sbb = new StringBuilder();
            int count = 0;  
            sbb.AppendLine($"Players in the guild: {Name}");
            foreach (var item in Roster)
            {
                sbb.Append(item.ToString());
                count++;
                if (count!=Roster.Count)
                {
                    sbb.AppendLine();
                }
            }
            return sbb.ToString();
        }

    }
}
