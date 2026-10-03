namespace Lesson3
{
    public class TicketSystem
    {
        public  int TicketCount = 1;
        static object lockObject = new object();
        public void ByTicket(object username)
        {
            lock(lockObject)
            if (TicketCount > 0)
            {
                Thread.Sleep(100);
                TicketCount--; //critical section
                Console.WriteLine($"{username} bilet aldi..");
            }
            else
            {
                Console.WriteLine($"{username} ucun artiq bilet yoxudr..");
            }
        }
    }
    static class Program
    {
        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(3, 3);

        static void Print(object student)
        {
            Console.WriteLine($"{student} gozleyir");
            semaphoreSlim.Wait();
            Console.WriteLine($"{student} cap etmeye basladi");
            Thread.Sleep(1000);
            Console.WriteLine($"{student} cap edib bitirdi");
            semaphoreSlim.Release();
        }
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Print);
            Thread thread2 = new Thread(Print);
            Thread thread3 = new Thread(Print);
            Thread thread4 = new Thread(Print);
            Thread thread5 = new Thread(Print);

            thread1.Start("Ali");
            thread2.Start("Nihad");
            thread3.Start("Arzuman");
            thread4.Start("Tural");
            thread5.Start("Elcan");

            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();
            thread5.Join();
        }
            //TicketSystem ticketSystem = new TicketSystem();
            //Thread thread1 = new Thread(ticketSystem.ByTicket);
            //Thread thread2 = new Thread(ticketSystem.ByTicket);
            //thread1.Start("Tural");
            //thread2.Start("Arzuman");

            //thread1.Join();
            //thread2.Join();
            //Console.WriteLine("Bilet sayi: " + ticketSystem.TicketCount);

            //Thread[] threads = new Thread[5];

            //for (int i = 0; i < threads.Length; i++)
            //{
            //    threads[i] = new Thread(() =>
            //    {
            //        for (int i = 0; i < 10000; i++)
            //        {
            //            Test.counter++; //critical section
            //        }
            //    });
            //}

            //for (int i = 0; i < threads.Length; i++)
            //{
            //    threads[i].Start();
            //}

            //Console.WriteLine(Test.counter); 


            //Thread[] threads = new Thread[5];

            //for (int i = 0; i < threads.Length; i++) 
            //{
            //    threads[i] = new Thread(() =>
            //    {
            //        for (int i = 0; i < 10000; i++)
            //        {
            //            //Test.counter++; //critical section
            //            lock (lock_Object)
            //            {
            //                Test.counter++;
            //            }
            //        }
            //    });
            //}

            //for (int i = 0; i < threads.Length; i++)
            //{
            //    threads[i].Start();
            //}

            //for (int i = 0; i < threads.Length; i++)
            //{
            //    threads[i].Join();
            //}

            //Console.WriteLine(Test.counter);



            //Thread[] threads = new Thread[5];

            //for (int i = 0; i < threads.Length; i++)
            //{
            //    threads[i] = new Thread(() =>
            //    {
            //        for (int i = 0; i < 1000; i++)
            //        {
            //            //Test.counter++; //critical section
            //            lock (lock_Object)
            //            {
            //                File.AppendAllText("text.txt", (Test.counter++) + " Data\n");
            //            }
            //        }
            //    });
            //}

            //for (int i = 0; i < threads.Length; i++)
            //{
            //    threads[i].Start();
            //}

            //for (int i = 0; i < threads.Length; i++)
            //{
            //    threads[i].Join(); //main thread gozlesin deye
            //}

            //Console.WriteLine(Test.counter);

        }
    }