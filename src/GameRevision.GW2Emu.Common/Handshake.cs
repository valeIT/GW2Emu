﻿using System;
using GameRevision.GW2Emu.Common.Network;
using GameRevision.GW2Emu.Common.Cryptography;
using GameRevision.GW2Emu.Common.Serialization;

namespace GameRevision.GW2Emu.Common
{
    public abstract class Handshake
    {
        public event Action HandshakeDone;
        public byte[] EncryptionKey;

        private Client client;

        public Handshake(Client client)
        {
            this.client = client;
            this.client.DataReceived += this.OnDataReceived;
        }

        protected abstract void HandlePacket(byte header, byte length, Deserializer deserializer);

        private void OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            Deserializer deserializer = new Deserializer(e.Buffer);

            while (!deserializer.EndOfStream)
            {
                byte header = deserializer.ReadByte();
                byte length = deserializer.ReadByte();

                switch (length)
                {
                    case 0x42:
                        byte[] publicKey = deserializer.ReadBytes(64);
                        byte[] sharedKey = DiffieHellman.GenerateSharedKey(publicKey, Keys.PrivateKey, Keys.Prime);
                        byte[] randomBytes = CryptoUtils.GetRandomBytes();
                        byte[] hashedRandomBytes = CryptoUtils.Hash(randomBytes);
                        byte[] xoredRandomBytes = CryptoUtils.XOR(randomBytes, sharedKey);
                        this.EncryptionKey = hashedRandomBytes;
                        this.SendKey(xoredRandomBytes);
                        this.client.DataReceived -= OnDataReceived;
                        this.OnHandshakeDone();
                        break;
                    default:
                        this.HandlePacket(header, length, deserializer);
                        break;
                }
            }
        }

        private void SendKey(byte[] key)
        {
            Serializer serializer = new Serializer();
            serializer.Write((byte)0x01);
            serializer.Write((byte)0x16);
            serializer.Write(key);

            this.client.Send(serializer.GetBytes());
        }

        private void OnHandshakeDone()
        {
            if (this.HandshakeDone != null)
            {
                this.HandshakeDone();
            }
        }
    }
}
