using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

//OB Hettiarachchi - 20908883 || KAD Miththaka - 20907819  || Assignment 02 - part B

namespace ClientGUI
{
    internal class InterfaceChannel
    {
        //Connecting the .net remoting server

        private DataServerInterface interfaceChannel;
        public DataServerInterface generateChannel(string URL)
        {
            ChannelFactory<DataServerInterface> channelFactory;
            NetTcpBinding tcp = new NetTcpBinding();
            channelFactory = new ChannelFactory<DataServerInterface>(tcp, URL);
            interfaceChannel = channelFactory.CreateChannel();
            return interfaceChannel;
        }
    }
}
