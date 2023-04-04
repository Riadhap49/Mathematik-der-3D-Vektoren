using Mathematik3DVektorenLib.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mathematik3DVektorenApp.Helpers
{
    /// <summary>
    /// Represent customized Assert 
    /// </summary>
    public  static class AssertExtension
    {
        public static bool AreInverted(this Assert assert, Mathe3DVektoren u, Mathe3DVektoren v)
        {
            return u.X == v.X * -1 && u.Y == v.Y * -1 && u.Z == v.Z * -1;
        }
    }
}
