using System.Windows;

namespace Mathematik3DVektorenApp.Helpers;


/// <summary>
/// Static class for those dependencyProp return DependencyProperty type
/// make it easier to call a propdp in any consuming part(class.cs) of the app
/// </summary>
public static class DP
{
    public static DependencyProperty Register<TProperty, TOwner>(string propName)
    {
        return DependencyProperty.Register(propName, typeof(TProperty), typeof(TOwner), new PropertyMetadata(default(TProperty)));
    }
}

