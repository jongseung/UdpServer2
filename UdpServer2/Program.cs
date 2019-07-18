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
            
            //IPAddess 객체 생성- 가입할 멀티캐스트 주소를 저장할 객체 224.0.1.0
            
            //멀티캐스트 가입
            
            //IPEndPoint 객체 생성 - 0.0 인자로 사용
            
            //데이터 수신 - byte[]
            
            //byte[] 을 MemoryStream에 객체생성시 인자값으로 사용
            
            //MemoryStream에 커서위치를 데이터 맨앞으로 이동
            
            //BinaryFormatter로 Deserialize 메소드 호출로 string 변환
            
            // 결과 출력
            
            //UdpClient 객체 연결 종료

        }
    }
}
