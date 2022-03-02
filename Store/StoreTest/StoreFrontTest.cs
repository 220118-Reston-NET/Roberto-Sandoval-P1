using System.Collections.Generic;
using Moq;
using StoreBL;
using StoreDL;
using StoreModel;
using Xunit;

namespace StoreTest;

public class StoreFrontTest
{
    [Fact]
    public void TestDataInt()
    {
        //Arrange
        StoreFront newStoreFront = new StoreFront();
        int storeNumber = 135;

        //Act
        newStoreFront.StoreNumber = storeNumber;

        //Assert
        Assert.NotNull(newStoreFront.StoreNumber);
        Assert.Equal(storeNumber, newStoreFront.StoreNumber);

    }

    [Fact]
    public void TestDataString()
    {
        //Arrange
        StoreFront newStoreFront = new StoreFront();
        string storeName = "Creekside";
        string storeAddress = "51536 Primera Ave, San Jose, CA";

        //Act
        newStoreFront.StoreName = storeName;
        newStoreFront.StoreAddress = storeAddress;

        //Assert
        Assert.NotNull(newStoreFront.StoreName);
        Assert.Equal(storeName, newStoreFront.StoreName);

        Assert.NotNull(newStoreFront.StoreAddress);
        Assert.Equal(storeAddress, newStoreFront.StoreAddress);

    }


}