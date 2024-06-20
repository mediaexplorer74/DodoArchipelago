﻿// Decompiled with JetBrains decompiler
// Type: SharpRaven.Configuration
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll

using System;

namespace SharpRaven
{
    internal class ConfigurationPropertyAttribute : Attribute
    {
        private string v;
        private bool isKey;

        public ConfigurationPropertyAttribute(string v)
        {
            this.v = v;
        }

        public ConfigurationPropertyAttribute(string v, bool IsKey)
        {
            this.v = v;
            isKey = IsKey;
        }
    }
}