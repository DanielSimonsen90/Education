using System;
using System.Text;

namespace NetworkCalc
{
    class NetworkCalc
    {
        public static readonly int[] BinaryNumbers = { 128, 64, 32, 16, 8, 4, 2, 1 };
        static int[] IPArray;

        public static void Run()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter IP: ");
                    string Input = Console.ReadLine();

                    IPArray = ConvertToIP(Input);
                    string BinaryIP = IPToBinary(new int[] { IPArray[0], IPArray[1], IPArray[2], IPArray[3] }),
                        Mask = CalcBinaryPrefix(IPArray[4], IPArray[0], out string Class),
                        NetworkName = GetNetworkName(BinaryIP, Mask);

                    ShowUI(BinaryIP, Mask, NetworkName, Class);
                }
                catch
                {
                    Console.Write("Please provide a valid IP address.");
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
        /// <summary>
        /// Shows the User Interface for result
        /// </summary>
        /// <param name="BinaryIP">IP in Binary</param>
        /// <param name="Mask">Mask in Binary</param>
        /// <param name="NetworkName">Hostname in Binary</param>
        /// <param name="Class">Class of IP</param>
        private static void ShowUI(string BinaryIP, string Mask, string NetworkName, string Class)
        {
            Console.Clear();
            string IP = "";
            for (int x = 0; x < 4; x++)
                if (x != 3)
                    IP += $"{IPArray[x]}.";
                else
                    IP += $"{IPArray[3]}/{IPArray[4]}";

            string HostIP = ConvertToNormal(NetworkName), Format = "{0, -20}{1, 0}";

            Console.WriteLine(Format, "IP ADDRESS:", $"{IP}, {Class}");
            Console.WriteLine(Format, "BINARY:", $"{BinaryIP}");
            Console.WriteLine(Format, "MASK BINARY:", $"{Mask}");
            Console.WriteLine("{0,-20}", "--------------------------");
            Console.WriteLine(Format, "NETWORKNAME BINARY:", $"{NetworkName}");
            Console.WriteLine();
            Console.WriteLine(Format, "NETWORKNAME:", $"{HostIP}");
        }

        /// <summary>
        /// Convert to normal numbers
        /// </summary>
        /// <param name="NetworkName">Hostname in binary</param>
        /// <returns>Hostname in normal numbers</returns>
        public static string ConvertToNormal(string NetworkName)
        {
            var SplitHost = NetworkName.Split('.');
            string output = "";
            foreach (string Segment in SplitHost)
                output += $"{Convert.ToInt32(Segment, 2).ToString()}.";
            output = output.Substring(0, output.Length - 1);
            return output;
        }
        /// <summary>
        /// Convert to normal numbers
        /// </summary>
        /// <param name="NetworkName">Hostname in binary</param>
        /// <param name="Class"></param>
        /// <returns>Hostname in normal numbers</returns>
        public static string ConvertToNormal(string NetworkName, string Class)
        {
            var SplitHost = NetworkName.Split('.');
            string output = "";
            int SegmentCycle = (Class == "A") ? 1 : (Class == "B") ? 2 : 3;
            for (int x = 0; x < SegmentCycle; x++)
                output += $"{Convert.ToInt32(SplitHost[x], 2).ToString()}.";
            return (SegmentCycle == 3) ? output.Substring(0, output.Length - 1) : output;
        }

        /// <summary>
        /// Uses ANDing system to get the binary version of Hostname
        /// </summary>
        /// <param name="BinaryIP"></param>
        /// <param name="SubnetMask"></param>
        /// <returns></returns>
        public static string GetNetworkName(string BinaryIP, string SubnetMask)
        {
            string ANDingResult = "";

            for (int x = 0; x < BinaryIP.Length; x++)
                ANDingResult += (BinaryIP[x] == '1' && BinaryIP[x] == SubnetMask[x]) ? "1" :
                                (BinaryIP[x] == '.' && BinaryIP[x] == SubnetMask[x]) ? "." : "0";
            return ANDingResult;
        }

        /// <summary>
        /// Calculates the /<paramref name="PrefixNumber"/> into i.e. 11111111.11111111.11111111.00000000
        /// </summary>
        /// <param name="PrefixNumber">/number of IP</param>
        /// <returns>Subnetmask in binary</returns>
        public static string CalcBinaryPrefix(int PrefixNumber, int BinaryIP, out string Class)
        {
            string result = "";
            if (PrefixNumber == 0)
            {
                PrefixNumber = (BinaryIP < 128) ? 8 : (BinaryIP < 192) ? 16 : (BinaryIP < 224) ? 24 : 32;
                IPArray[4] = PrefixNumber;
            }
            else if (PrefixNumber > 32 || BinaryIP == 0 || BinaryIP == 127)
                throw new Exception();
            Class = (BinaryIP < 128) ? "A" : (BinaryIP < 192) ? "B" : (BinaryIP < 224) ? "C" : "D";


            int PeriCount = 0;
            for (int x = 0; x < 32; x++)
            {
                if (PeriCount / 8 == 1)
                {
                    result += ".";
                    PeriCount = 0;
                }

                result += (PrefixNumber > x) ? "1" : "0";
                PeriCount++;
            }
            return result;
        }

        /// <summary>
        /// Converts <paramref name="IP"/> to binary
        /// </summary>
        /// <param name="IP">IP Address from <see cref="ConvertToIP(string)"/></param>
        /// <returns>Binary numbers in string</returns>
        public static string IPToBinary(int[] IP)
        {
            #region Variable Creation; Binary, sb
            int[] Binary = new int[8];
            StringBuilder sb = new StringBuilder();
            #endregion

            //Dummy IP: 192.168.50.25
            //Run through every segment of IP address
            for (int Segment = 0; Segment < 4; Segment++)
            {
                #region Individual bit
                //Run through every bit in the segment
                for (int Bit = 0; Bit < 8; Bit++)
                    //If 192 >= i.e. 128; Set Binary[Bit] = 1, and 192 - 128 = IP[Segment] = 64...
                    if (IP[Segment] >= BinaryNumbers[Bit])
                    {
                        Binary[Bit] = 1;
                        IP[Segment] -= BinaryNumbers[Bit];
                    }
                #endregion

                #region Convert to sb and make pretty
                //Go through every index of Binary and append to sb
                for (int x = 0; x < Binary.Length; x++)
                    sb.Append(Binary[x]);
                //If < 3, insert "."
                if (Segment < 3)
                    sb.Append(".");
                #endregion

                //Reset Binary
                Binary = new int[8];
            }
            //Return final result
            return sb.ToString();
        }

        /// <summary>
        /// Converts IP to Int[]
        /// </summary>
        /// <param name="IP">Input</param>
        /// <returns>IP in int[]</returns>
        public static int[] ConvertToIP(string IP)
        {
            string[] ToStringArr = IP.Split('.', '/');
            int[] Oct = new int[5];
            for (int i = 0; i < ToStringArr.Length; i++)
            {
                Oct[i] = Convert.ToInt32(ToStringArr[i]);
                if (Oct[i] > 255)
                    throw new Exception();
            }
            return Oct;
        }
    }
}
