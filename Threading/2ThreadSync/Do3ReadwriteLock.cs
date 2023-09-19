using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading._2ThreadSync
{
    internal class Do3ReadwriteLock
    {
    }

        public class BankCard
        {

            private decimal _moneyAmount;
            private readonly object _sync = new object();
            private readonly decimal _credit;

            public decimal TotalMoneyAmount
            {
                get
                {
                    using (ReaderWriterLockSlimExt.TakeReaderLock(TimeSpan.FromMilliseconds(3)))
                    {
                        return _moneyAmount + _credit;
                    }
                }
            }

            public BankCard(decimal moneyAmount, decimal credit)
            {
                _moneyAmount = moneyAmount;
                _credit = credit;
            }

            public void ReceivePayment(decimal amount)
            {

                var rw = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
                rw.EnterWriteLock();

                _moneyAmount += amount;

                rw.ExitWriteLock();

            }

            public void TransferToCard(decimal amount, BankCard recipient)
            {
                lock (_sync)
                {
                    _moneyAmount -= amount;
                    recipient.ReceivePayment(amount);
                }
            }
        }
    

    public static class ReaderWriterLockSlimExt
    {
        public static ReaderLockSlimWrapper TakeReaderLock(TimeSpan timeout)
        {
            var rwlock = new ReaderWriterLockSlim();

            bool taken = false;
            try
            {
                taken = rwlock.TryEnterReadLock(timeout);
                if (taken)
                    return new ReaderLockSlimWrapper(rwlock);
                throw new TimeoutException("Failed to acquire a ReaderWriterLockSlim in time.");
            }
            catch
            {
                if (taken)
                    rwlock.ExitReadLock();
                throw;
            }
        }

        public struct ReaderLockSlimWrapper : IDisposable
        {
            private readonly ReaderWriterLockSlim _rwlock;

            public ReaderLockSlimWrapper(ReaderWriterLockSlim rwlock)
            {
                _rwlock = rwlock;
            }
            public void Dispose()
            {
                _rwlock.ExitReadLock();
            }
        }

        public static WriterLockSlimWrapper TakeWriterLock(TimeSpan timeout)
        {
            var rwlock = new ReaderWriterLockSlim();

            bool taken = false;
            try
            {
                taken = rwlock.TryEnterWriteLock(timeout);
                if (taken)
                    return new WriterLockSlimWrapper(rwlock);
                throw new TimeoutException("Failed to acquire a ReaderWriterLockSlim in time.");
            }
            catch
            {
                if (taken)
                    rwlock.ExitWriteLock();
                throw;
            }
        }

        public struct WriterLockSlimWrapper : IDisposable
        {
            private readonly ReaderWriterLockSlim _rwlock;

            public WriterLockSlimWrapper(ReaderWriterLockSlim rwlock)
            {
                _rwlock = rwlock;
            }
            public void Dispose()
            {
                _rwlock.ExitWriteLock();
            }
        }
    }

}
