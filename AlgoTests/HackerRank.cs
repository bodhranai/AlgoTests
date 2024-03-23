using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AlgoTests
{
    [TestClass]
    public class HackerRank
    {
        [TestMethod]
        public void isBalanced()
        {
            //Arrange
            var output = string.Empty;
            //Act
            var str1 = "{[()]}";
            var str2 = "{[(])}";
            var str3 = "{{[[(())]]}}";

            //Assert
            Assert.AreEqual(checkForBalancedString(str1),"YES");
            Assert.AreEqual(checkForBalancedString(str2),"NO");
            Assert.AreEqual(checkForBalancedString(str3),"YES");
            
        }

        [TestMethod]
        public void LegoBlocks()
        {
            
        }


        private string checkForBalancedString(string s)
        {
            var brackets = new Dictionary<char, char>();
            brackets.Add('{', '}');
            brackets.Add('(', ')');
            brackets.Add('[', ']');
            Stack<char> matchingBraces = new Stack<char>();
            var strArr = s.ToCharArray();

            for (int i = 0;i<s.Length;i++)
            {
                if (brackets.ContainsKey(strArr[i]))
                {
                    var matchingBrace = brackets[strArr[i]];
                    matchingBraces.Push(matchingBrace);
                }

                else if (brackets.Values.Contains(strArr[i]))
                {
                    if (matchingBraces.Count() == 0 || matchingBraces.Pop() != strArr[i])
                        return "NO";
                }
            }
            return matchingBraces.Count() > 0 ? "NO" : "YES";


        }

    }
}
