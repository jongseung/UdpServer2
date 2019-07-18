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
            //UDP클아이언트의 IP/PORT를 얻기위한 소켓
            UdpClient udp = new UdpClient(11000);
            //UDP클라이언트에게 데이터 송신할 소켓
            UdpClient sender = new UdpClient();
            //받는거와 보내는거를 분류해주는 것이 좋다. (C#에서)
            IPEndPoint src_ip = new IPEndPoint(IPAddress.Parse("112.0.0.1"), 0);
            for (; ; )
            {
                byte[] rev_data = udp.Receive(ref src_ip);
                Console.WriteLine("{0} byte 수신 됨", rev_data.Length);
                Console.WriteLine("송신자의 IP : {0}, Port : {1}", src_ip.Address.ToString(), src_ip.Port);
                //DateTime : C# 에서 시간데이터를 처리할때 사용하는 클래스
                //DateTime.Now 정적 변수 : 컴퓨터의 현재시간을 지정하는 DateTime 객체 
                DateTime datetime = DateTime.Now;
                //객체나 변수값을 전송하기 위해 MemoryStream, BinaryFormatter 사용
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream stream = new MemoryStream();
                //메모리공간에 객체 데이터를 누적
                formatter.Serialize(stream, datetime);
                //메모리공간에 데이터를 byte[]로 추출
                byte[] send_data = stream.ToArray();

                //UDP통신으로 송신 - UDP클라이언트의 IP/PORT로 전송
                sender.Send(send_data, send_data.Length, src_ip);
            }
            //UDP 서버 닫기
            udp.Close();
        }
    }
}
