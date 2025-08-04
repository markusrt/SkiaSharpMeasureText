using FluentAssertions;
using SkiaSharp;
using static TestMeasurements.Utils;

namespace TestMeasurements
{
    public class EnsureFontsTests
    {
        [Test]
        public void LoadNotoSansBold_ReturnsExpectedFont()
        {
            var notoSansBold = LoadFontFromResource("Noto_Sans.NotoSans-Bold");
            
            notoSansBold.FamilyName.Should().Be("Noto Sans");
            notoSansBold.FontWidth.Should().Be(5);
            notoSansBold.FontWeight.Should().Be(700);
            notoSansBold.GlyphCount.Should().Be(4503);
            notoSansBold.IsBold.Should().BeTrue();
        }

        [Test]
        public void LoadNotoSansRegular_ReturnsExpectedFont()
        {
            var notoSansRegular = LoadFontFromResource("Noto_Sans.NotoSans-Regular");

            notoSansRegular.FamilyName.Should().Be("Noto Sans");
            notoSansRegular.FontWidth.Should().Be(5);
            notoSansRegular.FontWeight.Should().Be(400);
            notoSansRegular.GlyphCount.Should().Be(4503);
            notoSansRegular.IsBold.Should().BeFalse();
        }

        [Test]
        public void LoadRoboto_ReturnsExpectedFont()
        {
            var roboto = LoadFontFromResource("Roboto.Roboto-Bold");

            roboto.FamilyName.Should().Be("Roboto");
            roboto.FontWidth.Should().Be(5);
            roboto.FontWeight.Should().Be(700);
            roboto.GlyphCount.Should().Be(1321);
            roboto.IsBold.Should().BeTrue();
        }
    }
}