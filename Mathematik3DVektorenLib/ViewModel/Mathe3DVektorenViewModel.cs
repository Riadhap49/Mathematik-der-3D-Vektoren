using Mathematik3DVektorenLib.Helpers;
using Mathematik3DVektorenLib.Model;

namespace Mathematik3DVektorenLib.ViewModel
{
    /// <summary>
    /// Represente our VM class that is between the model and the UI
    /// because is just about to display the sum of two vectors so we don't need here all methods applied on vectors
    /// like in case of that the UI have a menu to choise the operation applied on vectors
    /// </summary>
    public class Mathe3DVektorenViewModel : ViewModelBase

    {
        private Mathe3DVektoren _u;
        private Mathe3DVektoren _v;
        private Mathe3DVektoren _vectorSum;

        public Mathe3DVektoren U
        {
            get
            {
                return _u;
            }

            set
            {
                _u = value;
                VectorSum = Math3DVectorHelper.CrossProductTwoVectors(_u, V);
            }
        }

        public Mathe3DVektoren V
        {
            get
            {
                return _v;
            }

            set
            {
                _v = value;
                VectorSum = Math3DVectorHelper.CrossProductTwoVectors(U, _v);
            }
        }
        
        public Mathe3DVektoren VectorSum
        {
            get => _vectorSum;
            private set
            {
                SetValue(ref _vectorSum, value);
            }
        }
    }
}
