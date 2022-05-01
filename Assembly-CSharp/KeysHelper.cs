using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002EA RID: 746
public static class KeysHelper
{
	// Token: 0x0600152D RID: 5421 RVA: 0x000D99F1 File Offset: 0x000D7BF1
	public static int[] GetIntegerKeys(string key)
	{
		return Array.ConvertAll<string, int>(KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key))), (string str) => int.Parse(str));
	}

	// Token: 0x0600152E RID: 5422 RVA: 0x000D9A27 File Offset: 0x000D7C27
	public static string[] GetStringKeys(string key)
	{
		return KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key)));
	}

	// Token: 0x0600152F RID: 5423 RVA: 0x000D9A39 File Offset: 0x000D7C39
	public static T[] GetEnumKeys<T>(string key) where T : struct, IConvertible
	{
		return Array.ConvertAll<string, T>(KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key))), (string str) => (T)((object)Enum.Parse(typeof(T), str)));
	}

	// Token: 0x06001530 RID: 5424 RVA: 0x000D9A70 File Offset: 0x000D7C70
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

	// Token: 0x06001531 RID: 5425 RVA: 0x000D9AEC File Offset: 0x000D7CEC
	public static void AddIfMissing(string key, string id)
	{
		string keyListKey = KeysHelper.GetKeyListKey(key);
		string keyList = KeysHelper.GetKeyList(keyListKey);
		if (!KeysHelper.HasKey(KeysHelper.SplitList(keyList), id))
		{
			KeysHelper.AppendKey(keyListKey, keyList, id);
		}
	}

	// Token: 0x06001532 RID: 5426 RVA: 0x000D9B1D File Offset: 0x000D7D1D
	public static void Delete(string key)
	{
		Globals.Delete(KeysHelper.GetKeyListKey(key));
	}

	// Token: 0x06001533 RID: 5427 RVA: 0x000D9B2A File Offset: 0x000D7D2A
	private static string GetKeyListKey(string key)
	{
		return key + "Keys";
	}

	// Token: 0x06001534 RID: 5428 RVA: 0x000D9B37 File Offset: 0x000D7D37
	private static string GetKeyList(string keyListKey)
	{
		return PlayerPrefs.GetString(keyListKey);
	}

	// Token: 0x06001535 RID: 5429 RVA: 0x000D9B3F File Offset: 0x000D7D3F
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

	// Token: 0x06001536 RID: 5430 RVA: 0x000D9B62 File Offset: 0x000D7D62
	private static int FindKey(string[] keyListStrings, string key)
	{
		return Array.IndexOf<string>(keyListStrings, key);
	}

	// Token: 0x06001537 RID: 5431 RVA: 0x000D9B6B File Offset: 0x000D7D6B
	private static bool HasKey(string[] keyListStrings, string key)
	{
		return KeysHelper.FindKey(keyListStrings, key) > -1;
	}

	// Token: 0x06001538 RID: 5432 RVA: 0x000D9B78 File Offset: 0x000D7D78
	private static void AppendKey(string keyListKey, string keyList, string key)
	{
		string value = (keyList.Length == 0) ? (keyList + key) : (keyList + "|" + key);
		PlayerPrefs.SetString(keyListKey, value);
	}

	// Token: 0x040021E0 RID: 8672
	private const string KeyListPrefix = "Keys";

	// Token: 0x040021E1 RID: 8673
	private const char KeyListSeparator = '|';

	// Token: 0x040021E2 RID: 8674
	public const char PairSeparator = '^';
}
