namespace HanoiTower
{
    public class PegStatus
    {
        public Peg Peg { get; set; }

        public string Alias { get; set; } = string.Empty;

        public PegStatus(Peg peg)
        {
            Peg = peg;

            switch (peg)
            {
                case Peg.Start: Alias = "A"; break;
                case Peg.Temp: Alias = "B"; break;
                case Peg.End: Alias = "C"; break;
            }
        }
    }
}
