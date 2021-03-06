using System;
using System.Collections.Generic;
using GameRevision.GW2Emu.Common.Events;
using GameRevision.GW2Emu.Common.Network;
using GameRevision.GW2Emu.Common.Messaging;
using GameRevision.GW2Emu.Common.Cryptography;
using GameRevision.GW2Emu.Common.Serialization;
using NLog;

namespace GameRevision.GW2Emu.Common.Session
{
    public abstract class GenericSession : ISession
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private Client client;
        private IEventAggregator aggregator;
        private IMessageFactory messageFactory;
        private Handshake handshake;
        private RC4Encryptor encryptor;
        private LZ4Compressor compressor;

        public GenericSession(Client client, IEventAggregator aggregator, IMessageFactory messageFactory, Handshake handshake)
        {
            this.client = client;
            this.client.Disconnected += this.OnDisconnected;

            this.aggregator = aggregator;
            this.messageFactory = messageFactory;
            this.handshake = handshake;

            logger.Trace("Session created.");

            this.handshake.HandshakeDone += delegate
            {
                this.encryptor = new RC4Encryptor(handshake.EncryptionKey);
                this.compressor = new LZ4Compressor();
                this.client.DataReceived += this.OnDataReceived;

                logger.Trace("Handshake done.");
            };
        }

        public void Send(IMessage message)
        {
            Serializer serializer = new Serializer();

            message.Serialize(serializer);

            this.Send(serializer.GetBytes());
        }

        public void Send(byte[] buffer)
        {
            byte[] compressed = this.compressor.Compress(buffer);
            byte[] encrypted = this.encryptor.Encrypt(compressed);

            this.client.Send(encrypted);

            logger.Trace("Session sent data ->\n{0}", BitConverter.ToString(buffer).Replace('-', ' '));
        }

        public void Start()
        {
            this.client.Run();
        }

        public void Disconnect()
        {
            this.client.Disconnect();
        }

        private void OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            byte[] buffer = this.encryptor.Decrypt(e.Buffer);

            logger.Trace("Session received data <-\n{0}", BitConverter.ToString(buffer).Replace('-', ' '));

            IEnumerable<IMessage> messages = this.messageFactory.CreateMessages(buffer);

            foreach (IMessage message in messages) 
            {
                message.Session = this;
                this.aggregator.Trigger(message);
            }
        }

        private void OnDisconnected(object sender, ClientDisconnectedEventArgs e)
        {
            this.aggregator.Trigger(new ClientDisconnectedEvent(this));
        }
    }
}

