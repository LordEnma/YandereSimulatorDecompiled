using System;
using System.Collections.Generic;
using UnityEngine;

public static class KeysHelper
{
	private const string KeyListPrefix = "Keys";

	private const char KeyListSeparator = '|';

	public const char PairSeparator = '^';

	public static int[] GetIntegerKeys(string key)
	{
		return Array.ConvertAll(SplitList(GetKeyList(GetKeyListKey(key))), (string str) => int.Parse(str));
	}

	public static string[] GetStringKeys(string key)
	{
		return SplitList(GetKeyList(GetKeyListKey(key)));
	}

	public static T[] GetEnumKeys<T>(string key) where T : struct, IConvertible
	{
		return Array.ConvertAll(SplitList(GetKeyList(GetKeyListKey(key))), (string str) => (T)Enum.Parse(typeof(T), str));
	}

	public static KeyValuePair<T, U>[] GetKeys<T, U>(string key) where T : struct where U : struct
	{
		string[] array = SplitList(GetKeyList(GetKeyListKey(key)));
		KeyValuePair<T, U>[] array2 = new KeyValuePair<T, U>[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			string[] array3 = array[i].Split('^');
			array2[i] = new KeyValuePair<T, U>((T)(object)int.Parse(array3[0]), (U)(object)int.Parse(array3[1]));
		}
		return array2;
	}

	public static void AddIfMissing(string key, string id)
	{
		string keyListKey = GetKeyListKey(key);
		string keyList = GetKeyList(keyListKey);
		if (!HasKey(SplitList(keyList), id))
		{
			AppendKey(keyListKey, keyList, id);
		}
	}

	public static void Delete(string key)
	{
		Globals.Delete(GetKeyListKey(key));
	}

	private static string GetKeyListKey(string key)
	{
		return key + "Keys";
	}

	private static string GetKeyList(string keyListKey)
	{
		return PlayerPrefs.GetString(keyListKey);
	}

	private static string[] SplitList(string keyList)
	{
		if (keyList.Length <= 0)
		{
			return new string[0];
		}
		return keyList.Split('|');
	}

	private static int FindKey(string[] keyListStrings, string key)
	{
		return Array.IndexOf(keyListStrings, key);
	}

	private static bool HasKey(string[] keyListStrings, string key)
	{
		return FindKey(keyListStrings, key) > -1;
	}

	private static void AppendKey(string keyListKey, string keyList, string key)
	{
		string value = ((keyList.Length == 0) ? (keyList + key) : (keyList + "|" + key));
		PlayerPrefs.SetString(keyListKey, value);
	}
}
