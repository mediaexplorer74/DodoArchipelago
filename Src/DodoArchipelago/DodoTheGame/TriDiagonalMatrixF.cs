// Decompiled with JetBrains decompiler
// Type: DodoTheGame.TriDiagonalMatrixF
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;
using System.Text;


namespace DodoTheGame
{
  public class TriDiagonalMatrixF
  {
    public float[] A;
    public float[] B;
    public float[] C;

    public int N => this.A == null ? 0 : this.A.Length;

    public float this[int row, int col]
    {
      get
      {
        switch (row - col)
        {
          case -1:
            return this.C[row];
          case 0:
            return this.B[row];
          case 1:
            return this.A[row];
          default:
            return 0.0f;
        }
      }
      set
      {
        switch (row - col)
        {
          case -1:
            this.C[row] = value;
            break;
          case 0:
            this.B[row] = value;
            break;
          case 1:
            this.A[row] = value;
            break;
          default:
            throw new ArgumentException("Only the main, super, and sub diagonals can be set.");
        }
      }
    }

    public TriDiagonalMatrixF(int n)
    {
      this.A = new float[n];
      this.B = new float[n];
      this.C = new float[n];
    }

    public string ToDisplayString(string fmt = "", string prefix = "")
    {
      if (this.N <= 0)
        return prefix + "0x0 Matrix";
      StringBuilder stringBuilder = new StringBuilder();
      string format = "{0" + fmt + "}";
      for (int row = 0; row < this.N; ++row)
      {
        stringBuilder.Append(prefix);
        for (int col = 0; col < this.N; ++col)
        {
          stringBuilder.AppendFormat(format, (object) this[row, col]);
          if (col < this.N - 1)
            stringBuilder.Append(", ");
        }
        stringBuilder.AppendLine();
      }
      return stringBuilder.ToString();
    }

    public float[] Solve(float[] d)
    {
      int n = this.N;
      if (d.Length != n)
        throw new ArgumentException("The input d is not the same size as this matrix.");
      float[] numArray1 = new float[n];
      numArray1[0] = this.C[0] / this.B[0];
      for (int index = 1; index < n; ++index)
        numArray1[index] = this.C[index] / (this.B[index] - numArray1[index - 1] * this.A[index]);
      float[] numArray2 = new float[n];
      numArray2[0] = d[0] / this.B[0];
      for (int index = 1; index < n; ++index)
        numArray2[index] = (float) (((double) d[index] - (double) numArray2[index - 1] * (double) this.A[index]) / ((double) this.B[index] - (double) numArray1[index - 1] * (double) this.A[index]));
      float[] numArray3 = new float[n];
      numArray3[n - 1] = numArray2[n - 1];
      for (int index = n - 2; index >= 0; --index)
        numArray3[index] = numArray2[index] - numArray1[index] * numArray3[index + 1];
      return numArray3;
    }
  }
}
