using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CurrencyControl.CustomControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrencyControl : ContentView
    {
        public CurrencyControl()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped_ForDisplayTextBox(object sender, EventArgs e)
        {

            lblDisplayAmount.IsVisible = false;
            txtAmmount.IsVisible = true;
            txtAmmount.Focus();
        }

        private void txtAmmount_Unfocused(object sender, FocusEventArgs e)
        {
            txtAmmount.IsVisible = false;
            lblDisplayAmount.IsVisible = true;
        }


        #region Amount Property
        public static readonly BindableProperty AmountProperty = BindableProperty.Create(
       propertyName: nameof(Amount),
       returnType: typeof(double),
       declaringType: typeof(CurrencyControl),
       defaultValue: 0d,
       defaultBindingMode: BindingMode.TwoWay,
       propertyChanged: AmountPropertyChanged);

        private static void AmountPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CurrencyControl)bindable;
            if (newValue != null)
            {
                double val = Convert.ToDouble(newValue);
                if (val > 0)
                {
                    control.lblDisplayAmount.Text = "$" + val.ToString("#,##0.00");
                };
            }
        }
        public double Amount
        {
            get { return (double)base.GetValue(AmountProperty); }
            set { base.SetValue(AmountProperty, value); }
        }
        #endregion

        #region Place Holder Property
        public static readonly BindableProperty PlaceHolderProperty = BindableProperty.Create(
       propertyName: nameof(PlaceHolder),
       returnType: typeof(string),
       declaringType: typeof(CurrencyControl),
       defaultValue: "",
       defaultBindingMode: BindingMode.TwoWay,
       propertyChanged: PlaceHolderPropertyChanged);

        private static void PlaceHolderPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CurrencyControl)bindable;
            if (newValue != null)
            {
                string val = (string)newValue;
                if (!string.IsNullOrWhiteSpace(val))
                {
                    control.txtAmmount.Placeholder = val;
                };
            }
        }
        public string PlaceHolder
        {
            get { return (string)base.GetValue(PlaceHolderProperty); }
            set { base.SetValue(PlaceHolderProperty, value); }
        }
        #endregion
    }
}