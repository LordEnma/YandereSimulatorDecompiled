using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002EB RID: 747
public static class KeysHelper
{
	// Token: 0x0600152F RID: 5423 RVA: 0x000D9E3D File Offset: 0x000D803D
	public static int[] GetIntegerKeys(string key)
	{
		return Array.ConvertAll<string, int>(KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key))), (string str) => int.Parse(str));
	}

	// Token: 0x06001530 RID: 5424 RVA: 0x000D9E73 File Offset: 0x000D8073
	public static string[] GetStringKeys(string key)
	{
		return KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key)));
	}

	// Token: 0x06001531 RID: 5425 RVA: 0x000D9E85 File Offset: 0x000D8085
	public static T[] GetEnumKeys<T>(string key) where T : struct, IConvertible
	{
		return Array.ConvertAll<string, T>(KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key))), (string str) => (T)((object)Enum.Parse(typeof(T), str)));
	}

	// Token: 0x06001532 RID: 5426 RVA: 0x000D9EBC File Offset: 0x000D80BC
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

	// Token: 0x06001533 RID: 5427 RVA: 0x000D9F38 File Offset: 0x000D8138
	public static void AddIfMissing(string key, string id)
	{
		string keyListKey = KeysHelper.GetKeyListKey(key);
		string keyList = KeysHelper.GetKeyList(keyListKey);
		if (!KeysHelper.HasKey(KeysHelper.SplitList(keyList), id))
		{
			KeysHelper.AppendKey(keyListKey, keyList, id);
		}
	}

	// Token: 0x06001534 RID: 5428 RVA: 0x000D9F69 File Offset: 0x000D8169
	public static void Delete(string key)
	{
		Globals.Delete(KeysHelper.GetKeyListKey(key));
	}

	// Token: 0x06001535 RID: 5429 RVA: 0x000D9F76 File Offset: 0x000D8176
	private static string GetKeyListKey(string key)
	{
		return key + "Keys";
	}

	// Token: 0x06001536 RID: 5430 RVA: 0x000D9F83 File Offset: 0x000D8183
	private static string GetKeyList(string keyListKey)
	{
		return PlayerPrefs.GetString(keyListKey);
	}

	// Token: 0x06001537 RID: 5431 RVA: 0x000D9F8B File Offset: 0x000D818B
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

	// Token: 0x06001538 RID: 5432 RVA: 0x000D9FAE File Offset: 0x000D81AE
	private static int FindKey(string[] keyListStrings, string key)
	{
		return Array.IndexOf<string>(keyListStrings, key);
	}

	// Token: 0x06001539 RID: 5433 RVA: 0x000D9FB7 File Offset: 0x000D81B7
	private static bool HasKey(string[] keyListStrings, string key)
	{
		return KeysHelper.FindKey(keyListStrings, key) > -1;
	}

	// Token: 0x0600153A RID: 5434 RVA: 0x000D9FC4 File Offset: 0x000D81C4
	private static void AppendKey(string keyListKey, string keyList, string key)
	{
		string value = (keyList.Length == 0) ? (keyList + key) : (keyList + "|" + key);
		PlayerPrefs.SetString(keyListKey, value);
	}

	// Token: 0x040021EA RID: 8682
	private const string KeyListPrefix = "Keys";

	// Token: 0x040021EB RID: 8683
	private const char KeyListSeparator = '|';

	// Token: 0x040021EC RID: 8684
	public const char PairSeparator = '^';
}
