using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Cross.DataVault.ViewModels;

namespace Cross.DataVault.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecureTextField : ContentView
    {
        #region Bindings
        //Text - Content
        public static BindableProperty SecureTextProperty = BindableProperty.Create(propertyName: "SecureText", returnType: typeof(string), declaringType: typeof(SecureTextField), defaultValue: string.Empty, defaultBindingMode: BindingMode.TwoWay, propertyChanged: HandleTextPropertyChanged);
        public string SecureText
        {
            get => (string)GetValue(SecureTextProperty);
            set { SetValue(SecureTextProperty, value); }
        }
        
        private static void HandleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            SecureTextField targetView;

            targetView = (SecureTextField)bindable;
            if (targetView != null)
                targetView.SecureEntryField.Text = (string)newValue;
        }

        //Placeholder
        public static BindableProperty PlaceholderProperty = BindableProperty.Create(propertyName: "Placeholder", returnType: typeof(string), declaringType: typeof(SecureTextField), defaultValue: string.Empty, defaultBindingMode: BindingMode.OneWay, propertyChanged: HandlePlaceholderPropertyChanged);
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set { SetValue(PlaceholderProperty, value); }
        }
        private static void HandlePlaceholderPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            SecureTextField targetView;

            targetView = (SecureTextField)bindable;
            if (targetView != null)
                targetView.SecureEntryField.Placeholder = (string)newValue;
        }


        //Hint for Placeholders
        public static BindableProperty HintProperty = BindableProperty.Create(propertyName: "Hint", returnType: typeof(string), declaringType: typeof(SecureTextField), defaultValue: string.Empty, defaultBindingMode: BindingMode.TwoWay, propertyChanged: HandleHintPropertyChanged);
        public string Hint
        {
            get => (string)GetValue(HintProperty);
            set { SetValue(HintProperty, value); }
        }
        private static void HandleHintPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            SecureTextField targetView;

            targetView = (SecureTextField)bindable;
            if (targetView != null)
                targetView.SecureHintView.Text = (string)newValue;
        }

        //Error Bindings
        public static BindableProperty ErrorProperty = BindableProperty.Create(propertyName: "Error", returnType: typeof(string), declaringType: typeof(SecureTextField), defaultValue: string.Empty, defaultBindingMode: BindingMode.TwoWay, propertyChanged: HandleErrorPropertyChanged);
        public string Error
        {
            get => (string)GetValue(ErrorProperty);
            set { SetValue(ErrorProperty, value); }
        }
        private static void HandleErrorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            SecureTextField targetView;

            targetView = (SecureTextField)bindable;
            if (targetView != null)
                targetView.SecureErrorView.Text = (string)newValue;
        }

        //Has Error
        public static BindableProperty HasErrorProperty = BindableProperty.Create(propertyName: "HasError", returnType: typeof(bool), declaringType: typeof(SecureTextField), defaultValue: false, defaultBindingMode: BindingMode.TwoWay, propertyChanged: HandleHasErrorPropertyChanged);
        public bool HasError
        {
            get => (bool)GetValue(HasErrorProperty);
            set { SetValue(HasErrorProperty, value); }
        }
        private static void HandleHasErrorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            SecureTextField targetView;

            targetView = (SecureTextField)bindable;
            if (targetView != null)
            {
                if (!((bool)newValue))
                    targetView.SecureErrorView.FadeTo(0, 250, Easing.Linear);
                else
                    targetView.SecureErrorView.FadeTo(1, 200, Easing.Linear);
            }
        }

        #endregion


        public SecureTextField()
        {
            InitializeComponent();
            
            this.SecureErrorView.Opacity = 0;

            //this.EntryField.FontSize = 19;
            this.SecureHintView.TextColor = Color.FromRgba(0.247f, 0.3176f, 0.7098f, 1.0f);
            this.SecureHintView.Opacity = 0.0f;
            
            this.SecureEntryField.Placeholder = Placeholder;

            this.SecureEntryField.Focused += EntryField_Focused;
            this.SecureEntryField.Unfocused += EntryField_Unfocused;
            this.SecureEntryField.TextChanged += SecureEntryField_TextChanged;

            if (Device.RuntimePlatform == Device.Android)
                this.UnderlineIndicator.IsVisible = false;
        }
        
        #region Animations
        private void SecureEntryField_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.SecureErrorView.FadeTo(0, 250, Easing.Linear);

            //Bindings
            SecureText = this.SecureEntryField.Text;
        }

        //Hint Animations
        private void EntryField_Unfocused(object sender, FocusEventArgs e)
        {
            this.UnderlineIndicator.TextColor = Color.FromHex("#000000");
        }

        private void EntryField_Focused(object sender, FocusEventArgs e)
        {
            this.UnderlineIndicator.TextColor = Color.FromHex("#3FFF00");
        }
        #endregion
    }
}