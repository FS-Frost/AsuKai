using Microsoft.JSInterop;

namespace BlazorApp.Utils {
    public class JSUtils {
        private readonly IJSRuntime _js;

        public JSUtils(IJSRuntime jsRuntime) {
            _js = jsRuntime;
        }

        public async Task Alert(params object?[]? values) {
            await _js.InvokeVoidAsync("alert", values);
        }

        public async Task OpenNewTab(string url) {
            await _js.InvokeVoidAsync("open", new object[2] { url, "_blank" });
        }
    }
}
