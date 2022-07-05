using BlazorWASMTypeScript.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorWASMTypeScript.Client.Pages;

public partial class JavascriptInterop
{
    [Inject]
    IJSRuntime JSRuntime { get; set; }

    private DotNetObjectReference<CalculatorNoficatioinService> ObjRefCalculatorNoficatioinService;
    private CalculatorNoficatioinService CalculatorNoficatioinService;

    protected override void OnInitialized()
    {
        CalculatorNoficatioinService = new CalculatorNoficatioinService();

        ObjRefCalculatorNoficatioinService = DotNetObjectReference.Create(CalculatorNoficatioinService);

        CalculatorNoficatioinService.Notify += OnNotify;
    }

    public void Dispose()
    {
        CalculatorNoficatioinService.Notify -= OnNotify;

        ObjRefCalculatorNoficatioinService?.Dispose();
    }

    private async void CallJavasctipt()
    {
        await JSRuntime.InvokeAsync<Task>("Calculator.Calculator.Sum", ObjRefCalculatorNoficatioinService, 1, 2);
    }

    public async Task OnNotify()
    {
        await InvokeAsync(() =>
        {
            StateHasChanged();
        });
    }
}
