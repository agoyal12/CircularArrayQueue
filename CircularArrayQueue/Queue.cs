using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularArrayQueue
{
    //Abstract data type
    //Queue is FIFO - First In First Out
    //Implements a queue as a circular array. (circular queue)
    //Items are inserted at one end and removed from the other
    public class Queue : IEnumerable // sort out error
    {
        private int _capacity;
        public int Count { get; private set; } = 0;
        private object[] _queueArray;
        private int _head = -1;
        private int _tail = -1;

        // constructor 
        public Queue(int capacity)
        {
            _capacity = capacity;
            _queueArray = new object[_capacity];
        }

        // Adds an object to the end/tail of the Queue
        // increment tail to Insert or Enqueue
        // increment head to Dequeue 

            // method
        public void Enqueue(object obj)
        {
            // tail++ = Enqueue
            // head++ = Dequeue
            // 0 to end = full or if the tail has looped around before the current head

            if ((_head == 0 && _tail == _capacity - 1) || _tail == (_head - 1)) // if we have full list- no empty space then we can do multiple things -logical queue
            {
                
                object[] tempArray = new object[Count + 1];

                //resize array
                if(_head !=-1) //check for empty list
                {
                    int j = 0;
                    if (_tail >= _head) //Normal
                    {
                        // loop from head to tail
                        for( int i = _head; i<_capacity; i++)
                        {
                            tempArray[j] = _queueArray[i];
                            j++;
                        }
                    }
                    else //tail has looped around
                    {
                        // head to end of array
                        for(int i =_head; i <_capacity; i++)
                        {
                            tempArray[j] = _queueArray[i];
                            j++;
                        }
                    }
                }
                else //for empty array
                {
                    if(_head == -1 && _tail == -1) // new list set head
                    {
                        _head++;
                        _tail++;
                    }
                    else if (_tail == _capacity -1) //tails at end wrap tail back to the beginning
                    {
                        _tail = 0;
                    }
                    else // normal increment for enqueue
                    {
                        _tail++;
                    }

                    _queueArray[_tail] = obj;

                }
                Count++;
            }
        }

        //Removes and returns the object at teh beginning of the Queue.
        // No need to physically remove the object just logically remove it

        public object Dequeue()
        {
            if (_head == -1) // empty queue
            {
                throw new Exception("Queue is Empty");
            }

            object head = _queueArray[_head];

            if (_head == _tail) //last item in array/queue
            {
                //reset array indexes
                _head = -1;
                _tail = -1;
            }
            else if (_head == _capacity - 1) // wrap around when we reach the end
            {
                _head = 0;
            }
            else // Normal increment for dequeue
            {
                _head++;
            }
            Count--;
            return head;
        }
    }
}
