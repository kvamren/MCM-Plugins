﻿using System;

namespace MCManager
{
    internal class Format_Jar : IBackupFormat
    {
        public IBackup Load(string file)
        {
            throw new NotImplementedException();
        }

        public void Save(string file, IBackup backup)
        {
            throw new NotImplementedException();
        }

        public byte getSignature()
        {
            return 0x01;
        }

        public IBackup CreateBackup()
        {
            Import i = new Import(null, null, null, null, null);
            i.ShowDialog();

            return null;
        }
    }
}