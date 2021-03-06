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
    public class P028_UnknownMessage : GenericMessage
    {
        public short Unknown0;
        public int Unknown1;
        public byte Unknown2;
        public int Unknown3;
        public byte[] Unknown4;
        public Vector4 Unknown5;
        public int Unknown6;
        public byte Unknown7;
        public byte Unknown8;
        public byte Unknown9;
        public int Unknown10;
        public short Unknown11;
        public Optional<WorldPosition> Unknown12;
        
        public override ushort Header
        {
            get
            {
                return 28;
            }
        }
        
        public override void Serialize(Serializer serializer)
        {
            serializer.Write(Header);
            serializer.Write(this.Unknown0);
            serializer.WriteVarint(this.Unknown1);
            serializer.Write(this.Unknown2);
            serializer.WriteVarint(this.Unknown3);
            serializer.Write((byte)Unknown4.Length);
            for (int i = 0; i < Unknown4.Length; i++)
            {
                serializer.Write(Unknown4[i]);
            }
            serializer.Write(this.Unknown5);
            serializer.WriteVarint(this.Unknown6);
            serializer.Write(this.Unknown7);
            serializer.Write(this.Unknown8);
            serializer.Write(this.Unknown9);
            serializer.WriteVarint(this.Unknown10);
            serializer.Write(this.Unknown11);
            serializer.Write(this.Unknown12.IsPresent ? (byte) 1 : (byte) 0);
            if (this.Unknown12.IsPresent)
            {
                serializer.Write(this.Unknown12.Value);
            }
        }
    }
}
