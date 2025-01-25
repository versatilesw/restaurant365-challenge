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

    // Test 7: Negative numbers should throw an exception
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Add_NegativeNumbersThrowException()
    {
        _calculator.Add("4,-3,-1");
    }

    // Test 8: Whitespace in input should be ignored
    [TestMethod]
    public void Add_WhitespaceInInput_Ignored()
    {
        var result = _calculator.Add(" 1 , 2 ");
        Assert.AreEqual(3, result);
    }

    // Test 9: Allow newline as delimiter
    [TestMethod]
    public void Add_NewLineAsDelimiter()
    {
        var result = _calculator.Add("1\n2,3");
        Assert.AreEqual(6, result);
    }

    // Test 10: Make any value greater than 1000 an invalid number
    [TestMethod]
    public void Add_BigNumber_TreatedAsInvalid()
    {
        var result = _calculator.Add("2,1001,6");
        Assert.AreEqual(8, result);
    }

    // Test 11: Support 1 custom delimiter of a single character
    [TestMethod]
    public void Add_OneCustomDelimiter_OneCharacter()
    {
        var result = _calculator.Add("//#\n2#5");
        Assert.AreEqual(7, result);
        result = _calculator.Add("//,\n2,ff,100");
        Assert.AreEqual(102, result);
    }

    // Test 12: Support 1 custom delimiter of any length
    [TestMethod]
    public void Add_OneCustomDelimiter_AnyLength()
    {
        var result = _calculator.Add("//[***]\n11***22***33");
        Assert.AreEqual(66, result);
    }

    // Test 13: Support custom delimiter of anylength
    [TestMethod]
    public void Add_MultipleCustomDelimiter_AnyLength()
    {
        var result = _calculator.Add("//[*][!!][r9r]\n11r9r22*hh*33!!44");
        Assert.AreEqual(110, result);
    }


    // Test 14: Verify formula display
    [TestMethod]
    public void Add_DisplayFormula_Correctly()
    {
        string input = "2,,4,rrrr,1001,6"; // Example input
        var result = _calculator.Add(input, out var parsedNumbers);
        Assert.AreEqual(12, result);
        CollectionAssert.AreEqual(new List<int> { 2, 0, 4, 0, 0, 6 }, parsedNumbers);
    }
}