using IPCalculator;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class AddressTests
    {
        [Test]
        public void AddressEqualAnotherAddressReturnsCorrectResult()
        {
            Address A = new Address("192.168.1.12");
            Address B = new Address("192.168.1.12");
            Address C = new Address("255.255.0.0");
            if (!(A == B)) Assert.Fail();
            if (A == C) Assert.Fail();
        }
        [Test]
        public void AddressNotEqualAnotherAddressReturnsCorrectResult()
        {
            Address A = new Address("192.168.1.12");
            Address B = new Address("255.255.0.0");
            Address C = new Address("192.168.1.12");
            if (!(A != B)) Assert.Fail();
            if (A != C) Assert.Fail();
        }
        [Test]
        public void AddressBitwiseOrReturnsCorrectResult()
        {
            Address A = new Address("192.168.1.12");
            Address B = new Address("255.255.0.0");
            Address Result = new Address("255.255.1.12");
            if ((A | B) != Result) Assert.Fail();
        }
        [Test]
        public void AddressBitwiseReverseReturnsCorrectResult()
        {
            Address A = new Address("192.168.1.12");
            Address Result = new Address("63.87.254.243");
            if (~A != Result) Assert.Fail();
        }
        [Test]
        public void AddressBitwiseAndReturnsCorrectResult()
        {
            Address A = new Address("192.168.1.12");
            Address B = new Address("255.255.0.0");
            Address Result = new Address("192.168.0.0");
            if ((A & B) != Result) Assert.Fail();
        }
        [Test]
        [TestCase("192.134.54.hdhf33")]
        [TestCase("dsd3hdhf33")]
        [TestCase("192.134.54.34.45")]
        [TestCase("192.134.54")]
        [TestCase("192.134.54.540")]
        public void CreateAddressWithWrongFormatRaiseException(string testcase)
        {
            try
            {
                new Address(testcase);
                Assert.Fail();
            }
            catch (System.Exception)
            { }
        }
        [Test]
        [TestCase("192.134.54.40", ExpectedResult = 3230021160)]
        public uint GetRawIntReturnsCorrectValue(string testcase)
        {
            Address addr = new Address(testcase);
            return addr.RawInt;
        }
        [Test]
        [TestCase(3230021160)]
        public void CreateAddressFromRawIntCreatesCorrectAddress(uint testcase)
        {
            try
            {
                Address address = new Address(testcase);
                Assert.IsTrue(address == new Address("192.134.54.40"));
            }
            catch (System.Exception)
            {

                Assert.Fail();
            }
        }
        [Test]
        [TestCase("192.168.1.0", 25, ExpectedResult = "192.168.1.128")]
        [TestCase("192.168.168.252", 31, ExpectedResult = "192.168.168.254")]
        [TestCase("196.168.168.252", 6, ExpectedResult = "192.168.168.252")]
        public string AddressInvertBitReturnsCorrectResult(string testcase, int position)
        {
            return Address.InvertBit(new Address(testcase), position).ToString();
        }
    }
}
