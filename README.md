## C# Unit Tests

*A unit test attempts to verify the functionality of a single unit of work. Given a class method with inputs and measurable outputs a unit test aims to verify the correctness of part of the method without peeking into private state management such as a database.*

### Prerequisites:

[.NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)
[Visual Studio Code](https://code.visualstudio.com/)
    *Note - C# extension from Microsoft helps*

### Loose Agenda:
Learn about the unit testing framework in .NET

Identify scenarios worth unit testing

### Step by Step

#### Setup testing framework

Create a directory for today's exercise and navigate to it in a terminal instance.

Create a new .NET unit test project in it's own directory by running `dotnet new mstest -o test`

Open Visual Studio Code to the root directory.

#### Create a test

In VS Code, open `test/UnitTest1.cs`.

*Note that this class uses the `Microsoft.VisualStudio.TestTools.UnitTesting` library and applies `[TestClass]` and `[TestMethod]` attributes to declare the intent of the class. These attributes help discovery of all tests to run in the test execution engine.*

We'll want to look at some of the key pieces in this library starting with Assert.

In the TestMethod1 method add `Assert.IsTrue(true);`. *Note that Assert has a number of methods which can be used to test various types of results.*

`Ctrl+Shift+P` to open the command window then search for and run `.NET: Run Tests in Context`. You should the .NET Test Log in the Output Window showing something similar to:

```
----- Test Execution Summary -----

test.UnitTest1.TestMethod1:
    Outcome: Passed
    
Total tests: 1. Passed: 1. Failed: 0. Skipped: 0
```

#### Make Testable Code

Open the terminal instance in the root directory once again. 

Create a new class library project by running `dotnet new classlib -o src`.

Add a reference from unit test project to the class library project by running `dotnet add .\test\test.csproj reference .\src\src.csproj`.

Back in Visual Studio Code let's navigate to Class1.cs. Within the class definition let's add a new method 
```
public string PrependNonZero(string input)
{
    return "NonZero " + input;
}
```

#### Arrange Act Assert

In Visual Studio Code let's navigate back to UnitTest1.cs and write a test for our Class1 method.

Let's create a new method below TestMethod1 and name it based on what it intends to test and let's add some comments to help organize our code. 

```
[TestMethod]
public void Class1_PrependNonZero_Given_Day_Prepends_NonZero()
{
    // Arrange

    // Act

    // Assert
}
```

Let's start by arranging inputs, expected outputs, and spin up an instance of the class we want to test.
*Note that you'll need to add a using declaration `using src;` at the top of the file.*

```
[TestMethod]
public void Class1_PrependNonZero_Prepends_NonZero()
{
    // Arrange
    var input = "Day";
    var expected = "NonZero Day";
    var testableClass = new Class1();

    // Act

    // Assert
}
```

Next let's call the Class1 method with our input.

```
[TestMethod]
public void Class1_PrependNonZero_Prepends_NonZero()
{
    // Arrange
    var input = "Day";
    var expected = "NonZero Day";
    var testableClass = new Class1();

    // Act
    var actual = testableClass.PrependNonZero(input);

    // Assert
}
```

Now let's Assert that the expected result and actual result should be equal.

```
[TestMethod]
public void Class1_PrependNonZero_Prepends_NonZero()
{
    // Arrange
    var input = "Day";
    var expected = "NonZero Day";
    var testableClass = new Class1();

    // Act
    var actual = testableClass.PrependNonZero(input);

    // Assert
    Assert.AreEqual(expected, actual);
}
```

`Ctrl+Shift+P` to open the command window then search for and run `.NET: Run Tests in Context`. You should the .NET Test Log in the Output Window showing something similar to:

```
----- Test Execution Summary -----

test.UnitTest1.TestMethod1:
    Outcome: Passed
    
test.UnitTest1.Class1_PrependNonZero_Prepends_NonZero:
    Outcome: Passed
    
Total tests: 2. Passed: 2. Failed: 0. Skipped: 0
```

Now you've written some tests.


Congratulations on a non-zero day!


### Additional Documentation

- [Clean Architecture](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#clean-architecture)
- [Unit Testing Library](https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting)
  * Assert
  * DataRowAttribute
  * ExpectedExceptionAttribute
  * DescriptionAttribute
  * TestCategoryAttribute
