using System.Collections.Generic;
using Moq;
using StoreBL;
using StoreDL;
using StoreModel;
using Xunit;

namespace StoreTest;

public class CostumerTest
{
    [Fact]
    public void CostumerDataInt()
    {
        //Arrange
        Costumer newCostumer = new Costumer();
        int costumerId = 1010;

        //Act
        newCostumer.CostumerId = costumerId;

        //Assert
        Assert.NotNull(newCostumer.CostumerId);
        Assert.Equal(costumerId, newCostumer.CostumerId);

    }

    [Fact]
    public void CostumerDataString()
    {
        //Arrange
        Costumer newCostumer = new Costumer();
        string costumerName = "Nancy";
        string costumerPhone = "415-555-5555";
        string costumerAddress = "555 River St. San Francisco CA";
        string costumerEmail = "nancy@email.com";

        //Act
        newCostumer.Name = costumerName;
        newCostumer.Phone = costumerPhone;
        newCostumer.Address = costumerAddress;
        newCostumer.Email = costumerEmail;

        //Assert

        Assert.NotNull(newCostumer.Name);
        Assert.Equal(costumerName, newCostumer.Name);

        Assert.NotNull(newCostumer.Phone);
        Assert.Equal(costumerPhone, newCostumer.Phone);

        Assert.NotNull(newCostumer.Address);
        Assert.Equal(costumerAddress, newCostumer.Address);

        Assert.NotNull(newCostumer.Email);
        Assert.Equal(costumerEmail, newCostumer.Email);

    }

    [Fact]
    public void CostumerList()
    {
        //Arrange
        int costumerId = 1010;
        string costumerName = "Nancy";
        string costumerPhone = "415-555-5555";
        string costumerAddress = "555 River St. San Francisco CA";
        string costumerEmail = "nancy@email.com";
        bool found = false;

        Costumer expectedCostumer = new Costumer()
        {
            CostumerId = costumerId,
            Name = costumerName,
            Phone = costumerPhone,
            Address = costumerAddress,
            Email = costumerEmail,
        };

        List<Costumer> newCostumerList = new List<Costumer>();
        newCostumerList.Add(expectedCostumer);

        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repo => repo.ListOfCostumers()).Returns(newCostumerList);

        ICostumerBL costumerBL = new CostumerBL(mockRepo.Object);

        //Act
        (Costumer actualCostumer, found)= costumerBL.findCostumer(expectedCostumer);


        //Assert
        Assert.Equal(expectedCostumer, actualCostumer);
        Assert.True(found);
    }
}