using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ColourPicker;

public class MainWindowViewModel : ObservableObject
{
    private bool _listenToHsl;
    private bool _listenToRgb;

    public SliderViewModel HueSlider { get; }

    public SliderViewModel SaturationSlider { get; }

    public SliderViewModel LightnessSlider { get; }

    public SliderViewModel RedSlider { get; }

    public SliderViewModel GreenSlider { get; }

    public SliderViewModel BlueSlider { get; }

    public SliderViewModel AlphaSlider { get; }

    public SolidColorBrush Colour
    {
        get;
        private set => SetProperty(ref field, value);
    }

    public MainWindowViewModel()
    {
        Colour = Brushes.Red;

        HueSlider = new SliderViewModel("Hue", 0, 360, 0);
        SaturationSlider = new SliderViewModel("Saturation", 0, 100, 100);
        LightnessSlider = new SliderViewModel("Lightness", 0, 100, 50);

        HueSlider.PropertyChanged += (_, _) => OnHslChanged();
        SaturationSlider.PropertyChanged += (_, _) => OnHslChanged();
        LightnessSlider.PropertyChanged += (_, _) => OnHslChanged();

        RedSlider = new SliderViewModel("R", 0, 255, 255);
        GreenSlider = new SliderViewModel("G", 0, 255, 0);
        BlueSlider = new SliderViewModel("B", 0, 255, 0);

        RedSlider.PropertyChanged += (_, _) => OnRgbChanged();
        GreenSlider.PropertyChanged += (_, _) => OnRgbChanged();
        BlueSlider.PropertyChanged += (_, _) => OnRgbChanged();

        AlphaSlider = new SliderViewModel("Opacity", 0, 100, 100);

        AlphaSlider.PropertyChanged += (_, _) =>
        {
            Colour = new SolidColorBrush(Color.FromArgb((byte)(255 * AlphaSlider.Value / AlphaSlider.Max), (byte)RedSlider.Value, (byte)GreenSlider.Value, (byte)BlueSlider.Value));
        };

        _listenToHsl = true;
        _listenToRgb = true;
    }

    private void OnHslChanged()
    {
        if (!_listenToHsl)
        {
            return;
        }

        // Stop listening to RGB changes to avoid circular updates
        _listenToRgb = false;

        var hsl = new HslColour(
            HueSlider.Value / HueSlider.Max,
            SaturationSlider.Value / SaturationSlider.Max,
            LightnessSlider.Value / LightnessSlider.Max);

        var rgb = hsl.ToRgb();

        RedSlider.Value = rgb.R;
        GreenSlider.Value = rgb.G;
        BlueSlider.Value = rgb.B;

        Colour = new SolidColorBrush(Color.FromArgb((byte)(255 * AlphaSlider.Value / AlphaSlider.Max), (byte)rgb.R, (byte)rgb.G, (byte)rgb.B));

        _listenToRgb = true;
    }

    private void OnRgbChanged()
    {
        if (!_listenToRgb)
        {
            return;
        }

        // Stop listening to HSL changes to avoid circular updates
        _listenToHsl = false;

        var rgb = new RgbColour(
            (int)RedSlider.Value,
            (int)GreenSlider.Value,
            (int)BlueSlider.Value);

        var hsl = rgb.ToHsl();

        HueSlider.Value = hsl.H * HueSlider.Max;
        SaturationSlider.Value = hsl.S * SaturationSlider.Max;
        LightnessSlider.Value = hsl.L * LightnessSlider.Max;

        Colour = new SolidColorBrush(Color.FromArgb((byte)(255 * AlphaSlider.Value / AlphaSlider.Max), (byte)rgb.R, (byte)rgb.G, (byte)rgb.B));

        _listenToHsl = true;
    }
}