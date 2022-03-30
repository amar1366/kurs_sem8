using lab4.Storage.Entity;
using System.Collections.Generic;

namespace lab4.Services
{
    public interface IPortInfoService
    {
        public List<EndPoint> GetActiveTcpListeners();
        public List<PortInfo> GetActiveTcpConnections();
        public List<EndPoint> GetActiveUdpListeners();
    }
}
