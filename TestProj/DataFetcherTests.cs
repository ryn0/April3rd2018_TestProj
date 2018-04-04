using April3rd2018_TestProj;
using Xunit;

namespace TestProj
{
    public class DataFetcherTests
    {
        [Theory]
        [InlineData(201, "ParentCategoryID=200, Name=Computer, Keywords=Teaching")]
        [InlineData(202, "ParentCategoryID=201, Name=Operating System, Keywords=Teaching")]
        public void CanGetCategoryIdResult(int input, string expectedOutput)
        {
            var dataFetcher = new DataFetcher();

            var output = dataFetcher.FetchResult(input);

            Assert.Equal(expectedOutput, output);
        }

        [Theory]
        [InlineData(2, "101, 102, 201")]
        [InlineData(3, "103, 109, 202")]
        public void CanGetIdsOfLevelsDeep(int input, string expectedOutput)
        {
            var dataFetcher = new DataFetcher();

            var output = dataFetcher.FetchResult(input);

            Assert.Equal(expectedOutput, output);
        }
    }
}

