using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
                List<Carts>
                List<Floors>
                Each Cart has composition with CartButtons
                Each Floor has composition with CartButtons
                A CartButtonCommand passed as ctor dependency to every CartButton
                A FloorButtonCommand passed as ctor dependency to every FloorButton
                A DispatcherSystemObject  : Can be used as Singleton

                make few APIs public:
                like :
                button press, get-Create Dispatcher etc. Rest can be created as internal as put main() in another namespace
                Think how to write complex Algos for schedular : Try to use heaps, find loginc for nearest (time and distance wise)

            */
        }
    }
}
