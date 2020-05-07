namespace Dom
{
    public class Sim
    {

        private string _name;
        private House _locatedAt;
        public House LocatedAt { get => _locatedAt; set => _locatedAt = value; }
        public string Name { get => _name; }


        public Sim(string name)
        {
            _name = name;
            LocatedAt = Homeless.Instance;
            PopulationCensus.Instance.Sims.Add(this);
        }

        public override string ToString()
        {


            return $"{_name} lives in [{LocatedAt}]";
        }

        public string ExtandedHousingInfo()
        {


            return $"{LocatedAt} that is of size: {LocatedAt.SizeInSqrMtrs} square meters";
        }
    }
}