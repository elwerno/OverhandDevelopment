using System;
using Xunit;

namespace TcpBrokerTest.Tests
{
    public class ParseTests
    {
        [Fact]
        public void Should_Do_The_Parsing_Correctly()
        {
            // string data = "20021625500400100168711625414518422002162550040050168711625414418422002162550040000158711625414418322002162550035000160711525414418322002162550040000168711625414418422002162550044060174711625414418422002162550040010016071162541451832200216255003401001607115254145183220021625500360160161711525414518322002162550046020016571162541461832";
            byte[] input = { 0x20, 0x02};

            // define expected output
            short expected = 1; // todo define this correctly

            // get actual value
            short actual = ParseBytes(input);

            // assertion
            Assert.Equal(expected, actual);
        }

        public short ParseBytes(byte[] bytesToParse)
        {
            // todo PARSE
            return 0;
        }
    }
}
