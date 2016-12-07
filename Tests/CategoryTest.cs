using Xunit;
using System;
using System.Collections.Generic;
using ToDo.Objects;
using System.Data;
using System.Data.SqlClient;

namespace  ToDo
{
  public class CategoryTest : IDisposable
  {
    public CategoryTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=todo_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void GetAll_DatabaseEmptyAtFirst_true()
    {
      //Arrange
      // Category newCategory = new Category(""){};
      // Act
      int result = Category.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Save_SavesToDatabase_true()
    {
      //Arrange
      Category testCategory = new Category("Yardwork");

      //Act
      testCategory.Save();
      List<Category> result = Category.GetAll();
      List<Category> testList = new List<Category>{testCategory};

      //Assert
      Assert.Equal(testList, result);
    }
    //
    //
    //
    [Fact]
    public void Equal_AreObjectsEquivalent_true()
    {
      //Arrange
      Category firstCategory = new Category("Holidays.");
      Category secondCategory = new Category("Holidays.");
      //Act
      //Assert
      Assert.Equal(firstCategory, secondCategory);
    }
    //
    [Fact]
    public void Find_FindsTaskInDatabase_true()
    {
      //Arrange
      Category testCategory = new Category("Holidays.");
      testCategory.Save();

      //Act
      Category foundCategory = Category.Find(testCategory.Id);

      //Assert
      Assert.Equal(testCategory, foundCategory);
    }

    public void Dispose()
    {
      Category.DeleteAll();
    }

  }
}
