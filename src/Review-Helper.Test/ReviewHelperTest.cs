using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Review_Helper.Test
{
    [TestClass]
    public class ReviewHelperTest
    {
        public ReviewHelperTest()
        {
            ResetSettings();
        }

        [TestMethod]
        public void RunCountIncrementsAfterPromptingForReview()
        {
            var reviewHelper = new ReviewHelper();
            reviewHelper.SuggestReview();

            Assert.AreEqual(SettingsManager.Get<int>("RunCount"), 1);
        }

        [TestMethod]
        public void RunCountResetsAfterVersionChange()
        {
            var reviewHelper = new ReviewHelper();
            reviewHelper.SuggestReview();
            reviewHelper.SuggestReview();
            reviewHelper.SuggestReview();
            reviewHelper.SuggestReview();

            Assert.AreEqual(SettingsManager.Get<int>("RunCount"), 4);

            SettingsManager.Set("Version", "1.1.1.1");
            reviewHelper.SuggestReview();

            Assert.AreEqual(SettingsManager.Get<int>("RunCount"), 1);
        }

        private void ResetSettings()
        {
            SettingsManager.Set("Version", string.Empty);
            SettingsManager.Set("RunCount", string.Empty);
        }
    }
}