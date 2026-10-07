using System.Drawing;
using Coding4Coffee.Basics.Configuration;
using Coding4Coffee.WinForms.Configuration;
using Xunit;

namespace Coding4Coffee.WinForms.Tests
{
    public class WinFormsConfigurationTests
    {
        [Fact]
        public void ColorConfig_StoresAndRetrievesColor_AndHandlesNull()
        {
            string key = $"Test_Color_{Guid.NewGuid()}";
            var config = WinFormsConfigFactory.GetColorConfig(key, isTransient: true);
            var expectedColor = Color.FromArgb(255, 64, 128, 200);
            config.Value = expectedColor;

            Assert.NotNull(config.Value);
            Assert.Equal(expectedColor.ToArgb(), config.Value.Value.ToArgb());

            Color? implicitColor = config;
            Assert.Equal(expectedColor.ToArgb(), implicitColor?.ToArgb());

            config.Value = null;
            Assert.Null(config.Value);
        }

        [Fact]
        public void FontConfig_StoresAndRetrievesFont_AndHandlesNull()
        {
            string key = $"Test_Font_{Guid.NewGuid()}";
            var config = WinFormsConfigFactory.GetFontConfig(key, isTransient: true);
            using var expectedFont = new Font("Arial", 12f, FontStyle.Bold);
            config.Value = expectedFont;

            Assert.NotNull(config.Value);
            Assert.Equal("Arial", config.Value.FontFamily.Name);
            Assert.Equal(12f, config.Value.Size);
            Assert.Equal(FontStyle.Bold, config.Value.Style);

            Font? implicitFont = config;
            Assert.NotNull(implicitFont);
            Assert.Equal("Arial", implicitFont.FontFamily.Name);

            config.Value = null;
            Assert.Null(config.Value);
        }

        [Fact]
        public void IconConfig_StoresAndRetrievesIcon_AndHandlesNull()
        {
            string key = $"Test_Icon_{Guid.NewGuid()}";
            var config = WinFormsConfigFactory.GetIconConfig(key, isTransient: true);
            var expectedIcon = SystemIcons.Information;
            config.Value = expectedIcon;

            Assert.NotNull(config.Value);
            Assert.Equal(expectedIcon.Width, config.Value.Width);
            Assert.Equal(expectedIcon.Height, config.Value.Height);

            Icon? implicitIcon = config;
            Assert.NotNull(implicitIcon);

            config.Value = null;
            Assert.Null(config.Value);
        }

        [Fact]
        public void ImageConfig_StoresAndRetrievesImage_AndHandlesNull()
        {
            string key = $"Test_Image_{Guid.NewGuid()}";
            var config = WinFormsConfigFactory.GetImageConfig(key, isTransient: true);
            using var bitmap = new Bitmap(16, 16);
            bitmap.SetPixel(0, 0, Color.Red);

            config.Value = bitmap;

            Assert.NotNull(config.Value);
            Assert.Equal(16, config.Value.Width);
            Assert.Equal(16, config.Value.Height);

            Image? implicitImage = config;
            Assert.NotNull(implicitImage);

            config.Value = null;
            Assert.Null(config.Value);
        }

        [Fact]
        public void GenericConfig_SupportsNativeWinFormsTypes()
        {
            string stateKey = $"Test_State_{Guid.NewGuid()}";
            var stateConfig = ConfigFactory.GetConfig<FormWindowState>(stateKey, isTransient: true);
            stateConfig.Value = FormWindowState.Maximized;
            Assert.Equal(FormWindowState.Maximized, stateConfig.Value);

            string pointKey = $"Test_Point_{Guid.NewGuid()}";
            var pointConfig = ConfigFactory.GetConfig<Point>(pointKey, isTransient: true);
            pointConfig.Value = new Point(120, 240);
            Assert.Equal(new Point(120, 240), pointConfig.Value);

            string sizeKey = $"Test_Size_{Guid.NewGuid()}";
            var sizeConfig = ConfigFactory.GetConfig<Size>(sizeKey, isTransient: true);
            sizeConfig.Value = new Size(800, 600);
            Assert.Equal(new Size(800, 600), sizeConfig.Value);
        }
    }
}
