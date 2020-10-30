using System;
using System.Collections.Generic;

namespace NetworkCalc
{
    class SubnetCalc
    {
        public static readonly int[] BinaryNumbers = { 256, 128, 64, 32, 16, 8, 4, 2, 1 };
        public static Network Network;
        public static void Run()
        {
            while (true)
            {
                Network = GetInformation();
                Network.Range = IntroduceSubnet();
                ShowUI();
                Console.Clear();
            }
        }

        private static void ShowUI()
        {
            string Format = "{0, -20}{1, 0}";
            Console.WriteLine();
            Console.WriteLine(Format, "Network Name", $"{Network.NetworkName}/{Network.Prefix}");
            Console.WriteLine("---------------------------------------");
            for (int x = 0; x < Network.Range.Networks.Length; x++)
                Console.WriteLine(Format, $"Network #{x + 1}:", Network.Range.Networks[x].NetworkName);
            Console.ReadKey(true);
        }

        /// <summary>
        /// Defines Network.Range
        /// </summary>
        /// <returns>Range of subbed network</returns>
        private static Range IntroduceSubnet()
        {
            #region Update Prefix
            int n = 0;
            while (Network.Subnets > Math.Pow(2, n))
                n += 1;
            Network.Prefix += n;
            #endregion

            #region Calculate amount of possible networks
            int Index = Network.Prefix % 8, //y = 0,
                MagicBit = BinaryNumbers[Index];
            #endregion

            #region Define Network ranges
            int OGMagicBit = MagicBit;
            var PureNetwork = (Network.Prefix <= 24 && Network.Prefix > 8) ?
                new int[] { Network.IP[0], Network.IP[1], 0, 0 } :
                new int[] { Network.IP[0], Network.IP[1], Network.IP[2], 0 };
            var RangedNetworks = new List<Network>();
            if (Network.Prefix <= 24 && Network.Prefix > 8) RangedNetworks.Add(new Network($"{Network.IP[0]}.{Network.IP[1]}.0.0/{Network.Prefix}"));
            else RangedNetworks.Add(new Network($"{Network.IP[0]}.{Network.IP[1]}.{Network.IP[2]}.0/{Network.Prefix}"));

            for (int x = 1; x < Network.Subnets; x++)
                if (MagicBit < 255)
                {
                    if (Network.Prefix <= 24 && Network.Prefix > 8) 
                        RangedNetworks.Add(new Network($"{PureNetwork[0]}.{PureNetwork[1]}.{(PureNetwork[3] + MagicBit)}.0/{Network.Prefix}"));
                    else 
                        RangedNetworks.Add(new Network($"{PureNetwork[0]}.{PureNetwork[1]}.{PureNetwork[2]}.{(PureNetwork[3] + MagicBit)}/{Network.Prefix}"));
                    MagicBit += OGMagicBit;
                }
                else if (MagicBit > 255 && x < Network.Subnets)
                {
                    if (Network.Prefix <= 24 && Network.Prefix > 8)
                    {
                        PureNetwork[1]++;
                        RangedNetworks.Add(new Network($"{Network.IP[0]}.{PureNetwork[1]}.0.0/{Network.Prefix}"));
                    }
                    else
                    {
                        PureNetwork[2]++;
                        RangedNetworks.Add(new Network($"{Network.IP[0]}.{Network.IP[1]}.{PureNetwork[2]}.0/{Network.Prefix}"));
                    }
                    MagicBit = BinaryNumbers[Index];
                }
            #endregion

            return new Range 
            {
                MagicBit = OGMagicBit,
                AmountOfNetworks = Network.Subnets,
                Networks = RangedNetworks.ToArray()
            };
        }

        /// <summary>
        /// Interacts with user to define <see cref="Network"/>
        /// </summary>
        /// <returns>Definition of <see cref="Network"/></returns>
        private static Network GetInformation()
        {
            Console.Write("IP-Address: ");
            var network = new Network(Console.ReadLine());
            Console.Write("Subnets: ");
            network.Subnets = int.Parse(Console.ReadLine());
            //var network = new Network("10.10.10.10/20") { Subnets = 4 };
            return network;
        }
    }
}