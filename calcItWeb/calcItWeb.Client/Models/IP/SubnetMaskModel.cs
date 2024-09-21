using System;
using System.Collections.Generic;
using System.Net;
using System.Linq; // Optional, if using LINQ

namespace calcItWeb.Client.Models.IP
{
    public class SubnetMaskModel
    {
        public string IpAddress { get; set; }
        public int SubnetMask { get; set; } // Subnet mask as a CIDR prefix (e.g., 24)

        public string CheckIPAddress { get; set; }

        // Returns a list of all IP addresses in the range
        public List<string> IpAddressesInRange
        {
            get
            {
                return GetIpAddressesInRange(IpAddress, SubnetMask);
            }
        }

        // Checks if the CheckIPAddress is in the defined range
        public bool CheckIpAddressInRangeSpecified()
        {
            return IsIpAddressInRange(IpAddress, SubnetMask, CheckIPAddress);
        }

        // Method to check if an IP address is within a given range
        private bool IsIpAddressInRange(string ip, int subnetMask, string checkIp)
        {
            if (string.IsNullOrWhiteSpace(ip) || string.IsNullOrWhiteSpace(checkIp))
                return false; // Return false if either IP is null or empty

            var ipAddress = IPAddress.Parse(ip);
            var checkIPAddress = IPAddress.Parse(checkIp);

            var ipBytes = ipAddress.GetAddressBytes();
            var checkIpBytes = checkIPAddress.GetAddressBytes();

            uint mask = uint.MaxValue << (32 - subnetMask);

            uint ipValue = BitConverter.ToUInt32(ipBytes, 0);
            uint checkIpValue = BitConverter.ToUInt32(checkIpBytes, 0);

            uint networkAddress = ipValue & mask;

            return (checkIpValue & mask) == networkAddress;
        }

        private List<string> GetIpAddressesInRange(string ip, int subnetMask)
        {
            if (string.IsNullOrWhiteSpace(ip))
                return new List<string>(); // Return an empty list if IP is null or empty

            var ipAddress = IPAddress.Parse(ip);
            var ipBytes = ipAddress.GetAddressBytes();

            uint mask = uint.MaxValue << (32 - subnetMask);

            uint ipValue = BitConverter.ToUInt32(ipBytes, 0);

            uint networkAddress = ipValue & mask;

            int numberOfHosts = (int)Math.Pow(2, 32 - subnetMask) - 2;

            var ipAddresses = new List<string>();

            for (int i = 1; i <= numberOfHosts; i++)
            {
                uint hostAddress = networkAddress + (uint)i;
                var bytes = BitConverter.GetBytes(hostAddress);

                ipAddresses.Add(new IPAddress(bytes).ToString());
            }

            return ipAddresses;
        }

    }
}