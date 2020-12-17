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
    public partial class TextField : ContentView
    {
        #region Bindings
        //Text - Content
        public static BindableProperty TextProperty = BindableProperty.Create(propertyName: "Text", returnType: typeof(string), declaringType: typeof(TextField), defaultValue: string.Empty, defaultBindingMode: BindingMode.TwoWay, propertyChanged: HandleTextPropertyChanged);
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set { SetValue(TextProperty, value); }
        }
        
        private static void HandleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            TextField targetView;

            targetView = (TextField)bindable;
            if (targetView != null)
                targetView.EntryField.Text = (string)newValue;
        }

        //Placeholder
        public static BindableProperty PlaceholderProperty = BindableProperty.Create(propertyName: "Placeholder", returnType: typeof(string), declaringType: typeof(TextField), defaultValue: string.Empty, defaultBindingMode: BindingMode.OneWay, propertyChanged: HandlePlaceholderPropertyChanged);
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set { SetValue(PlaceholderProperty, value); }
        }
        private static void HandlePlaceholderPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            TextField targetView;

            targetView = (TextField)bindable;
            if (targetView != null)
                targetView.EntryField.Placeholder = (string)newValue;
        }


        //Hint for Placeholders
        public static BindableProperty HintProperty = BindableProperty.Create(propertyName: "Hint", returnType: typeof(string), declaringType: typeof(TextField), defaultValue: string.Empty, defaultBindingMode: BindingMode.TwoWay, propertyChanged: HandleHintPropertyChanged);
        public string Hint
        {
            get => (string)GetValue(HintProperty);
            set { SetValue(HintProperty, value); }
        }
        private static void HandleHintPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            TextField targetView;

            targetView = (TextField)bindable;
            if (targetView != null)
                targetView.HintView.Text = (string)newValue;
        }

        //Error Bindings
        public static BindableProperty ErrorProperty = BindableProperty.Create(propertyName: "Error", returnType: typeof(string), declaringType: typeof(TextField), defaultValue: string.Empty, defaultBindingMode: BindingMode.TwoWay, propertyChanged: HandleErrorPropertyChanged);
        public string Error
        {
            get => (string)GetValue(ErrorProperty);
            set { SetValue(ErrorProperty, value); }
        }
        private static void HandleErrorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            TextField targetView;

            targetView = (TextField)bindable;
            if (targetView != null)
                targetView.ErrorView.Text = (string)newValue;
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
            TextField targetView;

            targetView = (TextField)bindable;
            if (targetView != null)
            {
                if (!((bool)newValue))
                    targetView.ErrorView.FadeTo(0, 250, Easing.Linear);
                else
                    targetView.ErrorView.FadeTo(1, 200, Easing.Linear);
            }
        }

        #endregion
        
        public TextField()
        {
            InitializeComponent();

            this.ErrorView.Opacity = 0;

            //this.EntryField.FontSize = 19;
            this.HintView.TextColor = Color.FromRgba(0.247f, 0.3176f, 0.7098f, 1.0f);
            this.HintView.Opacity = 0.0f;

            this.EntryField.Placeholder = Placeholder;

            this.EntryField.Focused += EntryField_Focused;
            this.EntryField.Unfocused += EntryField_Unfocused;
            this.EntryField.TextChanged += SecureEntryField_TextChanged;

            if (Device.RuntimePlatform == Device.Android)
                this.UnderlineIndicator.IsVisible = false;
            
        }
        
        #region Animations

        private void SecureEntryField_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ErrorView.FadeTo(0, 250, Easing.Linear);

            this.Text = this.EntryField.Text;
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