using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InvalidateMeasurePerformanceIssue;

public class MainPageViewModel
{
    public List<Thingwithvisibility> Things { get; set; }

    public MainPageViewModel()
    {
        Things = new List<Thingwithvisibility>();
        for (var i = 0; i < 200; i++)
        {
            Things.Add(new Thingwithvisibility { Name = $"{i}: Thing with a long name that should tailtruncate when there is not enough space" });
        }
    }
}

public class Thingwithvisibility : INotifyPropertyChanged
{
    public string Name { get; set; }
    
    private bool _isVisible;

    public bool IsVisible
    {
        get => _isVisible;
        set
        {
            var before = _isVisible;
            _isVisible = value;
            if(before != value)
                OnPropertyChanged();
        }
    }
    
    public Command ToggleVisibilityCommand { get; }

    public Thingwithvisibility()
    {
        ToggleVisibilityCommand = new Command(() =>
        {
            Debug.WriteLine("Visibility changed");
            IsVisible = !IsVisible;
        });
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}