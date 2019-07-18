using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

/* 
 * UDP수신 프로그램 - 브로드캐스트된 데이터를 수신
 */

namespace UdpServer2
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient recver = new UdpClient(12000);

            IPEndPoint src_ip = new IPEndPoint(0, 0);
            byte[] recv_data;
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            string result;
            for(; ; )
            {
                recv_data = recver.Receive(ref src_ip);
                stream.Write(recv_data, 0, recv_data.Length);
                stream.Seek(0, SeekOrigin.Begin);
                result = (string)formatter.Deserialize(stream);
                Console.WriteLine("수신된 데이터 : {0}", result);
                stream.SetLength(0);
            }

            recver.Close();
        }
    }
}
