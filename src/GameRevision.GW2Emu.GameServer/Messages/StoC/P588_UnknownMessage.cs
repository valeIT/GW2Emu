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
    public class P588_UnknownMessage : GenericMessage
    {
        public struct Struct0
        {
            public int Unknown1;
            public long Unknown2;
            
            public void Serialize(Serializer serializer)
            {
                serializer.WriteVarint(this.Unknown1);
                serializer.Write(this.Unknown2);
            }
        }
        public Struct0[] Unknown3;
        
        public override ushort Header
        {
            get
            {
                return 588;
            }
        }
        
        public override void Serialize(Serializer serializer)
        {
            serializer.Write(Header);
            serializer.Write((byte)Unknown3.Length);
            for (int i = 0; i < Unknown3.Length; i++)
            {
                Unknown3[i].Serialize(serializer);
            }
        }
    }
}
