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
    [TestFixture]
    public class NetTests
    {
        [Test]
        [TestCase(-4)]
        [TestCase(34)]
        public void CreateNetThrowsExceptionWhenIncorrectMaskSpecified(int mask)
        {
            try
            {
                Address address = new Address("192.168.3.2");
                Net net = new Net(address, mask);
                Assert.Fail();
            }
            catch (System.Exception)
            { }
        }
        [Test]
        [TestCase("192.134.54.hdhf33")]
        [TestCase("dsd3hdhf33")]
        [TestCase("192.134.54.34/45")]
        [TestCase("192.134.54.34/-1")]
        [TestCase("192.134.54")]
        [TestCase("192.134.54.540/12")]
        public void CreateNetWithWrongFormatRaiseException(string testcase)
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
        [TestCase("192.168.1.0/24", ExpectedResult = "255.255.255.0")]
        [TestCase("192.168.1.0/8", ExpectedResult = "255.0.0.0")]
        [TestCase("192.168.1.0/30", ExpectedResult = "255.255.255.252")]
        public string GetFullMaskReturnCorrectResult(string tescase)
        {
            Net net = new Net(tescase);
            return net.FullMask.ToString();
        }
        [Test]
        [TestCase("192.168.1.0/24", ExpectedResult = "192.168.1.1")]
        [TestCase("192.168.1.0/8", ExpectedResult = "192.0.0.1")]
        [TestCase("192.168.1.0/30", ExpectedResult = "192.168.1.1")]
        public string GetStartAddressReturnCorrectResult(string tescase)
        {
            Net net = new Net(tescase);
            return net.StartAddress.ToString();
        }
        [Test]
        [TestCase("192.168.1.0/24", ExpectedResult = "192.168.1.254")]
        [TestCase("192.168.1.0/8", ExpectedResult = "192.255.255.254")]
        [TestCase("192.168.1.0/30", ExpectedResult = "192.168.1.2")]
        public string GetEndAddressReturnCorrectResult(string tescase)
        {
            Net net = new Net(tescase);
            return net.EndAddress.ToString();
        }
        [Test]
        [TestCase("192.168.1.0/24", ExpectedResult = "192.168.1.255")]
        [TestCase("192.168.1.0/8", ExpectedResult = "192.255.255.255")]
        [TestCase("192.168.1.0/30", ExpectedResult = "192.168.1.3")]
        public string GetBroadcastAddressReturnCorrectResult(string tescase)
        {
            Net net = new Net(tescase);
            return net.BroadcastAddress.ToString();
        }
        [Test]
        [TestCase("192.168.1.0/24", ExpectedResult = "0.0.0.255")]
        [TestCase("192.168.1.0/8", ExpectedResult = "0.255.255.255")]
        [TestCase("192.168.1.0/30", ExpectedResult = "0.0.0.3")]
        public string GetWildcardReturnCorrectResult(string tescase)
        {
            Net net = new Net(tescase);
            return net.Wildcard.ToString();
        }
        [Test]
        [TestCase("192.168.1.0/24", ExpectedResult = 254)]
        [TestCase("192.168.1.0/8", ExpectedResult = 16777214)]
        [TestCase("192.168.1.0/30", ExpectedResult = 2)]
        public int GetHostAmReturnCorrectResult(string tescase)
        {
            Net net = new Net(tescase);
            return net.HostAm;
        }

    }

}