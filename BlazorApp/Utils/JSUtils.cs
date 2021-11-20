using Microsoft.JSInterop;

namespace BlazorApp.Utils {
    public class JSUtils {
        private readonly IJSRuntime _js;

        public JSUtils(IJSRuntime jsRuntime) {
            _js = jsRuntime;
        }

        public void Alert(params object?[]? values) {
            _js.InvokeVoidAsync("alert", values);
        }
    }
}
