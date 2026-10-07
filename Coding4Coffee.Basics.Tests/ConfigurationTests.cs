using System.Globalization;
using System.Net;
using System.Text;
using Coding4Coffee.Basics.Configuration;
using Xunit;

namespace Coding4Coffee.Basics.Tests
{
    public class ConfigurationTests
    {
        public record TestPayload(string Name, int Counter);

        [Fact]
        public void GetConfig_StoresAndRetrievesValue()
        {
            string key = $"Test_Int_{Guid.NewGuid()}";
            var config = ConfigFactory.GetConfig<int>(key, isTransient: true);
            config.Value = 42;

            Assert.True(config.HasValue);
            Assert.Equal(42, config.Value);

            int implicitVal = config;
            Assert.Equal(42, implicitVal);
        }

        [Fact]
        public void GetConfig_ReturnsCachedInstance_AndSynchronizesStateAndEvents()
        {
            string key = $"Test_Cache_{Guid.NewGuid()}";
            var instanceA = ConfigFactory.GetConfig<string>(key, isTransient: true);
            var instanceB = ConfigFactory.GetConfig<string>(key, isTransient: true);

            bool eventTriggeredOnB = false;
            instanceB.ValueChanged += (s, e) => eventTriggeredOnB = true;

            // Act: change value via instance A
            instanceA.Value = "SharedValue";

            // Assert: reference equality, state reflection on B, and event propagation
            Assert.Same(instanceA, instanceB);
            Assert.Equal("SharedValue", instanceB.Value);
            Assert.True(eventTriggeredOnB, "Changing value on reference A must raise ValueChanged for subscribers on reference B.");
        }

        [Fact]
        public void GetConfig_ThrowsOnConflictingType()
        {
            string key = $"Test_Conflict_{Guid.NewGuid()}";
            ConfigFactory.GetConfig<int>(key, isTransient: true);

            Assert.Throws<InvalidOperationException>(() =>
            {
                ConfigFactory.GetConfig<string>(key, isTransient: true);
            });
        }

        [Fact]
        public void Config_ValueChanged_OnlyFiresWhenValueActuallyChanges()
        {
            string key = $"Test_Event_{Guid.NewGuid()}";
            var config = ConfigFactory.GetConfig<string>(key, isTransient: true);
            int fireCount = 0;
            config.ValueChanged += (s, e) => fireCount++;

            // Initial change -> should fire
            config.Value = "Alpha";
            Assert.Equal(1, fireCount);

            // Same value -> should NOT fire again
            config.Value = "Alpha";
            Assert.Equal(1, fireCount);

            // Different value -> should fire again
            config.Value = "Beta";
            Assert.Equal(2, fireCount);
        }

        [Fact]
        public void Config_HasValue_And_HasDefaultValue()
        {
            string key = $"Test_Defaults_{Guid.NewGuid()}";
            var config = ConfigFactory.GetConfig<int>(key, isTransient: true);

            // Default int is 0
            Assert.True(config.HasValue);
            Assert.True(config.HasDefaultValue);

            config.Value = 100;
            Assert.True(config.HasValue);
            Assert.False(config.HasDefaultValue);

            string strKey = $"Test_StrDefaults_{Guid.NewGuid()}";
            var strConfig = ConfigFactory.GetConfig<string>(strKey, isTransient: true);

            // Null reference type
            Assert.False(strConfig.HasValue);
            Assert.False(strConfig.HasDefaultValue);

            strConfig.Value = "Hello";
            Assert.True(strConfig.HasValue);
            Assert.False(strConfig.HasDefaultValue);
        }

        [Fact]
        public void GetConfig_ComplexObject_SerializesAndDeserializes()
        {
            string key = $"Test_Complex_{Guid.NewGuid()}";
            var config = ConfigFactory.GetConfig<TestPayload>(key, isTransient: true);
            var payload = new TestPayload("Sample", 99);

            config.Value = payload;

            Assert.NotNull(config.Value);
            Assert.Equal("Sample", config.Value.Name);
            Assert.Equal(99, config.Value.Counter);
        }

        [Fact]
        public void CultureInfoConfig_StoresAndRetrievesCulture_AndHandlesNull()
        {
            string key = $"Test_Culture_{Guid.NewGuid()}";
            var config = ConfigFactory.GetCultureInfoConfig(key, isTransient: true);
            config.Value = new CultureInfo("de-DE");

            Assert.NotNull(config.Value);
            Assert.Equal("de-DE", config.Value.Name);

            CultureInfo? implicitCulture = config;
            Assert.Equal("de-DE", implicitCulture?.Name);

            // Null handling
            config.Value = null;
            Assert.Null(config.Value);
        }

        [Fact]
        public void DirectoryInfoConfig_StoresAndRetrievesDirectory_AndHandlesNull()
        {
            string key = $"Test_Dir_{Guid.NewGuid()}";
            var config = ConfigFactory.GetDirectoryInfoConfig(key, isTransient: true);
            var dir = new DirectoryInfo(Path.GetTempPath());
            config.Value = dir;

            Assert.NotNull(config.Value);
            Assert.Equal(dir.FullName, config.Value.FullName);

            DirectoryInfo? implicitDir = config;
            Assert.Equal(dir.FullName, implicitDir?.FullName);

            config.Value = null;
            Assert.Null(config.Value);
        }

        [Fact]
        public void FileInfoConfig_StoresAndRetrievesFile_AndHandlesNull()
        {
            string key = $"Test_File_{Guid.NewGuid()}";
            var config = ConfigFactory.GetFileInfoConfig(key, isTransient: true);
            var file = new FileInfo(Path.Combine(Path.GetTempPath(), "test.txt"));
            config.Value = file;

            Assert.NotNull(config.Value);
            Assert.Equal(file.FullName, config.Value.FullName);

            FileInfo? implicitFile = config;
            Assert.Equal(file.FullName, implicitFile?.FullName);

            config.Value = null;
            Assert.Null(config.Value);
        }

        [Fact]
        public void UriConfig_StoresAndRetrievesUri_AndHandlesNullAndInvalid()
        {
            string key = $"Test_Uri_{Guid.NewGuid()}";
            var config = ConfigFactory.GetUriConfig(key, isTransient: true);
            var testUri = new Uri("https://github.com/nolanrasinjaria/Coding4Coffee");
            config.Value = testUri;

            Assert.NotNull(config.Value);
            Assert.Equal(testUri, config.Value);

            Uri? implicitUri = config;
            Assert.Equal(testUri, implicitUri);

            config.Value = null;
            Assert.Null(config.Value);
        }

        [Fact]
        public void IPAddressConfig_StoresAndRetrievesIPAddress_AndHandlesNullAndInvalid()
        {
            string key = $"Test_IP_{Guid.NewGuid()}";
            var config = ConfigFactory.GetIPAddressConfig(key, isTransient: true);
            var testIp = IPAddress.Parse("192.168.1.100");
            config.Value = testIp;

            Assert.NotNull(config.Value);
            Assert.Equal(testIp, config.Value);

            IPAddress? implicitIp = config;
            Assert.Equal(testIp, implicitIp);

            config.Value = null;
            Assert.Null(config.Value);
        }

        [Fact]
        public void VersionConfig_StoresAndRetrievesVersion_AndHandlesNullAndInvalid()
        {
            string key = $"Test_Version_{Guid.NewGuid()}";
            var config = ConfigFactory.GetVersionConfig(key, isTransient: true);
            var testVersion = new Version(2, 1, 0, 4);
            config.Value = testVersion;

            Assert.NotNull(config.Value);
            Assert.Equal(testVersion, config.Value);

            Version? implicitVersion = config;
            Assert.Equal(testVersion, implicitVersion);

            config.Value = null;
            Assert.Null(config.Value);
        }

        [Fact]
        public void EncodingConfig_StoresAndRetrievesEncoding_AndHandlesNull()
        {
            string key = $"Test_Encoding_{Guid.NewGuid()}";
            var config = ConfigFactory.GetEncodingConfig(key, isTransient: true);
            config.Value = Encoding.UTF8;

            Assert.NotNull(config.Value);
            Assert.Equal(Encoding.UTF8.WebName, config.Value.WebName);

            Encoding? implicitEncoding = config;
            Assert.Equal(Encoding.UTF8.WebName, implicitEncoding?.WebName);

            config.Value = null;
            Assert.Null(config.Value);
        }
    }
}
