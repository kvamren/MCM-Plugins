﻿using System;
using System.IO;
using MCManager.Backups;
using MCManager;
using MCM_Plugins;

namespace MCManager
{
    internal class Format_Jar : IBackupFormat
    {
        byte signature = 0x01;

        public IBackup Load(string file)
        {
            BinaryReader br = new BinaryReader(new FileStream(file, FileMode.Open));
            br.ReadByte();
            string name = br.ReadString();
            string desc = br.ReadString();
            Backup_Jar backup = new Backup_Jar(name, desc, file);
            return backup;
        }

        public void Save(string file, IBackup backup)
        {
            BinaryWriter bw = new BinaryWriter(new FileStream(file, FileMode.OpenOrCreate));
            bw.Write(signature);
            bw.Write(backup.GetName());
            bw.Write(backup.GetDescription());
            bw.Write((backup as Backup_Jar).GetData());
        }

        public byte getSignature()
        {
            return 0x01;
        }

        public IBackup CreateBackup()
        {
            CreateBackup cb = new CreateBackup("Create new JarBackup", "Name:","Description:","File:","","",Data.minecraftbin,false);
            if (cb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(cb.path))
                {
                    if (cb.name != "")
                    {
                        Backup_Jar backup = new Backup_Jar(cb.name, cb.description, cb.path);
                        return backup;
                    }
                    else
                    {
                        ErrorReporter.Error("You have to enter a name for the backup!");
                        return null;
                    }
                }
                else
                {
                    ErrorReporter.Error("Invalid file!");
                    return null;
                }
            }
            return null;
        }
    }
}