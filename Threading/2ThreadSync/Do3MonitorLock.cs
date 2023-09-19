using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading._2ThreadSync
{
    public class MonitorforPayment
    {
        private decimal _moneyAmount;
        private readonly object _sync = new object();
        private readonly decimal amount;

        public void ReceivePayment(decimal amount)
        {
            _moneyAmount += amount;

        }


        private void WaysOfUsingMonitor()
        {
            //Monitor with lock keyword
            lock (_sync)
                {
                    _moneyAmount -= amount;
                    ReceivePayment(amount);
                }
            //Monitor with exntesion
            using (_sync.MyLock(TimeSpan.FromSeconds(3)))
            {
                _moneyAmount -= amount;
                ReceivePayment(amount);
            }
            //Full-blown pattern with Monitor
            bool lockTaken = false;
            try
            {
                Monitor.Enter(_sync, ref lockTaken);
                _moneyAmount -= amount;
                ReceivePayment(amount);
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit(_sync);
            }
        }
    }

 

    public static class LockExtensions
    {
        public static Lock MyLock(this object obj, TimeSpan timeout)
        {
            bool lockTaken = false;
            try
            {
                Monitor.TryEnter(obj, timeout, ref lockTaken);
                if (lockTaken)
                {
                    return new Lock(obj);
                }

                throw new TimeoutException("Failed to acquire sync object.");
            }
            catch
            {
                if (lockTaken)
                {
                    Monitor.Exit(obj);
                }

                throw;
            }
        }
        public struct Lock : IDisposable
        {
            private readonly object _obj;

            public Lock(object obj)
            {
                _obj = obj;
            }
            public void Dispose()
            {
                Monitor.Exit(_obj);
            }
        }
    }
}
