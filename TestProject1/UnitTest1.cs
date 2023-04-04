using Mathematik3DVektorenLib.Helpers;
using Mathematik3DVektorenLib.Model;
using Mathematik3DVektorenApp.Helpers;
using System.Runtime.ConstrainedExecution;
using System.Globalization;
using System.ComponentModel;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        #region Init & CleanUp
        //Mathe3DVektoren u;
        //Mathe3DVektoren v;
        //double value;

        //[ClassInitialize]
        //public void Init()
        //{
        //    u = new Mathe3DVektoren() { X = 4, Y = 6, Z = 10 };
        //    v = new Mathe3DVektoren() { X = 2, Y = 4, Z = 8 };
        //    value= 5;
        //}

        #endregion


        #region Invert vector test
        /// <summary>
        ///   With[TestMethod] attribut, we mark this methid in the class to be in test
        /// with triple ArangeActAssert :
        ///1. we define our vector to be inverted
        /// 2.we call the invertion method from our helper class, it return for us an actual vector
        /// 2.we define the expected vector
        ///3.we call the method AreEqual from the Assert class
        /// </summary>

        [TestMethod]
        public void TestMethodInvertVectorExpectedInvertedVector()
        {
            Mathe3DVektoren vector = new() { X = 1, Y = 2, Z = -3 };
            Mathe3DVektoren actualVector = Math3DVectorHelper.InvertVector(vector);
            Mathe3DVektoren expectedVector = new() { X = -1, Y = -2, Z = 3 };
            Assert.AreEqual(expectedVector, actualVector);
        }
        #endregion


        #region Add two vectors test
        /// <summary>
        /// we apply the addition operation on two vectors 
        /// </summary>
        [TestMethod]
        public void TestMethodAddTwoVectorsExpectedSumVector()
        {
            Mathe3DVektoren vectorU = new() { X = 1, Y = 2, Z = -3 };
            Mathe3DVektoren vectorV = new() { X = 1, Y = 2, Z = 3 };
            Mathe3DVektoren actualVector = Math3DVectorHelper.AddTwoVectors(vectorU, vectorV);
            Mathe3DVektoren expectedVector = new() { X = 2, Y = 4, Z = 0 };
            Assert.AreEqual(expectedVector, actualVector);
        }
        #endregion


        #region Invert vector test using the attribute [DynamicData]
        /// <summary>
        /// With [DynamicData] attribute :externalized test into the method "GetData"
        /// </summary>
        /// <param name="u"></param>
        /// <param name="expectedVector"></param>
        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]

        public void TestMethodWithDynamicDataInvertVectorExpectedInvertedVector(Mathe3DVektoren u, Mathe3DVektoren expectedVector)
        {
            var actualVector = Math3DVectorHelper.InvertVector(u);
            Assert.AreEqual(expectedVector, actualVector);

            // Extension method for the Assert class, press F12 to go to definition
            Assert.That.AreInverted(u, expectedVector);

        }

        /// <summary>
        /// this multiple input(vectors) will be tested with only one test
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetData()
        {
            return new List<object[]>()
           {
           new object[]{new Mathe3DVektoren() {X = 1, Y = 2, Z = -3}, new Mathe3DVektoren() { X = -1, Y = -2, Z = 3 } },
           new object[]{new Mathe3DVektoren() {X = -10, Y = 3.5, Z = 4}, new Mathe3DVektoren() { X = 10, Y = -3.5, Z = -4 } },
           new object[]{new Mathe3DVektoren() {X = -1, Y = 2, Z = -2.8}, new Mathe3DVektoren() { X = 1, Y = -2, Z = 2.8} },
           new object[]{new Mathe3DVektoren() {X = 0, Y = -5, Z = 1}, new Mathe3DVektoren() { X = 0, Y = 5, Z = -1} }
           };
        }
        #endregion


        #region Scallar product test

        /// <summary>
        /// Data-driven Test: parameterized test with [DataRow] attribute
        /// we test here the scallar product between a vector and a double value
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(-3)]

        public void TestMethodScallarProductExpectedRightVectorValues(double value)
        {
            Mathe3DVektoren v = new Mathe3DVektoren() { X = 2, Y = -2, Z = 3 };
            var actualVector = Math3DVectorHelper.MultiplicateVectorWithScalar(v, value);
            Assert.AreEqual(new Mathe3DVektoren() { X = -6, Y = 6, Z = -9 }, actualVector);
        }
        #endregion


        #region Substract vectors test
        /// <summary>
        /// simple attribute decoration [TestMethod] of the method substract between two vectors
        /// </summary>
        [TestMethod]
        public void TestMethodSubstractTwoVectorsExpectedrightVectorValues()
        {
            var u = new Mathe3DVektoren() { X = 4, Y = 6, Z = 10 };
            var v = new Mathe3DVektoren() { X = 2, Y = 4, Z = 8 };

            var actualVector = Math3DVectorHelper.SubstractTwoVectors(u, v);
            var expectedVector = new Mathe3DVektoren() { X = 2, Y = 2, Z = 2 };
            Assert.AreEqual(expectedVector, actualVector);
        }
        #endregion


        #region Deviosion vector on scallar value test using [DynamicData] attribute
        /// <summary>
        /// With the attribute [DynamicData] can call one test for multiple input
        /// </summary>
        /// <param name="u"></param>
        /// <param name="value"></param>
        /// <param name="v"></param>
        [DataTestMethod]
        [DynamicData(nameof(GetDataforDevisionOnScallarValue), DynamicDataSourceType.Method)]
        public void TestMethodDevisionVectorWithScalarExpectedRightVectorValues(Mathe3DVektoren u, double value, Mathe3DVektoren v)
        {

            var actualVector = Math3DVectorHelper.DevideVectorWithScalar(u, value);
            var expectedVector = v;
            Assert.AreEqual(expectedVector, actualVector);
        }

        private static IEnumerable<object[]> GetDataforDevisionOnScallarValue()
        {
            return new List<object[]>
            {

               new object[]{new Mathe3DVektoren() {X = 4, Y = 2, Z = -3}, 2 , new Mathe3DVektoren() { X = 2, Y = 1, Z = -1.5 } },
               new object[]{new Mathe3DVektoren() {X = -10, Y = 30, Z = 40}, 5 , new Mathe3DVektoren() { X = -2, Y = 6, Z = 8 } },
               new object[]{new Mathe3DVektoren() {X = 9, Y = 12, Z = 18}, 3 , new Mathe3DVektoren() { X = 3, Y = 4, Z = 6} },
               new object[]{new Mathe3DVektoren() {X = 0, Y = -5, Z = 6}, -2 , new Mathe3DVektoren() { X = 0, Y = 2.5, Z = -3} }
            };
        }
        #endregion


        #region Multiplication vector with scallar value test
        [DataTestMethod]
        [DataRow(4)]

        public void TestMethodMutiplicationVectorWithScalarExpectedRightVectorValues(double value)
        {
            var vector = new Mathe3DVektoren() { X = 2, Y = 3, Z = 4 };
            var actualVector = Math3DVectorHelper.MultiplicateVectorWithScalar(vector, value);
            var expectedVector = new Mathe3DVektoren() { X = 8, Y = 12, Z = 16 };
            Assert.AreEqual(expectedVector, actualVector);
        }
        #endregion


        #region Scallar product two vectors
        [DataTestMethod]
        [DynamicData(nameof(GetDataforScallarProductOnVectors), DynamicDataSourceType.Property)]
        public void TestMethodScallarProductTwoVectorsExpectedRightVectorValues(Mathe3DVektoren u, Mathe3DVektoren v, double expectedResult)
        {
            double actualResult = Math3DVectorHelper.ScalarProductTwoVectors(u, v);
            Assert.AreEqual(expectedResult, actualResult);
        }


        public static IEnumerable<object[]> GetDataforScallarProductOnVectors
        {
            get
            {
                return new List<object[]>
                {
                    new object[]{new Mathe3DVektoren() { X=2, Y=2, Z=2} , new Mathe3DVektoren() { X=2, Y=2, Z=2}, 12},
                    new object[]{new Mathe3DVektoren() { X=1, Y=2, Z=3} , new Mathe3DVektoren() { X=2, Y=3, Z=1}, 11},
                    new object[]{new Mathe3DVektoren() { X=0, Y=-3, Z=0} , new Mathe3DVektoren() { X=2, Y=2, Z=2}, -6},
                    new object[]{new Mathe3DVektoren() { X=-3, Y=-2, Z=-2} , new Mathe3DVektoren() { X=1, Y=5, Z=2.5}, -18},
                    new object[]{new Mathe3DVektoren() { X=20, Y=10, Z=-2} , new Mathe3DVektoren() { X=3, Y=2, Z=-4}, 88},
                };
            }
        }
        #endregion


        #region Cross product two vectors test
        [DataTestMethod]
        [DynamicData(nameof(GetDataforCrossProductTwoVectors), DynamicDataSourceType.Property)]
        public void TestMethodCrossProductTwoVectorsExpectedRightVectorValues(Mathe3DVektoren v, Mathe3DVektoren u, Mathe3DVektoren expectedVector)
        {
            var actualVector = Math3DVectorHelper.CrossProductTwoVectors(v, u);
            Assert.AreEqual(expectedVector, actualVector);
        }


        public static IEnumerable<object[]> GetDataforCrossProductTwoVectors
        {
            get
            {
                return new List<object[]>
                {
                    new object[]{new Mathe3DVektoren() { X=2, Y=2, Z=2} , new Mathe3DVektoren() { X=2, Y=2, Z=2}, new Mathe3DVektoren() { X=0, Y=0, Z=0}},
                    new object[]{new Mathe3DVektoren() { X=1, Y=2, Z=3} , new Mathe3DVektoren() { X=3, Y=2, Z=1}, new Mathe3DVektoren() { X=-4, Y=8, Z=-4}},
                    new object[]{new Mathe3DVektoren() { X=0, Y=-3, Z=0} , new Mathe3DVektoren() { X=2, Y=2, Z=2},new Mathe3DVektoren() { X=-6, Y=0, Z=6}},
                    new object[]{new Mathe3DVektoren() { X=-3, Y=-2, Z=-2} , new Mathe3DVektoren() { X=1, Y=5, Z=2.5}, new Mathe3DVektoren() { X=5, Y=5.5, Z=-13}},
                    new object[]{new Mathe3DVektoren() { X=20, Y=10, Z=2} , new Mathe3DVektoren() { X=3, Y=2, Z=4},new Mathe3DVektoren() { X=36, Y=-74, Z=10}},
                };
            }
        }
        #endregion


        #region Length of vector
        [DataTestMethod]
        [DynamicData(nameof(GetDataforLengthVector), DynamicDataSourceType.Property)]
        public void TestMethodLengthVectorExpectedRightValue(Mathe3DVektoren v, double expectedLength)
        {
            double actualLength = Math3DVectorHelper.LengthVector(v);
            Assert.AreEqual(expectedLength, actualLength);
        }

        /// <summary>
        /// We read this time from a text file that is localy found in this project
        /// line format in the our file.txt: X/Y/Z;magnitude => 2/2/-2;3.4641016151377544
        /// </summary>
        public static IEnumerable<object[]> GetDataforLengthVector
        {
            get
            {
                List<object[]> myList = new List<object[]>();
                var content = File.ReadAllLines(@"C:\Users\Ahmed\source\repos\Mathematik der 3D-Vektoren\Mathematik3DVektorenLib\DAL\VectorLength.txt");
                foreach (var line in content)
                {

                    var lineArray = line.Split(';');
                    double length = double.Parse(lineArray[1], CultureInfo.InvariantCulture);
                    var vectorPrintMember = lineArray[0];

                    var vectorMembers = vectorPrintMember.Split('/');
                    Mathe3DVektoren vector = new Mathe3DVektoren()
                    {
                        X = double.Parse(vectorMembers[0], CultureInfo.InvariantCulture),
                        Y = double.Parse(vectorMembers[1], CultureInfo.InvariantCulture),
                        Z = double.Parse(vectorMembers[2], CultureInfo.InvariantCulture)
                    };

                    myList.Add(new object[] { vector, length });
                }

                return myList;
            }
        }
        #endregion


        #region Angel between two vectors

        /// <summary>
        /// DynamicDataDisplayName ="This test must be succeeded!, all values are right checked manually or  through online calculator"
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="expectedResult"></param>
        [DataTestMethod]
        [DynamicData(nameof(GetDataforArcBetweenTwoVectors), DynamicDataSourceType.Property)]
        public void TestMethodAngelBetweenTwoVectorsExpectedRightValue(Mathe3DVektoren u, Mathe3DVektoren v, double expectedResult)
        {
            double actualResult = Math3DVectorHelper.AngelBetweenTwoVector(u, v);
            Assert.AreEqual(expectedResult, actualResult);
        }


        public static IEnumerable<object[]> GetDataforArcBetweenTwoVectors
        {
            get
            {
                return new List<object[]>
                {
                    new object[]{new Mathe3DVektoren() { X=5 , Y=-2 , Z=3} , new Mathe3DVektoren() { X=-4 , Y=5 , Z=7}, 98.852817147625106},
                    new object[]{new Mathe3DVektoren() { X=1 , Y=2 , Z=3} , new Mathe3DVektoren() { X=4 , Y=5 , Z=6}, 12.933154491899119},
                    new object[]{new Mathe3DVektoren() { X=2 , Y=-4 , Z=1} , new Mathe3DVektoren() { X=4 , Y=-8 , Z=2}, 0},
                    new object[]{new Mathe3DVektoren() { X=2 , Y=4 , Z=0} , new Mathe3DVektoren() { X=-2 , Y=-4 , Z=0}, 180},
                    new object[]{new Mathe3DVektoren() { X=2 , Y=-3 , Z=7} , new Mathe3DVektoren() { X=8 , Y=4 , Z=0}, 86.744066292740883}
                };
            }
        }
        #endregion


        #region Equality two vectors
        [DataTestMethod]
        [DynamicData(nameof(GetDataforEqualityTwoVectors), DynamicDataSourceType.Method)]
        public void TestMethodEqualityBetweenTwoVectorsExpectedRightValue(Mathe3DVektoren u, Mathe3DVektoren v, bool expectedResult)
        {
            bool actualResult = Math3DVectorHelper.IsEqualTwoVectors(u, v);
            Assert.AreEqual(expectedResult, actualResult);
        }


        public static IEnumerable<object[]> GetDataforEqualityTwoVectors()
        {
                return new List<object[]>
                {
                    new object[]{new Mathe3DVektoren() { X=5 , Y=-2 , Z=3} , new Mathe3DVektoren() { X=5 , Y=-2 , Z=3}, true},
                    new object[]{new Mathe3DVektoren() { X=1 , Y=2 , Z=3} , new Mathe3DVektoren() { X=4 , Y=5 , Z=6}, false},
                    new object[]{new Mathe3DVektoren() { X=2 , Y=-4 , Z=1} , new Mathe3DVektoren() { X=4 , Y=-8 , Z=2}, false},
                    new object[]{new Mathe3DVektoren() { X=2 , Y=4 , Z=0} , new Mathe3DVektoren() { X=2 , Y=4 , Z=-0}, true},
                    new object[]{new Mathe3DVektoren() { X=2 , Y=-3 , Z=7} , new Mathe3DVektoren() { X=8 , Y=4 , Z=0}, false}
                };
        }

        #endregion
    }


}