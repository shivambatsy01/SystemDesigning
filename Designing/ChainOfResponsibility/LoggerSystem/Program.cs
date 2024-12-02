using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new InfoLogger(new DebugLogger(new ErrorLogger(null)));

            logger.Log("Debug Log++", LogLevel.Debug);
            logger.Log("Info Log++", LogLevel.Info);
            logger.Log("Error Log++", LogLevel.Error);
            logger.Log("None Log++", LogLevel.None);


            another a1 = new another();
            a1.Run2();

            Console.ReadLine();
        }
    }

    public abstract class test
    {
        public void Run1();
        public void Run2();
        public void Run3();
    }

    public class another : test
    {

    }
}
