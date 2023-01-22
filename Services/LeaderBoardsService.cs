using LeaderBoards.Models;
using System.Xml.Linq;

namespace LeaderBoards.Services
{
    public static class LeaderBoardsService
    {
        static List<Leader> Leaders { get; }
        static int nextId = 3;
        static LeaderBoardsService()
        {
            Leaders = new List<Leader>
        {
            new Leader { Id = 1, Name = "Illia Kurilenko", Points = 10 },
            new Leader { Id = 2, Name = "Kostya Omelcenko", Points = 7 },
        };
        }

        public static List<Leader> GetAll() => Leaders;

        public static Leader? Get(int id) => Leaders.FirstOrDefault(p => p.Id == id);

        public static void Add(Leader leader)
        {
            leader.Id = nextId++;
            Leaders.Add(leader);
        }

        public static void Delete(int id)
        {
            var leader = Get(id);

            if (leader is null)
                return;

            Leaders.Remove(leader);
        }

        public static void Update(Leader leader)
        {
            var index = Leaders.FindIndex(p => p.Id == leader.Id);
            if (index == -1)
                return;

            Leaders[index] = leader;
        }
    }
}
