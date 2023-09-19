using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Threading._2ThreadSync
{
    public static class Do5AutoResetEventandManualResetSignaling
    {

        public static void TestBankTerminalWithManualReset()
        {
            var bt = new BankTerminalManual(new IPEndPoint(new IPAddress(0x2414188f), 8080));

            Task purchaseTask = bt.Purchase(100);
            var firstContinue = purchaseTask.ContinueWith(x => { Console.WriteLine("Operation is done!"); });
            firstContinue.ContinueWith(x =>
            {
                Console.WriteLine("-----------Another Operation with Manual-----------");
                Task secondPurchase = bt.Purchase(100);
                secondPurchase.ContinueWith(y => { Console.WriteLine("Operation is Done!"); });
            });
        }

        public static void TestBankTerminalWithAutoReset()
        {
            var bt = new BankTerminalAuto(new IPEndPoint(new IPAddress(0x2414188f), 8080));

            Task purchaseTask = bt.Purchase(100);
            var firstContinue = purchaseTask.ContinueWith(x => { Console.WriteLine("Operation is done!"); });
            firstContinue.ContinueWith(x =>
            {
                Console.WriteLine("-----------Another Operation With Auto-----------");
                Task secondPurchase = bt.Purchase(100);
                secondPurchase.ContinueWith(y => { Console.WriteLine("Operation is Done!"); });
            });
        }



    }



    public class BankTerminalAuto
    {
        private readonly Protocol _protocol;
        private readonly AutoResetEvent _operationSignal = new AutoResetEvent(false);

        public BankTerminalAuto(IPEndPoint endPoint)
        {
            _protocol = new Protocol(endPoint);
            _protocol.OnMessageReceived += OnMessageReceived;
        }

        private void OnMessageReceived(object sender, ProtocolMessage e)
        {
            if (e.Status == OperationStatus.Finished)
            {
                Console.WriteLine("Signaling!");
                _operationSignal.Set();
            }
        }

        public Task Purchase(decimal amount)
        {
            return Task.Run(() =>
            {
                const int purchaseOpCode = 1;
                _protocol.Send(purchaseOpCode, amount);
                Console.WriteLine("Waiting for Auto signal.");
                _operationSignal.WaitOne();
            });
        }
    }


    public class BankTerminalManual
    {
        private readonly Protocol _protocol;
        private readonly ManualResetEvent _operationSignal = new ManualResetEvent(false);

        public BankTerminalManual(IPEndPoint endPoint)
        {
            _protocol = new Protocol(endPoint);
            _protocol.OnMessageReceived += OnMessageReceived;
        }

        private void OnMessageReceived(object sender, ProtocolMessage e)
        {
            if (e.Status == OperationStatus.Finished)
            {
                Console.WriteLine("Signaling!");
                _operationSignal.Set();
            }
        }

        public Task Purchase(decimal amount)
        {
            return Task.Run(() =>
            {
                const int purchaseOpCode = 1;
                _protocol.Send(purchaseOpCode, amount);

                _operationSignal.Reset();
                Console.WriteLine("Waiting for Manual signal.");
                _operationSignal.WaitOne();
            });
        }
    }



    public enum OperationStatus
    {
        Finished,
        Faulted
    }


    public class Protocol
    {
        private readonly IPEndPoint _endPoint;

        public Protocol(IPEndPoint endPoint)
        {
            _endPoint = endPoint;
        }

        public void Send(int opCode, object parameters)
        {
            Task.Run(() =>
            {
                //emulating interoperatinon with a bank terminal device
                Console.WriteLine("Operation is in action.");
                Thread.Sleep(3000);

                OnMessageReceived?.Invoke(this, new ProtocolMessage(OperationStatus.Finished));

            });
        }

        public event EventHandler<ProtocolMessage> OnMessageReceived;
    }


    public class ProtocolMessage
    {
        public OperationStatus Status { get; }

        public ProtocolMessage(OperationStatus status)
        {
            this.Status = status;
        }
    }


}
