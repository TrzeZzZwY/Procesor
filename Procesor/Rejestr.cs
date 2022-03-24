using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Procesor
{
    public class Rejestr
    {
        private string _name;
        public string Name { get => _name; set => _name = (value.Length == 2 && Regex.IsMatch(value, @"^[a-zA-Z]+$")) ? value.ToUpper() : throw new ArgumentException("Nazwa rejestru powinna być 2 literowa"); }

        private byte _value;
        public string Value { get => _value.ToString("x2").ToUpper(); set => _value = Byte.Parse(value); }
        public Rejestr(string name, int value = 0)
        {
            Name = name.ToUpper();
            Value = value.ToString();
        }
        public override string ToString() => $"Name: {Name}\tValue: {Value} ";
        public static Rejestr operator +(Rejestr a, int b) => new Rejestr(a.Name, (byte)((Convert.ToByte(a.Value, 16) + b)));
        public static Rejestr operator +(Rejestr a, Rejestr b) => new Rejestr(a.Name, (byte)(Convert.ToByte(a.Value, 16) + Convert.ToByte(b.Value, 16)));
        public static Rejestr operator -(Rejestr a, int b) => new Rejestr(a.Name, (byte)((Convert.ToByte(a.Value, 16) - b)));
        public static Rejestr operator -(Rejestr a, Rejestr b) => new Rejestr(a.Name, (byte)(Convert.ToByte(a.Value, 16) - Convert.ToByte(b.Value, 16)));
        public static Rejestr operator ~(Rejestr a) => new Rejestr(a.Name, (byte)~((Convert.ToByte(a.Value, 16) )));
        public static Rejestr operator &(Rejestr a, Rejestr b) => new Rejestr(a.Name, (byte)(Convert.ToByte(a.Value, 16) & Convert.ToByte(b.Value, 16)));
        public static Rejestr operator |(Rejestr a, Rejestr b) => new Rejestr(a.Name, (byte)(Convert.ToByte(a.Value, 16) | Convert.ToByte(b.Value, 16)));
        public static Rejestr operator ^(Rejestr a, Rejestr b) => new Rejestr(a.Name, (byte)(Convert.ToByte(a.Value, 16) ^ Convert.ToByte(b.Value, 16)));

        public static void MOV(Rejestr a, Rejestr b) => a._value = b._value;
        public static void XCHG(Rejestr a, Rejestr b)
        {
            var temp = a._value;
            a._value = b._value;
            b._value = temp;
        }
        public static void INC(ref Rejestr a) => a += 1;
        public static void DEC(ref Rejestr a) => a -= 1;
        public static void NOT(ref Rejestr a) => a = ~a;
        public static void NEG(ref Rejestr a) => a = (~a)+1;
        public static void ADD(ref Rejestr a, Rejestr b) => a += b;
        public static void SUB(ref Rejestr a, Rejestr b) => a -= b;
        public static void AND(ref Rejestr a, Rejestr b) => a &= b;
        public static void OR(ref Rejestr a, Rejestr b) => a |= b;
        public static void XOR(ref Rejestr a, Rejestr b) => a ^= b;
    }
}
