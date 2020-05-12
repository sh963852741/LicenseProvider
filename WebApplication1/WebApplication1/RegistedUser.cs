﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{

    public struct RegRecord
    {
        public string userName;
        public string password;
        public string serialNumber;
        public int type;

        public RegRecord(string Name,string word,string Number,int types)
        {
            userName = Name;
            password = word;
            serialNumber = Number;
            type = types;
        }
    }
    public class RegistedUser
    {
        private Dictionary<string, RegRecord> regDic = new Dictionary<string, RegRecord>();

        public void ReadFromFile(string filePath = "RegData.dat")
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                object o = JsonConvert.DeserializeObject<Dictionary<string, RegRecord>>(json);
                regDic = (Dictionary<string, RegRecord>)o;
            }

        }
        public void WriteToFile(string filePath = "RegData.dat")
        {
            string json = JsonConvert.SerializeObject(regDic);
            File.WriteAllText(filePath, json);
        }
        public void Add(RegRecord regRecord)
        {
            regDic.Add(regRecord.serialNumber, regRecord);
        }
        public void Remove(RegRecord regRecord)
        {
            regDic.Remove(regRecord.serialNumber);
        }
        public RegRecord GetUser(string serialNumber)
        {
                return regDic[serialNumber];
        }

        public bool Contains(string serialNumber)
        {
            return regDic.ContainsKey(serialNumber);
        }
    }
}