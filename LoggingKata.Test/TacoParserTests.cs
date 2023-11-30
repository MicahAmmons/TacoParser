using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("32.609135,-85.479907,Taco Bell Auburn...", -85.479907)]
        [InlineData("33.715798,-84.215646,Taco Bell Decatur...", -84.215646)]
        [InlineData("34.901154,-85.136345,Taco Bell Ringgol...", -85.136345)]
        [InlineData("33.283584,-86.855317,Taco Bell Helena...", -86.855317)]


        public void ShouldParseLongitude(string line, double expected)
        {

            //Arrange
            TacoParser parser = new TacoParser();

            //Act
            double actual = (parser.Parse(line)).Location.Longitude;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("32.609135,-85.479907,Taco Bell Auburn...", 32.609135)]
        [InlineData("33.715798,-84.215646,Taco Bell Decatur...", 33.715798)]
        [InlineData("34.901154,-85.136345,Taco Bell Ringgol...", 34.901154)]
        [InlineData("33.283584,-86.855317,Taco Bell Helena...", 33.283584)]
        public void ShouldParseLatitude(string line, double expected)
        {
            TacoParser parser = new TacoParser();

            double actual = (parser.Parse(line)).Location.Latitude;

            Assert.Equal(expected, actual);
        }
    }
}
