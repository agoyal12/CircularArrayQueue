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
    public class Queue : IEnumerable
    {
        private int _capacity;
        public int Count { get; private set; } = 0;

    }
}
