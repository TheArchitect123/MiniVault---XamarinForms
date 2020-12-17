using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Cross.DataVault.Binders
{
    [ContentProperty(nameof(Content))]
    public class TextFieldBinder : BindableObject
    {
        public TextFieldBinder()
        {
            //Initialization of Binder
        }

        public TextFieldBinder(View content)
        {
            Content = content;
        }

        //Standard Entry Properties
        private static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(TextFieldBinder), BindingMode.TwoWay);
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set { SetValue(PlaceholderProperty, value); }
        }

        private static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(TextFieldBinder), BindingMode.TwoWay);
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set { SetValue(TextProperty, value); }
        }

        //Hint for Placeholders
        private static readonly BindableProperty HintProperty = BindableProperty.Create(nameof(Hint), typeof(string), typeof(TextFieldBinder), BindingMode.TwoWay);
        public string Hint
        {
            get => (string)GetValue(HintProperty);
            set { SetValue(HintProperty, value); }
        }

        //Error Bindings
        private static readonly BindableProperty ErrorMessageProperty = BindableProperty.Create(nameof(ErrorMessage), typeof(string), typeof(TextFieldBinder), BindingMode.TwoWay);
        public string ErrorMessage
        {
            get => (string)GetValue(ErrorMessageProperty);
            set { SetValue(ErrorMessageProperty, value); }
        }

        private static readonly BindableProperty HasErrorProperty = BindableProperty.Create(nameof(HasError), typeof(string), typeof(TextFieldBinder), BindingMode.TwoWay);
        public string HasError
        {
            get => (string)GetValue(HasErrorProperty);
            set { SetValue(HasErrorProperty, value); }
        }

        //Content - Where to Place the Hint, Error, and other entry fields
        public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(View), typeof(TextFieldBinder));
        public View Content
        {
            get => (View)GetValue(ContentProperty);
            set { SetValue(ContentProperty, value); }
        }
    }
}
