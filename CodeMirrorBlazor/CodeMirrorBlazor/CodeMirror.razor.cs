using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMirrorBlazor
{
    public partial class CodeMirror
    {
        [Inject] IJSRuntime JSRuntime { get; set; } = null!;

        [Parameter]
        public string Value { get; set; } = null!;

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }

        ElementReference? element;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            //var module = await JSRuntime.InvokeAsync<IJSObjectReference>(
            //    "import",
            //    "./_content/CodeMirrorBlazor/node_modules/codemirror/dist/index.js");
            if (!firstRender) return;

            var codeMirrorModule = await JSRuntime.InvokeAsync<IJSObjectReference>(
                "import",
                "./_content/CodeMirrorBlazor/CodeMirror.razor.js");

            var loaded = await codeMirrorModule.InvokeAsync<IJSObjectReference>("load", element, new { });
        }
    }
}
