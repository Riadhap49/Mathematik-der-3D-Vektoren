using System;

namespace Mathematik3DVektorenLib.Model
{
    #region 3D Vector struct
    /// <summary>
    /// Math: 3D Vector struct
    /// struct or  a class : the application define more than point in the 3D universe,
    /// imagine we have a 1.mio points/vectors 2D or 3D . Do we need to make a lot of them, each is reference type? then struct!
    /// As a struct is a value type defined in the .NET so not garbage collected (isuue performance),its a leight version of class.
    /// its also about Thred safety and immutability, in addition that the data is a primitive type(double)
    /// Not immutable: but we could make a copy once it' created then using readonly record struct 
    /// and the "with" expressionbut they still stay reference type!
    /// record are reference type but semanticly have a value based comparaison, it means two vector are equal if they have the same x,y,z coordinates
    /// but this is just one case of eqaulity. the same (x,y,y) tuple mean that they are 100% aufeinander. 
    /// Mathematicly two vectors are equal when three conditions are relased:
    /// 1.same || means "parallelism" to proove that we need to check if the middle of the two diagonals is the same 
    /// 2.same direction to proove that we need to check which point in the vector is bigger than the other one: start or end point of the vecor? 
    /// 3.same length to proove that we need to calculate the sqrt of the sum of each value'power then compare the two results.
    /// And with record struct to benefit from the record structure, they are also faster than regular struct.
    /// With a positional record struct we have to use the "readonly" keyword for immutability advantage, 
    /// otherwise we use the "init" keyword instead of using the "set" in the record stuct properties. 
    /// </summary>


    public record struct Mathe3DVektoren

    {

        #region Properties of the 3D Vector struct
        /// <summary>
        ///  Readonly Propereties for the Coordinates of the 3D Vector
        ///  Basicly every 3D vector is build from two 3D points 
        ///  so our vector is a record struct of two points (Startpoint, Endpoint),
        ///  we consider that the start point is (0,0,0) so we could define the vector with the endpoint's 3D coordinates  
        /// </summary>

        public double X { get; init; }
        public double Y { get; init; }
        public double Z { get; init; }


        /// <summary>
        /// Overriding the  method "GetHashCode" from the super class "Object" 
        /// we don't need to implement the IEqutable interface for comparaison and override the Equals method and other methods
        /// because we define our vector as a record
        /// so our vector is a value-based comparaison
        /// we just need to override the GetHashCode method 
        /// The Hashcode will build  from the three coordinates x,y,z with the static method Combine from the sturct HashCode 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => HashCode.Combine(X, Y, Z);
        
        #endregion
    }

    #endregion
}

