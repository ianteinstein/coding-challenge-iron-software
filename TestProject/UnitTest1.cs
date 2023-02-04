using CoreLogic;

namespace TestProject
{
    public class UnitTest1
    {
        private readonly StringEngine _stringEngine;
        public UnitTest1()
        {
            _stringEngine = new StringEngine(new PhonePadDictionary());
        }

        [Theory]
        [InlineData("222 2 22#")]
        [InlineData("33#")]
        [InlineData("227*#")]
        [InlineData("4433555 555666#")]
        [InlineData("8 88777444666*664#")]
        public void TestValidation_Success(string input)
        {
            var resultInfo = _stringEngine.ValidationPhonePadTxt(input);

            Assert.True(resultInfo.IsValid);
            Assert.NotEqual("Input is invalid", resultInfo.Text);
        }

        [Theory]
        [InlineData("222 2 22")]
        [InlineData("33abc#")]
        [InlineData("227=#")]
        [InlineData("4433+555 555666#")]
        [InlineData("8 887,77444666*664#")]
        public void TestValidation_Fail(string input)
        {
            var resultInfo = _stringEngine.ValidationPhonePadTxt(input);

            Assert.False(resultInfo.IsValid);
            Assert.Equal("Input is invalid", resultInfo.Text);
        }

        [Theory]
        [InlineData("222 2 22#", "CAB")]
        [InlineData("33#", "E")]
        [InlineData("227*#", "B")]
        [InlineData("4433555 555666#", "HELLO")]
        [InlineData("8 88777444666*664#", "TURING")]
        public void TestRun_Success(string input,string expectResult)
        {
            var resultInfo = _stringEngine.GetResultString(input);

            Assert.True(resultInfo.IsValid);
            Assert.Equal(expectResult, resultInfo.Text);
        }

    }
}