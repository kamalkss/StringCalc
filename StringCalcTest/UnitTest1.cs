using Xunit;


namespace StringCalcTest
{
    public class UnitTest1
    {
        [Fact]
        public void return_zero_if_input_empty()
        {
            int expectedResult = 0;
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("");
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void return_one_if_input_is_one()
        {
            int expectedResult = 1;
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("1");
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void return_one_if_input_is_one_delim()
        {
            int expectedResult = 1;
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("1,\n");
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void return_three_if_input_is_one_and_two()
        {
            int expectedResult = 3;
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("1\n2");
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void return_nine_if_input_is_three_three()
        {
            int expectedResult = 9;
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("//[***]\n3***3***3");
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void return_six_if_input_is_one_two_three()
        {
            int expectedResult = 6;
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("//[***]\n1***2***3");
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void return_six_if_input_is_one_two_three_Nodelim()
        {
            int expectedResult = 6;
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("1\n2,3");
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void return_six_if_input_is_one_two_three_complex_Nodelim()
        {
            int expectedResult = 6;
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("//[*][%]\n1*2%3");
            Assert.Equal(expectedResult, result);
        }
    }
}