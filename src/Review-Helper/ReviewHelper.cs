using System;
using Windows.ApplicationModel;
using Windows.UI.Popups;

namespace Review_Helper
{
    public class ReviewHelper
    {
        private const int RunCountBeforePrompt = 6;

        public async void SuggestReview()
        {
            var version = Package.Current.Id.Version;
            var appVersion = string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
            var savedVersion = SettingsManager.Get<string>("Version");

            if (appVersion != savedVersion)
            {
                SettingsManager.Set("Version", appVersion);
                SettingsManager.Set("RunCount", 0);
            }

            var runCount = SettingsManager.Get<int>("RunCount");
            if (runCount > RunCountBeforePrompt)
                return;

            if (runCount < RunCountBeforePrompt)
            {
                runCount++;
                SettingsManager.Set("RunCount", runCount);
                return;
            }

            runCount++;
            SettingsManager.Set("RunCount", runCount);

            var reviewReminder = new MessageDialog("It looks like you’ve used this app a few times now, would you like to leave a review or rating to let us know what you think? We’d love to hear from you and it should only take a second or two.", "So... What do you think?");

            var reviewItNow = new UICommand("Sure, i'll review it now!");
            reviewReminder.Commands.Add(reviewItNow);

            var doNotWant = new UICommand("No Thanks");
            reviewReminder.Commands.Add(doNotWant);

            if (await reviewReminder.ShowAsync() == reviewItNow)
                Windows.System.Launcher.LaunchUriAsync(new Uri(string.Format("ms-windows-store:REVIEW?PFN={0}", Package.Current.Id.FamilyName)));
        }
    }
}