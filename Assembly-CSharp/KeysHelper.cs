using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002E6 RID: 742
public static class KeysHelper
{
	// Token: 0x0600150A RID: 5386 RVA: 0x000D7AFD File Offset: 0x000D5CFD
	public static int[] GetIntegerKeys(string key)
	{
		return Array.ConvertAll<string, int>(KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key))), (string str) => int.Parse(str));
	}

	// Token: 0x0600150B RID: 5387 RVA: 0x000D7B33 File Offset: 0x000D5D33
	public static string[] GetStringKeys(string key)
	{
		return KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key)));
	}

	// Token: 0x0600150C RID: 5388 RVA: 0x000D7B45 File Offset: 0x000D5D45
	public static T[] GetEnumKeys<T>(string key) where T : struct, IConvertible
	{
		return Array.ConvertAll<string, T>(KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key))), (string str) => (T)((object)Enum.Parse(typeof(T), str)));
	}

	// Token: 0x0600150D RID: 5389 RVA: 0x000D7B7C File Offset: 0x000D5D7C
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

	// Token: 0x0600150E RID: 5390 RVA: 0x000D7BF8 File Offset: 0x000D5DF8
	public static void AddIfMissing(string key, string id)
	{
		string keyListKey = KeysHelper.GetKeyListKey(key);
		string keyList = KeysHelper.GetKeyList(keyListKey);
		if (!KeysHelper.HasKey(KeysHelper.SplitList(keyList), id))
		{
			KeysHelper.AppendKey(keyListKey, keyList, id);
		}
	}

	// Token: 0x0600150F RID: 5391 RVA: 0x000D7C29 File Offset: 0x000D5E29
	public static void Delete(string key)
	{
		Globals.Delete(KeysHelper.GetKeyListKey(key));
	}

	// Token: 0x06001510 RID: 5392 RVA: 0x000D7C36 File Offset: 0x000D5E36
	private static string GetKeyListKey(string key)
	{
		return key + "Keys";
	}

	// Token: 0x06001511 RID: 5393 RVA: 0x000D7C43 File Offset: 0x000D5E43
	private static string GetKeyList(string keyListKey)
	{
		return PlayerPrefs.GetString(keyListKey);
	}

	// Token: 0x06001512 RID: 5394 RVA: 0x000D7C4B File Offset: 0x000D5E4B
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

	// Token: 0x06001513 RID: 5395 RVA: 0x000D7C6E File Offset: 0x000D5E6E
	private static int FindKey(string[] keyListStrings, string key)
	{
		return Array.IndexOf<string>(keyListStrings, key);
	}

	// Token: 0x06001514 RID: 5396 RVA: 0x000D7C77 File Offset: 0x000D5E77
	private static bool HasKey(string[] keyListStrings, string key)
	{
		return KeysHelper.FindKey(keyListStrings, key) > -1;
	}

	// Token: 0x06001515 RID: 5397 RVA: 0x000D7C84 File Offset: 0x000D5E84
	private static void AppendKey(string keyListKey, string keyList, string key)
	{
		string value = (keyList.Length == 0) ? (keyList + key) : (keyList + "|" + key);
		PlayerPrefs.SetString(keyListKey, value);
	}

	// Token: 0x0400218B RID: 8587
	private const string KeyListPrefix = "Keys";

	// Token: 0x0400218C RID: 8588
	private const char KeyListSeparator = '|';

	// Token: 0x0400218D RID: 8589
	public const char PairSeparator = '^';
}
