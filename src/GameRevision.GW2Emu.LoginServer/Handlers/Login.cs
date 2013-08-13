﻿using System;
using System.Net;
using GameRevision.GW2Emu.Common.Events;
using GameRevision.GW2Emu.Common.Session;
using CtoS = GameRevision.GW2Emu.LoginServer.Messages.CtoS;
using StoC = GameRevision.GW2Emu.LoginServer.Messages.StoC;

namespace GameRevision.GW2Emu.LoginServer.Handlers
{
    public class Login : IRegisterable
    {
        public void Register(IEventAggregator aggregator)
        {
            aggregator.Register<CtoS.P01_PingServer>(this.OnPingServer);
            aggregator.Register<CtoS.P02_ComputerUserName>(this.OnComputerUserName);
            aggregator.Register<CtoS.P03_ComputerInfo>(this.OnComputerInfo);
            aggregator.Register<CtoS.P10_ClientSessionInfo>(this.OnClientSessionInfo);
            aggregator.Register<CtoS.P04_UnknownMessage>(this.OnMessage04);
            aggregator.Register<CtoS.P34_UnknownMessage>(this.OnMessage34);
            aggregator.Register<CtoS.P12_UnknownMessage>(this.OnMessage12);
            aggregator.Register<CtoS.P29_EnterWorld>(this.OnRedirectToGs);
            aggregator.Register<CtoS.P14_UnknownMessage>(this.OnMessageP14);
            aggregator.Register<CtoS.P22_UnknownMessage>(this.OnCharacterSelect);
            aggregator.Register<CtoS.P20_UnknownMessage>(this.OnCharacterDelete); 
        }

        private void OnPingServer(CtoS.P01_PingServer message)
        {
            ISession Session = message.Session;

            StoC.P01_PingServerReply PingServerReply = new StoC.P01_PingServerReply();
            PingServerReply.Timestamp = message.Timestamp;
            Session.Send(PingServerReply);
        }

        private void OnComputerUserName(CtoS.P02_ComputerUserName message)
        {
            ISession Session = message.Session;
        }

        private void OnComputerInfo(CtoS.P03_ComputerInfo message)
        {
            ISession Session = message.Session;

            Session.Send(new StoC.P02_ComputerInfoReply());
        }

        private void OnClientSessionInfo(CtoS.P10_ClientSessionInfo message)
        {
            ISession Session = message.Session;

            Session.Send(new StoC.P15_UnknownMessage());

            StoC.P04_UnknownMessage ClientSync = new StoC.P04_UnknownMessage();
            ClientSync.Unknown0 = 0;
            ClientSync.Unknown1 = 21;
            ClientSync.Unknown2 = 6;
            ClientSync.Unknown3 = 3;
            ClientSync.Unknown4 = 2198;
            Session.Send(ClientSync);

            StoC.P17_CharacterInformation CharacterInfo = new StoC.P17_CharacterInformation();
            CharacterInfo.Unknown0 = message.Unknown0;
            CharacterInfo.CharacterID = new Common.UID(new byte[] { 0x74, 0xAE, 0x2A, 0x01, 0xBA, 0x34, 0xE2, 0x11, 0xBC, 0xD1, 0x44, 0x1E, 0xA1, 0x02, 0xB1, 0xB6 });
            CharacterInfo.Unknown1 = 0;
            CharacterInfo.CharacterName = "User";
            CharacterInfo.Character.UnkVal1 = 7;
            CharacterInfo.Character.MaybeFlags = 0x8A;
            CharacterInfo.Character.UnkVal2 = 0;
            CharacterInfo.Character.Level = 1;
            CharacterInfo.Character.Class = 6; // Elementalist
            CharacterInfo.Character.UnkVal4 = 0;
            CharacterInfo.Character.UnkVal5 = 0;

            CharacterInfo.Character.Body = new StoC.P17_CharacterInformation.Body() { Appearance = new byte[] {0x02, 0x80, 0x00, 0x00, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x16, 0x00, 0x2B, 0x0B, 0x17, 0x00, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x4A, 0x80, 0x02, 0x09, 0x01, 0x0C, 0x00, 0x00, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x03 } };
            
            CharacterInfo.Character.Equipment = new StoC.P17_CharacterInformation.Equipment();

            CharacterInfo.Character.Equipment.RightHand.ItemID = 0x8248;
            CharacterInfo.Character.Equipment.RightHand.Flag = Messages.StoC.P17_CharacterInformation.Visibility.kVisible;
            CharacterInfo.Character.Equipment.LeftHand.ItemID = 0;
            CharacterInfo.Character.Equipment.LeftHand.Flag = Messages.StoC.P17_CharacterInformation.Visibility.kVisible;

            CharacterInfo.Character.Equipment.BUnk0 = 0;
            CharacterInfo.Character.Equipment.BUnk1 = 0;

            CharacterInfo.Character.Equipment.Chest.ItemID = 0x1941;
            CharacterInfo.Character.Equipment.Chest.Flag = Messages.StoC.P17_CharacterInformation.Visibility.kVisible;
            CharacterInfo.Character.Equipment.Chest.Color1 = 0xC1;
            CharacterInfo.Character.Equipment.Chest.Color2 = 0x6B;
            CharacterInfo.Character.Equipment.Chest.Color3 = 0xC1;

            CharacterInfo.Character.Equipment.Boots.ItemID = 0x1940;
            CharacterInfo.Character.Equipment.Boots.Flag = Messages.StoC.P17_CharacterInformation.Visibility.kVisible;
            CharacterInfo.Character.Equipment.Boots.Color1 = 0xC1;
            CharacterInfo.Character.Equipment.Boots.Color2 = 0x6D;
            CharacterInfo.Character.Equipment.Boots.Color3 = 0x6B;

            CharacterInfo.Character.Equipment.UnkItem1.ItemID = 0;
            CharacterInfo.Character.Equipment.UnkItem1.Flag = Messages.StoC.P17_CharacterInformation.Visibility.kVisible;
            CharacterInfo.Character.Equipment.UnkItem1.Color1 = 0;
            CharacterInfo.Character.Equipment.UnkItem1.Color2 = 0;
            CharacterInfo.Character.Equipment.UnkItem1.Color3 = 0;

            CharacterInfo.Character.Equipment.Hands.ItemID = 0x1942;
            CharacterInfo.Character.Equipment.Hands.Flag = Messages.StoC.P17_CharacterInformation.Visibility.kVisible;
            CharacterInfo.Character.Equipment.Hands.Color1 = 0;
            CharacterInfo.Character.Equipment.Hands.Color2 = 0;
            CharacterInfo.Character.Equipment.Hands.Color3 = 0;

            CharacterInfo.Character.Equipment.Legs.ItemID = 0x1943;
            CharacterInfo.Character.Equipment.Legs.Flag = Messages.StoC.P17_CharacterInformation.Visibility.kVisible;
            CharacterInfo.Character.Equipment.Legs.Color1 = 0xC1;
            CharacterInfo.Character.Equipment.Legs.Color2 = 0x6B;
            CharacterInfo.Character.Equipment.Legs.Color3 = 0xC1;

            CharacterInfo.Character.Equipment.Shoulders.ItemID = 0;
            CharacterInfo.Character.Equipment.Shoulders.Flag = Messages.StoC.P17_CharacterInformation.Visibility.kVisible;
            CharacterInfo.Character.Equipment.Shoulders.Color1 = 0;
            CharacterInfo.Character.Equipment.Shoulders.Color2 = 0;
            CharacterInfo.Character.Equipment.Shoulders.Color3 = 0;

            CharacterInfo.Character.Equipment.Mask.ItemID = 0;
            CharacterInfo.Character.Equipment.Mask.Flag = Messages.StoC.P17_CharacterInformation.Visibility.kVisible;
            CharacterInfo.Character.Equipment.Mask.Color1 = 0;
            CharacterInfo.Character.Equipment.Mask.Color2 = 0;
            CharacterInfo.Character.Equipment.Mask.Color3 = 0;

            CharacterInfo.Character.Float1 = 0;
            CharacterInfo.Character.Float2 = -4366729686259965706108928.000000f;

            Session.Send(CharacterInfo);

            StoC.P10_AccountMedals AccountMedals = new StoC.P10_AccountMedals();
            AccountMedals.Unknown0 = message.Unknown0;
            AccountMedals.Unknown1 = new byte[456];
            Session.Send(AccountMedals);

            StoC.P27_UnknownMessage P27 = new StoC.P27_UnknownMessage();
            P27.Unknown0 = message.Unknown0;
            P27.Unknown4 = new StoC.P27_UnknownMessage.Struct1[32];
            Session.Send(P27);

            // Protocol version: 21315
            StoC.P08_AccountInfo AccountInfo = new StoC.P08_AccountInfo();
            AccountInfo.Unknown0 = message.Unknown0;
            AccountInfo.Unknown1 = new Common.UID(new byte[16]);
            AccountInfo.CharacterID = new Common.UID(new byte[16]);
            AccountInfo.Unknown3 = 2;
            AccountInfo.Unknown4 = 5;
            AccountInfo.Unknown5 = 390149345;
            AccountInfo.Unknown6 = 0;
            AccountInfo.Unknown7 = 0;
            AccountInfo.Unknown8 = 3;
            AccountInfo.Unknown9 = new byte[] { 0xA9, 0xD4, 0x57, 0x38, 0x56, 0x05, 0x08, 0x4D, 0x6A, 0xD7, 0x9A, 0x37, 0x50, 0xC5, 0x1B, 0x30, 0xC7, 0xBB, 0x11, 0xA5, 0x64, 0x8C, 0x9C, 0x65, 0x42, 0x20, 0xAD, 0xB2, 0xD3, 0xFD, 0xD3, 0x5F };
            AccountInfo.Unknown16 = new StoC.P08_AccountInfo.Struct10[1];
            AccountInfo.Unknown17 = new byte[32];
            Session.Send(AccountInfo);

            StoC.P16_UnknownMessage P16 = new StoC.P16_UnknownMessage();
            P16.Unknown0 = message.Unknown0;
            P16.Unknown1 = new Common.UID(new byte[16]);
            P16.Unknown2 = 0;
            P16.Unknown3 = 12651121;
            P16.Unknown4 = 168;
            P16.Unknown5 = 1800;
            P16.Unknown6 = 0;
            Session.Send(P16);

            Session.Send(new StoC.P23_UnknownMessage());

            StoC.P25_UnknownMessage GameServerInfo = new StoC.P25_UnknownMessage();
            GameServerInfo.Unknown0 = 1001;
            GameServerInfo.Unknown1 = 0;
            GameServerInfo.Unknown2 = 0;
            GameServerInfo.Unknown3 = 168;
            Session.Send(GameServerInfo);

            Session.Send(new StoC.P24_UnknownMessage());

            StoC.P04_UnknownMessage Sync = new StoC.P04_UnknownMessage();
            Sync.Unknown0 = message.Unknown0;
            Sync.Unknown1 = 0;
            Sync.Unknown2 = 49;
            Sync.Unknown3 = 7004;
            Sync.Unknown4 = 823;
            Session.Send(Sync);
        }

        private void OnMessage04(CtoS.P04_UnknownMessage message)
        {
        }

        private void OnMessage34(CtoS.P34_UnknownMessage message)
        {
        }

        private void OnMessage12(CtoS.P12_UnknownMessage message)
        {
            ISession Session = message.Session;

            StoC.P04_UnknownMessage Sync = new StoC.P04_UnknownMessage();
            Sync.Unknown0 = message.Unknown0;
            Sync.Unknown1 = 0;
            Sync.Unknown2 = 4;
            Sync.Unknown3 = 5;
            Sync.Unknown4 = 2324;
            Session.Send(Sync);
        }

        private void OnRedirectToGs(CtoS.P29_EnterWorld message)
        {
            ISession Session = message.Session;

            StoC.P20_UnknownMessage ReferToGameServerMessage = new StoC.P20_UnknownMessage();
            ReferToGameServerMessage.Unknown0 = message.AuthInc;
            ReferToGameServerMessage.Unknown1 = message.Type; // Stage 
            ReferToGameServerMessage.Unknown2 = 0;
            ReferToGameServerMessage.Unknown3 = message.MapID; // Map
            ReferToGameServerMessage.Unknown4 = new IPEndPoint(IPAddress.Loopback, 0);
            ReferToGameServerMessage.Unknown5 = 0;
            Session.Send(ReferToGameServerMessage);
        }

        private void OnMessageP14(CtoS.P14_UnknownMessage message)
        {
            ISession Session = message.Session;

            StoC.P04_UnknownMessage Sync = new StoC.P04_UnknownMessage();
            Sync.Unknown0 = message.Unknown0;
            Sync.Unknown1 = 0;
            Sync.Unknown2 = 4;
            Sync.Unknown3 = 5;
            Sync.Unknown4 = 2923;
            Session.Send(Sync);
        }

        private void OnCharacterSelect(CtoS.P22_UnknownMessage message)
        {
            ISession Session = message.Session;

            // Protocol version: 20849
            StoC.P08_AccountInfo AccountInfo = new StoC.P08_AccountInfo();
            AccountInfo.Unknown0 = message.Unknown0;
            AccountInfo.Unknown1 = new Common.UID(new byte[16]);
            AccountInfo.CharacterID = new Common.UID(new byte[16]);
            AccountInfo.Unknown3 = 2;
            AccountInfo.Unknown4 = 5;
            AccountInfo.Unknown5 = 390149345;
            AccountInfo.Unknown6 = 1001;
            AccountInfo.Unknown7 = 1001;
            AccountInfo.Unknown8 = 3;
            AccountInfo.Unknown9 = new byte[] { 0x0f, 0x8a, 0xa1, 0xbb, 0x47, 0x79, 0xb8, 0xf9, 0x20, 0xec, 0x40, 0xfa, 0x45, 0x2c, 0x7d, 0xed, 0x0c, 0xa2, 0xe4, 0x99, 0x70, 0x7c, 0xe9, 0x30, 0x6c, 0x13, 0x01, 0xc5, 0x80, 0xff, 0x57, 0x31 };
            AccountInfo.Unknown16 = new StoC.P08_AccountInfo.Struct10[1];
            AccountInfo.Unknown17 = new byte[32];
            Session.Send(AccountInfo);

            StoC.P04_UnknownMessage Sync = new StoC.P04_UnknownMessage();
            Sync.Unknown0 = message.Unknown0;
            Sync.Unknown1 = 0;
            Sync.Unknown2 = 1002;
            Sync.Unknown3 = 3;
            Sync.Unknown4 = 3443;
            Session.Send(Sync);
        }

        private void OnCharacterDelete(CtoS.P20_UnknownMessage message)
        {
        }
    }
}
