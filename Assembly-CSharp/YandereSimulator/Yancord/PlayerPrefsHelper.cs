// Decompiled with JetBrains decompiler
// Type: YandereSimulator.Yancord.PlayerPrefsHelper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace YandereSimulator.Yancord
{
  public static class PlayerPrefsHelper
  {
    public static void SetBool(string name, bool flag) => PlayerPrefs.SetInt(name, flag ? 1 : 0);

    public static bool GetBool(string name) => PlayerPrefs.GetInt(name) == 1;
  }
}
