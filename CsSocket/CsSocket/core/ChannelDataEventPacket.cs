namespace CSSocket.core
{
    class ChannelDataEventPacket
    {

        public readonly IIncomingDataEvent DataEvent;
        public readonly string Channel;

        public ChannelDataEventPacket(string channel, IIncomingDataEvent dataEvent)
        {
            Channel = channel;
            DataEvent = dataEvent;
        }

    }
}
