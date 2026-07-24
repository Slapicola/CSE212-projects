using System.Collections;
using System.Data;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // TODO Problem 1
        //Create a new node
        Node newTail = new(value);

        //If the list is empty, then make both the head and the tail the new node.
        if (_tail is null)
        {
            _head = newTail;
            _tail = newTail;
        }
        else
        {
            newTail.Prev = _tail; //Connect new node to the current tail
            _tail.Next = newTail; //Connect the current tail to the new node
            _tail = newTail; //Set the tail equal to the new node
        }

    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // TODO Problem 2
        //If the list has only one item in it, set both the head and the tail to null
        if(_head == _tail)
        {
            _head = null;
            _tail = null;
        } else if (_tail is not null)
        {
            _tail.Prev.Next = null; //Disconnect the second to last node from the tail
            _tail = _tail.Prev; //Set the tail to be the second to last node
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        // TODO Problem 3
        //Travese through the list, using an if statement, check if the value parameter exists, if it does, remove the node that has that value.
        var currentNode = _head;

        while (currentNode != null)
        {
            if (currentNode.Data == value)
            {

                //If the node with the value is at the end of the list, we can call RemoveTail to remove that node
                if (currentNode == _tail)
                {
                    RemoveTail();
                }
                else if (currentNode == _head) // If the node with the value is at the head, call the RemoveHead function
                {
                    RemoveHead();
                }
                else //else set the prev of the node after the current one to the one before it
                     // and set the next of the node before the current one to the one after it.
                {
                    currentNode.Next.Prev = currentNode.Prev;
                    currentNode.Prev.Next = currentNode.Next;
                }
                return;

            }

            currentNode = currentNode.Next; //Go to the next node
            
        }


    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        // TODO Problem 4
        var currentNode = _head; //Start at the beggining of the list

        while (currentNode != null) //Loop through the list until the end
        {
            if (currentNode.Data == oldValue) //If the data in a node is equal to oldValue, set it to the newValue
            {
                currentNode.Data = newValue;
            }

            currentNode = currentNode.Next; //Go to next node
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        // TODO Problem 5
        var currentNode = _tail; //Start at the end of the list
        while (currentNode is not null)
        {
            yield return currentNode.Data; // replace this line with the correct yield return statement(s)
            currentNode = currentNode.Prev; //Go backwards in the linked list
        
            
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}