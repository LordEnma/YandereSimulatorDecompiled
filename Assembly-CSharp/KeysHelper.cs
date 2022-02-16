using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002E7 RID: 743
public static class KeysHelper
{
	// Token: 0x0600150F RID: 5391 RVA: 0x000D7CA5 File Offset: 0x000D5EA5
	public static int[] GetIntegerKeys(string key)
	{
		return Array.ConvertAll<string, int>(KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key))), (string str) => int.Parse(str));
	}

	// Token: 0x06001510 RID: 5392 RVA: 0x000D7CDB File Offset: 0x000D5EDB
	public static string[] GetStringKeys(string key)
	{
		return KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key)));
	}

	// Token: 0x06001511 RID: 5393 RVA: 0x000D7CED File Offset: 0x000D5EED
	public static T[] GetEnumKeys<T>(string key) where T : struct, IConvertible
	{
		return Array.ConvertAll<string, T>(KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key))), (string str) => (T)((object)Enum.Parse(typeof(T), str)));
	}

	// Token: 0x06001512 RID: 5394 RVA: 0x000D7D24 File Offset: 0x000D5F24
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

	// Token: 0x06001513 RID: 5395 RVA: 0x000D7DA0 File Offset: 0x000D5FA0
	public static void AddIfMissing(string key, string id)
	{
		string keyListKey = KeysHelper.GetKeyListKey(key);
		string keyList = KeysHelper.GetKeyList(keyListKey);
		if (!KeysHelper.HasKey(KeysHelper.SplitList(keyList), id))
		{
			KeysHelper.AppendKey(keyListKey, keyList, id);
		}
	}

	// Token: 0x06001514 RID: 5396 RVA: 0x000D7DD1 File Offset: 0x000D5FD1
	public static void Delete(string key)
	{
		Globals.Delete(KeysHelper.GetKeyListKey(key));
	}

	// Token: 0x06001515 RID: 5397 RVA: 0x000D7DDE File Offset: 0x000D5FDE
	private static string GetKeyListKey(string key)
	{
		return key + "Keys";
	}

	// Token: 0x06001516 RID: 5398 RVA: 0x000D7DEB File Offset: 0x000D5FEB
	private static string GetKeyList(string keyListKey)
	{
		return PlayerPrefs.GetString(keyListKey);
	}

	// Token: 0x06001517 RID: 5399 RVA: 0x000D7DF3 File Offset: 0x000D5FF3
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

	// Token: 0x06001518 RID: 5400 RVA: 0x000D7E16 File Offset: 0x000D6016
	private static int FindKey(string[] keyListStrings, string key)
	{
		return Array.IndexOf<string>(keyListStrings, key);
	}

	// Token: 0x06001519 RID: 5401 RVA: 0x000D7E1F File Offset: 0x000D601F
	private static bool HasKey(string[] keyListStrings, string key)
	{
		return KeysHelper.FindKey(keyListStrings, key) > -1;
	}

	// Token: 0x0600151A RID: 5402 RVA: 0x000D7E2C File Offset: 0x000D602C
	private static void AppendKey(string keyListKey, string keyList, string key)
	{
		string value = (keyList.Length == 0) ? (keyList + key) : (keyList + "|" + key);
		PlayerPrefs.SetString(keyListKey, value);
	}

	// Token: 0x04002192 RID: 8594
	private const string KeyListPrefix = "Keys";

	// Token: 0x04002193 RID: 8595
	private const char KeyListSeparator = '|';

	// Token: 0x04002194 RID: 8596
	public const char PairSeparator = '^';
}
