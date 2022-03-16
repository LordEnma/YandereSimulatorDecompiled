using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002E8 RID: 744
public static class KeysHelper
{
	// Token: 0x0600151B RID: 5403 RVA: 0x000D8D29 File Offset: 0x000D6F29
	public static int[] GetIntegerKeys(string key)
	{
		return Array.ConvertAll<string, int>(KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key))), (string str) => int.Parse(str));
	}

	// Token: 0x0600151C RID: 5404 RVA: 0x000D8D5F File Offset: 0x000D6F5F
	public static string[] GetStringKeys(string key)
	{
		return KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key)));
	}

	// Token: 0x0600151D RID: 5405 RVA: 0x000D8D71 File Offset: 0x000D6F71
	public static T[] GetEnumKeys<T>(string key) where T : struct, IConvertible
	{
		return Array.ConvertAll<string, T>(KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key))), (string str) => (T)((object)Enum.Parse(typeof(T), str)));
	}

	// Token: 0x0600151E RID: 5406 RVA: 0x000D8DA8 File Offset: 0x000D6FA8
	public static KeyValuePair<T, U>[] GetKeys<T, U>(string key) where T : struct where U : struct
	{
		string[] array = KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key)));
		KeyValuePair<T, U>[] array2 = new KeyValuePair<T, U>[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			string[] array3 = array[i].Split(new char[]
			{
				'^'
			});
			array2[i] = new KeyValuePair<T, U>((T)((object)int.Parse(array3[0])), (U)((object)int.Parse(array3[1])));
		}
		return array2;
	}

	// Token: 0x0600151F RID: 5407 RVA: 0x000D8E24 File Offset: 0x000D7024
	public static void AddIfMissing(string key, string id)
	{
		string keyListKey = KeysHelper.GetKeyListKey(key);
		string keyList = KeysHelper.GetKeyList(keyListKey);
		if (!KeysHelper.HasKey(KeysHelper.SplitList(keyList), id))
		{
			KeysHelper.AppendKey(keyListKey, keyList, id);
		}
	}

	// Token: 0x06001520 RID: 5408 RVA: 0x000D8E55 File Offset: 0x000D7055
	public static void Delete(string key)
	{
		Globals.Delete(KeysHelper.GetKeyListKey(key));
	}

	// Token: 0x06001521 RID: 5409 RVA: 0x000D8E62 File Offset: 0x000D7062
	private static string GetKeyListKey(string key)
	{
		return key + "Keys";
	}

	// Token: 0x06001522 RID: 5410 RVA: 0x000D8E6F File Offset: 0x000D706F
	private static string GetKeyList(string keyListKey)
	{
		return PlayerPrefs.GetString(keyListKey);
	}

	// Token: 0x06001523 RID: 5411 RVA: 0x000D8E77 File Offset: 0x000D7077
	private static string[] SplitList(string keyList)
	{
		if (keyList.Length <= 0)
		{
			return new string[0];
		}
		return keyList.Split(new char[]
		{
			'|'
		});
	}

	// Token: 0x06001524 RID: 5412 RVA: 0x000D8E9A File Offset: 0x000D709A
	private static int FindKey(string[] keyListStrings, string key)
	{
		return Array.IndexOf<string>(keyListStrings, key);
	}

	// Token: 0x06001525 RID: 5413 RVA: 0x000D8EA3 File Offset: 0x000D70A3
	private static bool HasKey(string[] keyListStrings, string key)
	{
		return KeysHelper.FindKey(keyListStrings, key) > -1;
	}

	// Token: 0x06001526 RID: 5414 RVA: 0x000D8EB0 File Offset: 0x000D70B0
	private static void AppendKey(string keyListKey, string keyList, string key)
	{
		string value = (keyList.Length == 0) ? (keyList + key) : (keyList + "|" + key);
		PlayerPrefs.SetString(keyListKey, value);
	}

	// Token: 0x040021C5 RID: 8645
	private const string KeyListPrefix = "Keys";

	// Token: 0x040021C6 RID: 8646
	private const char KeyListSeparator = '|';

	// Token: 0x040021C7 RID: 8647
	public const char PairSeparator = '^';
}
