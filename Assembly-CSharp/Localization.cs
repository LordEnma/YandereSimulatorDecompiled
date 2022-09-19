// Decompiled with JetBrains decompiler
// Type: Localization
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

public static class Localization
{
  public static Localization.LoadFunction loadFunction;
  public static Localization.OnLocalizeNotification onLocalize;
  public static bool localizationHasBeenSet = false;
  private static string[] mLanguages = (string[]) null;
  private static Dictionary<string, string> mOldDictionary = new Dictionary<string, string>();
  private static Dictionary<string, string[]> mDictionary = new Dictionary<string, string[]>();
  private static Dictionary<string, string> mReplacement = new Dictionary<string, string>();
  private static int mLanguageIndex = -1;
  private static string mLanguage;
  private static bool mMerging = false;

  public static Dictionary<string, string[]> dictionary
  {
    get
    {
      if (!Localization.localizationHasBeenSet)
        Localization.LoadDictionary(PlayerPrefs.GetString("Language", "English"));
      return Localization.mDictionary;
    }
    set
    {
      Localization.localizationHasBeenSet = value != null;
      Localization.mDictionary = value;
    }
  }

  public static string[] knownLanguages
  {
    get
    {
      if (!Localization.localizationHasBeenSet)
        Localization.LoadDictionary(PlayerPrefs.GetString("Language", "English"));
      return Localization.mLanguages;
    }
  }

  public static string language
  {
    get
    {
      if (string.IsNullOrEmpty(Localization.mLanguage))
      {
        Localization.mLanguage = PlayerPrefs.GetString("Language", "English");
        Localization.LoadAndSelect(Localization.mLanguage);
      }
      return Localization.mLanguage;
    }
    set
    {
      if (!(Localization.mLanguage != value))
        return;
      Localization.mLanguage = value;
      Localization.LoadAndSelect(value);
    }
  }

  public static bool Reload()
  {
    Localization.localizationHasBeenSet = false;
    if (!Localization.LoadDictionary(Localization.mLanguage, true))
      return false;
    if (Localization.onLocalize != null)
      Localization.onLocalize();
    UIRoot.Broadcast("OnLocalize");
    return true;
  }

  private static bool LoadDictionary(string value, bool merge = false)
  {
    byte[] bytes = (byte[]) null;
    if (!Localization.localizationHasBeenSet)
    {
      if (Localization.loadFunction == null)
      {
        TextAsset textAsset = Resources.Load<TextAsset>(nameof (Localization));
        if ((UnityEngine.Object) textAsset != (UnityEngine.Object) null)
          bytes = textAsset.bytes;
      }
      else
        bytes = Localization.loadFunction(nameof (Localization));
      Localization.localizationHasBeenSet = true;
    }
    if (Localization.LoadCSV(bytes, merge))
      return true;
    if (string.IsNullOrEmpty(value))
      value = Localization.mLanguage;
    if (string.IsNullOrEmpty(value))
      return false;
    if (Localization.loadFunction == null)
    {
      TextAsset textAsset = Resources.Load<TextAsset>(value);
      if ((UnityEngine.Object) textAsset != (UnityEngine.Object) null)
        bytes = textAsset.bytes;
    }
    else
      bytes = Localization.loadFunction(value);
    if (bytes == null)
      return false;
    Localization.Set(value, bytes);
    return true;
  }

  private static bool LoadAndSelect(string value)
  {
    if (!string.IsNullOrEmpty(value))
    {
      if (Localization.mDictionary.Count == 0 && !Localization.LoadDictionary(value))
        return false;
      if (Localization.SelectLanguage(value))
        return true;
    }
    if (Localization.mOldDictionary.Count > 0)
      return true;
    Localization.mOldDictionary.Clear();
    Localization.mDictionary.Clear();
    if (string.IsNullOrEmpty(value))
      PlayerPrefs.DeleteKey("Language");
    return false;
  }

  public static void Load(TextAsset asset)
  {
    ByteReader byteReader = new ByteReader(asset);
    Localization.Set(asset.name, byteReader.ReadDictionary());
  }

  public static void Set(string languageName, byte[] bytes)
  {
    ByteReader byteReader = new ByteReader(bytes);
    Localization.Set(languageName, byteReader.ReadDictionary());
  }

  public static void ReplaceKey(string key, string val)
  {
    if (!string.IsNullOrEmpty(val))
      Localization.mReplacement[key] = val;
    else
      Localization.mReplacement.Remove(key);
  }

  public static void ClearReplacements() => Localization.mReplacement.Clear();

  public static bool LoadCSV(TextAsset asset, bool merge = false) => Localization.LoadCSV(asset.bytes, asset, merge);

  public static bool LoadCSV(byte[] bytes, bool merge = false) => Localization.LoadCSV(bytes, (TextAsset) null, merge);

  private static bool HasLanguage(string languageName)
  {
    int index = 0;
    for (int length = Localization.mLanguages.Length; index < length; ++index)
    {
      if (Localization.mLanguages[index] == languageName)
        return true;
    }
    return false;
  }

  private static bool LoadCSV(byte[] bytes, TextAsset asset, bool merge = false)
  {
    if (bytes == null)
      return false;
    ByteReader byteReader = new ByteReader(bytes);
    BetterList<string> betterList = byteReader.ReadCSV();
    if (betterList.size < 2)
      return false;
    betterList.RemoveAt(0);
    string[] newLanguages = (string[]) null;
    if (string.IsNullOrEmpty(Localization.mLanguage))
      Localization.localizationHasBeenSet = false;
    if (!Localization.localizationHasBeenSet || !merge && !Localization.mMerging || Localization.mLanguages == null || Localization.mLanguages.Length == 0)
    {
      Localization.mDictionary.Clear();
      Localization.mLanguages = new string[betterList.size];
      if (!Localization.localizationHasBeenSet)
      {
        Localization.mLanguage = PlayerPrefs.GetString("Language", betterList.buffer[0]);
        Localization.localizationHasBeenSet = true;
      }
      for (int index = 0; index < betterList.size; ++index)
      {
        Localization.mLanguages[index] = betterList.buffer[index];
        if (Localization.mLanguages[index] == Localization.mLanguage)
          Localization.mLanguageIndex = index;
      }
    }
    else
    {
      newLanguages = new string[betterList.size];
      for (int index = 0; index < betterList.size; ++index)
        newLanguages[index] = betterList.buffer[index];
      for (int index = 0; index < betterList.size; ++index)
      {
        if (!Localization.HasLanguage(betterList.buffer[index]))
        {
          int newSize = Localization.mLanguages.Length + 1;
          Array.Resize<string>(ref Localization.mLanguages, newSize);
          Localization.mLanguages[newSize - 1] = betterList.buffer[index];
          Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();
          foreach (KeyValuePair<string, string[]> m in Localization.mDictionary)
          {
            string[] array = m.Value;
            Array.Resize<string>(ref array, newSize);
            array[newSize - 1] = array[0];
            dictionary.Add(m.Key, array);
          }
          Localization.mDictionary = dictionary;
        }
      }
    }
    Dictionary<string, int> languageIndices = new Dictionary<string, int>();
    for (int index = 0; index < Localization.mLanguages.Length; ++index)
      languageIndices.Add(Localization.mLanguages[index], index);
    while (true)
    {
      BetterList<string> newValues;
      do
      {
        newValues = byteReader.ReadCSV();
        if (newValues == null || newValues.size == 0)
          goto label_33;
      }
      while (string.IsNullOrEmpty(newValues.buffer[0]));
      Localization.AddCSV(newValues, newLanguages, languageIndices);
    }
label_33:
    if (!Localization.mMerging && Localization.onLocalize != null)
    {
      Localization.mMerging = true;
      Localization.OnLocalizeNotification onLocalize = Localization.onLocalize;
      Localization.onLocalize = (Localization.OnLocalizeNotification) null;
      onLocalize();
      Localization.onLocalize = onLocalize;
      Localization.mMerging = false;
    }
    if (merge)
    {
      if (Localization.onLocalize != null)
        Localization.onLocalize();
      UIRoot.Broadcast("OnLocalize");
    }
    return true;
  }

  private static void AddCSV(
    BetterList<string> newValues,
    string[] newLanguages,
    Dictionary<string, int> languageIndices)
  {
    if (newValues.size < 2)
      return;
    string key = newValues.buffer[0];
    if (string.IsNullOrEmpty(key))
      return;
    string[] strings = Localization.ExtractStrings(newValues, newLanguages, languageIndices);
    if (Localization.mDictionary.ContainsKey(key))
    {
      Localization.mDictionary[key] = strings;
      if (newLanguages != null)
        return;
      Debug.LogWarning((object) ("Localization key '" + key + "' is already present"));
    }
    else
    {
      try
      {
        Localization.mDictionary.Add(key, strings);
      }
      catch (Exception ex)
      {
        Debug.LogError((object) ("Unable to add '" + key + "' to the Localization dictionary.\n" + ex.Message));
      }
    }
  }

  private static string[] ExtractStrings(
    BetterList<string> added,
    string[] newLanguages,
    Dictionary<string, int> languageIndices)
  {
    if (newLanguages == null)
    {
      string[] strings = new string[Localization.mLanguages.Length];
      int index1 = 1;
      for (int index2 = Mathf.Min(added.size, strings.Length + 1); index1 < index2; ++index1)
        strings[index1 - 1] = added.buffer[index1];
      return strings;
    }
    string key = added.buffer[0];
    string[] strings1;
    if (!Localization.mDictionary.TryGetValue(key, out strings1))
      strings1 = new string[Localization.mLanguages.Length];
    int index = 0;
    for (int length = newLanguages.Length; index < length; ++index)
    {
      string newLanguage = newLanguages[index];
      int languageIndex = languageIndices[newLanguage];
      strings1[languageIndex] = added.buffer[index + 1];
    }
    return strings1;
  }

  private static bool SelectLanguage(string language)
  {
    Localization.mLanguageIndex = -1;
    if (Localization.mDictionary.Count == 0)
      return false;
    int index = 0;
    for (int length = Localization.mLanguages.Length; index < length; ++index)
    {
      if (Localization.mLanguages[index] == language)
      {
        Localization.mOldDictionary.Clear();
        Localization.mLanguageIndex = index;
        Localization.mLanguage = language;
        PlayerPrefs.SetString("Language", Localization.mLanguage);
        if (Localization.onLocalize != null)
          Localization.onLocalize();
        UIRoot.Broadcast("OnLocalize");
        return true;
      }
    }
    return false;
  }

  public static void Set(string languageName, Dictionary<string, string> dictionary)
  {
    Localization.mLanguage = languageName;
    PlayerPrefs.SetString("Language", Localization.mLanguage);
    Localization.mOldDictionary = dictionary;
    Localization.localizationHasBeenSet = true;
    Localization.mLanguageIndex = -1;
    Localization.mLanguages = new string[1]
    {
      languageName
    };
    if (Localization.onLocalize != null)
      Localization.onLocalize();
    UIRoot.Broadcast("OnLocalize");
  }

  public static void Set(string key, string value)
  {
    if (Localization.mOldDictionary.ContainsKey(key))
      Localization.mOldDictionary[key] = value;
    else
      Localization.mOldDictionary.Add(key, value);
  }

  public static bool Has(string key)
  {
    if (string.IsNullOrEmpty(key))
      return false;
    if (!Localization.localizationHasBeenSet)
      Localization.LoadDictionary(PlayerPrefs.GetString("Language", "English"));
    if (Localization.mLanguages == null)
      return false;
    string language = Localization.language;
    if (Localization.mLanguageIndex == -1)
    {
      for (int index = 0; index < Localization.mLanguages.Length; ++index)
      {
        if (Localization.mLanguages[index] == language)
        {
          Localization.mLanguageIndex = index;
          break;
        }
      }
    }
    if (Localization.mLanguageIndex == -1)
    {
      Localization.mLanguageIndex = 0;
      Localization.mLanguage = Localization.mLanguages[0];
    }
    switch (UICamera.currentScheme)
    {
      case UICamera.ControlScheme.Touch:
        string key1 = key + " Mobile";
        if (Localization.mReplacement.ContainsKey(key1) || Localization.mLanguageIndex != -1 && Localization.mDictionary.ContainsKey(key1) || Localization.mOldDictionary.ContainsKey(key1))
          return true;
        break;
      case UICamera.ControlScheme.Controller:
        string key2 = key + " Controller";
        if (Localization.mReplacement.ContainsKey(key2) || Localization.mLanguageIndex != -1 && Localization.mDictionary.ContainsKey(key2) || Localization.mOldDictionary.ContainsKey(key2))
          return true;
        break;
    }
    return Localization.mReplacement.ContainsKey(key) || Localization.mLanguageIndex != -1 && Localization.mDictionary.ContainsKey(key) || Localization.mOldDictionary.ContainsKey(key);
  }

  public static string Get(string key, bool warnIfMissing = true)
  {
    if (string.IsNullOrEmpty(key))
      return (string) null;
    if (!Localization.localizationHasBeenSet)
      Localization.LoadDictionary(PlayerPrefs.GetString("Language", "English"));
    if (Localization.mLanguages == null)
    {
      Debug.LogError((object) "No localization data present");
      return (string) null;
    }
    string language = Localization.language;
    if (Localization.mLanguageIndex == -1)
    {
      for (int index = 0; index < Localization.mLanguages.Length; ++index)
      {
        if (Localization.mLanguages[index] == language)
        {
          Localization.mLanguageIndex = index;
          break;
        }
      }
    }
    if (Localization.mLanguageIndex == -1)
    {
      Localization.mLanguageIndex = 0;
      Localization.mLanguage = Localization.mLanguages[0];
      Debug.LogWarning((object) ("Language not found: " + language));
    }
    string str1;
    string[] strArray;
    switch (UICamera.currentScheme)
    {
      case UICamera.ControlScheme.Touch:
        string key1 = key + " Mobile";
        if (Localization.mReplacement.TryGetValue(key1, out str1))
          return str1;
        if (Localization.mLanguageIndex != -1 && Localization.mDictionary.TryGetValue(key1, out strArray) && Localization.mLanguageIndex < strArray.Length)
          return strArray[Localization.mLanguageIndex];
        if (Localization.mOldDictionary.TryGetValue(key1, out str1))
          return str1;
        break;
      case UICamera.ControlScheme.Controller:
        string key2 = key + " Controller";
        if (Localization.mReplacement.TryGetValue(key2, out str1))
          return str1;
        if (Localization.mLanguageIndex != -1 && Localization.mDictionary.TryGetValue(key2, out strArray) && Localization.mLanguageIndex < strArray.Length)
          return strArray[Localization.mLanguageIndex];
        if (Localization.mOldDictionary.TryGetValue(key2, out str1))
          return str1;
        break;
    }
    if (Localization.mReplacement.TryGetValue(key, out str1))
      return str1;
    if (Localization.mLanguageIndex != -1 && Localization.mDictionary.TryGetValue(key, out strArray))
    {
      if (Localization.mLanguageIndex >= strArray.Length)
        return strArray[0];
      string str2 = strArray[Localization.mLanguageIndex];
      if (string.IsNullOrEmpty(str2))
        str2 = strArray[0];
      return str2;
    }
    return Localization.mOldDictionary.TryGetValue(key, out str1) ? str1 : key;
  }

  public static string Format(string key, object parameter)
  {
    try
    {
      return string.Format(Localization.Get(key), parameter);
    }
    catch (Exception ex)
    {
      Debug.LogError((object) ("string.Format(1): " + key));
      return key;
    }
  }

  public static string Format(string key, object arg0, object arg1)
  {
    try
    {
      return string.Format(Localization.Get(key), arg0, arg1);
    }
    catch (Exception ex)
    {
      Debug.LogError((object) ("string.Format(2): " + key));
      return key;
    }
  }

  public static string Format(string key, object arg0, object arg1, object arg2)
  {
    try
    {
      return string.Format(Localization.Get(key), arg0, arg1, arg2);
    }
    catch (Exception ex)
    {
      Debug.LogError((object) ("string.Format(3): " + key));
      return key;
    }
  }

  public static string Format(string key, params object[] parameters)
  {
    try
    {
      return string.Format(Localization.Get(key), parameters);
    }
    catch (Exception ex)
    {
      Debug.LogError((object) ("string.Format(" + parameters.Length.ToString() + "): " + key));
      return key;
    }
  }

  [Obsolete("Localization is now always active. You no longer need to check this property.")]
  public static bool isActive => true;

  [Obsolete("Use Localization.Get instead")]
  public static string Localize(string key) => Localization.Get(key);

  public static bool Exists(string key)
  {
    if (!Localization.localizationHasBeenSet)
      Localization.language = PlayerPrefs.GetString("Language", "English");
    return Localization.mDictionary.ContainsKey(key) || Localization.mOldDictionary.ContainsKey(key);
  }

  public static void Set(string language, string key, string text)
  {
    string[] strArray1 = Localization.knownLanguages;
    if (strArray1 == null)
    {
      Localization.mLanguages = new string[1]
      {
        language
      };
      strArray1 = Localization.mLanguages;
    }
    int index = 0;
    for (int length = strArray1.Length; index < length; ++index)
    {
      if (strArray1[index] == language)
      {
        string[] strArray2;
        if (!Localization.mDictionary.TryGetValue(key, out strArray2))
        {
          strArray2 = new string[strArray1.Length];
          Localization.mDictionary[key] = strArray2;
          strArray2[0] = text;
        }
        strArray2[index] = text;
        return;
      }
    }
    int newSize = Localization.mLanguages.Length + 1;
    Array.Resize<string>(ref Localization.mLanguages, newSize);
    Localization.mLanguages[newSize - 1] = language;
    Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();
    foreach (KeyValuePair<string, string[]> m in Localization.mDictionary)
    {
      string[] array = m.Value;
      Array.Resize<string>(ref array, newSize);
      array[newSize - 1] = array[0];
      dictionary.Add(m.Key, array);
    }
    Localization.mDictionary = dictionary;
    string[] strArray3;
    if (!Localization.mDictionary.TryGetValue(key, out strArray3))
    {
      strArray3 = new string[strArray1.Length];
      Localization.mDictionary[key] = strArray3;
      strArray3[0] = text;
    }
    strArray3[newSize - 1] = text;
  }

  public delegate byte[] LoadFunction(string path);

  public delegate void OnLocalizeNotification();
}
