using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TouchInjection.Services;

namespace TouchInjection.Panel.Shell
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly TouchInjectionExecutor _executor;

        public MainWindow()
        {
            InitializeComponent();
            _executor = new TouchInjectionExecutor();
            ITouchInjectionListener listener = new TouchInjectionListener(new KeyboardAndMouseProvider(), _executor);
            listener.Start();
        }

        private void UIElement_OnTouchDown(object sender, TouchEventArgs e)
        {
            AddMessage("Touch Down");
        }

        private void AddMessage(string text)
        {
            ListBox.Items.Add(text);
        }

        private void UIElement_OnTouchUp(object sender, TouchEventArgs e)
        {
            AddMessage("Touch Up");
        }

        private void UIElement_OnPreviewTouchDown(object sender, TouchEventArgs e)
        {
            AddMessage("Preview Touch Down");
        }

        private void UIElement_OnTouchEnter(object sender, TouchEventArgs e)
        {
            AddMessage("Touch Enter");
        }

        private async void ButtonPinchClick(object sender, RoutedEventArgs e)
        {
            await Task.Delay(1000);
            await _executor.PinchZoomOutAsync(500, 500, 100, 1);
        }

        private async void ButtonZoomClick(object sender, RoutedEventArgs e)
        {
            await Task.Delay(1000);
            await _executor.PinchZoomInAsync(500, 500, 100, 1);
        }        
    }
}