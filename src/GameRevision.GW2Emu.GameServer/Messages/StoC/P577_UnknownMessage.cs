/*
 * This code was autogenerated by
 * GameRevision.GW2Emu.CodeWriter.
 * Date generated: 24-07-13
 */

using System;
using System.IO;
using System.Net;
using GameRevision.GW2Emu.Common;
using GameRevision.GW2Emu.Common.Math;
using GameRevision.GW2Emu.Common.Session;
using GameRevision.GW2Emu.Common.Messaging;
using GameRevision.GW2Emu.Common.Serialization;

namespace GameRevision.GW2Emu.GameServer.Messages.StoC
{
    public class P577_UnknownMessage : GenericMessage
    {
        public int Unknown0;
        public int Unknown1;
        public int Unknown2;
        public string Unknown3;
        public Vector3 Unknown4;
        public float Unknown5;
        public float Unknown6;
        public string Unknown7;
        public int[] Unknown8;
        public int[] Unknown9;
        public byte[] Unknown10;
        public int[] Unknown11;
        
        public override ushort Header
        {
            get
            {
                return 577;
            }
        }
        
        public override void Serialize(Serializer serializer)
        {
            serializer.Write(Header);
            serializer.WriteVarint(this.Unknown0);
            serializer.WriteVarint(this.Unknown1);
            serializer.WriteVarint(this.Unknown2);
            serializer.WriteUtf16String(this.Unknown3);
            serializer.Write(this.Unknown4);
            serializer.Write(this.Unknown5);
            serializer.Write(this.Unknown6);
            serializer.WriteUtf16String(this.Unknown7);
            for (int i = 0; i < this.Unknown8.Length; i++)
            {
                serializer.WriteVarint(this.Unknown8[i]);
            }
            serializer.Write((byte)Unknown9.Length);
            for (int i = 0; i < Unknown9.Length; i++)
            {
                serializer.WriteVarint(Unknown9[i]);
            }
            serializer.Write((byte)Unknown10.Length);
            for (int i = 0; i < Unknown10.Length; i++)
            {
                serializer.Write(Unknown10[i]);
            }
            serializer.Write((byte)Unknown11.Length);
            for (int i = 0; i < Unknown11.Length; i++)
            {
                serializer.WriteVarint(Unknown11[i]);
            }
        }
    }
}
