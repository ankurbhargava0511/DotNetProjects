using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Threading._2ThreadSync
{
    public static class Do5zaCountDownEvent
    {

        private static CountdownEvent _countdown = new CountdownEvent(3);


        public static void TestCountdown()
        {
            Task.Run(() => { DoWork(); });
            Task.Run(() => { DoWork(); });
            Task.Run(() => { DoWork(); });

            _countdown.Wait();
            Console.WriteLine("All tasks have finished their work!");

            //won't work (return false) if countdown is already equal to zero
            //_countdown.TryAddCount(1);
        }

        private static void DoWork()
        {
            Thread.Sleep(1000);
            Console.WriteLine($"I'm a task with id:{Task.CurrentId}");
            _countdown.Signal();
        }

    }


}
