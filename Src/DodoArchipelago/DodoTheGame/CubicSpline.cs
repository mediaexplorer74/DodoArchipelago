// Decompiled with JetBrains decompiler
// Type: DodoTheGame.CubicSpline
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;


namespace DodoTheGame
{
  public class CubicSpline
  {
    private float[] a;
    private float[] b;
    private float[] xOrig;
    private float[] yOrig;
    private int _lastIndex;

    public CubicSpline()
    {
    }

    public CubicSpline(float[] x, float[] y, float startSlope = float.NaN, float endSlope = float.NaN, bool debug = false)
    {
      this.Fit(x, y, startSlope, endSlope, debug);
    }

    private void CheckAlreadyFitted()
    {
      if (this.a == null)
        throw new Exception("Fit must be called before you can evaluate.");
    }

    private int GetNextXIndex(float x)
    {
      if ((double) x < (double) this.xOrig[this._lastIndex])
        throw new ArgumentException("The X values to evaluate must be sorted.");
      while (this._lastIndex < this.xOrig.Length - 2 && (double) x > (double) this.xOrig[this._lastIndex + 1])
        ++this._lastIndex;
      return this._lastIndex;
    }

    private float EvalSpline(float x, int j, bool debug = false)
    {
      float num1 = this.xOrig[j + 1] - this.xOrig[j];
      float num2 = (x - this.xOrig[j]) / num1;
      double num3 = (1.0 - (double) num2) * (double) this.yOrig[j] + (double) num2 * (double) this.yOrig[j + 1] + (double) num2 * (1.0 - (double) num2) * ((double) this.a[j] * (1.0 - (double) num2) + (double) this.b[j] * (double) num2);
      if (!debug)
        return (float) num3;
      Console.WriteLine("xs = {0}, j = {1}, t = {2}", (object) x, (object) j, (object) num2);
      return (float) num3;
    }

    public float[] FitAndEval(
      float[] x,
      float[] y,
      float[] xs,
      float startSlope = float.NaN,
      float endSlope = float.NaN,
      bool debug = false)
    {
      this.Fit(x, y, startSlope, endSlope, debug);
      return this.Eval(xs, debug);
    }

    public void Fit(float[] x, float[] y, float startSlope = float.NaN, float endSlope = float.NaN, bool debug = false)
    {
      if (float.IsInfinity(startSlope) || float.IsInfinity(endSlope))
        throw new Exception("startSlope and endSlope cannot be infinity.");
      this.xOrig = x;
      this.yOrig = y;
      int length = x.Length;
      float[] d = new float[length];
      TriDiagonalMatrixF triDiagonalMatrixF = new TriDiagonalMatrixF(length);
      if (float.IsNaN(startSlope))
      {
        float num = x[1] - x[0];
        triDiagonalMatrixF.C[0] = 1f / num;
        triDiagonalMatrixF.B[0] = 2f * triDiagonalMatrixF.C[0];
        d[0] = (float) (3.0 * ((double) y[1] - (double) y[0]) / ((double) num * (double) num));
      }
      else
      {
        triDiagonalMatrixF.B[0] = 1f;
        d[0] = startSlope;
      }
      for (int index = 1; index < length - 1; ++index)
      {
        float num1 = x[index] - x[index - 1];
        float num2 = x[index + 1] - x[index];
        triDiagonalMatrixF.A[index] = 1f / num1;
        triDiagonalMatrixF.C[index] = 1f / num2;
        triDiagonalMatrixF.B[index] = (float) (2.0 * ((double) triDiagonalMatrixF.A[index] + (double) triDiagonalMatrixF.C[index]));
        float num3 = y[index] - y[index - 1];
        float num4 = y[index + 1] - y[index];
        d[index] = (float) (3.0 * ((double) num3 / ((double) num1 * (double) num1) + (double) num4 / ((double) num2 * (double) num2)));
      }
      if (float.IsNaN(endSlope))
      {
        float num5 = x[length - 1] - x[length - 2];
        float num6 = y[length - 1] - y[length - 2];
        triDiagonalMatrixF.A[length - 1] = 1f / num5;
        triDiagonalMatrixF.B[length - 1] = 2f * triDiagonalMatrixF.A[length - 1];
        d[length - 1] = (float) (3.0 * ((double) num6 / ((double) num5 * (double) num5)));
      }
      else
      {
        triDiagonalMatrixF.B[length - 1] = 1f;
        d[length - 1] = endSlope;
      }
      float[] array = triDiagonalMatrixF.Solve(d);
      if (debug)
        Console.WriteLine("k = {0}", (object) ArrayUtil.ToString<float>(array));
      this.a = new float[length - 1];
      this.b = new float[length - 1];
      for (int index = 1; index < length; ++index)
      {
        float num7 = x[index] - x[index - 1];
        float num8 = y[index] - y[index - 1];
        this.a[index - 1] = array[index - 1] * num7 - num8;
        this.b[index - 1] = -array[index] * num7 + num8;
      }
      if (debug)
        Console.WriteLine("a: {0}", (object) ArrayUtil.ToString<float>(this.a));
      if (!debug)
        return;
      Console.WriteLine("b: {0}", (object) ArrayUtil.ToString<float>(this.b));
    }

    public float[] Eval(float[] x, bool debug = false)
    {
      this.CheckAlreadyFitted();
      int length = x.Length;
      float[] numArray = new float[length];
      this._lastIndex = 0;
      for (int index = 0; index < length; ++index)
      {
        int nextXindex = this.GetNextXIndex(x[index]);
        numArray[index] = this.EvalSpline(x[index], nextXindex, debug);
      }
      return numArray;
    }

    public float[] EvalSlope(float[] x, bool debug = false)
    {
      this.CheckAlreadyFitted();
      int length = x.Length;
      float[] numArray = new float[length];
      this._lastIndex = 0;
      for (int index = 0; index < length; ++index)
      {
        int nextXindex = this.GetNextXIndex(x[index]);
        float num1 = this.xOrig[nextXindex + 1] - this.xOrig[nextXindex];
        float num2 = this.yOrig[nextXindex + 1] - this.yOrig[nextXindex];
        float num3 = (x[index] - this.xOrig[nextXindex]) / num1;
        numArray[index] = (float) ((double) num2 / (double) num1 + (1.0 - 2.0 * (double) num3) * ((double) this.a[nextXindex] * (1.0 - (double) num3) + (double) this.b[nextXindex] * (double) num3) / (double) num1 + (double) num3 * (1.0 - (double) num3) * ((double) this.b[nextXindex] - (double) this.a[nextXindex]) / (double) num1);
        if (debug)
          Console.WriteLine("[{0}]: xs = {1}, j = {2}, t = {3}", new object[4]
          {
            (object) index,
            (object) x[index],
            (object) nextXindex,
            (object) num3
          });
      }
      return numArray;
    }

    public static float[] Compute(
      float[] x,
      float[] y,
      float[] xs,
      float startSlope = float.NaN,
      float endSlope = float.NaN,
      bool debug = false)
    {
      return new CubicSpline().FitAndEval(x, y, xs, startSlope, endSlope, debug);
    }

    public static void FitParametric(
      float[] x,
      float[] y,
      int nOutputPoints,
      out float[] xs,
      out float[] ys,
      float firstDx = float.NaN,
      float firstDy = float.NaN,
      float lastDx = float.NaN,
      float lastDy = float.NaN)
    {
      int length = x.Length;
      float[] x1 = new float[length];
      x1[0] = 0.0f;
      float num1 = 0.0f;
      for (int index = 1; index < length; ++index)
      {
        double num2 = (double) x[index] - (double) x[index - 1];
        float num3 = y[index] - y[index - 1];
        float num4 = (float) Math.Sqrt(num2 * num2 + (double) num3 * (double) num3);
        num1 += num4;
        x1[index] = num1;
      }
      float num5 = num1 / (float) (nOutputPoints - 1);
      float[] xs1 = new float[nOutputPoints];
      xs1[0] = 0.0f;
      for (int index = 1; index < nOutputPoints; ++index)
        xs1[index] = xs1[index - 1] + num5;
      CubicSpline.NormalizeVector(ref firstDx, ref firstDy);
      CubicSpline.NormalizeVector(ref lastDx, ref lastDy);
      CubicSpline cubicSpline1 = new CubicSpline();
      xs = cubicSpline1.FitAndEval(x1, x, xs1, firstDx / num5, lastDx / num5);
      CubicSpline cubicSpline2 = new CubicSpline();
      ys = cubicSpline2.FitAndEval(x1, y, xs1, firstDy / num5, lastDy / num5);
    }

    private static void NormalizeVector(ref float dx, ref float dy)
    {
      if (!float.IsNaN(dx) && !float.IsNaN(dy))
      {
        float num = (float) Math.Sqrt((double) dx * (double) dx + (double) dy * (double) dy);
        if ((double) num <= 1.4012984643248171E-45)
          throw new ArgumentException("The input vector is too small to be normalized.");
        dx /= num;
        dy /= num;
      }
      else
        dx = dy = float.NaN;
    }
  }
}
