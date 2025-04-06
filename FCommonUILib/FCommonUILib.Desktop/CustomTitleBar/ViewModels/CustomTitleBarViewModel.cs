using Avalonia.Controls;
using Avalonia.Threading;
using ReactiveUI;
using System;
using System.Reactive;

namespace FCommonUILib.FCommonUILib.Desktop.CustomTitleBar.ViewModels
{
    public class CustomTitleBarViewModel : ReactiveObject
    {
        public ReactiveCommand<Window, Unit> MinimizeCommand { get; }
        public ReactiveCommand<Window, Unit> MaximizeRestoreCommand { get; }
        public ReactiveCommand<Window, Unit> CloseCommand { get; }

        public CustomTitleBarViewModel()
        {
            MinimizeCommand = ReactiveCommand.Create<Window>(window =>
            {
                if (window != null)
                {
                    ExecuteOnUIThread(() => window.WindowState = WindowState.Minimized);
                }
            }, outputScheduler: RxApp.TaskpoolScheduler);

            MaximizeRestoreCommand = ReactiveCommand.Create<Window>(window =>
            {
                if (window != null)
                {
                    ExecuteOnUIThread(() => window.WindowState = window.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized);
                }
            }, outputScheduler: RxApp.TaskpoolScheduler);

            CloseCommand = ReactiveCommand.Create<Window>(window =>
            {
                if (window != null)
                {
                    ExecuteOnUIThread(() => window.Close());
                }
            }, outputScheduler: RxApp.TaskpoolScheduler);

        }

        public static void ExecuteOnUIThread(Action action)
        {
            Dispatcher.UIThread.InvokeAsync(action);
        }
    }
}