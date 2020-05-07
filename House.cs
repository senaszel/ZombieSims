using System.Collections.Generic;

namespace Dom
{
    public class House
    {
        private string _doorsColor;
        private double _sizeInSqrMtrs;
        private int _MaxCapacity;
        private List<Sim> _tenants;

        internal List<Sim> Tenants { get => _tenants; }
        public double SizeInSqrMtrs { get => _sizeInSqrMtrs; }

        public House(string doorColor, double sizeInSqrMtrs)
        {
            _doorsColor = doorColor;
            _sizeInSqrMtrs = sizeInSqrMtrs;
            _MaxCapacity = (int)sizeInSqrMtrs / 15;
            _tenants = new List<Sim>();
            if (GetType() != typeof(Homeless))
            {
                BuildingsCensus.Instance.Buildings.Add(this);
            }
        }

        public override string ToString()
        {
            if (GetType() == typeof(Homeless))
            {


                return "currently homeless";
            }

            List<Sim> evictionList = new List<Sim>();
            _tenants.ForEach(x => { if (x.LocatedAt.Equals(this) == false) { evictionList.Add(x); } });
            evictionList.ForEach(x => _tenants.Remove(x));

            return $"House with {_doorsColor} door, {_tenants.Count} people inhabit this place.";
        }

        public string ShortToString()
        {


            return $"House with {_doorsColor} door";
        }

        public int TryAddTennant(Sim sim)
        {
            if (Tenants.Count + 1 <= _MaxCapacity)
            {
                if (_tenants.Find(x => x.Equals(sim)) != sim)
                {
                    _tenants.Add(sim);
                    sim.LocatedAt = this;


                    return 0;
                }
                else
                {


                    return -2;
                }
            }
            else
            {


                return -1;
            }

        }

    }
}
