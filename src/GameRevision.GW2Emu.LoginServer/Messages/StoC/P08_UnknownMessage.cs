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

namespace GameRevision.GW2Emu.LoginServer.Messages.StoC
{
    public class P08_UnknownMessage : GenericMessage
    {
        public int Unknown0;
        public UID Unknown1;
        public UID Unknown2;
        public int Unknown3;
        public int Unknown4;
        public int Unknown5;
        public int Unknown6;
        public int Unknown7;
        public int Unknown8;
        public byte[] Unknown9;
        public struct Struct10
        {
            public short Unknown11;
            public short Unknown12;
            public int Unknown13;
            public int Unknown14;
            public int Unknown15;
            
            public void Serialize(Serializer serializer)
            {
                serializer.Write(this.Unknown11);
                serializer.Write(this.Unknown12);
                serializer.WriteVarint(this.Unknown13);
                serializer.WriteVarint(this.Unknown14);
                serializer.WriteVarint(this.Unknown15);
            }
        }
        public Struct10[] Unknown16;
        public byte[] Unknown17;
        
        public override ushort Header
        {
            get
            {
                return 8;
            }
        }
        
        public override void Serialize(Serializer serializer)
        {
            serializer.Write(Header);
            serializer.WriteVarint(this.Unknown0);
            serializer.Write(this.Unknown1);
            serializer.Write(this.Unknown2);
            serializer.WriteVarint(this.Unknown3);
            serializer.WriteVarint(this.Unknown4);
            serializer.WriteVarint(this.Unknown5);
            serializer.WriteVarint(this.Unknown6);
            serializer.WriteVarint(this.Unknown7);
            serializer.WriteVarint(this.Unknown8);
            for (int i = 0; i < this.Unknown9.Length; i++)
            {
                serializer.Write(this.Unknown9[i]);
            }
            serializer.Write((byte)Unknown16.Length);
            for (int i = 0; i < Unknown16.Length; i++)
            {
                Unknown16[i].Serialize(serializer);
            }
            for (int i = 0; i < this.Unknown17.Length; i++)
            {
                serializer.Write(this.Unknown17[i]);
            }
        }
    }
}
