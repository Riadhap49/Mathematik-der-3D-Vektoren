using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mathematik3DVektorenLib.ViewModel
{

    /// <summary>
    /// We define a base class that implment the interface INotifyPropertyChanged, 
    /// give us the possibilty in case of exisiting  more than ViewModel that can inherit from this base class.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// this generic method include the invoke of the implemented event PropertyChanged from the Interface INotifyPropertyChanged
        /// usually we give as argument a "hard coded" string value in this event or with using the nameOf method to get this argument,
        /// here the caller argument is optional decorated with the CallerMemberName attribut do this job for us.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="caller"></param>
        protected void SetValue<T>(ref T field, T value, [CallerMemberName] string? caller = null)
        
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
