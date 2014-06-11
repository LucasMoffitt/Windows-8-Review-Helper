using Windows.ApplicationModel;
using Windows.UI.Xaml.Controls;

namespace Review_Helper
{
    public sealed partial class MainPage : Page
    {
        private readonly ReviewHelper _reviewHelper;
        private int _buttonClickCount;

        public MainPage()
        {
            InitializeComponent();

            ResetSettings();

            var version = Package.Current.Id.Version;
            CurrentVersionLabel.Text = string.Format("Current Version: {0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);

            _reviewHelper = new ReviewHelper();
        }

        private void FakePageLoad_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            _buttonClickCount++;

            _reviewHelper.SuggestReview();

            FakePageLoadCountLabel.Text = string.Format("Faked Load Count: {0}", _buttonClickCount);
        }

        private void Reset_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ResetSettings();
            _buttonClickCount = 0;

            FakePageLoadCountLabel.Text = string.Format("Faked Load Count: {0}", _buttonClickCount);
        }

        private void ResetSettings()
        {
            SettingsManager.Set("Version", string.Empty);
            SettingsManager.Set("RunCount", string.Empty);
        }
    }
}