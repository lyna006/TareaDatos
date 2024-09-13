[TestClass]
public class ListaDobleTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestMergeSorted_NullListA_ThrowsException()
    {
        var listA = new ListaDoble();
        var listB = new ListaDoble();
        listA.MergeSorted(null, listB, SortDirection.Asc);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestMergeSorted_NullListB_ThrowsException()
    {
        var listA = new ListaDoble();
        var listB = new ListaDoble();
        listA.MergeSorted(listA, null, SortDirection.Asc);
    }

    [TestMethod]
    public void TestMergeSorted_AscOrder_EmptyListA()
    {
        var listA = new ListaDoble();
        var listB = new ListaDoble();
        listB.InsertInOrder(3);
        listB.InsertInOrder(7);
        listB.InsertInOrder(11);

        listA.MergeSorted(listA, listB, SortDirection.Asc);

        Assert.AreEqual(3, listA.DeleteFirst());
        Assert.AreEqual(7, listA.DeleteFirst());
        Assert.AreEqual(11, listA.DeleteFirst());
    }

    [TestMethod]
    public void TestMergeSorted_AscOrder_EmptyListB()
    {
        var listA = new ListaDoble();
        var listB = new ListaDoble();
        listA.InsertInOrder(10);
        listA.InsertInOrder(15);

        listA.MergeSorted(listA, listB, SortDirection.Asc);

        Assert.AreEqual(10, listA.DeleteFirst());
        Assert.AreEqual(15, listA.DeleteFirst());
    }

    [TestMethod]
    public void TestMergeSorted_AscOrder()
    {
        var listA = new ListaDoble();
        var listB = new ListaDoble();
        listA.InsertInOrder(0);
        listA.InsertInOrder(2);
        listA.InsertInOrder(6);
        listA.InsertInOrder(10);
        listA.InsertInOrder(25);

        listB.InsertInOrder(3);
        listB.InsertInOrder(7);
        listB.InsertInOrder(11);
        listB.InsertInOrder(40);
        listB.InsertInOrder(50);

        listA.MergeSorted(listA, listB, SortDirection.Asc);

        Assert.AreEqual(0, listA.DeleteFirst());
        Assert.AreEqual(2, listA.DeleteFirst());
        Assert.AreEqual(3, listA.DeleteFirst());
        Assert.AreEqual(6, listA.DeleteFirst());
        Assert.AreEqual(7, listA.DeleteFirst());
        Assert.AreEqual(10, listA.DeleteFirst());
        Assert.AreEqual(11, listA.DeleteFirst());
        Assert.AreEqual(25, listA.DeleteFirst());
        Assert.AreEqual(40, listA.DeleteFirst());
        Assert.AreEqual(50, listA.DeleteFirst());
    }

    [TestMethod]
    public void TestMergeSorted_DescOrder()
    {
        var listA = new ListaDoble();
        var listB = new ListaDoble();
        listA.InsertInOrder(10);
        listA.InsertInOrder(15);

        listB.InsertInOrder(9);
        listB.InsertInOrder(40);
        listB.InsertInOrder(50);

        listA.MergeSorted(listA, listB, SortDirection.Desc);

        Assert.AreEqual(50, listA.DeleteFirst());
        Assert.AreEqual(40, listA.DeleteFirst());
        Assert.AreEqual(15, listA.DeleteFirst());
        Assert.AreEqual(10, listA.DeleteFirst());
        Assert.AreEqual(9, listA.DeleteFirst());
    }

    [TestMethod]
    public void TestMergeSorted_DescOrder_EmptyListA()
    {
        var listA = new ListaDoble();
        var listB = new ListaDoble();
        listB.InsertInOrder(9);
        listB.InsertInOrder(40);
        listB.InsertInOrder(50);

        listA.MergeSorted(listA, listB, SortDirection.Desc);

        Assert.AreEqual(50, listA.DeleteFirst());
        Assert.AreEqual(40, listA.DeleteFirst());
        Assert.AreEqual(9, listA.DeleteFirst());
    }

    [TestMethod]
    public void TestInvert_NullList()
    {
        var list = new ListaDoble();
        Assert.ThrowsException<ArgumentException>(() => list.Invert());
    }

    [TestMethod]
    public void TestInvert_EmptyList()
    {
        var list = new ListaDoble();
        list.Invert();
        // List remains empty, nothing to assert
    }

    [TestMethod]
    public void TestInvert_MultipleElements()
    {
        var list = new ListaDoble();
        list.InsertInOrder(1);
        list.InsertInOrder(0);
        list.InsertInOrder(30);
        list.InsertInOrder(50);
        list.InsertInOrder(2);

        list.Invert();

        Assert.AreEqual(2, list.DeleteFirst());
        Assert.AreEqual(50, list.DeleteFirst());
        Assert.AreEqual(30, list.DeleteFirst());
        Assert.AreEqual(0, list.DeleteFirst());
        Assert.AreEqual(1, list.DeleteFirst());
    }

    [TestMethod]
    public void TestInvert_SingleElement()
    {
        var list = new ListaDoble();
        list.InsertInOrder(2);
        list.Invert();
        Assert.AreEqual(2, list.DeleteFirst());
    }

    [TestMethod]
    public void TestGetMiddle_NullList()
    {
        var list = new ListaDoble();
        Assert.ThrowsException<ArgumentException>(() => list.GetMiddle());
    }

    [TestMethod]
    public void TestGetMiddle_EmptyList()
    {
        var list = new ListaDoble();
        Assert.ThrowsException<ArgumentException>(() => list.GetMiddle());
    }

    [TestMethod]
    public void TestGetMiddle_SingleElement()
    {
        var list = new ListaDoble();
        list.InsertInOrder(1);
        Assert.AreEqual(1, list.GetMiddle());
    }

    [TestMethod]
    public void TestGetMiddle_TwoElements()
    {
        var list = new ListaDoble();
        list.InsertInOrder(1);
        list.InsertInOrder(2);
        Assert.AreEqual(2, list.GetMiddle());
    }

    [TestMethod]
    public void TestGetMiddle_ThreeElements()
    {
        var list = new ListaDoble();
        list.InsertInOrder(0);
        list.InsertInOrder(1);
        list.InsertInOrder(2);
        Assert.AreEqual(1, list.GetMiddle());
    }

    [TestMethod]
    public void TestGetMiddle_FourElements()
    {
        var list = new ListaDoble();
        list.InsertInOrder(1);
        list.InsertInOrder(2);
        list.InsertInOrder(3);
        list.InsertInOrder(4);
        Assert.AreEqual(2, list.GetMiddle()); 
    }

}
