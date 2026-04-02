using CommunityToolkit.Mvvm.ComponentModel;

namespace ColourPicker.Desktop;

public class SliderViewModel : ObservableObject
{
    public string Title { get; }

    public double Min { get; }
    public double Max { get; }

    public double Value
    {
        get;
        set => SetProperty(ref field, Math.Clamp(value, Min, Max));
    }

    public SliderViewModel(string title, double min, double max, double initialValue)
    {
        Title = title;
        Min = min;
        Max = max;
        Value = initialValue;
    }
}
