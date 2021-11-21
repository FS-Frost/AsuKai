using Asu;
using Microsoft.JSInterop;

namespace BlazorApp.Utils
{
    public class JSUtils
    {
        private readonly IJSRuntime _jsRuntime;

        public JSUtils(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public ValueTask AlertAsync(params object?[]? values)
        {
            return _jsRuntime.InvokeVoidAsync("alert", values);
        }

        public ValueTask OpenNewTabAsync(string url)
        {
            return _jsRuntime.InvokeVoidAsync("open", new object[2] { url, "_blank" });
        }

        public ValueTask<string> ClipboardReadTextAsync()
        {
            return _jsRuntime.InvokeAsync<string>("navigator.clipboard.readText");
        }

        public ValueTask ClipboardWriteTextAsync(string text)
        {
            return _jsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", text);
        }

        public async ValueTask<string[]> ClipboardReadLinesAsync()
        {
            var text = await ClipboardReadTextAsync();
            var lines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            return lines;
        }

        public ValueTask ClipboardWriteLinesAsync(string[] lines)
        {
            var text = "";

            foreach (var l in lines)
            {
                text += l.ToString() + Environment.NewLine;
            }

            return ClipboardWriteTextAsync(text);
        }

        public ValueTask ClipboardWriteLinesAsync(List<Line> lines)
        {
            var text = "";

            foreach (var l in lines)
            {
                text += l.ToString() + Environment.NewLine;
            }

            return ClipboardWriteTextAsync(text);
        }
    }
}
