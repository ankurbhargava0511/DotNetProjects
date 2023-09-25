using System.Collections.Generic;

namespace Basic4ServicesDI.AllServices
{
    public class Tansgi : ITrans
    {
        int counter = 0;
        public int Add()
        {
            return counter++;
        }
    }


    public class Singlett : ISingle
    {
        int counter = 0;
        public int Add()
        {
            return counter++;
        }
    }

    public class Scopes : IScoped
    {
        int counter = 0;
        public int Add()
        {
            return counter++;
        }
    }
}

   

