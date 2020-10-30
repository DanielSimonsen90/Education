using System;

namespace NetworkCalc
{
    class Network : NetworkCalc
    {
        #region NetworkCalc Properties
        public int[] IP
        {
            get => ip;
            set
            {
                ip = value;
                BinaryIP = IPToBinary(new int[] { ip[0], ip[1], ip[2], ip[3] }); 
            }
        }
        private static int[] ip;
        public string BinaryIP { get; private set; }

        public int Prefix 
        { 
            get => prefix; 
            set 
            { 
                prefix = value; 
                SetBinaryPrefix(); 
            }
        }
        private static int prefix;
        public string BinaryPrefix { get; private set; }

        public string NetworkName 
        { 
            get => networkName; 
            set 
            { 
                networkName = value; 
                BinaryNetworkName = GetNetworkName(BinaryIP, BinaryPrefix); 
            }
        }
        private string networkName;
        public string BinaryNetworkName { get; private set; }

        public string Class;
        #endregion

        #region Subnetting
        public int Subnets 
        { 
            get => subnets; 
            set => subnets = value; 
        }
        private static int subnets;
        public Range Range { get; set; }
        #endregion

        public Network(string input)
        {
            IP = ConvertToIP(input);
            Prefix = IP[4];
            NetworkName = ConvertToNormal(GetNetworkName(BinaryIP, BinaryPrefix));
        }
        private void SetBinaryPrefix()
        {
            try { BinaryPrefix = CalcBinaryPrefix(prefix, IP[0], out Class); }
            catch (NullReferenceException)
            {
                Console.WriteLine("Please provide a valid prefix");
                Console.Clear();
                SubnetCalc.Run();
            }
        }
    }
}
