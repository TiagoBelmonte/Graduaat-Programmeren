//using Assignment.Domain.Models;

namespace Assignment.Tests
{
    // TODO: use CodiumAI in Visual Studio Code to generate unit tests

#if EXAMPLE
    public class AlphabeticalListOfCustomersTests
    {
        // The class can be instantiated without any errors.
        [Fact]
        public void test_instantiation()
        {
            // Arrange
    
            // Act
            var customer = new AlphabeticalListOfCustomers();

            // Assert
            Assert.NotNull(customer);
        }

        // When the Naam property of a customer is set to null, an ArgumentNullException should be thrown.
        [Fact]
        public void test_customer_name_null()
        {
            // Arrange
            var customer = new AlphabeticalListOfCustomers();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => customer.Naam = null);
        }
    }
#endif
}