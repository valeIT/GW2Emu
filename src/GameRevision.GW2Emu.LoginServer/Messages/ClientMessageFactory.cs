/*
 * This code was autogenerated by
 * GameRevision.GW2Emu.CodeWriter.
 * Date generated: 24-07-13
 */

using System;
using GameRevision.GW2Emu.Common.Messaging;
using GameRevision.GW2Emu.LoginServer.Messages.CtoS;

namespace GameRevision.GW2Emu.LoginServer.Messages
{
    public class ClientMessageFactory : GenericMessageFactory
    {
        protected override IMessage CreateEmptyMessage(ushort header){
            switch (header)
            {
                case 1:
                    return new P01_UnknownMessage();
                case 2:
                    return new P02_UnknownMessage();
                case 3:
                    return new P03_UnknownMessage();
                case 4:
                    return new P04_UnknownMessage();
                case 5:
                    return new P05_UnknownMessage();
                case 10:
                    return new P10_UnknownMessage();
                case 11:
                    return new P11_UnknownMessage();
                case 12:
                    return new P12_UnknownMessage();
                case 14:
                    return new P14_UnknownMessage();
                case 15:
                    return new P15_UnknownMessage();
                case 16:
                    return new P16_UnknownMessage();
                case 20:
                    return new P20_UnknownMessage();
                case 21:
                    return new P21_UnknownMessage();
                case 22:
                    return new P22_UnknownMessage();
                case 23:
                    return new P23_UnknownMessage();
                case 24:
                    return new P24_UnknownMessage();
                case 25:
                    return new P25_UnknownMessage();
                case 26:
                    return new P26_UnknownMessage();
                case 29:
                    return new P29_UnknownMessage();
                case 34:
                    return new P34_UnknownMessage();
                case 35:
                    return new P35_UnknownMessage();
                case 36:
                    return new P36_UnknownMessage();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}