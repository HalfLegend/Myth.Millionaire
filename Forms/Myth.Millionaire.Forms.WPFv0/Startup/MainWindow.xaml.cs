using System;
using System.ComponentModel;
using System.Windows;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

namespace Myth.Millionaire.Forms.WPFv0.Startup {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    // ReSharper disable once InheritdocConsiderUsage
    public partial class MainWindow {
        public MainWindow() {
            InitializeComponent();
        }
    }

    public static class DependencyObjectExtensions {
        public static void Observe<T>(this T component, DependencyProperty dependencyProperty, EventHandler update)
            where T : DependencyObject {
            DependencyPropertyDescriptor property = DependencyPropertyDescriptor.FromProperty(dependencyProperty, typeof(T));
            property.AddValueChanged(component, update);
        }
    }
}
