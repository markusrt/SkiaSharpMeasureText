using FluentAssertions;
using SkiaSharp;
using static TestMeasurements.Utils;

namespace TestMeasurements
{
    public class MeasureWithSkiaTests
    {
        private const float FontSize = 10f;

        [Test]
        public void MeasureNotoSansBold_ReturnsExpectedSize()
        {
            var skTypeface = LoadFontFromResource("Noto_Sans.NotoSans-Bold");
            
            var font = new SKFont(skTypeface, FontSize);
            font.MeasureText("Lorem Ipsum", out var bounds);

            bounds.Height.Should().Be(11f);
            bounds.Width.Should().Be(65.36f);
        }

        [Test]
        public void MeasureNotoSansRegular_ReturnsExpectedSize()
        {
            var skTypeface = LoadFontFromResource("Noto_Sans.NotoSans-Regular");

            var font = new SKFont(skTypeface, FontSize);
            font.MeasureText("Lorem Ipsum", out var bounds);

            bounds.Height.Should().Be(11f);
            bounds.Width.Should().Be(61.52f);
        }

        [Test]
        public void MeasureRoboto_ReturnsExpectedSize()
        {
            var skTypeface = LoadFontFromResource("Roboto.Roboto-Bold");

            var font = new SKFont(skTypeface, FontSize);
            font.MeasureText("Lorem Ipsum", out var bounds);

            bounds.Height.Should().Be(9f);
            bounds.Width.Should().Be(59.551758f);
        }

    }
}