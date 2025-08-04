using FluentAssertions;
using SkiaSharp;
using Topten.RichTextKit;
using static TestMeasurements.Utils;

namespace TestMeasurements
{
    public class MeasureWithRichTextKitTests
    {
        private const float FontSize = 10f;

        [Test]
        public void MeasureNotoSansBold_ReturnsExpectedSize()
        {
            FontMapper.Default = new SimpleFontMapper();
            var richString = new RichString("Lorem Ipsum")
            {
                DefaultStyle = new Style { FontFamily = "Noto Sans", FontWeight = 700, FontSize = 10 },
            };

            richString.MeasuredHeight.Should().Be(13.620000839233398f);
            richString.MeasuredWidth.Should().Be(65.91797f);
        }

        [Test]
        public void MeasureNotoSansRegular_ReturnsExpectedSize()
        {
            FontMapper.Default = new SimpleFontMapper();
            var richString = new RichString("Lorem Ipsum")
            {
                DefaultStyle = new Style { FontFamily = "Noto Sans", FontSize = 10 },
            };

            richString.MeasuredHeight.Should().Be(13.620000839233398f);
            richString.MeasuredWidth.Should().Be(62.67578125f);
        }

        [Test]
        public void MeasureRobotoBold_ReturnsExpectedSize()
        {
            FontMapper.Default = new SimpleFontMapper();
            var richString = new RichString("Lorem Ipsum")
            {
                DefaultStyle = new Style { FontFamily = "Roboto", FontWeight = 700, FontSize = 10 },
            };

            richString.MeasuredHeight.Should().Be(12.001953f);
            richString.MeasuredWidth.Should().Be(59.160156f);
        }

        [Test]
        public void MeasureRobotoRegular_ReturnsExpectedSize()
        {
            FontMapper.Default = new SimpleFontMapper();
            var richString = new RichString("Lorem Ipsum")
            {
                DefaultStyle = new Style { FontFamily = "Roboto", FontSize = 10 },
            };

            richString.MeasuredHeight.Should().Be(12.001953f);
            richString.MeasuredWidth.Should().Be(58.73047f);
        }

        public class SimpleFontMapper : FontMapper
        {
            SKTypeface _notoSansRegular;
            SKTypeface _notoSansBold;
            SKTypeface _robotoRegular;
            SKTypeface _robotoBold;

            public SimpleFontMapper()
            {
                _notoSansRegular = LoadFontFromResource("Noto_Sans.NotoSans-Regular");
                _notoSansBold = LoadFontFromResource("Noto_Sans.NotoSans-Bold");
                _robotoRegular = LoadFontFromResource("Roboto.Roboto-Regular");
                _robotoBold = LoadFontFromResource("Roboto.Roboto-Bold");
            }

            public override SKTypeface TypefaceFromStyle(IStyle style, bool ignoreFontVariants)
            {
                return style.FontFamily switch
                {
                    "Noto Sans" => style.FontWeight == 700 ? _notoSansBold : _notoSansRegular,
                    "Roboto" => style.FontWeight == 700 ? _robotoBold : _robotoRegular,
                    _ => throw new Exception($"No font found for family {style.FontFamily}")
                };
            }
        }

    }
}