using Microsoft.JSInterop;

namespace BlazorWASMTypeScript.Client.Services;

public class CalculatorNoficatioinService
{
    public event Func<Task> Notify;
    public int Sum { get; set; }

    [JSInvokableAttribute("ReturnSum")]
    public async Task GetCountyName(int sum)
    {
        Sum = sum;

        if (Notify != null)
        {
            await Notify?.Invoke();
        }
    }
}
