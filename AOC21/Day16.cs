using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC21
{
    public class Day16
    {
        public static int SolvePart1(string input)
        {
            string binary = HexToBinary(input);

            var (packet, _) = ParsePacket(binary);

            return packet.SumVersionNumbers();
        }

        public static long SolvePart2(string input)
        {
            string binary = HexToBinary(input);

            var (packet, _) = ParsePacket(binary);

            return packet.Compute();
        }

        private static string HexToBinary(string input)
        {
            var binaryList = input
                .Select(s => {
                    return Convert.ToString(Convert.ToInt32(s.ToString(), 16), 2).PadLeft(4, '0');
                });
            return string.Join("", binaryList);
        }

        private static (LiteralPacket, string) ParseLiteral(string binaryStr, int version, int typeID)
        {
            string number = "";

            while (true)
            {
                var group = binaryStr.Take(5).ToList();
                number += string.Join("", group.Skip(1));
                binaryStr = binaryStr[5..];

                if (group[0] == '0')
                {
                    break;
                }
            }

            var literalPacket = new LiteralPacket
            {
                Version = version,
                TypeID = typeID,
                Literal = Convert.ToInt64(number, 2)
            };

            return (literalPacket, binaryStr);
        }

        private static (OperatorPacket, string) ParseOperator(string binaryStr, int version, int typeID)
        {
            LengthType lengthType = binaryStr[0] == '0' ? LengthType.TotalLength : LengthType.SubPackets;
            binaryStr = binaryStr[1..];

            var subPackets = new List<Packet>();

            if (lengthType == LengthType.TotalLength)
            {
                long totalLength = GetTotalLength(binaryStr);
                binaryStr = binaryStr[15..];

                while (totalLength > 0)
                {
                    var (subPacket, newBinaryStr) = ParsePacket(binaryStr);
                    totalLength -= (binaryStr.Length - newBinaryStr.Length);
                    binaryStr = newBinaryStr;
                    subPackets.Add(subPacket);
                }
            } else
            {
                long numSubPackets = GetNumSubPackets(binaryStr);
                binaryStr = binaryStr[11..];

                for (int i = 0; i < numSubPackets; i++)
                {
                    var (subPacket, newBinaryStr) = ParsePacket(binaryStr);
                    binaryStr = newBinaryStr;
                    subPackets.Add(subPacket);
                }
            }

            var operatorPacket = new OperatorPacket
            {
                Version = version,
                TypeID = typeID,
                SubPackets = subPackets
            };

            return (operatorPacket, binaryStr);
        }

        private static long GetTotalLength(string binaryStr)
        {
            return Convert.ToInt64(string.Join("", binaryStr.Take(15)), 2);
        }

        private static long GetNumSubPackets(string binaryStr)
        {
            return Convert.ToInt64(string.Join("", binaryStr.Take(11)), 2);
        }

        private static (Packet, string) ParsePacket(string binaryStr)
        {
            int version = Convert.ToInt32(string.Join("", binaryStr.Take(3)), 2);
            binaryStr = binaryStr[3..];
            int typeID = Convert.ToInt32(string.Join("", binaryStr.Take(3)), 2);
            binaryStr = binaryStr[3..];

            if (typeID == 4)
            {
                return ParseLiteral(binaryStr, version, typeID);
            } else
            {
                return ParseOperator(binaryStr, version, typeID);
            }
        }

        private abstract class Packet
        {
            public int Version { get; set; }
            public int TypeID { get; set; }
            public abstract int SumVersionNumbers();
            public abstract long Compute();
        }

        private class OperatorPacket : Packet
        {
            public List<Packet> SubPackets { get; set; } = new List<Packet>();
            public LengthType LengthType { get; set; }

            public override long Compute()
            {
                return TypeID switch
                {
                    0 => SubPackets.Select(p => p.Compute()).Sum(),
                    1 => SubPackets.Aggregate((long)1, (acc, curr) => acc * curr.Compute()),
                    2 => SubPackets.Select(p => p.Compute()).Min(),
                    3 => SubPackets.Select(p => p.Compute()).Max(),
                    5 => SubPackets[0].Compute() > SubPackets[1].Compute() ? 1 : 0,
                    6 => SubPackets[0].Compute() < SubPackets[1].Compute() ? 1 : 0,
                    7 => SubPackets[0].Compute() == SubPackets[1].Compute() ? 1 : 0,
                    _ => throw new Exception("Unrecognized packet type")
                };
            }

            public override int SumVersionNumbers()
            {
                return SubPackets.Aggregate(Version, (acc, curr) => acc + curr.SumVersionNumbers());
            }
        }

        private class LiteralPacket : Packet
        {
            public long Literal { get; set; }

            public override long Compute()
            {
                return Literal;
            }

            public override int SumVersionNumbers()
            {
                return Version;
            }
        }

        private enum LengthType
        {
            TotalLength,
            SubPackets
        }
    }
}
