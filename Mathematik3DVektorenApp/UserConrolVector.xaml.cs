using Mathematik3DVektorenApp.Helpers;
using Mathematik3DVektorenLib.Model;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Mathematik3DVektorenApp
{
    /// <summary>
    /// Represent our userControl to build the vector through the user input values
    /// and using Dependecy prop for Bunding 
    /// </summary>
    public partial class UserConrolVector : UserControl
    {
        //This pattern is used for textBoxes input double values check
        string pattern = @"^[-+]?[0-9]*[.,]?[0-9]+$";

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public Mathe3DVektoren Vector
        {
            get { return (Mathe3DVektoren)GetValue(VectorProperty); }
            set { SetValue(VectorProperty, value); }
        }

        public string UserInputX
        {
            get { return (string)GetValue(UserInputXProperty); }
            set { SetValue(UserInputXProperty, value); }
        }

        public string UserInputY
        {
            get { return (string)GetValue(UserInputYProperty); }
            set { SetValue(UserInputYProperty, value); }
        }

        public string UserInputZ
        {
            get { return (string)GetValue(UserInputZProperty); }
            set { SetValue(UserInputZProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DP.Register<string, UserControl>(nameof(Title));
        public static readonly DependencyProperty VectorProperty = DP.Register<Mathe3DVektoren, UserConrolVector>(nameof(Vector));
        public static readonly DependencyProperty UserInputXProperty = DP.Register<string, UserConrolVector>(nameof(UserInputX));
        public static readonly DependencyProperty UserInputYProperty = DP.Register<string, UserConrolVector>(nameof(UserInputY));
        public static readonly DependencyProperty UserInputZProperty = DP.Register<string, UserConrolVector>(nameof(UserInputZ));


        public UserConrolVector()
        {
            InitializeComponent();
        }

        /// <summary>
        /// the logic here and same for all textChanged events is when we define a real vector with right coordinates
        /// then we create our vector with those values so it's ready for the operation otherwise, 
        /// we create it but we set  0 value in the wrong coordinate,
        /// that give us with validation more control about operation
        /// x * 0 = 0, x - 0 = x and x belong to double values set
        /// other scenario: we could  also just ignore  the vector wenn at lease one value is wrong
        /// but we set 0 on the wrong value and not all vector values!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbXinput_TextChanged(object sender, TextChangedEventArgs e)
        {
            Vector = new()
            {
                X = Regex.IsMatch(tbXinput.Text, pattern) ? double.Parse(tbXinput.Text.Replace(",", "."), CultureInfo.InvariantCulture) : 0,
                Y = Vector.Y,
                Z = Vector.Z
            };
        }

        private void tbYinput_TextChanged(object sender, TextChangedEventArgs e)
        {
            Vector = new()
            {
                X = Vector.X,
                Y = Regex.IsMatch(tbYinput.Text, pattern) ? double.Parse(tbYinput.Text.Replace(",", "."), CultureInfo.InvariantCulture) : 0,
                Z = Vector.Z
            };
        }

        private void tbZinput_TextChanged(object sender, TextChangedEventArgs e)
        {
            Vector = new()
            {
                X = Vector.X,
                Y = Vector.Y,
                Z = Regex.IsMatch(tbZinput.Text, pattern) ? double.Parse(tbZinput.Text.Replace(",", "."), CultureInfo.InvariantCulture) : 0
            };
        }

    }
}
