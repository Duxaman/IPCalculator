using System;
using Newtonsoft.Json;
namespace IPCalculator
{
    [JsonObject]
    sealed public class Net
    {
        [JsonProperty]
        public Address Address { get; private set; }
        [JsonProperty]
        public int Mask { get; private set; }
        [JsonIgnore]
        public Address FullMask
        {
            get
            {
                int Bitmask = Mask;
                Address FullMask = new Address();
                for (int i = 0; (i < 4) && (Bitmask != 0); ++i)
                {
                    for (int j = 0; j < 8; ++j)
                    {
                        FullMask[i] *= 2;
                        if (Bitmask != 0) FullMask[i] += 1;
                        else continue;
                        --Bitmask;
                    }
                }
                return FullMask;
            }
        }
        [JsonIgnore]
        public Address StartAddress
        {
            get
            {
                Address Min = new Address(Address);
                Min[3] += 1;
                return Min;
            }
        }
        [JsonIgnore]
        public Address EndAddress
        {
            get
            {
                Address Max = new Address(BroadcastAddress);
                Max[3] -= 1;
                return Max;
            }
        }
        [JsonIgnore]
        public Address BroadcastAddress
        {
            get
            {
                return Address | Wildcard;
            }
        }
        [JsonIgnore]
        public Address Wildcard
        {
            get
            {
                return ~FullMask;
            }
        }
        [JsonIgnore]
        public int HostAm
        {
            get
            {
                return (int)Math.Pow(2, 32 - Mask) - 2;
            }
        }
        [JsonConstructor]
        public Net(Address Address, int Mask)
        {
            if(Mask < 0 || Mask > 30) throw new ArgumentException("Incorrect subnet mask specified ");
            this.Address = Address;
            this.Mask = Mask;
            Address = Address & FullMask; //in case input is not the net address
        }
        public Net(string net)
        {
            try
            {
                string[] elements = net.Trim().Split('/');
                Address = new Address(elements[0]);
                Mask = System.Convert.ToInt32(elements[1]);
                if (Mask < 0 || Mask > 30) throw new ArgumentException("Incorrect subnet mask specified ");
                Address = Address & FullMask; //in case input is not the net address
            }
            catch(ArgumentException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new ArgumentException("Incorrect subnet mask specified " +  " " + ex.Message);
            }
        }
        public override string ToString()
        {
            return Address.ToString() + "/" + Mask.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Net net = obj as Net;
            if (net == null)
            {
                return false;
            }
            if (this.Address.Equals(net.Address) && this.Mask == net.Mask) return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
