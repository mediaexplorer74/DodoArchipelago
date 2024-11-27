
// Type: FMOD.Geometry

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Runtime.InteropServices;


namespace FMOD
{
  public struct Geometry
  {
    public IntPtr handle;

    public RESULT release() => Geometry.FMOD5_Geometry_Release(this.handle);

    public RESULT addPolygon(
      float directocclusion,
      float reverbocclusion,
      bool doublesided,
      int numvertices,
      VECTOR[] vertices,
      out int polygonindex)
    {
      return Geometry.FMOD5_Geometry_AddPolygon(this.handle, directocclusion, reverbocclusion, doublesided, numvertices, vertices, out polygonindex);
    }

    public RESULT getNumPolygons(out int numpolygons)
    {
      return Geometry.FMOD5_Geometry_GetNumPolygons(this.handle, out numpolygons);
    }

    public RESULT getMaxPolygons(out int maxpolygons, out int maxvertices)
    {
      return Geometry.FMOD5_Geometry_GetMaxPolygons(this.handle, out maxpolygons, out maxvertices);
    }

    public RESULT getPolygonNumVertices(int index, out int numvertices)
    {
      return Geometry.FMOD5_Geometry_GetPolygonNumVertices(this.handle, index, out numvertices);
    }

    public RESULT setPolygonVertex(int index, int vertexindex, ref VECTOR vertex)
    {
      return Geometry.FMOD5_Geometry_SetPolygonVertex(this.handle, index, vertexindex, ref vertex);
    }

    public RESULT getPolygonVertex(int index, int vertexindex, out VECTOR vertex)
    {
      return Geometry.FMOD5_Geometry_GetPolygonVertex(this.handle, index, vertexindex, out vertex);
    }

    public RESULT setPolygonAttributes(
      int index,
      float directocclusion,
      float reverbocclusion,
      bool doublesided)
    {
      return Geometry.FMOD5_Geometry_SetPolygonAttributes(this.handle, index, directocclusion, reverbocclusion, doublesided);
    }

    public RESULT getPolygonAttributes(
      int index,
      out float directocclusion,
      out float reverbocclusion,
      out bool doublesided)
    {
      return Geometry.FMOD5_Geometry_GetPolygonAttributes(this.handle, index, out directocclusion, out reverbocclusion, out doublesided);
    }

    public RESULT setActive(bool active) => Geometry.FMOD5_Geometry_SetActive(this.handle, active);

    public RESULT getActive(out bool active)
    {
      return Geometry.FMOD5_Geometry_GetActive(this.handle, out active);
    }

    public RESULT setRotation(ref VECTOR forward, ref VECTOR up)
    {
      return Geometry.FMOD5_Geometry_SetRotation(this.handle, ref forward, ref up);
    }

    public RESULT getRotation(out VECTOR forward, out VECTOR up)
    {
      return Geometry.FMOD5_Geometry_GetRotation(this.handle, out forward, out up);
    }

    public RESULT setPosition(ref VECTOR position)
    {
      return Geometry.FMOD5_Geometry_SetPosition(this.handle, ref position);
    }

    public RESULT getPosition(out VECTOR position)
    {
      return Geometry.FMOD5_Geometry_GetPosition(this.handle, out position);
    }

    public RESULT setScale(ref VECTOR scale)
    {
      return Geometry.FMOD5_Geometry_SetScale(this.handle, ref scale);
    }

    public RESULT getScale(out VECTOR scale)
    {
      return Geometry.FMOD5_Geometry_GetScale(this.handle, out scale);
    }

    public RESULT save(IntPtr data, out int datasize)
    {
      return Geometry.FMOD5_Geometry_Save(this.handle, data, out datasize);
    }

    public RESULT setUserData(IntPtr userdata)
    {
      return Geometry.FMOD5_Geometry_SetUserData(this.handle, userdata);
    }

    public RESULT getUserData(out IntPtr userdata)
    {
      return Geometry.FMOD5_Geometry_GetUserData(this.handle, out userdata);
    }

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Geometry_Release(IntPtr geometry);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Geometry_AddPolygon(
      IntPtr geometry,
      float directocclusion,
      float reverbocclusion,
      bool doublesided,
      int numvertices,
      VECTOR[] vertices,
      out int polygonindex);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Geometry_GetNumPolygons(IntPtr geometry, out int numpolygons);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Geometry_GetMaxPolygons(
      IntPtr geometry,
      out int maxpolygons,
      out int maxvertices);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Geometry_GetPolygonNumVertices(
      IntPtr geometry,
      int index,
      out int numvertices);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Geometry_SetPolygonVertex(
      IntPtr geometry,
      int index,
      int vertexindex,
      ref VECTOR vertex);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Geometry_GetPolygonVertex(
      IntPtr geometry,
      int index,
      int vertexindex,
      out VECTOR vertex);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Geometry_SetPolygonAttributes(
      IntPtr geometry,
      int index,
      float directocclusion,
      float reverbocclusion,
      bool doublesided);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Geometry_GetPolygonAttributes(
      IntPtr geometry,
      int index,
      out float directocclusion,
      out float reverbocclusion,
      out bool doublesided);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Geometry_SetActive(IntPtr geometry, bool active);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Geometry_GetActive(IntPtr geometry, out bool active);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Geometry_SetRotation(
      IntPtr geometry,
      ref VECTOR forward,
      ref VECTOR up);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Geometry_GetRotation(
      IntPtr geometry,
      out VECTOR forward,
      out VECTOR up);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Geometry_SetPosition(IntPtr geometry, ref VECTOR position);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Geometry_GetPosition(IntPtr geometry, out VECTOR position);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Geometry_SetScale(IntPtr geometry, ref VECTOR scale);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Geometry_GetScale(IntPtr geometry, out VECTOR scale);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Geometry_Save(
      IntPtr geometry,
      IntPtr data,
      out int datasize);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Geometry_SetUserData(IntPtr geometry, IntPtr userdata);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Geometry_GetUserData(IntPtr geometry, out IntPtr userdata);

    public bool hasHandle() => this.handle != IntPtr.Zero;

    public void clearHandle() => this.handle = IntPtr.Zero;
  }
}
