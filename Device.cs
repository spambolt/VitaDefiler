﻿using System;
using System.Collections.Generic;

namespace VitaDefiler
{
    struct Variable
    {
        public static readonly Variable Null = new Variable();
        public uint Data;
        public uint Size;
        public bool IsCode;
    }

    class Device
    {
        public List<Variable> Vars { get; private set; }
        public Network Network { get; private set; }
        public USB USB { get; private set; }

        public Device(USB usb, Network net)
        {
            Vars = new List<Variable>();
            Network = net;
            USB = usb;
        }

        public int CreateVariable(uint addr, uint size, bool isCode)
        {
            Variable var = new Variable()
            {
                Data = addr,
                Size = size,
                IsCode = isCode
            };
            int i;
            for (i = 0; i < Vars.Count; i++)
            {
                if (Vars[i].Data == 0)
                {
                    Vars[i] = var;
                    return i;
                }
            }
            Vars.Add(var);
            return i;
        }

        public int DeleteVariable(Variable var)
        {
            for (int i = 0; i < Vars.Count; i++)
            {
                if (Vars[i].Data == var.Data)
                {
                    Vars[i] = Variable.Null;
#if DEBUG
                    Console.Error.WriteLine("Deleted variable ${0}", i);
#endif
                }
            }
            return 0;
        }

        public int DeleteVariable(int id)
        {
            if (id < Vars.Count)
            {
                Vars[id] = Variable.Null;
            }
            return 0;
        }

        public void ConnectUSB()
        {
        }

        public void ConnectNetwork()
        {
        }
    }
}