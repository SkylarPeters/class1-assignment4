using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment4
{
    class GenericStack<T>
    {
        // Make node class as an inner class.
        protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
        }

        // A couple of pointers to the head and tail of the linked list.
        protected Node _head;
        protected Node _tail;
        protected int _size;

        public bool IsEmpty
        {
            get
            {
                // To check whether or not it is empty we can check
                // to see if the head pointer is null. If so, there
                // are no nodes in the list, so it must be empty.
                return _head == null;
            }
        }

        public int Size
        {
            get
            {
                return _size;
            }
        }

        // Method to add to the stack
        public void Push(T Data)
        {
            // Make a pointer to the tail called oldTail
            Node oldTail = _tail;
            // Make a new node and assign it to the tail variable
            _tail = new Node();
            // Assign the data and set the next pointer
            _tail.Data = Data;
            _tail.Next = null;
            // Ceck to see if the list is empty. If so, make the head
            // point to the same location as the tail
            // Could use _size == 1 instead of IsEmpty
            if (IsEmpty)
            {
                _head = _tail;
            }
            // We need to take out the oldTail and make it's next property
            // point to the tail that we just created
            else
            {
                oldTail.Next = _tail;
            }

            //Increment the size
            _size++;
        }

        // Method to remove from the stack
        public T Pop()
        {
            // Check for empty, throw exception if it is
            if (IsEmpty)
            {
                throw new Exception("List is empty");
            }

            // Get the return data right off the bat
            T returnData = _tail.Data;

            // Check to see if we are on the last node
            // If so, we can just set the head and tail to null since we want
            // to remove the only node remaining in the list
            if (_head == _tail)
            {
                _head = null;
                _tail = null;
            }
            // Else, we need to traverse the list and stop right before we reach the tail
            else
            {
                // Create a temporary node to use to 'walk' down the list
                Node current = _head;

                // Keep movijng forward until the current.Next is
                // equal to the tail.
                // Keep looping whilt current.Next != _tail
                while (current.Next != _tail)
                {
                    // Set the current pointer to the cirrent pointer's next node
                    current = current.Next;
                }

                // I am now in position to do some work.
                // Set the tail to the current position.
                _tail = current;

                // Make the last node that we are removing go away
                // by setting tail's next property to null
                _tail.Next = null;
            }

            // Return the returnData
            return returnData;
        }

    }
}
