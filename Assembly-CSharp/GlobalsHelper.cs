// Decompiled with JetBrains decompiler
// Type: GlobalsHelper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public static class GlobalsHelper
{
  public static bool GetBool(string key) => PlayerPrefs.GetInt(key) == 1;

  public static void SetBool(string key, bool value) => PlayerPrefs.SetInt(key, value ? 1 : 0);

  public static T GetEnum<T>(string key) where T : struct, IConvertible => (T) (ValueType) PlayerPrefs.GetInt(key);

  public static void SetEnum<T>(string key, T value) where T : struct, IConvertible => PlayerPrefs.SetInt(key, (int) (ValueType) value);

  public static Vector2 GetVector2(string key) => new Vector2(PlayerPrefs.GetFloat(key + "_X"), PlayerPrefs.GetFloat(key + "_Y"));

  public static void SetVector2(string key, Vector2 value)
  {
    PlayerPrefs.SetFloat(key + "_X", value.x);
    PlayerPrefs.SetFloat(key + "_Y", value.y);
  }

  public static void DeleteVector2(string key)
  {
    Globals.Delete(key + "_X");
    Globals.Delete(key + "_Y");
  }

  public static void DeleteVector2Collection(string key, int[] usedKeys)
  {
    foreach (int usedKey in usedKeys)
      GlobalsHelper.DeleteVector2(key + usedKey.ToString());
    KeysHelper.Delete(key);
  }

  public static Vector3 GetVector3(string key)
  {
    double x = (double) PlayerPrefs.GetFloat(key + "_X");
    float num1 = PlayerPrefs.GetFloat(key + "_Y");
    float num2 = PlayerPrefs.GetFloat(key + "_Z");
    double y = (double) num1;
    double z = (double) num2;
    return new Vector3((float) x, (float) y, (float) z);
  }

  public static void SetVector3(string key, Vector3 value)
  {
    PlayerPrefs.SetFloat(key + "_X", value.x);
    PlayerPrefs.SetFloat(key + "_Y", value.y);
    PlayerPrefs.SetFloat(key + "_Z", value.z);
  }

  public static void DeleteVector3(string key)
  {
    Globals.Delete(key + "_X");
    Globals.Delete(key + "_Y");
    Globals.Delete(key + "_Z");
  }

  public static void DeleteVector3Collection(string key, int[] usedKeys)
  {
    foreach (int usedKey in usedKeys)
      GlobalsHelper.DeleteVector3(key + usedKey.ToString());
    KeysHelper.Delete(key);
  }

  public static Vector4 GetVector4(string key)
  {
    double x = (double) PlayerPrefs.GetFloat(key + "_W");
    float num1 = PlayerPrefs.GetFloat(key + "_X");
    float num2 = PlayerPrefs.GetFloat(key + "_Y");
    float num3 = PlayerPrefs.GetFloat(key + "_Z");
    double y = (double) num1;
    double z = (double) num2;
    double w = (double) num3;
    return new Vector4((float) x, (float) y, (float) z, (float) w);
  }

  public static void SetVector4(string key, Vector4 value)
  {
    PlayerPrefs.SetFloat(key + "_W", value.w);
    PlayerPrefs.SetFloat(key + "_X", value.x);
    PlayerPrefs.SetFloat(key + "_Y", value.y);
    PlayerPrefs.SetFloat(key + "_Z", value.z);
  }

  public static void DeleteVector4(string key)
  {
    Globals.Delete(key + "_W");
    Globals.Delete(key + "_X");
    Globals.Delete(key + "_Y");
    Globals.Delete(key + "_Z");
  }

  public static Color GetColor(string key)
  {
    double r = (double) PlayerPrefs.GetFloat(key + "_R");
    float num1 = PlayerPrefs.GetFloat(key + "_G");
    float num2 = PlayerPrefs.GetFloat(key + "_B");
    float num3 = PlayerPrefs.GetFloat(key + "_A");
    double g = (double) num1;
    double b = (double) num2;
    double a = (double) num3;
    return new Color((float) r, (float) g, (float) b, (float) a);
  }

  public static void SetColor(string key, Color value)
  {
    PlayerPrefs.SetFloat(key + "_R", value.r);
    PlayerPrefs.SetFloat(key + "_G", value.g);
    PlayerPrefs.SetFloat(key + "_B", value.b);
    PlayerPrefs.SetFloat(key + "_A", value.a);
  }

  public static void DeleteColor(string key)
  {
    Globals.Delete(key + "_R");
    Globals.Delete(key + "_G");
    Globals.Delete(key + "_B");
    Globals.Delete(key + "_A");
  }

  public static void DeleteColorCollection(string key, int[] usedKeys)
  {
    foreach (int usedKey in usedKeys)
      GlobalsHelper.DeleteColor(key + usedKey.ToString());
    KeysHelper.Delete(key);
  }
}
