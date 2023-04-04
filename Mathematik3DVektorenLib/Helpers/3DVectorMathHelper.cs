using System;
using Mathematik3DVektorenLib.Model;

namespace Mathematik3DVektorenLib.Helpers;


/// <summary>
/// Represent a helper class contains all logic that we need for apply some operations on vectors
/// </summary>
public class Math3DVectorHelper 
{
    #region Methods applied on 3D vectors

    /// <summary>
    /// Invert or negate a vector v(2,2,3) => v(-2,-2,-3)
    /// </summary>
    /// <param name="vector"></param>
    /// <returns></returns>
    public static Mathe3DVektoren InvertVector(Mathe3DVektoren v)
    {
        return new Mathe3DVektoren { X = v.X * -1, Y = v.Y * -1, Z = v.Z * -1 };
    }

   
    /// <summary>
    /// Add two vectors v(1,2,-1) + u(1,2,4) => result(2,4,3)
    /// </summary>
    /// <param name="v"></param>
    /// <param name="u"></param>
    /// <returns></returns>
    public static Mathe3DVektoren AddTwoVectors(Mathe3DVektoren v, Mathe3DVektoren u)
    {
        return new Mathe3DVektoren
        {
            X = v.X + u.X,
            Y = v.Y + u.Y,
            Z = v.Z + u.Z
        };
    }

    /// <summary>
    /// Substract two vectors v(1,4,-1) - u(3,2,4) => result(-2,2,-5)
    /// </summary>
    /// <param name="v"></param>
    /// <param name="u"></param>
    /// <returns></returns>
    public static Mathe3DVektoren SubstractTwoVectors(Mathe3DVektoren v, Mathe3DVektoren u)
    {
        return new Mathe3DVektoren
        {
            X = v.X - u.X,
            Y = v.Y - u.Y,
            Z = v.Z - u.Z
        };
    }


    /// <summary>
    /// Multiplcate vector with scalar v(1,4,-1) * 5 => result(5,20,-5)
    /// </summary>
    /// <param name="v"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Mathe3DVektoren MultiplicateVectorWithScalar(Mathe3DVektoren v, double value)
    {
        return new Mathe3DVektoren
        {
            X = v.X * value,
            Y = v.Y * value,
            Z = v.Z * value
        };
    }



    /// <summary>
    /// Devide vector with scalar v(10,4,-1) / 2 => result(5,2,-0.5)
    /// </summary>
    /// <param name="v"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Mathe3DVektoren DevideVectorWithScalar(Mathe3DVektoren v, double value)
    {
        return new Mathe3DVektoren
        {
            X = v.X / value,
            Y = v.Y / value,

            Z = v.Z / value
        };
    }


    /// <summary>
    /// Scalar produkt of two vectors  v(1,4,-1) * u(2,6,3) => result 1*2 + 4*6 + -1*3 = 23
    /// </summary>
    /// <param name="v"></param>
    /// <param name="u"></param>
    /// <returns></returns>
    public static double ScalarProductTwoVectors(Mathe3DVektoren v, Mathe3DVektoren u)
    {
        return v.X * u.X +
                v.Y * u.Y +
                v.Z * u.Z;
    }


    /// <summary>
    /// Cross produkt of two vectors  v(1,2,-4) * u(-2,6,3) => result (2*3-(-4*6), -4*-2-1*3 , 1*6-2*(-2)) = (30,5,10)
    /// </summary>
    /// <param name="v"></param>
    /// <param name="u"></param>
    /// <returns></returns>
    public static Mathe3DVektoren CrossProductTwoVectors(Mathe3DVektoren v, Mathe3DVektoren u)
    {
        return new Mathe3DVektoren
        {
            X = v.Y * u.Z - v.Z * u.Y,
            Y = v.Z * u.X - v.X * u.Z,
            Z = v.X * u.Y - v.Y * u.X
        };
    }

    /// <summary>
    /// Length of vector  v(2,3,5) => result (2²+3²+5²)^0.5
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public static double LengthVector(Mathe3DVektoren v)
    {
        return Math.Sqrt(Math.Pow(v.X, 2) + Math.Pow(v.Y, 2) + Math.Pow(v.Z, 2));
    }


    /// <summary>
    /// Angel between two vector v and u  reuslt : cos ß = (v*u)/||v||*||u|| 
    /// </summary>
    /// <param name="v"></param>
    /// <param name="u"></param>
    /// <returns></returns>
    /// 

    public  static double AngelBetweenTwoVector(Mathe3DVektoren v, Mathe3DVektoren u)
    {
        double angel = 0d;
        if (!IsVectorMultipleOfAnotherVector(v, u))
        {
            double scalarproduct = ScalarProductTwoVectors(v, u);
            double lengthOfThisVector = LengthVector(v);
            double lengthOfOtherVector = LengthVector(u);
            double productOfLengthsTwoVectors = lengthOfThisVector * lengthOfOtherVector;
            angel = Math.Cos(scalarproduct / productOfLengthsTwoVectors);
        }

        return angel;
    }


    /// <summary>
    /// Check for  parallelism || between two vectors for ex: v(5,20,1) is 5* u(1,4,1/5) then the angel must be 0°
    /// Remarque: in the two ways of division we became the "true" boolean (5=5=5) or (1/5=1/5=1/5)
    /// special cases: v/u or u/v is representing a scalar product value
    /// by positive value the arc is 0°
    /// by negative value the arc is 180°
    /// </summary>
    /// <param name="v"></param>
    /// <param name="u"></param>
    /// <returns></returns>
    /// 
    private static bool IsVectorMultipleOfAnotherVector(Mathe3DVektoren v, Mathe3DVektoren u)
    {
        return v.X / u.X == v.Y / u.Y && v.X / u.X == v.Z / u.Z;
    }

    /// <summary>
    /// Check for equality between two vectors 
    /// since the 3DVector is a record then the equality is value based comparaison 
    /// so two vector are equal when
    /// 1.they have the same x,y,z coordinates
    /// 2.they have the same ||, the same direction, the same length (this case is not going to be demonstrated here
    /// because its considered that every vector have (0,0,0) as start point)
    /// </summary>
    /// <param name="v"></param>
    /// <param name="u"></param>
    /// <returns></returns>
    /// 
    //You should expose this method (and the other) (make them public)
    public static bool IsEqualTwoVectors(Mathe3DVektoren v, Mathe3DVektoren u) => v == u;

    #endregion

}
