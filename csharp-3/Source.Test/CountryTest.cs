using System;
using Xunit;

namespace Codenation.Challenge
{
    public class CountryTest
    {

        [Fact]
        public void Should_Return_10_Itens_When_Get_Top_10_States()
        {            
            var states = new Country();
            var top = states.Top10StatesByArea();
            Assert.NotNull(top);
            Assert.Equal(10, top.Length);
        }

        [Fact]
        public void verifyStates()
        {
            var states = new Country();
            State[] testStates = states.Top10StatesByArea();
            Assert.Equal("AM", testStates[0].Acronym);
            Assert.Equal("PA", testStates[1].Acronym);
            Assert.Equal("MT", testStates[2].Acronym);
            Assert.Equal("MG", testStates[3].Acronym);
            Assert.Equal("BA", testStates[4].Acronym);
            Assert.Equal("MS", testStates[5].Acronym);
            Assert.Equal("GO", testStates[6].Acronym);
            Assert.Equal("MA", testStates[7].Acronym);
            Assert.Equal("RS", testStates[8].Acronym);
            Assert.Equal("TO", testStates[9].Acronym);

        }
    }
}
