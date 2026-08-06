using System.Data;
using System.Net;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        //We need to check if a value is already in the tree
        if(value == Data) //if the value is in the tree, just stop and return.
        {
            return;
        } else if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }

    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        //Go through the tree, if the value is in it return true, else return false.
        if(value == Data)
        {
            return true;
        } else if (value < Data) //Go through the left subtree
        {
            if (Left is null)
                return false;
            else
                 return Left.Contains(value);
        } else //else go through the right subtree
        {
            if (Right is null)
                return false;
            else
                return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        int leftHeight;
        int rightHeight;
        // TODO Start Problem 4
        if (Left == null && Right == null) //if there are no child nodes, height is one.
        {
            return 1;
        } else
        {
            if (Left == null) //If the left side is null, the left's height is 0.
            {
                leftHeight = 0;
            }
            else //get the height of the left side.
            {
                leftHeight = Left.GetHeight();
            }

            if (Right == null) //If the right side is null, the right's height is 0.
            {
                rightHeight = 0;
            }
            else //get the height of the right side.
            {
                rightHeight = Right.GetHeight();
            }
            
            if (leftHeight < rightHeight) //Compare the heights of either size, whichever is bigger, return that height + 1.
            {
                return rightHeight + 1;
            }
            else
            {
                return leftHeight + 1;
            }
        }
    }
}