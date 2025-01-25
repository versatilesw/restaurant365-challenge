using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

[TestClass]
public class CalculatorTests
{
    private Calculator _calculator;

    [TestInitialize]
    public void Setup()
    {
        _calculator = new Calculator();
    }

    // Test 1: Empty input should return 0
    [TestMethod]
    public void Add_EmptyInput_ReturnsZero()
    {
        var result = _calculator.Add("");
        Assert.AreEqual(0, result);
    }

    // Test 2: Single number input should return the number
    [TestMethod]
    public void Add_SingleNumber_ReturnsNumber()
    {
        var result = _calculator.Add("5");
        Assert.AreEqual(5, result);
    }

    // Test 3: Two numbers input should return their sum
    [TestMethod]
    public void Add_TwoNumbers_ReturnsSum()
    {
        var result = _calculator.Add("3,5");
        Assert.AreEqual(8, result);
    }

    // Test 4: More than two numbers should return their sum
    [TestMethod]
    public void Add_MoreThanTwoNumbers_ReturnsSum()
    {
        var result = _calculator.Add("1,2,3");
        Assert.AreEqual(6, result);
    }

    // Test 5: Invalid numbers should be treated as 0
    [TestMethod]
    public void Add_InvalidNumber_TreatedAsZero()
    {
        var result = _calculator.Add("5,tytyt");
        Assert.AreEqual(5, result);
    }

    // Test 6: Missing numbers should be treated as 0
    [TestMethod]
    public void Add_MissingNumbers_TreatedAsZero()
    {
        var result = _calculator.Add("4,");
        Assert.AreEqual(4, result);
    }

    // Test 7: Negative numbers should be treated as 0 (if not explicitly denied)
    [TestMethod]
    public void Add_NegativeNumbers_TreatedAsZero()
    {
        var result = _calculator.Add("4,-3");
        Assert.AreEqual(1, result);
    }

    // Test 8: Whitespace in input should be ignored
    [TestMethod]
    public void Add_WhitespaceInInput_Ignored()
    {
        var result = _calculator.Add(" 1 , 2 ");
        Assert.AreEqual(3, result);
    }
}