using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTests
{
    [TestClass]
    public class Movies
    {
        [TestMethod]
        public void GetMovieSequence()
        {
            //Arrange
            var movieLengths = new int[] { 30, 40, 50, 80, 80,20,70 };
            int flightLength = 180;
           
            //Act
            // Get movie sequence equal to flight Length

            var actual = GetMovieSequence(movieLengths, flightLength);
            //Assert
            var expected = new List<int>();
            expected.Add(80);
            expected.Add(80);
            expected.Add(20);
            
            Assert.IsTrue(CompareLists<int>(actual, expected));
            
             movieLengths = new int[] { 180, 40, 50, 80,50,70, 80 };
             flightLength = 200;
           
            //Act
            // Get movie sequence equal to flight Length

             actual = GetMovieSequence(movieLengths, flightLength);
            //Assert
             expected = new List<int>();
            expected.Add(80);
            expected.Add(50);
            expected.Add(70);
            
            Assert.IsTrue(CompareLists<int>(actual, expected));
            
            
            movieLengths = new int[] { 180, 40, 50, 80,70,70, 80 };
             flightLength = 240;
           
            //Act
            // Get movie sequence equal to flight Length

             actual = GetMovieSequence(movieLengths, flightLength);
            //Assert
             expected = new List<int>();
            expected.Add(40);
            expected.Add(50);
            expected.Add(80);
            expected.Add(70);
            
            Assert.IsTrue(CompareLists<int>(actual, expected));



        }

        private List<int> GetMovieSequence(int[] movieLengths, int flightLength)
        {
            int totalMovieLength = 0;
            List<int> result = new List<int>();
            for (int i = 0;i<movieLengths.Length;i++)
            {
                totalMovieLength += movieLengths[i];
                if (totalMovieLength < flightLength)
                    result.Add(movieLengths[i]);
                else if (totalMovieLength > flightLength)
                {
                    result.Clear();
                    totalMovieLength = movieLengths[i-1];
                    totalMovieLength += movieLengths[i];
                    result.Add(movieLengths[i-1]);
                    result.Add(movieLengths[i]);
                }
                else if (totalMovieLength == flightLength)
                {
                    result.Add(movieLengths[i]);
                    break;
                }
            }
            return result;
        }

        static bool CompareLists<T>(List<T> list1, List<T> list2)
        {
            // Check if the lists have the same number of elements
            if (list1.Count != list2.Count)
            {
                return false;
            }

            // Compare each element of the lists
            for (int i = 0; i < list1.Count; i++)
            {
                if (!list1[i].Equals(list2[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
