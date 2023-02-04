using System;
using System.Collections.Generic;
using UnityEngine;

public static class Localization
{
	public delegate byte[] LoadFunction(string path);

	public delegate void OnLocalizeNotification();

	public static LoadFunction loadFunction;

	public static OnLocalizeNotification onLocalize;

	public static bool localizationHasBeenSet = false;

	private static string[] mLanguages = null;

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
			if (!localizationHasBeenSet)
			{
				LoadDictionary(PlayerPrefs.GetString("Language", "English"));
			}
			return mDictionary;
		}
		set
		{
			localizationHasBeenSet = value != null;
			mDictionary = value;
		}
	}

	public static string[] knownLanguages
	{
		get
		{
			if (!localizationHasBeenSet)
			{
				LoadDictionary(PlayerPrefs.GetString("Language", "English"));
			}
			return mLanguages;
		}
	}

	public static string language
	{
		get
		{
			if (string.IsNullOrEmpty(mLanguage))
			{
				mLanguage = PlayerPrefs.GetString("Language", "English");
				LoadAndSelect(mLanguage);
			}
			return mLanguage;
		}
		set
		{
			if (mLanguage != value)
			{
				mLanguage = value;
				LoadAndSelect(value);
			}
		}
	}

	[Obsolete("Localization is now always active. You no longer need to check this property.")]
	public static bool isActive => true;

	public static bool Reload()
	{
		localizationHasBeenSet = false;
		if (!LoadDictionary(mLanguage, merge: true))
		{
			return false;
		}
		if (onLocalize != null)
		{
			onLocalize();
		}
		UIRoot.Broadcast("OnLocalize");
		return true;
	}

	private static bool LoadDictionary(string value, bool merge = false)
	{
		byte[] array = null;
		if (!localizationHasBeenSet)
		{
			if (loadFunction == null)
			{
				TextAsset textAsset = Resources.Load<TextAsset>("Localization");
				if (textAsset != null)
				{
					array = textAsset.bytes;
				}
			}
			else
			{
				array = loadFunction("Localization");
			}
			localizationHasBeenSet = true;
		}
		if (LoadCSV(array, merge))
		{
			return true;
		}
		if (string.IsNullOrEmpty(value))
		{
			value = mLanguage;
		}
		if (string.IsNullOrEmpty(value))
		{
			return false;
		}
		if (loadFunction == null)
		{
			TextAsset textAsset2 = Resources.Load<TextAsset>(value);
			if (textAsset2 != null)
			{
				array = textAsset2.bytes;
			}
		}
		else
		{
			array = loadFunction(value);
		}
		if (array != null)
		{
			Set(value, array);
			return true;
		}
		return false;
	}

	private static bool LoadAndSelect(string value)
	{
		if (!string.IsNullOrEmpty(value))
		{
			if (mDictionary.Count == 0 && !LoadDictionary(value))
			{
				return false;
			}
			if (SelectLanguage(value))
			{
				return true;
			}
		}
		if (mOldDictionary.Count > 0)
		{
			return true;
		}
		mOldDictionary.Clear();
		mDictionary.Clear();
		if (string.IsNullOrEmpty(value))
		{
			PlayerPrefs.DeleteKey("Language");
		}
		return false;
	}

	public static void Load(TextAsset asset)
	{
		ByteReader byteReader = new ByteReader(asset);
		Set(asset.name, byteReader.ReadDictionary());
	}

	public static void Set(string languageName, byte[] bytes)
	{
		ByteReader byteReader = new ByteReader(bytes);
		Set(languageName, byteReader.ReadDictionary());
	}

	public static void ReplaceKey(string key, string val)
	{
		if (!string.IsNullOrEmpty(val))
		{
			mReplacement[key] = val;
		}
		else
		{
			mReplacement.Remove(key);
		}
	}

	public static void ClearReplacements()
	{
		mReplacement.Clear();
	}

	public static bool LoadCSV(TextAsset asset, bool merge = false)
	{
		return LoadCSV(asset.bytes, asset, merge);
	}

	public static bool LoadCSV(byte[] bytes, bool merge = false)
	{
		return LoadCSV(bytes, null, merge);
	}

	private static bool HasLanguage(string languageName)
	{
		int i = 0;
		for (int num = mLanguages.Length; i < num; i++)
		{
			if (mLanguages[i] == languageName)
			{
				return true;
			}
		}
		return false;
	}

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
		if (string.IsNullOrEmpty(mLanguage))
		{
			localizationHasBeenSet = false;
		}
		if (!localizationHasBeenSet || (!merge && !mMerging) || mLanguages == null || mLanguages.Length == 0)
		{
			mDictionary.Clear();
			mLanguages = new string[betterList.size];
			if (!localizationHasBeenSet)
			{
				mLanguage = PlayerPrefs.GetString("Language", betterList.buffer[0]);
				localizationHasBeenSet = true;
			}
			for (int i = 0; i < betterList.size; i++)
			{
				mLanguages[i] = betterList.buffer[i];
				if (mLanguages[i] == mLanguage)
				{
					mLanguageIndex = i;
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
				if (HasLanguage(betterList.buffer[k]))
				{
					continue;
				}
				int num = mLanguages.Length + 1;
				Array.Resize(ref mLanguages, num);
				mLanguages[num - 1] = betterList.buffer[k];
				Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();
				foreach (KeyValuePair<string, string[]> item in mDictionary)
				{
					string[] array2 = item.Value;
					Array.Resize(ref array2, num);
					array2[num - 1] = array2[0];
					dictionary.Add(item.Key, array2);
				}
				mDictionary = dictionary;
			}
		}
		Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
		for (int l = 0; l < mLanguages.Length; l++)
		{
			dictionary2.Add(mLanguages[l], l);
		}
		while (true)
		{
			BetterList<string> betterList2 = byteReader.ReadCSV();
			if (betterList2 == null || betterList2.size == 0)
			{
				break;
			}
			if (!string.IsNullOrEmpty(betterList2.buffer[0]))
			{
				AddCSV(betterList2, array, dictionary2);
			}
		}
		if (!mMerging && onLocalize != null)
		{
			mMerging = true;
			OnLocalizeNotification onLocalizeNotification = onLocalize;
			onLocalize = null;
			onLocalizeNotification();
			onLocalize = onLocalizeNotification;
			mMerging = false;
		}
		if (merge)
		{
			if (onLocalize != null)
			{
				onLocalize();
			}
			UIRoot.Broadcast("OnLocalize");
		}
		return true;
	}

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
		string[] value = ExtractStrings(newValues, newLanguages, languageIndices);
		if (mDictionary.ContainsKey(text))
		{
			mDictionary[text] = value;
			if (newLanguages == null)
			{
				Debug.LogWarning("Localization key '" + text + "' is already present");
			}
			return;
		}
		try
		{
			mDictionary.Add(text, value);
		}
		catch (Exception ex)
		{
			Debug.LogError("Unable to add '" + text + "' to the Localization dictionary.\n" + ex.Message);
		}
	}

	private static string[] ExtractStrings(BetterList<string> added, string[] newLanguages, Dictionary<string, int> languageIndices)
	{
		if (newLanguages == null)
		{
			string[] array = new string[mLanguages.Length];
			int i = 1;
			for (int num = Mathf.Min(added.size, array.Length + 1); i < num; i++)
			{
				array[i - 1] = added.buffer[i];
			}
			return array;
		}
		string key = added.buffer[0];
		if (!mDictionary.TryGetValue(key, out var value))
		{
			value = new string[mLanguages.Length];
		}
		int j = 0;
		for (int num2 = newLanguages.Length; j < num2; j++)
		{
			string key2 = newLanguages[j];
			int num3 = languageIndices[key2];
			value[num3] = added.buffer[j + 1];
		}
		return value;
	}

	private static bool SelectLanguage(string language)
	{
		mLanguageIndex = -1;
		if (mDictionary.Count == 0)
		{
			return false;
		}
		int i = 0;
		for (int num = mLanguages.Length; i < num; i++)
		{
			if (mLanguages[i] == language)
			{
				mOldDictionary.Clear();
				mLanguageIndex = i;
				mLanguage = language;
				PlayerPrefs.SetString("Language", mLanguage);
				if (onLocalize != null)
				{
					onLocalize();
				}
				UIRoot.Broadcast("OnLocalize");
				return true;
			}
		}
		return false;
	}

	public static void Set(string languageName, Dictionary<string, string> dictionary)
	{
		mLanguage = languageName;
		PlayerPrefs.SetString("Language", mLanguage);
		mOldDictionary = dictionary;
		localizationHasBeenSet = true;
		mLanguageIndex = -1;
		mLanguages = new string[1] { languageName };
		if (onLocalize != null)
		{
			onLocalize();
		}
		UIRoot.Broadcast("OnLocalize");
	}

	public static void Set(string key, string value)
	{
		if (mOldDictionary.ContainsKey(key))
		{
			mOldDictionary[key] = value;
		}
		else
		{
			mOldDictionary.Add(key, value);
		}
	}

	public static bool Has(string key)
	{
		if (string.IsNullOrEmpty(key))
		{
			return false;
		}
		if (!localizationHasBeenSet)
		{
			LoadDictionary(PlayerPrefs.GetString("Language", "English"));
		}
		if (mLanguages == null)
		{
			return false;
		}
		string text = language;
		if (mLanguageIndex == -1)
		{
			for (int i = 0; i < mLanguages.Length; i++)
			{
				if (mLanguages[i] == text)
				{
					mLanguageIndex = i;
					break;
				}
			}
		}
		if (mLanguageIndex == -1)
		{
			mLanguageIndex = 0;
			mLanguage = mLanguages[0];
		}
		switch (UICamera.currentScheme)
		{
		case UICamera.ControlScheme.Touch:
		{
			string key3 = key + " Mobile";
			if (mReplacement.ContainsKey(key3))
			{
				return true;
			}
			if (mLanguageIndex != -1 && mDictionary.ContainsKey(key3))
			{
				return true;
			}
			if (mOldDictionary.ContainsKey(key3))
			{
				return true;
			}
			break;
		}
		case UICamera.ControlScheme.Controller:
		{
			string key2 = key + " Controller";
			if (mReplacement.ContainsKey(key2))
			{
				return true;
			}
			if (mLanguageIndex != -1 && mDictionary.ContainsKey(key2))
			{
				return true;
			}
			if (mOldDictionary.ContainsKey(key2))
			{
				return true;
			}
			break;
		}
		}
		if (mReplacement.ContainsKey(key))
		{
			return true;
		}
		if (mLanguageIndex != -1 && mDictionary.ContainsKey(key))
		{
			return true;
		}
		if (mOldDictionary.ContainsKey(key))
		{
			return true;
		}
		return false;
	}

	public static string Get(string key, bool warnIfMissing = true)
	{
		if (string.IsNullOrEmpty(key))
		{
			return null;
		}
		if (!localizationHasBeenSet)
		{
			LoadDictionary(PlayerPrefs.GetString("Language", "English"));
		}
		if (mLanguages == null)
		{
			Debug.LogError("No localization data present");
			return null;
		}
		string text = language;
		if (mLanguageIndex == -1)
		{
			for (int i = 0; i < mLanguages.Length; i++)
			{
				if (mLanguages[i] == text)
				{
					mLanguageIndex = i;
					break;
				}
			}
		}
		if (mLanguageIndex == -1)
		{
			mLanguageIndex = 0;
			mLanguage = mLanguages[0];
			Debug.LogWarning("Language not found: " + text);
		}
		string value;
		string[] value2;
		switch (UICamera.currentScheme)
		{
		case UICamera.ControlScheme.Touch:
		{
			string key3 = key + " Mobile";
			if (mReplacement.TryGetValue(key3, out value))
			{
				return value;
			}
			if (mLanguageIndex != -1 && mDictionary.TryGetValue(key3, out value2) && mLanguageIndex < value2.Length)
			{
				return value2[mLanguageIndex];
			}
			if (mOldDictionary.TryGetValue(key3, out value))
			{
				return value;
			}
			break;
		}
		case UICamera.ControlScheme.Controller:
		{
			string key2 = key + " Controller";
			if (mReplacement.TryGetValue(key2, out value))
			{
				return value;
			}
			if (mLanguageIndex != -1 && mDictionary.TryGetValue(key2, out value2) && mLanguageIndex < value2.Length)
			{
				return value2[mLanguageIndex];
			}
			if (mOldDictionary.TryGetValue(key2, out value))
			{
				return value;
			}
			break;
		}
		}
		if (mReplacement.TryGetValue(key, out value))
		{
			return value;
		}
		if (mLanguageIndex != -1 && mDictionary.TryGetValue(key, out value2))
		{
			if (mLanguageIndex < value2.Length)
			{
				string text2 = value2[mLanguageIndex];
				if (string.IsNullOrEmpty(text2))
				{
					text2 = value2[0];
				}
				return text2;
			}
			return value2[0];
		}
		if (mOldDictionary.TryGetValue(key, out value))
		{
			return value;
		}
		return key;
	}

	public static string Format(string key, object parameter)
	{
		try
		{
			return string.Format(Get(key), parameter);
		}
		catch (Exception)
		{
			Debug.LogError("string.Format(1): " + key);
			return key;
		}
	}

	public static string Format(string key, object arg0, object arg1)
	{
		try
		{
			return string.Format(Get(key), arg0, arg1);
		}
		catch (Exception)
		{
			Debug.LogError("string.Format(2): " + key);
			return key;
		}
	}

	public static string Format(string key, object arg0, object arg1, object arg2)
	{
		try
		{
			return string.Format(Get(key), arg0, arg1, arg2);
		}
		catch (Exception)
		{
			Debug.LogError("string.Format(3): " + key);
			return key;
		}
	}

	public static string Format(string key, params object[] parameters)
	{
		try
		{
			return string.Format(Get(key), parameters);
		}
		catch (Exception)
		{
			Debug.LogError("string.Format(" + parameters.Length + "): " + key);
			return key;
		}
	}

	[Obsolete("Use Localization.Get instead")]
	public static string Localize(string key)
	{
		return Get(key);
	}

	public static bool Exists(string key)
	{
		if (!localizationHasBeenSet)
		{
			language = PlayerPrefs.GetString("Language", "English");
		}
		if (!mDictionary.ContainsKey(key))
		{
			return mOldDictionary.ContainsKey(key);
		}
		return true;
	}

	public static void Set(string language, string key, string text)
	{
		string[] array = knownLanguages;
		if (array == null)
		{
			mLanguages = new string[1] { language };
			array = mLanguages;
		}
		int i = 0;
		for (int num = array.Length; i < num; i++)
		{
			if (array[i] == language)
			{
				if (!mDictionary.TryGetValue(key, out var value))
				{
					value = new string[array.Length];
					mDictionary[key] = value;
					value[0] = text;
				}
				value[i] = text;
				return;
			}
		}
		int num2 = mLanguages.Length + 1;
		Array.Resize(ref mLanguages, num2);
		mLanguages[num2 - 1] = language;
		Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();
		foreach (KeyValuePair<string, string[]> item in mDictionary)
		{
			string[] array2 = item.Value;
			Array.Resize(ref array2, num2);
			array2[num2 - 1] = array2[0];
			dictionary.Add(item.Key, array2);
		}
		mDictionary = dictionary;
		if (!mDictionary.TryGetValue(key, out var value2))
		{
			value2 = new string[array.Length];
			mDictionary[key] = value2;
			value2[0] = text;
		}
		value2[num2 - 1] = text;
	}
}
