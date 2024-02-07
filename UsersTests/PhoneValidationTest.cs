using LR2TIS.Models;

namespace UsersTests
{
    public class PhoneValidationTest
    {
        private readonly User _validation;
        public PhoneValidationTest()
        {
            _validation = new User();
        }
        [Fact]
        public void IsValid_PhoneValidation_ReturnsTrue()
        {
            Assert.True(_validation.IsValid(Convert.ToString(89236476453)));
        }
        [Fact]
        public void IsValid_PhoneValidation_ReturnsFalse()
        {
            Assert.False(_validation.IsValid(Convert.ToString(892364376453)));
        }
        [Theory]
        [InlineData(865738463749)]
        [InlineData(8699999999)]
        public void IsValid_AccountNumberFirstPartWrong_ReturnsFalse(double Number)
        {
            Assert.False(_validation.IsValid(Convert.ToString(Number)));
        }
    }
}
