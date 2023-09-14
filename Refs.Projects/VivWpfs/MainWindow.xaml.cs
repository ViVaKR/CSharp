using System;
using System.Windows;
using System.Windows.Input;
using Microsoft.Web.WebView2.Core;

namespace VivWpfs
{
    public partial class MainWindow : Window
    {
        private readonly string initUri = @"https://www.microsoft.com";
        public MainWindow()
        {
            InitializeComponent();

            WindowState = WindowState.Maximized;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            webView.NavigationStarting += EnsureHttps;

            InitializeAsync();

            addressBar.Text = initUri;

            Uri uri = new(initUri);
            webView.Source = uri;

            addressBar.KeyDown += AddressBar_KeyDown;
        }


        private void AddressBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) NavigateTo();
        }


        private async void InitializeAsync()
        {
            await webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2.WebMessageReceived += UpdateAddressBar;

            await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.postMessage(window.document.URL);");

            // await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.addEventListener(\'message\', event => alert(event.data));");
        }

        private void UpdateAddressBar(object? sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            string uri = args.TryGetWebMessageAsString();
            addressBar.Text = uri;
            webView.CoreWebView2.PostWebMessageAsString(uri);
        }

        private void EnsureHttps(object? sender, CoreWebView2NavigationStartingEventArgs args)
        {
            string uri = args.Uri;
            if (!uri.StartsWith("http"))
            {
                string v = $"https://{uri}";
                uri = v;
                addressBar.Text = uri;
            }
        }

        public void Go(Uri uri)
        {
            try
            {
                webView.Source = uri;
            }
            catch (Exception ex)
            {
                webView.CoreWebView2.ExecuteScriptAsync($"alert('오류발생: {ex.Message} ')");
            }
        }

        private void ButtonGo_Click(object sender, RoutedEventArgs e)=>  NavigateTo();

        private void NavigateTo()
        {
            if (webView == null && webView?.CoreWebView2 == null) return;


            var uri = addressBar.Text;
            var check = uri[..4].Contains("http");
            var uriProtocol = !check ? $"http://{uri}" : uri;

            check = Uri.TryCreate(uriProtocol, UriKind.Absolute, out var uriResult) &&
                (uriResult.Scheme == Uri.UriSchemeHttp ||
                uriResult.Scheme == Uri.UriSchemeHttps);


            Uri finUri;
            if (check)
            {
                finUri = new Uri($"{uriResult}");
            }
            else
            {
                var search = new Uri($"https://www.google.com/search?q={uri}");
                finUri = new Uri($"{search}");
            }

            Go(finUri);
        }
    }
}
