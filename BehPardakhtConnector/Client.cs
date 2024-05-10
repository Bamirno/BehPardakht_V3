using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using POS_PC_v3;
using static POS_PC_v3.Transaction;

namespace BehPardakhtConnector
{
    
    public abstract class Client
    {
        protected Transaction.Connection connection;
        protected string ipAddress { get; set; }
        protected string port { get; set; }

        public Response Payment(long amount,string pcId = "1", string payerId = "", string merchantMsg = "", string merchantAdditionalData = "")
        {
            var transaction = new Transaction(connection);
            Result result = new Result();
            result = transaction.Debits_Goods_And_Service(pcId, amount.ToString(), payerId, merchantMsg, merchantAdditionalData);
            return new Response(result);
        }
    }

    public class TCPClient : Client
    {

        public TCPClient(string ip, int port)
        {
            connection = new Transaction.Connection();
            connection.CommunicationType = "TCP/IP";
            connection.POS_PORTtcp = port;
            connection.POS_IP = ip;
            connection.POSPC_TCPCOMMU_SocketRecTimeout = 0x2bf20;
        }

    }


}
