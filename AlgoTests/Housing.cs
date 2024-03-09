using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTests
{
    [TestClass]
    public class Housing
    {
        [TestMethod]
        public void GetInhabitants()
        {
            //Arrange
            var grid = new Dictionary<int, Dictionary<int, int>>();
            var inhabitants = new int[] { 3, 2, 4, 2, 3, 2, 3 };
            var houses = new Dictionary<int, int>();
            //populate grid
            for (int i = 1; i <= 4; i++)
            {
                houses = new Dictionary<int, int>();

                for (int j = 1; j <= 7; j++)
                {
                    int key = 0;
                    if (grid.Any())
                    {
                        key = grid.Max(a => a.Value.Max(b => b.Key)) + j;
                    }
                    else
                        key = j;

                    houses.Add(key, inhabitants[j - 1]);
                }
                grid.Add(i, houses);

            }
            var result = GetNeighbours(grid, 11);
            Assert.AreEqual(result, 25);
            Assert.AreEqual(GetNeighbours(grid,4), 16);
            Assert.AreEqual(GetNeighbours(grid,25), 16);

        }
        public static int GetNeighbours(Dictionary<int, Dictionary<int, int>> map, int houseNum)
        {
            //e.g.Neighbors of House# 11: 3,4,5,10,12,17,18,19
            //Neighbors of House# 26: 18,19,20, 25, 27
            int neighbours = 0;
            int numRows = map.Count();//4
            int numHousesPerRow = map.Values.FirstOrDefault().Keys.Count(); //7
            int numHouses = numRows * numHousesPerRow; //28
            int rowNum = 0;
            for (int i = 1; i <= map.Count(); i++)// each ( var item in map)
            {
                if (map[i].ContainsKey(houseNum))
                {
                    rowNum = i;
                    neighbours = GetTotal(map, houseNum, rowNum, numHousesPerRow);
                    break;
                }
            }
            return neighbours;

        }
        private static int GetTotal(Dictionary<int, Dictionary<int, int>> map, int houseNum, int rowNum, int numHousesPerRow)
        {
            var numInhabitants = new List<int>();

            //upper Row
            if (rowNum > 1)
            {
                int start = (houseNum - (numHousesPerRow + 1));
                int end = (houseNum - (numHousesPerRow - 1));
                for (int i = start; i <= end; i++)
                {
                    numInhabitants.Add(map[rowNum - 1][i]);
                }
            }
            // current Row
            numInhabitants.Add(map[rowNum][houseNum - 1]);
            numInhabitants.Add(map[rowNum][houseNum + 1]);
           
            //lower Row
            if (rowNum < map.Count() - 1)
            {
                for (int i = (houseNum + (numHousesPerRow - 1)); i <= (houseNum + (numHousesPerRow + 1)); i++)
                {
                    numInhabitants.Add(map[rowNum + 1][i]);
                }
            }
            return numInhabitants.Sum();


        }


    }
}
