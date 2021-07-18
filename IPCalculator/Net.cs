using System;
namespace IPCalculator
{
    sealed public class Net
    {
        public Address Address { get; private set; }
        public int Mask { get; private set; }
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
        public Address StartAddress
        {
            get
            {
                Address Min = new Address(Address);
                Min[3] += 1;
                return Min;
            }
        }
        public Address EndAddress
        {
            get
            {
                Address Max = new Address(BroadcastAddress);
                Max[3] -= 1;
                return Max;
            }
        }
        public Address BroadcastAddress
        {
            get
            {
                return Address | ReverseMask;
            }
        }
        public Address ReverseMask
        {
            get
            {
                return ~FullMask;
            }
        }
        public int HostAm
        {
            get
            {
                return (int)Math.Pow(2, 32 - Mask) - 2;
            }
        }
        public Net(Address address, int mask)
        {
            if(mask < 1 || mask > 30) throw new ArgumentException("Неверно задана маска сети"); //TODO
            Address = address;
            Mask = mask;
            Address = Address & FullMask; //in case input is not the net address
        }
        public Net(string net)
        {
            try
            {
                string[] elements = net.Split('/');
                Address = new Address(elements[0]);
                Mask = System.Convert.ToInt32(elements[1]);
                if (Mask < 1 || Mask > 30) throw new ArgumentException("Неверно задана маска сети"); //TODO
                Address = Address & FullMask; //in case input is not the net address
            }
            catch(ArgumentException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new ArgumentException("Неверно задана маска сети: " + ex.Message);
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
            if (this.Address.Equals(net.Address) && this.Mask == net.Mask) return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
