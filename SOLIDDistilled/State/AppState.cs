namespace SolidDistilled.State;

public class AppState
{
    public event Action? OnChange;
    
    public void NotifyStateChanged() => OnChange?.Invoke();
}