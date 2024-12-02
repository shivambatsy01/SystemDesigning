using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketing
{
    internal class SearchFunctionalities
    {
    }

    public interface SearchBar
    {
        void Search();
    }



    public class SearchByName : SearchBar
    {
        public List<Movie> Search(string Name)
        {
            return new List<Movie>();
        }
    }
    
}
