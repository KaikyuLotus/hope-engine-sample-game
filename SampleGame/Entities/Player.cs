namespace HopeEngineSampleGame.SampleGame.Entities
{
    // TODO this will be created from an API call, constructor must be empty
    public class Player
    {

        public string Name { get; private set; }

        public int Exp;

        public int Level { get; private set; }

        public int Coins { get; private set; }

        public int Gems { get; private set; }

        public Player(string name, int exp, int level, int coins, int gems)
        {
            Name = name;
            Exp = exp;
            Level = level;
            Coins = coins;
            Gems = gems;
        }

    }
}