public class ListaDoble : IList
{
    private class Node
    {
        public int Value;
        public Node Next;
        public Node Prev;

        public Node(int value) => Value = value;
    }

    private Node head;
    private Node tail;
    private int count;
    private Node middle;

    public void InsertInOrder(int value)
    {
        Node newNode = new Node(value);

        if (head == null)
        {
            head = tail = newNode;
            middle = newNode;
        }
        else
        {
            Node current = head;
            while (current != null && current.Value < value)
                current = current.Next;

            if (current == null)
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
            else if (current == head)
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }
            else
            {
                newNode.Next = current;
                newNode.Prev = current.Prev;
                current.Prev.Next = newNode;
                current.Prev = newNode;
            }
        }

        count++;
        UpdateMiddle();
    }


    private void UpdateMiddle()
    {
        if (count == 0)
            return;

        Node current = head;
        int middleIndex = count / 2;

        if (count % 2 == 0)
            middleIndex++;

        for (int i = 0; i < middleIndex; i++)
            current = current.Next;

        middle = current;
    }



    public int GetMiddle()
    {
        if (head == null)
            throw new ArgumentException("List is empty"); 

        return middle.Value;
    }

    public int DeleteFirst()
    {
        if (head == null)
            throw new InvalidOperationException("List is empty");

        int value = head.Value;
        if (head == tail)
        {
            head = tail = middle = null;
        }
        else
        {
            head = head.Next;
            head.Prev = null;
        }
        count--;
        UpdateMiddle();
        return value;
    }

    public int DeleteLast()
    {
        if (tail == null)
            throw new InvalidOperationException("List is empty");

        int value = tail.Value;
        if (head == tail)
        {
            head = tail = middle = null;
        }
        else
        {
            tail = tail.Prev;
            tail.Next = null;
        }
        count--;
        UpdateMiddle();
        return value;
    }

    public bool DeleteValue(int value)
    {
        Node current = head;
        while (current != null && current.Value != value)
            current = current.Next;

        if (current == null)
            return false;

        if (current == head)
            head = current.Next;
        if (current == tail)
            tail = current.Prev;
        if (current.Prev != null)
            current.Prev.Next = current.Next;
        if (current.Next != null)
            current.Next.Prev = current.Prev;

        count--;
        UpdateMiddle();
        return true;
    }

    public void MergeSorted(IList listA, IList listB, SortDirection direction)
    {
        if (listA == null || listB == null)
            throw new ArgumentException("List cannot be null");

        var listAImpl = listA as ListaDoble;
        var listBImpl = listB as ListaDoble;

        if (listAImpl == null || listBImpl == null)
            throw new ArgumentException("Both lists must be of type ListaDoble");

        var mergedList = new ListaDoble();
        var nodeA = listAImpl.head;
        var nodeB = listBImpl.head;

        while (nodeA != null && nodeB != null)
        {
            if (direction == SortDirection.Asc)
            {
                if (nodeA.Value <= nodeB.Value)
                {
                    mergedList.Append(nodeA.Value);
                    nodeA = nodeA.Next;
                }
                else
                {
                    mergedList.Append(nodeB.Value);
                    nodeB = nodeB.Next;
                }
            }
            else // Descending order
            {
                if (nodeA.Value >= nodeB.Value)
                {
                    mergedList.Append(nodeA.Value);
                    nodeA = nodeA.Next;
                }
                else
                {
                    mergedList.Append(nodeB.Value);
                    nodeB = nodeB.Next;
                }
            }
        }

        while (nodeA != null)
        {
            mergedList.Append(nodeA.Value);
            nodeA = nodeA.Next;
        }

        while (nodeB != null)
        {
            mergedList.Append(nodeB.Value);
            nodeB = nodeB.Next;
        }

        head = mergedList.head;
        tail = mergedList.tail;
        middle = mergedList.middle;
        count = mergedList.count;
    }

    private void Append(int value)
    {
        Node newNode = new Node(value);
        if (tail == null)
        {
            head = tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
        }
        count++;
        UpdateMiddle();
    }


    public void Invert()
    {
        if (head == null)
        {
            // La lista está vacía, no es necesario lanzar una excepción.
            return;
        }

        Node current = head;
        Node temp = null;

        while (current != null)
        {
            // Intercambiar los punteros Next y Prev
            temp = current.Prev;
            current.Prev = current.Next;
            current.Next = temp;
            current = current.Prev;
        }

        // Actualizar la cabeza y la cola
        if (temp != null)
        {
            tail = head;
            head = temp.Prev;
        }

        // Actualizar el nodo medio
        UpdateMiddle();
    }




}
