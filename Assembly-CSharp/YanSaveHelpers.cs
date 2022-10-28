// Decompiled with JetBrains decompiler
// Type: YanSaveHelpers
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Reflection;

public static class YanSaveHelpers
{
  public static System.Type GrabType(string type)
  {
    if (string.IsNullOrEmpty(type))
      return (System.Type) null;
    foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
    {
      System.Type type1 = assembly.GetType(type);
      if (type1 != (System.Type) null)
        return type1;
    }
    return (System.Type) null;
  }
}
