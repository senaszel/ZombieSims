namespace Dom
{
    public sealed class TempSim
    {
        private static TempSim instance = new TempSim();
        private Sim sim;

        private TempSim()
        {
        }

        public static TempSim Instance
        {
            get
            {
                return instance;
            }
        }

        internal Sim Sim { get => sim; set => sim = value; }
    }
}
