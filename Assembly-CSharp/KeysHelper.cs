// Decompiled with JetBrains decompiler
// Type: KeysHelper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

public static class KeysHelper
{
  private const string KeyListPrefix = "Keys";
  private const char KeyListSeparator = '|';
  public const char PairSeparator = '^';

  public static int[] GetIntegerKeys(string key) => Array.ConvertAll<string, int>(KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key))), (Converter<string, int>) (str => int.Parse(str)));

  public static string[] GetStringKeys(string key) => KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key)));

  public static T[] GetEnumKeys<T>(string key) where T : struct, IConvertible => Array.ConvertAll<string, T>(KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key))), (Converter<string, T>) (str => (T) Enum.Parse(typeof (T), str)));

  public static KeyValuePair<T, U>[] GetKeys<T, U>(string key)
    where T : struct
    where U : struct
  {
    string[] strArray1 = KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key)));
    KeyValuePair<T, U>[] keys = new KeyValuePair<T, U>[strArray1.Length];
    for (int index = 0; index < strArray1.Length; ++index)
    {
      string[] strArray2 = strArray1[index].Split('^');
      keys[index] = new KeyValuePair<T, U>((T) (ValueType) int.Parse(strArray2[0]), (U) (ValueType) int.Parse(strArray2[1]));
    }
    return keys;
  }

  public static void AddIfMissing(string key, string id)
  {
    string keyListKey = KeysHelper.GetKeyListKey(key);
    string keyList = KeysHelper.GetKeyList(keyListKey);
    if (KeysHelper.HasKey(KeysHelper.SplitList(keyList), id))
      return;
    KeysHelper.AppendKey(keyListKey, keyList, id);
  }

  public static void Delete(string key) => Globals.Delete(KeysHelper.GetKeyListKey(key));

  private static string GetKeyListKey(string key) => key + "Keys";

  private static string GetKeyList(string keyListKey) => PlayerPrefs.GetString(keyListKey);

  private static string[] SplitList(string keyList)
  {
    if (keyList.Length <= 0)
      return new string[0];
    return keyList.Split('|');
  }

  private static int FindKey(string[] keyListStrings, string key) => Array.IndexOf<string>(keyListStrings, key);

  private static bool HasKey(string[] keyListStrings, string key) => KeysHelper.FindKey(keyListStrings, key) > -1;

  private static void AppendKey(string keyListKey, string keyList, string key)
  {
    string str = keyList.Length == 0 ? keyList + key : keyList + "|" + key;
    PlayerPrefs.SetString(keyListKey, str);
  }
}
