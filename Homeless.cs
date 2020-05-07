namespace Dom
{
    public class Homeless : House
    {
        private static Homeless instance = new Homeless("currently homeless",0.0);
        
        private Homeless(string doorColor,double sizeInSqrMtrs)
            : base(doorColor,sizeInSqrMtrs)
        {
        }

        public static Homeless Instance
        {
            get
            {


                return instance;
            }
        }

    }
}