
// Type: FMOD.Studio.USER_PROPERTY

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


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
