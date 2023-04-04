using System.Windows.Controls;
using System.Windows;
using Mathematik3DVektorenLib.Model;
using Mathematik3DVektorenApp.Helpers;
using System.Net.Http.Headers;

namespace Mathematik3DVektorenApp
{
    /// <summary>
    /// Interaction logic for UserControlAdditionTwoVectorsResult.xaml
    /// </summary>
    public partial class UserControlAdditionTwoVectorsResult : UserControl
    {

        public Mathe3DVektoren VectorResult
        {
            get { return (Mathe3DVektoren)GetValue(VectorResultProperty); }
            set { SetValue(VectorResultProperty, value); }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }


        public UserControlAdditionTwoVectorsResult()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TitleProperty =
            DP.Register<string, UserControlAdditionTwoVectorsResult>(nameof(Title));

        public static readonly DependencyProperty VectorResultProperty =
            DP.Register<Mathe3DVektoren, UserControlAdditionTwoVectorsResult>(nameof(VectorResult));
    }
}
