using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading
{
    public delegate void SumOfNumberCallbackDelegate(int SumOfNum);
    internal class ThreadBasic
    {
        

        public void RunThread()
        {
            Console.WriteLine("Only Thread");
            Thread t = new Thread(Method);
            t.Start();

            Console.WriteLine("Only ThreadStart");
            ThreadStart ts = MethodThreadStart;
            Thread tt = new Thread(ts);
            tt.Start();

            Console.WriteLine("ParameterizedThreadStart");
            ParameterizedThreadStart pts = new ParameterizedThreadStart(MethodThreadStartWithN);
            Thread PtsT = new Thread(pts);
            PtsT.Start(6);


            Console.WriteLine("ThreadWithReturnWithTypeSafe()");
            ThreadWithReturnWithTypeSafe();

            ThreadWithCallBack();
        }

        public void Method()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("T" + i.ToString());
            }
        }


        public void MethodThreadStart()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("Ts" + i.ToString());
            }
        }

        public void MethodThreadStartWithN(object n)
        {
            int nvalue = Convert.ToInt32(n);
            for (int i = 0; i <= nvalue; i++)
            {
                Console.WriteLine("Tsp " + n.ToString() + " " + i.ToString());
            }
        }


        public void ThreadWithReturnWithTypeSafe()
        {
            int max = 10;
            NumberHelper _helper = new NumberHelper(max);
            ThreadStart obj = new ThreadStart(_helper.ShowNumbers);

            Thread t = new Thread(obj);
            t.Start();
            
        }

        public void ThreadWithCallBack()
        {
            int max = 10;
            SumOfNumberCallbackDelegate _callback = new SumOfNumberCallbackDelegate(DisplaySumOfNo);
            NumberHelperCallback _helper = new NumberHelperCallback(max, _callback);

            ThreadStart obj = new ThreadStart(_helper.ShowNumbers);

            Thread t = new Thread(obj);
            t.Start();
            

        }
        public static void DisplaySumOfNo(int Sum)
        {
            Console.WriteLine("the sum of numbers is :- " + Sum);
        }
    }



    public class NumberHelper
    {
        private int _Number;
        public NumberHelper(int num)
        {
            _Number = num;
        }

        public void ShowNumbers()
        {
            for (int i = 0; i < _Number; i++)
            {
                Console.WriteLine(i);
            }
        }

    }

    public class NumberHelperCallback
    {
        private int _Number;
        SumOfNumberCallbackDelegate _callbackDelegate;
        public NumberHelperCallback(int num, SumOfNumberCallbackDelegate _deletgate)
        {
            _Number = num;
            _callbackDelegate = _deletgate;
        }

        public void ShowNumbers()
        {
            int sum = 0;
            for (int i = 0; i < _Number; i++)
            {
                sum = sum + i;
            }

            if (_callbackDelegate != null)
                _callbackDelegate(sum);

        }

    }






}
