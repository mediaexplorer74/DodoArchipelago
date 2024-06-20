// Decompiled with JetBrains decompiler
// Type: FMOD.Studio.USER_PROPERTY
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe


namespace FMOD.Studio
{
  public struct USER_PROPERTY
  {
    public StringWrapper name;
    public USER_PROPERTY_TYPE type;
    private Union_IntBoolFloatString value;

    public int intValue() => this.type != USER_PROPERTY_TYPE.INTEGER ? -1 : this.value.intvalue;

    public bool boolValue() => this.type == USER_PROPERTY_TYPE.BOOLEAN && this.value.boolvalue;

    public float floatValue()
    {
      return this.type != USER_PROPERTY_TYPE.FLOAT ? -1f : this.value.floatvalue;
    }

    public string stringValue()
    {
      return this.type != USER_PROPERTY_TYPE.STRING ? "" : (string) this.value.stringvalue;
    }
  }
}
