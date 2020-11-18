using System;
using Xunit;
using HeroesLib;

namespace HeroesTest
{
    public class HeroTest
    {
        /*
        [Fact] //fact attribute signifies a single-input test
        public void AddSuperPowerShouldAddSuperPower() //method names should be verbose
        {
            //Arrange --> arranging artifacts that I might need
            string superPower = "Unit testing god";
            Hero testHero = new Hero();

            //Act --> do the thing you want to test
            testHero.AddSuperPower(superPower);

            //Assert --> verify that what you wanted to happen actually happened
            Assert.Equal(superPower, testHero.superPowers.Peek());
        }*/

        Hero testHero = new Hero();
        [Theory] //attribute that allows multiple inputs for a single test
        [InlineData("Unit testing god")] //this an input
        [InlineData("Flying")]
        [InlineData("Laser eyes")]
        public void AddSuperPowerShouldAddSuperPower(string superPower) //this parameter accepts the InlineData
        {
            //Act --> do the thing you want to test
            testHero.AddSuperPower(superPower);

            //Assert --> verify that what you wanted to happen actually happened
            Assert.Equal(superPower, testHero.superPowers.Peek());
        }

        [Theory]
        [InlineData("")] 
        [InlineData(null)]
        public void AddSuperPowerShouldThrowArgumentException(string superPower)
        {
            //testing for "failure"
            Assert.Throws<ArgumentException>(() => testHero.AddSuperPower(superPower)); //lambda expression
        }
    }
}
