using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asynchronous
{
    internal class Demos
    {
        #region thread vs task 
        // To display thread info

        public static void Display(string message)
        {
            ShowThreadInfo(Thread.CurrentThread);
            Console.WriteLine(message);
        }

        public static void ShowThreadInfo(Thread th)
        {
            Console.WriteLine($"ID : {th.ManagedThreadId} , pooled : {th.IsThreadPoolThread} , Background : {th.IsBackground}");
        }

        #endregion

        #region Task return value

        public static DateTime GetCuurentDateTime() => DateTime.Now;

        #endregion

        #region Long Runinng task

        public static void RunLongTask()
        {
            Thread.Sleep(3000);
            ShowThreadInfo(Thread.CurrentThread);
            Console.WriteLine("completed");
        }
        #endregion

        #region Exception Propagation

        public static void ThrowException()
        {
            throw new NullReferenceException();
        }
        #endregion

        #region Task continuation

        public static int CountPrimeNumberInRange(int lowerBound, int upperBound)
        {
            int count = 0;
            for (int i = lowerBound; i < upperBound; i++)
            {
                int j = lowerBound;
                bool isPrime = true;
                while (j <= (int)Math.Sqrt(i))
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }

                    ++j;
                }

                if (isPrime) ++count;
            }

            return count;
        }
        #endregion

        #region Task.Delay vs thread.sleep

        public static void DelayUsingTask(int ms)
        {
            Task.Delay(ms).GetAwaiter().OnCompleted(() =>
            {
                Console.WriteLine($"completed after Task.Delay({ms})");
            });
        }

        public static void SleepUsingThread(int ms)
        {
            Thread.Sleep(ms);
            Console.WriteLine($"completed after Thread.Sleep({ms})");
        }
        #endregion


        #region Function(Async , Await)

        public static async Task<string> ReadContentAsync(string url)
        {
            var clint = new HttpClient();

            string content = await clint.GetStringAsync(url);

            return content;
        }

        #endregion

    }
}
