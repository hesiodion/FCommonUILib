using Avalonia;
using Avalonia.Controls;
using FCommonUILib.FCommonUILib.Desktop.CustomTitleBar.ViewModels;

namespace FCommonUILib.FCommonUILib.Desktop.CustomTitleBar.Views
{
    public partial class CustomTitleBar : UserControl
    {
        public static readonly StyledProperty<string> CustomTextProperty =
            AvaloniaProperty.Register<CustomTitleBar, string>(nameof(CustomText));

        public string CustomText
        {
            get => GetValue(CustomTextProperty);
            set => SetValue(CustomTextProperty, value);
        }

        public CustomTitleBar()
        {
            InitializeComponent();
            DataContext = new CustomTitleBarViewModel();
        }
    }
}
