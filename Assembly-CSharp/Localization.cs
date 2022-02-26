using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000073 RID: 115
public static class Localization
{
	// Token: 0x1700005E RID: 94
	// (get) Token: 0x06000353 RID: 851 RVA: 0x0002172E File Offset: 0x0001F92E
	// (set) Token: 0x06000354 RID: 852 RVA: 0x00021752 File Offset: 0x0001F952
	public static Dictionary<string, string[]> dictionary
	{
		get
		{
			if (!Localization.localizationHasBeenSet)
			{
				Localization.LoadDictionary(PlayerPrefs.GetString("Language", "English"), false);
			}
			return Localization.mDictionary;
		}
		set
		{
			Localization.localizationHasBeenSet = (value != null);
			Localization.mDictionary = value;
		}
	}

	// Token: 0x1700005F RID: 95
	// (get) Token: 0x06000355 RID: 853 RVA: 0x00021763 File Offset: 0x0001F963
	public static string[] knownLanguages
	{
		get
		{
			if (!Localization.localizationHasBeenSet)
			{
				Localization.LoadDictionary(PlayerPrefs.GetString("Language", "English"), false);
			}
			return Localization.mLanguages;
		}
	}

	// Token: 0x17000060 RID: 96
	// (get) Token: 0x06000356 RID: 854 RVA: 0x00021787 File Offset: 0x0001F987
	// (set) Token: 0x06000357 RID: 855 RVA: 0x000217B9 File Offset: 0x0001F9B9
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
			if (Localization.mLanguage != value)
			{
				Localization.mLanguage = value;
				Localization.LoadAndSelect(value);
			}
		}
	}

	// Token: 0x06000358 RID: 856 RVA: 0x000217D5 File Offset: 0x0001F9D5
	public static bool Reload()
	{
		Localization.localizationHasBeenSet = false;
		if (!Localization.LoadDictionary(Localization.mLanguage, true))
		{
			return false;
		}
		if (Localization.onLocalize != null)
		{
			Localization.onLocalize();
		}
		UIRoot.Broadcast("OnLocalize");
		return true;
	}

	// Token: 0x06000359 RID: 857 RVA: 0x00021808 File Offset: 0x0001FA08
	private static bool LoadDictionary(string value, bool merge = false)
	{
		byte[] array = null;
		if (!Localization.localizationHasBeenSet)
		{
			if (Localization.loadFunction == null)
			{
				TextAsset textAsset = Resources.Load<TextAsset>("Localization");
				if (textAsset != null)
				{
					array = textAsset.bytes;
				}
			}
			else
			{
				array = Localization.loadFunction("Localization");
			}
			Localization.localizationHasBeenSet = true;
		}
		if (Localization.LoadCSV(array, merge))
		{
			return true;
		}
		if (string.IsNullOrEmpty(value))
		{
			value = Localization.mLanguage;
		}
		if (string.IsNullOrEmpty(value))
		{
			return false;
		}
		if (Localization.loadFunction == null)
		{
			TextAsset textAsset2 = Resources.Load<TextAsset>(value);
			if (textAsset2 != null)
			{
				array = textAsset2.bytes;
			}
		}
		else
		{
			array = Localization.loadFunction(value);
		}
		if (array != null)
		{
			Localization.Set(value, array);
			return true;
		}
		return false;
	}

	// Token: 0x0600035A RID: 858 RVA: 0x000218B8 File Offset: 0x0001FAB8
	private static bool LoadAndSelect(string value)
	{
		if (!string.IsNullOrEmpty(value))
		{
			if (Localization.mDictionary.Count == 0 && !Localization.LoadDictionary(value, false))
			{
				return false;
			}
			if (Localization.SelectLanguage(value))
			{
				return true;
			}
		}
		if (Localization.mOldDictionary.Count > 0)
		{
			return true;
		}
		Localization.mOldDictionary.Clear();
		Localization.mDictionary.Clear();
		if (string.IsNullOrEmpty(value))
		{
			PlayerPrefs.DeleteKey("Language");
		}
		return false;
	}

	// Token: 0x0600035B RID: 859 RVA: 0x00021924 File Offset: 0x0001FB24
	public static void Load(TextAsset asset)
	{
		ByteReader byteReader = new ByteReader(asset);
		Localization.Set(asset.name, byteReader.ReadDictionary());
	}

	// Token: 0x0600035C RID: 860 RVA: 0x0002194C File Offset: 0x0001FB4C
	public static void Set(string languageName, byte[] bytes)
	{
		ByteReader byteReader = new ByteReader(bytes);
		Localization.Set(languageName, byteReader.ReadDictionary());
	}

	// Token: 0x0600035D RID: 861 RVA: 0x0002196C File Offset: 0x0001FB6C
	public static void ReplaceKey(string key, string val)
	{
		if (!string.IsNullOrEmpty(val))
		{
			Localization.mReplacement[key] = val;
			return;
		}
		Localization.mReplacement.Remove(key);
	}

	// Token: 0x0600035E RID: 862 RVA: 0x0002198F File Offset: 0x0001FB8F
	public static void ClearReplacements()
	{
		Localization.mReplacement.Clear();
	}

	// Token: 0x0600035F RID: 863 RVA: 0x0002199B File Offset: 0x0001FB9B
	public static bool LoadCSV(TextAsset asset, bool merge = false)
	{
		return Localization.LoadCSV(asset.bytes, asset, merge);
	}

	// Token: 0x06000360 RID: 864 RVA: 0x000219AA File Offset: 0x0001FBAA
	public static bool LoadCSV(byte[] bytes, bool merge = false)
	{
		return Localization.LoadCSV(bytes, null, merge);
	}

	// Token: 0x06000361 RID: 865 RVA: 0x000219B4 File Offset: 0x0001FBB4
	private static bool HasLanguage(string languageName)
	{
		int i = 0;
		int num = Localization.mLanguages.Length;
		while (i < num)
		{
			if (Localization.mLanguages[i] == languageName)
			{
				return true;
			}
			i++;
		}
		return false;
	}

	// Token: 0x06000362 RID: 866 RVA: 0x000219E8 File Offset: 0x0001FBE8
	private static bool LoadCSV(byte[] bytes, TextAsset asset, bool merge = false)
	{
		if (bytes == null)
		{
			return false;
		}
		ByteReader byteReader = new ByteReader(bytes);
		BetterList<string> betterList = byteReader.ReadCSV();
		if (betterList.size < 2)
		{
			return false;
		}
		betterList.RemoveAt(0);
		string[] array = null;
		if (string.IsNullOrEmpty(Localization.mLanguage))
		{
			Localization.localizationHasBeenSet = false;
		}
		if (!Localization.localizationHasBeenSet || (!merge && !Localization.mMerging) || Localization.mLanguages == null || Localization.mLanguages.Length == 0)
		{
			Localization.mDictionary.Clear();
			Localization.mLanguages = new string[betterList.size];
			if (!Localization.localizationHasBeenSet)
			{
				Localization.mLanguage = PlayerPrefs.GetString("Language", betterList.buffer[0]);
				Localization.localizationHasBeenSet = true;
			}
			for (int i = 0; i < betterList.size; i++)
			{
				Localization.mLanguages[i] = betterList.buffer[i];
				if (Localization.mLanguages[i] == Localization.mLanguage)
				{
					Localization.mLanguageIndex = i;
				}
			}
		}
		else
		{
			array = new string[betterList.size];
			for (int j = 0; j < betterList.size; j++)
			{
				array[j] = betterList.buffer[j];
			}
			for (int k = 0; k < betterList.size; k++)
			{
				if (!Localization.HasLanguage(betterList.buffer[k]))
				{
					int num = Localization.mLanguages.Length + 1;
					Array.Resize<string>(ref Localization.mLanguages, num);
					Localization.mLanguages[num - 1] = betterList.buffer[k];
					Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();
					foreach (KeyValuePair<string, string[]> keyValuePair in Localization.mDictionary)
					{
						string[] value = keyValuePair.Value;
						Array.Resize<string>(ref value, num);
						value[num - 1] = value[0];
						dictionary.Add(keyValuePair.Key, value);
					}
					Localization.mDictionary = dictionary;
				}
			}
		}
		Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
		for (int l = 0; l < Localization.mLanguages.Length; l++)
		{
			dictionary2.Add(Localization.mLanguages[l], l);
		}
		for (;;)
		{
			BetterList<string> betterList2 = byteReader.ReadCSV();
			if (betterList2 == null || betterList2.size == 0)
			{
				break;
			}
			if (!string.IsNullOrEmpty(betterList2.buffer[0]))
			{
				Localization.AddCSV(betterList2, array, dictionary2);
			}
		}
		if (!Localization.mMerging && Localization.onLocalize != null)
		{
			Localization.mMerging = true;
			Localization.OnLocalizeNotification onLocalizeNotification = Localization.onLocalize;
			Localization.onLocalize = null;
			onLocalizeNotification();
			Localization.onLocalize = onLocalizeNotification;
			Localization.mMerging = false;
		}
		if (merge)
		{
			if (Localization.onLocalize != null)
			{
				Localization.onLocalize();
			}
			UIRoot.Broadcast("OnLocalize");
		}
		return true;
	}

	// Token: 0x06000363 RID: 867 RVA: 0x00021C84 File Offset: 0x0001FE84
	private static void AddCSV(BetterList<string> newValues, string[] newLanguages, Dictionary<string, int> languageIndices)
	{
		if (newValues.size < 2)
		{
			return;
		}
		string text = newValues.buffer[0];
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		string[] value = Localization.ExtractStrings(newValues, newLanguages, languageIndices);
		if (Localization.mDictionary.ContainsKey(text))
		{
			Localization.mDictionary[text] = value;
			if (newLanguages == null)
			{
				Debug.LogWarning("Localization key '" + text + "' is already present");
				return;
			}
		}
		else
		{
			try
			{
				Localization.mDictionary.Add(text, value);
			}
			catch (Exception ex)
			{
				Debug.LogError("Unable to add '" + text + "' to the Localization dictionary.\n" + ex.Message);
			}
		}
	}

	// Token: 0x06000364 RID: 868 RVA: 0x00021D28 File Offset: 0x0001FF28
	private static string[] ExtractStrings(BetterList<string> added, string[] newLanguages, Dictionary<string, int> languageIndices)
	{
		if (newLanguages == null)
		{
			string[] array = new string[Localization.mLanguages.Length];
			int i = 1;
			int num = Mathf.Min(added.size, array.Length + 1);
			while (i < num)
			{
				array[i - 1] = added.buffer[i];
				i++;
			}
			return array;
		}
		string key = added.buffer[0];
		string[] array2;
		if (!Localization.mDictionary.TryGetValue(key, out array2))
		{
			array2 = new string[Localization.mLanguages.Length];
		}
		int j = 0;
		int num2 = newLanguages.Length;
		while (j < num2)
		{
			string key2 = newLanguages[j];
			int num3 = languageIndices[key2];
			array2[num3] = added.buffer[j + 1];
			j++;
		}
		return array2;
	}

	// Token: 0x06000365 RID: 869 RVA: 0x00021DD0 File Offset: 0x0001FFD0
	private static bool SelectLanguage(string language)
	{
		Localization.mLanguageIndex = -1;
		if (Localization.mDictionary.Count == 0)
		{
			return false;
		}
		int i = 0;
		int num = Localization.mLanguages.Length;
		while (i < num)
		{
			if (Localization.mLanguages[i] == language)
			{
				Localization.mOldDictionary.Clear();
				Localization.mLanguageIndex = i;
				Localization.mLanguage = language;
				PlayerPrefs.SetString("Language", Localization.mLanguage);
				if (Localization.onLocalize != null)
				{
					Localization.onLocalize();
				}
				UIRoot.Broadcast("OnLocalize");
				return true;
			}
			i++;
		}
		return false;
	}

	// Token: 0x06000366 RID: 870 RVA: 0x00021E58 File Offset: 0x00020058
	public static void Set(string languageName, Dictionary<string, string> dictionary)
	{
		Localization.mLanguage = languageName;
		PlayerPrefs.SetString("Language", Localization.mLanguage);
		Localization.mOldDictionary = dictionary;
		Localization.localizationHasBeenSet = true;
		Localization.mLanguageIndex = -1;
		Localization.mLanguages = new string[]
		{
			languageName
		};
		if (Localization.onLocalize != null)
		{
			Localization.onLocalize();
		}
		UIRoot.Broadcast("OnLocalize");
	}

	// Token: 0x06000367 RID: 871 RVA: 0x00021EB6 File Offset: 0x000200B6
	public static void Set(string key, string value)
	{
		if (Localization.mOldDictionary.ContainsKey(key))
		{
			Localization.mOldDictionary[key] = value;
			return;
		}
		Localization.mOldDictionary.Add(key, value);
	}

	// Token: 0x06000368 RID: 872 RVA: 0x00021EE0 File Offset: 0x000200E0
	public static bool Has(string key)
	{
		if (string.IsNullOrEmpty(key))
		{
			return false;
		}
		if (!Localization.localizationHasBeenSet)
		{
			Localization.LoadDictionary(PlayerPrefs.GetString("Language", "English"), false);
		}
		if (Localization.mLanguages == null)
		{
			return false;
		}
		string language = Localization.language;
		if (Localization.mLanguageIndex == -1)
		{
			for (int i = 0; i < Localization.mLanguages.Length; i++)
			{
				if (Localization.mLanguages[i] == language)
				{
					Localization.mLanguageIndex = i;
					break;
				}
			}
		}
		if (Localization.mLanguageIndex == -1)
		{
			Localization.mLanguageIndex = 0;
			Localization.mLanguage = Localization.mLanguages[0];
		}
		UICamera.ControlScheme currentScheme = UICamera.currentScheme;
		if (currentScheme == UICamera.ControlScheme.Touch)
		{
			string key2 = key + " Mobile";
			if (Localization.mReplacement.ContainsKey(key2))
			{
				return true;
			}
			if (Localization.mLanguageIndex != -1 && Localization.mDictionary.ContainsKey(key2))
			{
				return true;
			}
			if (Localization.mOldDictionary.ContainsKey(key2))
			{
				return true;
			}
		}
		else if (currentScheme == UICamera.ControlScheme.Controller)
		{
			string key3 = key + " Controller";
			if (Localization.mReplacement.ContainsKey(key3))
			{
				return true;
			}
			if (Localization.mLanguageIndex != -1 && Localization.mDictionary.ContainsKey(key3))
			{
				return true;
			}
			if (Localization.mOldDictionary.ContainsKey(key3))
			{
				return true;
			}
		}
		return Localization.mReplacement.ContainsKey(key) || (Localization.mLanguageIndex != -1 && Localization.mDictionary.ContainsKey(key)) || Localization.mOldDictionary.ContainsKey(key);
	}

	// Token: 0x06000369 RID: 873 RVA: 0x00022038 File Offset: 0x00020238
	public static string Get(string key, bool warnIfMissing = true)
	{
		if (string.IsNullOrEmpty(key))
		{
			return null;
		}
		if (!Localization.localizationHasBeenSet)
		{
			Localization.LoadDictionary(PlayerPrefs.GetString("Language", "English"), false);
		}
		if (Localization.mLanguages == null)
		{
			Debug.LogError("No localization data present");
			return null;
		}
		string language = Localization.language;
		if (Localization.mLanguageIndex == -1)
		{
			for (int i = 0; i < Localization.mLanguages.Length; i++)
			{
				if (Localization.mLanguages[i] == language)
				{
					Localization.mLanguageIndex = i;
					break;
				}
			}
		}
		if (Localization.mLanguageIndex == -1)
		{
			Localization.mLanguageIndex = 0;
			Localization.mLanguage = Localization.mLanguages[0];
			Debug.LogWarning("Language not found: " + language);
		}
		UICamera.ControlScheme currentScheme = UICamera.currentScheme;
		string result;
		string[] array;
		if (currentScheme == UICamera.ControlScheme.Touch)
		{
			string key2 = key + " Mobile";
			if (Localization.mReplacement.TryGetValue(key2, out result))
			{
				return result;
			}
			if (Localization.mLanguageIndex != -1 && Localization.mDictionary.TryGetValue(key2, out array) && Localization.mLanguageIndex < array.Length)
			{
				return array[Localization.mLanguageIndex];
			}
			if (Localization.mOldDictionary.TryGetValue(key2, out result))
			{
				return result;
			}
		}
		else if (currentScheme == UICamera.ControlScheme.Controller)
		{
			string key3 = key + " Controller";
			if (Localization.mReplacement.TryGetValue(key3, out result))
			{
				return result;
			}
			if (Localization.mLanguageIndex != -1 && Localization.mDictionary.TryGetValue(key3, out array) && Localization.mLanguageIndex < array.Length)
			{
				return array[Localization.mLanguageIndex];
			}
			if (Localization.mOldDictionary.TryGetValue(key3, out result))
			{
				return result;
			}
		}
		if (Localization.mReplacement.TryGetValue(key, out result))
		{
			return result;
		}
		if (Localization.mLanguageIndex != -1 && Localization.mDictionary.TryGetValue(key, out array))
		{
			if (Localization.mLanguageIndex < array.Length)
			{
				string text = array[Localization.mLanguageIndex];
				if (string.IsNullOrEmpty(text))
				{
					text = array[0];
				}
				return text;
			}
			return array[0];
		}
		else
		{
			if (Localization.mOldDictionary.TryGetValue(key, out result))
			{
				return result;
			}
			return key;
		}
	}

	// Token: 0x0600036A RID: 874 RVA: 0x0002220C File Offset: 0x0002040C
	public static string Format(string key, object parameter)
	{
		string result;
		try
		{
			result = string.Format(Localization.Get(key, true), parameter);
		}
		catch (Exception)
		{
			Debug.LogError("string.Format(1): " + key);
			result = key;
		}
		return result;
	}

	// Token: 0x0600036B RID: 875 RVA: 0x00022250 File Offset: 0x00020450
	public static string Format(string key, object arg0, object arg1)
	{
		string result;
		try
		{
			result = string.Format(Localization.Get(key, true), arg0, arg1);
		}
		catch (Exception)
		{
			Debug.LogError("string.Format(2): " + key);
			result = key;
		}
		return result;
	}

	// Token: 0x0600036C RID: 876 RVA: 0x00022294 File Offset: 0x00020494
	public static string Format(string key, object arg0, object arg1, object arg2)
	{
		string result;
		try
		{
			result = string.Format(Localization.Get(key, true), arg0, arg1, arg2);
		}
		catch (Exception)
		{
			Debug.LogError("string.Format(3): " + key);
			result = key;
		}
		return result;
	}

	// Token: 0x0600036D RID: 877 RVA: 0x000222DC File Offset: 0x000204DC
	public static string Format(string key, params object[] parameters)
	{
		string result;
		try
		{
			result = string.Format(Localization.Get(key, true), parameters);
		}
		catch (Exception)
		{
			Debug.LogError("string.Format(" + parameters.Length.ToString() + "): " + key);
			result = key;
		}
		return result;
	}

	// Token: 0x17000061 RID: 97
	// (get) Token: 0x0600036E RID: 878 RVA: 0x00022330 File Offset: 0x00020530
	[Obsolete("Localization is now always active. You no longer need to check this property.")]
	public static bool isActive
	{
		get
		{
			return true;
		}
	}

	// Token: 0x0600036F RID: 879 RVA: 0x00022333 File Offset: 0x00020533
	[Obsolete("Use Localization.Get instead")]
	public static string Localize(string key)
	{
		return Localization.Get(key, true);
	}

	// Token: 0x06000370 RID: 880 RVA: 0x0002233C File Offset: 0x0002053C
	public static bool Exists(string key)
	{
		if (!Localization.localizationHasBeenSet)
		{
			Localization.language = PlayerPrefs.GetString("Language", "English");
		}
		return Localization.mDictionary.ContainsKey(key) || Localization.mOldDictionary.ContainsKey(key);
	}

	// Token: 0x06000371 RID: 881 RVA: 0x00022374 File Offset: 0x00020574
	public static void Set(string language, string key, string text)
	{
		string[] knownLanguages = Localization.knownLanguages;
		if (knownLanguages == null)
		{
			Localization.mLanguages = new string[]
			{
				language
			};
			knownLanguages = Localization.mLanguages;
		}
		int i = 0;
		int num = knownLanguages.Length;
		while (i < num)
		{
			if (knownLanguages[i] == language)
			{
				string[] array;
				if (!Localization.mDictionary.TryGetValue(key, out array))
				{
					array = new string[knownLanguages.Length];
					Localization.mDictionary[key] = array;
					array[0] = text;
				}
				array[i] = text;
				return;
			}
			i++;
		}
		int num2 = Localization.mLanguages.Length + 1;
		Array.Resize<string>(ref Localization.mLanguages, num2);
		Localization.mLanguages[num2 - 1] = language;
		Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();
		foreach (KeyValuePair<string, string[]> keyValuePair in Localization.mDictionary)
		{
			string[] value = keyValuePair.Value;
			Array.Resize<string>(ref value, num2);
			value[num2 - 1] = value[0];
			dictionary.Add(keyValuePair.Key, value);
		}
		Localization.mDictionary = dictionary;
		string[] array2;
		if (!Localization.mDictionary.TryGetValue(key, out array2))
		{
			array2 = new string[knownLanguages.Length];
			Localization.mDictionary[key] = array2;
			array2[0] = text;
		}
		array2[num2 - 1] = text;
	}

	// Token: 0x040004AB RID: 1195
	public static Localization.LoadFunction loadFunction;

	// Token: 0x040004AC RID: 1196
	public static Localization.OnLocalizeNotification onLocalize;

	// Token: 0x040004AD RID: 1197
	public static bool localizationHasBeenSet = false;

	// Token: 0x040004AE RID: 1198
	private static string[] mLanguages = null;

	// Token: 0x040004AF RID: 1199
	private static Dictionary<string, string> mOldDictionary = new Dictionary<string, string>();

	// Token: 0x040004B0 RID: 1200
	private static Dictionary<string, string[]> mDictionary = new Dictionary<string, string[]>();

	// Token: 0x040004B1 RID: 1201
	private static Dictionary<string, string> mReplacement = new Dictionary<string, string>();

	// Token: 0x040004B2 RID: 1202
	private static int mLanguageIndex = -1;

	// Token: 0x040004B3 RID: 1203
	private static string mLanguage;

	// Token: 0x040004B4 RID: 1204
	private static bool mMerging = false;

	// Token: 0x020005E7 RID: 1511
	// (Invoke) Token: 0x06002548 RID: 9544
	public delegate byte[] LoadFunction(string path);

	// Token: 0x020005E8 RID: 1512
	// (Invoke) Token: 0x0600254C RID: 9548
	public delegate void OnLocalizeNotification();
}
