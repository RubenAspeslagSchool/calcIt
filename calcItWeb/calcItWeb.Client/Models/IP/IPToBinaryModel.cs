using System;
using System.Linq; // Ensure this is included for using Linq methods
using System.Collections.Generic;
using System.Text; // For StringBuilder

namespace calcItWeb.Client.Models.IP
{
    public class IPToBinaryModel
    {
        public string IPInNumbers { get; set; }
        public string IPOutInBinary { get => ConvertToBinary(); }

        public IPToBinaryModel() { }

        private string ConvertToBinary()
        {
            // Use StringBuilder for efficient string concatenation
            StringBuilder binary = new StringBuilder();

            // Check if IPInNumbers is not null or empty
            if (string.IsNullOrEmpty(IPInNumbers))
                return string.Empty;

            // Split the IP and convert each part to binary
            var parts = IPInNumbers.Split('.');
            foreach (var number in parts)
            {
                if (int.TryParse(number, out int newNumber) && newNumber >= 0 && newNumber <= 255)
                {
                    binary.Append(Convert.ToString(newNumber, 2).PadLeft(8, '0')); // Pad to 8 bits
                    binary.Append(".");
                }
                else
                {
                    // Invalid IP segment, handle as needed (e.g., return empty string)
                    return string.Empty;
                }
            }

            // Remove the last character if it's a dot
            if (binary.Length > 0 && binary[binary.Length - 1] == '.')
            {
                binary.Length--; // Remove the last character (dot)
            }

            return binary.ToString();
        }
    }
}
