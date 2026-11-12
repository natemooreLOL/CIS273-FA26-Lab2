namespace ReverseFirstK;

public class Program
{
     public static void Main(string[] args)
     {
     }

     /// <summary>
     /// Write a method void ReverseFirstK(Queue q, int k) that reverses the first k elements of the given queue. 
     /// You may only use stacks and queues (NOT deques) to do this. 
     /// </summary>
     /// <typeparam name="T"></typeparam>
     /// <param name="queue"></param>
     /// <param name="k"></param>
     /// <returns></returns>
     public static void ReverseFirstK<T>(Queue<T> queue, int k)
     {
          if(queue is null)
          {
               throw new ArgumentNullException();
          }
          if(k < 0)
          {
               throw new ArgumentException();
          }
          if(k == 0)
          {
               return;
          }
          Stack<T> TempStack = new Stack<T>();
          if(k >= queue.Count)
          {
               while(queue.Count > 0)
               {
                    TempStack.Push(queue.Dequeue());
               }
               while(TempStack.Count > 0)
               {
                    queue.Enqueue(TempStack.Pop());
               }
               return;
          }
          // if k > length, then just reverse the entire queue
          // if queue is null, throw an ArgumentNullException
          // if k < 0, throw an ArgumentException
          Queue<T> TempQueue = new Queue<T>();

          // 1) dequeue first k elements and push them on a stack
          for(int i = k; i > 0; i--)
          {
               TempStack.Push(queue.Dequeue());
          }
          // 2) pop elements from stack and enqueue on queue 
          while(queue.Count > 0)
          {
               TempQueue.Enqueue(queue.Dequeue());
          }
          while(TempStack.Count > 0)
          {
               queue.Enqueue(TempStack.Pop());
          }
          // 3)  dequeue and enqueue q.length - k times
          while(TempQueue.Count > 0)
          {
               queue.Enqueue(TempQueue.Dequeue());
          }


     }
}

