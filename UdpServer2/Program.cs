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
 * UDP 클라이언트의 IP/PORT로 데이터 송신
 */

// 수신부분은 데이터가 올때까지 대기하는 코드로 짜야한다.
// 데이터를 쌓아 놓는 부분 - 버퍼
// 
namespace UdpServer2
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udp = new UdpClient(11000);
            IPEndPoint src_ip = new IPEndPoint(IPAddress.Parse("112.0.0.1"), 0);


            for (; ; )
            {
                byte[] rev_data = udp.Receive(ref src_ip);
                Console.WriteLine("{0} byte 수신 됨", rev_data.Length);
                Console.WriteLine("송신자의 IP : {0}, Port : {1}", src_ip.Address.ToString(), src_ip.Port);
            }
            //UDP 서버 닫기
            udp.Close();
        }
    }
}
