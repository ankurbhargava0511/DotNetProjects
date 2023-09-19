using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Threading._2ThreadSync
{
    public static class Do5zbBarrier
    {
        private static readonly Barrier Barrier = new Barrier(participantCount: 0);

        public static void TestBarrier()
        {
            int totalRecords = GetNumberOfRecords();

            Task[] tasks = new Task[totalRecords];

            for (int i = 0; i < totalRecords; ++i)
            {
                Barrier.AddParticipant();

                int j = i;
                tasks[j] = Task.Factory.StartNew(() =>
                {
                    GetDataAndStoreData(j);
                });
            }

            Task.WaitAll(tasks);

            Console.WriteLine("Backup completed");

            Console.Read();
        }


        private static int GetNumberOfRecords()
        {
            return 10;
        }

        private static void GetDataAndStoreData(int index)
        {
            Console.WriteLine("Getting data from server: " + index);
            Thread.Sleep(TimeSpan.FromSeconds(2));

            Barrier.SignalAndWait();

            Console.WriteLine("Send data to Backup server: " + index);

            Barrier.SignalAndWait();
        }

    }


}
