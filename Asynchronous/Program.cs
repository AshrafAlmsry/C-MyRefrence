using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using static Asynchronous.Demos;
namespace Asynchronous
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("==========Asynchronous==========");
            #region thread vs task
            //var th = new Thread((() => Display("Metiator using thread !!!")));
            //th.Start();
            //th.Join();
            ////-------------
            //Task.Run((() => Display("Metigator using task !!"))).Wait();
            #endregion

            #region tsk return value
            //Task<DateTime> task = Task.Run(GetCuurentDateTime);
            //way => 1
            //Console.WriteLine(task.Result);//block thread until result is ready
            //way => 2
            //Console.WriteLine(task.GetAwaiter().GetResult());
            #endregion

            #region Long Runinng task
            //var task = Task.Factory.StartNew(() => RunLongTask(), TaskCreationOptions.LongRunning);
            #endregion

            #region Exception Propagation

            //try
            //{
            //    Task.Run(ThrowException).Wait();
            //}
            //catch
            //{
            //    Console.WriteLine("Exception is thrown !!");
            //}
            #endregion

            #region Task continuation
            //Task<int> task = Task.Run(() => CountPrimeNumberInRange(2, 3_000_000));
            //Console.WriteLine(task.Result);//this pad way becuse block thread(after code)
            //-- 1 --
            //Console.WriteLine("using (awaiter , onCompleted");
            //var awaiter = task.GetAwaiter();
            //awaiter.OnCompleted(() => Console.WriteLine(awaiter.GetResult()));
            //Console.WriteLine("code after task");
            //-------
            //-- 2 --
            //Console.WriteLine("using task ContinueWith ");
            //task.ContinueWith((x) => Console.WriteLine(x.Result));
            //Console.WriteLine("code after task");
            //-------
            #endregion

            #region Task.Delay vs thread.sleep

            //DelayUsingTask(3000);//controll the logical delay

            //SleepUsingThread(3000);//plock the thread to its finish
            #endregion

            #region Function(Async , Await)

            //--1--
            //put shoult method[static async Task Main(string[] args)]
            //string content = await ReadContentAsync("https://www.youtube.com/@Metigator");
            //Console.WriteLine(content);
            #endregion


            Console.ReadKey();
        }
    }
}
