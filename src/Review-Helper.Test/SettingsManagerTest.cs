using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Review_Helper.Test
{
    [TestClass]
    public class SettingsManagerTest
    {
        [TestMethod]
        public void HasKeyReturnsTrueWhenKeyIsSet()
        {
            const string testKey = "TestKey";
            SettingsManager.Set(testKey, "Just some test data");

            var hasKey = SettingsManager.HasKey(testKey);

            Assert.IsTrue(hasKey);
        }

        [TestMethod]
        public void HasKeyReturnsFalseWhenKeyIsDeleted()
        {
            const string testKey = "TestKey";
            SettingsManager.Set(testKey, "Just some test data");

            var hasKey = SettingsManager.HasKey(testKey);
            var removeKey = SettingsManager.Delete(testKey);
            var hasKeyAfterDelete = SettingsManager.HasKey(testKey);

            Assert.IsTrue(hasKey);
            Assert.IsTrue(removeKey);
            Assert.IsFalse(hasKeyAfterDelete);
        }

        [TestMethod]
        public void SettingsManagerCanSaveAndRetrieveString()
        {
            const string testKey = "TestStringKey";
            const string testData = "Something to save!";

            SettingsManager.Set(testKey, testData);

            var dataFromSettings = SettingsManager.Get<string>(testKey);

            Assert.IsFalse(string.IsNullOrEmpty(dataFromSettings));
            Assert.AreEqual(testData, dataFromSettings);
        }

        [TestMethod]
        public void SettingsManagerCanSaveAndRetrieveBool()
        {
            const string testKey = "TestBoolKey";
            const bool testData = true;

            SettingsManager.Set(testKey, testData);

            var dataFromSettings = SettingsManager.Get<bool>(testKey);

            Assert.AreEqual(testData, dataFromSettings);
        }
    }
}