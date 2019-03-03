# Laboratory Work No.2

## Multithreading Programming

### Task
- Create a program that would use Event-Driven Concurrency to _"recreate the situation"_ below:

![img](https://user-images.githubusercontent.com/22482507/52741749-cbcd8600-2fde-11e9-8547-d8fdc9260a9b.JPG)   

---

### Solution_

__Language__: C#

```cs
AutoResetEvent[] autoResetEvents = {
  new AutoResetEvent(false),
  new AutoResetEvent(false),
  new AutoResetEvent(false)
};
var lastEvent = new Man static AutoResetEvent[] waitall = 
        {
           new AutoResetEvent(false),
           new AutoResetEvent(false),
           new AutoResetEvent(false),

        };

        static ManualResetEvent waitone = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            Thread five = new Thread(() => { Console.WriteLine("5"); waitall[0].Set(); });
            Thread six = new Thread(() => { Console.WriteLine("6"); waitall[1].Set(); });
            Thread seven = new Thread(() => {Console.WriteLine("7"); waitall[2].Set(); });
            Thread four = new Thread(() => {  WaitHandle.WaitAll(waitall); Console.WriteLine("4"); waitone.Set(); });
            Thread three = new Thread(() => { waitone.WaitOne(); Console.WriteLine("3"); });
            Thread two = new Thread(() => {  waitone.WaitOne(); Console.WriteLine("2"); });
            Thread one = new Thread(() => { waitone.WaitOne(); Console.WriteLine("1"); });


            List<Thread> list = new List<Thread>();

            list.Add(five);
            list.Add(six);
            list.Add(seven);
            list.Add(four);
            list.Add(three);
            list.Add(two);
            list.Add(one);

            foreach (var x in list)
            {
                x.Start();
            }
            Console.ReadKey();

        }ualResetEvent(false);

var threads = new List<Thread>
{
  new Thread(() => { Console.WriteLine("7"); autoResetEvents[0].Set(); }),
  new Thread(() => { Console.WriteLine("6"); autoResetEvents[1].Set(); }),
  new Thread(() => { Console.WriteLine("5"); autoResetEvents[2].Set(); }),
  new Thread(() => { WaitHandle.WaitAll(autoResetEvents);
                Console.WriteLine("4"); lastEvent.Set(); }),
  new Thread(() => { lastEvent.WaitOne(); Console.WriteLine("3"); }),
  new Thread(() => { lastEvent.WaitOne(); Console.WriteLine("2"); }),
  new Thread(() => { lastEvent.WaitOne(); Console.WriteLine("1"); })
};

threads.ForEach(x => x.Start());
Console.ReadKey();
```

- There are 6 threads and an array of _AutoResetEvents_ is set to `false`.

- The first 3 threads (__5-7__) after they're executed, each set an _AutoResetEvent_ from the array to `true`.

- The __4th__ thread is waiting for all of those to be set to `true`, after that it can be executed.

  + After it finishes its task, a _ManualResetEvent_ (which is `false` until this) is set to `true`.


- The last threads (__1-3__) are waiting for that _ManualResetEvent_ to be set to `true`, and then execute.

  + A _ManualResetEvent_ is used instead of an _AutoResetEvent_ because it allows multiple threads to continue, whereas the 2nd one only allows one thread at a time, and we don't want that.
