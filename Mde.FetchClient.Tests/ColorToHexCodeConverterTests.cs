using Mde.FetchClient.Converters;
using Xamarin.Forms;

namespace Mde.FetchClient.Tests
{
    public class ColorToHexCodeConverterTests
    {
        [Fact]
        public void Convert_ValidColor_ReturnsHexString()
        {
            // arrange
            var converterke = new ColorToHexCodeConverter();
            Color inputColor = Color.Red;
            string expectedHexCode = "#ff0000";

            // act
            object output = converterke.Convert(inputColor, null, null, null);
            string actualHexCode = (string)output;

            // assert
            Assert.Equal(expectedHexCode, actualHexCode);
        }

        [Fact]
        public void ConvertBack_ValidHexCode_ReturnsColor()
        {
            // arrange
            var converterke = new ColorToHexCodeConverter();
            string inputCode = "#ff0000";
            Color expectedColor = Color.Red;

            // act
            object output = converterke.ConvertBack(inputCode, null, null, null);
            Color actualColor = (Color)output;

            // assert
            Assert.Equal(expectedColor, actualColor);
        }
    }
}