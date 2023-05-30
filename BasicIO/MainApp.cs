using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BasicIO
{
    class MainApp
    {
        static void Main(string[] args)
        {
            long someValue = 0x123456789abcdef0;
            Console.WriteLine("{0, -1} : 0x{1:X16}", "Original Data", someValue);

            Stream outStream = new FileStream("a.dat", FileMode.Create);
            byte[] wBytes = BitConverter.GetBytes(someValue); // someValue의 8바이트를 바이트 배열에 나눠 넣습니다.

            Console.Write("{0,-13} : ", "Byte Array");

            foreach (byte b in wBytes)
            {
                Console.Write("{0:X2} ", b);
            }
            Console.WriteLine();

            outStream.Write(wBytes, 0, wBytes.Length); // Write() 메소드를 이용해서 단번에 파일을 기록합니다.
            outStream.Close();

            Stream inStream = new FileStream("a.dat", FileMode.Open);
            byte[] rbytes = new byte[8];

            int i = 0;
            while (inStream.Position < inStream.Length)
            {
                rbytes[i++] = (byte)inStream.ReadByte();
            }

            long readValue = BitConverter.ToInt64(rbytes, 0);

            Console.WriteLine("{0,-13} : 0x{1:X16} ", "Read Data", readValue);
            inStream.Close();


        }
    }
}
