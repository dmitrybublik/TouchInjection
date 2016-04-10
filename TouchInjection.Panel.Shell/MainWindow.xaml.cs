﻿using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using TouchInjection.Services;

namespace TouchInjection.Panel.Shell
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly TouchInjectionService _service;

        public MainWindow()
        {
            InitializeComponent();
            _service = new TouchInjectionService();
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
            await _service.PinchZoomOutAsync(500, 500, 100);
        }

        private async void ButtonZoomClick(object sender, RoutedEventArgs e)
        {
            await Task.Delay(1000);
            await _service.PinchZoomInAsync(500, 500, 100);
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            _service.RegisterPinchZoomHotKeys(Keys.F11, Keys.F12);
            //_service.RegisterHotkeys(this, Keys.F11, Keys.F12);
        }
    }
}