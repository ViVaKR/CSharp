namespace HanoiTower
{
    public class Pile
    {
        public PileType PileType { get; set; }

        public string Alias { get; set; } = string.Empty;

        public Pile(PileType pile)
        {
            PileType = pile;

            switch (pile)
            {
                case PileType.Start: Alias = "A"; break;
                case PileType.Temp: Alias = "B"; break;
                case PileType.End: Alias = "C"; break;
            }
        }
    }
}
