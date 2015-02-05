using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Grundforloeb_projekt
{
    class Program
    {
        static void Main(string[] args)
        {

            int slash;
            string ip;
            int t = 0, x = 0, y = 0;
            int[] ipDecimal = new int[4];
            int[] ipBinary = new int[32];
            int[] subnetDecimal = new int[4];
            int[] subnetBinary = new int[32];
            int[] networkAddress = new int[32];
            int[] broadcastAddress = new int[32];
            int[] broadcastDecimal = new int[4];
            int[] networkAddressDecimal = new int[4];
            int[] temp8 = new int[8];
            string[] tempStringArray = new string[32];
            string tempString = "";

            Console.Clear();

            x = 23;
            y = 1;
            frame(x, y, 32, 2);
            Console.SetCursorPosition(x + 2, y + 1);
            Console.Write("Welcomme to IP Addressing Aid");
            Console.SetCursorPosition(x - 6, y + 4);
            Console.Write("Enter an IP(x.x.x.x/x): \t");
            ip = Console.ReadLine();
            string[] tempIP = ip.Split('/');
            slash = Convert.ToInt32(tempIP[1]);
            string[] tempIP2 = tempIP[0].Split('.');
            
            for (int i = 0; i < 4; i++)
            {
                ipDecimal[i] = Convert.ToInt32(tempIP2[i]);
            }
            
            // ## Converts IP to 32 Bits Array ##            
            
            for (int i = 0; i < 4; i++)
            {
                tempStringArray[i] = ToBin(ipDecimal[i]);
                tempString = tempString + tempStringArray[i];
            }
            char[] r = tempString.ToCharArray();
            for (int i = 0; i < 32; i++) tempStringArray[i] = Convert.ToString(r[i]);
            for (int i = 0; i < 32; i++) ipBinary[i] = Convert.ToInt32(tempStringArray[i]);
            
            // ## Populating array broadcast ##
            
            for (int i = 0; i < 32; i++) broadcastAddress[i] = 0;
            
            // ## Calculate SubnetMask Binary According to slash '/' ##
            
            for (int i = 0; i <= slash; i++) subnetBinary[i] = 1;
            for (int i = slash; i < 32; i++)
            {
                subnetBinary[i] = 0;
                broadcastAddress[i] = 1;
            }
            
            // ## Add Ip and Subnetmask to get IP address ##
            
            for (int i = 0; i < 32; i++)
            {
                if (subnetBinary[i] == 1 & ipBinary[i] == 1)
                {
                    networkAddress[i] = 1;
                    broadcastAddress[i] = 1;
                }
                else networkAddress[i] = 0;
            }
            for (int i = 0; i < 4; i++)
            {
                for (int u = 0; u < 8; u++)
                {
                    temp8[u] = networkAddress[t];
                    t++;
                }
                networkAddressDecimal[i] = ToDec(temp8);
            }
            t = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int u = 0; u < 8; u++)
                {
                    temp8[u] = subnetBinary[t];
                    t++;
                }
                subnetDecimal[i] = ToDec(temp8);
            }
            t = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int u = 0; u < 8; u++)
                {
                    temp8[u] = broadcastAddress[t];
                    t++;
                }
                broadcastDecimal[i] = ToDec(temp8);
            }
             
            // ## Frame position ##
            
            x = 4;
            y = 7;
            frame(x, y, 70, 12);
            x = x + 2;
            Console.SetCursorPosition(x, y + 1);
            
            // ## Print info ##
            
            Console.Write("IP Address: {0}.{1}.{2}.{3}/{4}", ipDecimal[0], ipDecimal[1], ipDecimal[2], ipDecimal[3], slash);
            Console.SetCursorPosition(x + 32, y + 1);
            Console.Write("{0}.{1}.{2}.{3}", ToBin(ipDecimal[0]), ToBin(ipDecimal[1]), ToBin(ipDecimal[2]), ToBin(ipDecimal[3]));
            Console.SetCursorPosition(x, y + 3);
            Console.Write("Subnetmask: {0}.{1}.{2}.{3}", subnetDecimal[0], subnetDecimal[1], subnetDecimal[2], subnetDecimal[3]);
            Console.SetCursorPosition(x + 32, y + 3);
            Console.Write("{0}.{1}.{2}.{3}", ToBin(subnetDecimal[0]), ToBin(subnetDecimal[1]), ToBin(subnetDecimal[2]), ToBin(subnetDecimal[3]));
            Console.SetCursorPosition(x, y + 5);
            Console.Write("Network: {0}.{1}.{2}.{3}", networkAddressDecimal[0], networkAddressDecimal[1], networkAddressDecimal[2], networkAddressDecimal[3]);
            Console.SetCursorPosition(x + 32, y + 5);
            Console.Write("{0}.{1}.{2}.{3}", ToBin(networkAddressDecimal[0]), ToBin(networkAddressDecimal[1]), ToBin(networkAddressDecimal[2]), ToBin(networkAddressDecimal[3]));
            Console.SetCursorPosition(x, y + 7);
            Console.Write("Broadcast: {0}.{1}.{2}.{3}", broadcastDecimal[0], broadcastDecimal[1], broadcastDecimal[2], broadcastDecimal[3]);
            Console.SetCursorPosition(x + 32, y + 7);
            Console.Write("{0}.{1}.{2}.{3}", ToBin(broadcastDecimal[0]), ToBin(broadcastDecimal[1]), ToBin(broadcastDecimal[2]), ToBin(broadcastDecimal[3]));
            Console.SetCursorPosition(x, y + 9);
            Console.Write("First host: {0}.{1}.{2}.{3}", networkAddressDecimal[0], networkAddressDecimal[1], networkAddressDecimal[2], networkAddressDecimal[3] + 1);
            Console.SetCursorPosition(x + 32, y + 9);
            Console.Write("{0}.{1}.{2}.{3}", ToBin(networkAddressDecimal[0]), ToBin(networkAddressDecimal[1]), ToBin(networkAddressDecimal[2]), ToBin(networkAddressDecimal[3] + 1));
            Console.SetCursorPosition(x, y + 11);
            Console.Write("Last host: {0}.{1}.{2}.{3}", broadcastDecimal[0], broadcastDecimal[1], broadcastDecimal[2], broadcastDecimal[3] - 1);
            Console.SetCursorPosition(x + 32, y + 11);
            Console.Write("{0}.{1}.{2}.{3}", ToBin(broadcastDecimal[0]), ToBin(broadcastDecimal[1]), ToBin(broadcastDecimal[2]), ToBin(broadcastDecimal[3] - 1));
            Console.CursorVisible = false;
            Console.SetCursorPosition(x, y + 16);
            Console.Read();

        }
        
        // ## Frame ##
        
        static void frame(int x, int y, int width, int high)
        {
            int a, b;
            a = x + width;
            b = y + high;
            Console.SetCursorPosition(x, y);
            Console.Write("╔");
            Console.SetCursorPosition(x, y + high);
            Console.Write("╚");
            for (x++; x < a; x++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("═");
                Console.SetCursorPosition(x, y + high);
                Console.Write("═");
            }
            Console.SetCursorPosition(x, y);
            Console.Write("╗");
            Console.SetCursorPosition(x, y + high);
            Console.Write("╝");
            for (y++; y < b; y++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("║");
                Console.SetCursorPosition(x - width, y);
                Console.Write("║");
            }
        }
        
        // ## Binary to Decimal ##
        
        static int ToDec(int[] a)
        {
            int[] bin = a;
            int[] bits = new int[8];
            int result = 0;
            double temp;
            for (int i = 0; i < 8; i++)
            {
                temp = Math.Pow(2, i);
                bits[i] = Convert.ToInt32(temp);
                if (bin[7 - i] == 1)
                {
                    result = result + bits[i];
                }

            }
            return result;
        }
        
        // ## Decimal to Binary ##
        
        static string ToBin(int a)
        {
            int decTemp;
            int[] dec = new int[4];
            int[] temp1 = new int[8];
            string[] binArray = new string[8];
            int b = 2, temp;
            string result = "";
            decTemp = a;
            for (int i = 0; i < 8; i++)
            {
                temp1[i] = decTemp % b;
                temp = decTemp / b;
                decTemp = temp;
                binArray[i] = Convert.ToString(temp1[i]);
            }
            for (int i = 7; i >= 0; i--)
            {
                result = result + binArray[i];
            }
            return result;
        }
    }
}

