using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCalculator
{
    sealed public class Address
    {
        private byte[] Bytes;
        public Address(byte oct1, byte oct2, byte oct3, byte oct4)
        {
            Bytes = new byte[] { oct1, oct2, oct3, oct4 };
        }
        public Address()
        {
            Bytes = new byte[4];
        }
        public Address(Address add)
        {
            Bytes = new byte[] { add.Bytes[0], add.Bytes[1], add.Bytes[2], add.Bytes[3] };
        }
        public Address(string address)
        {
            try
            {
                string[] Elements = address.Split('.');
                if (Elements.Length != 4) throw new ArgumentException("Недопустимый формат адреса"); //TODO: language
                else
                {
                    Bytes = new byte[] { Convert.ToByte(Elements[0]), Convert.ToByte(Elements[1]), Convert.ToByte(Elements[2]), Convert.ToByte(Elements[3]) };
                }
            }
            catch(ArgumentException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new ArgumentException("Недопустимый формат адреса: " + ex.Message);
            }
        }
        public byte this[int index]
        {
            get
            {
                return Bytes[index];
            }
            set
            {
                Bytes[index] = value;
            }
        }
        public static Address operator &(Address A, Address B)
        {
            Address Res = new Address();
            for (int i = 0; i < 4; ++i)
            {
                Res[i] = (byte)(A[i] & B[i]);
            }
            return Res;
        }
        public static Address operator |(Address A, Address B)
        {
            Address Res = new Address();
            for (int i = 0; i < 4; ++i)
            {
                Res[i] = (byte)(A[i] | B[i]);
            }
            return Res;
        }
        public static Address operator ~(Address A)
        {
            Address Inverted = new Address();
            for (int i = 0; i < 4; ++i)
            {
                Inverted[i] = (byte)~A[i];
            }
            return Inverted;
        }
        public static bool operator ==(Address A, Address B)
        {
            for (int i = 0; i < 4; ++i)
            {
                if (A[i] != B[i]) return false;
            }
            return true;
        }
        public static bool operator !=(Address A, Address B)
        {
            for (int i = 0; i < 4; ++i)
            {
                if (A[i] != B[i]) return true;
            }
            return false;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Address add = obj as Address;
            if (this == add) return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return Convert.ToString(Bytes[0]) + "." + Convert.ToString(Bytes[1]) + "." + Convert.ToString(Bytes[2]) + "." + Convert.ToString(Bytes[3]);
        }
    }
}
