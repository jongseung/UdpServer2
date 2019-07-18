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
 * UDP 수신 프로그램 - 멀티케스트된 데이터를 수신
 */

namespace UdpServer2
{
    class Program
    {
        static void Main(string[] args)
        {
            //UdpClient 객체 생성 - 13000 포트
            UdpClient rev = new UdpClient(13000);
            //IPAddress 객체 생성- 가입할 멀티캐스트 주소를 저장할 객체 224.0.1.0
            IPAddress multicast_ip = IPAddress.Parse("224.0.1.0");
            //멀티캐스트 가입
            //JoinMulticastGroup(IPAddress 객체) : IPAddress객체가 저장한 IP주소 (멀티캐스트 주소)로 해당 UDP소켓이 가입하는 기능이 있는 메소드
            rev.JoinMulticastGroup(multicast_ip);

            //IPEndPoint 객체 생성 - 0.0 인자로 사용
            IPEndPoint src_ip = new IPEndPoint(0, 0);

            byte[] recv_data;
            string result;
            for(; ; )
            {

                //데이터 수신 - byte[]
                recv_data = rev.Receive(ref src_ip);
                //byte[] 을 MemoryStream에 객체생성시 인자값으로 사용
                MemoryStream stream = new MemoryStream(recv_data);
                BinaryFormatter formatter = new BinaryFormatter();
                //MemoryStream에 커서위치를 데이터 맨앞으로 이동
                stream.Seek(0, SeekOrigin.Begin);
                //BinaryFormatter로 Deserialize 메소드 호출로 string 변환
                result = (string)formatter.Deserialize(stream);
                // 결과 출력
                Console.WriteLine(result);

                stream.Close();
            }

            rev.DropMulticastGroup(multicast_ip);
            //UdpClient 객체 연결 종료
            rev.Close();
        }
    }
}
