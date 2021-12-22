using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002E5 RID: 741
public static class KeysHelper
{
	// Token: 0x06001505 RID: 5381 RVA: 0x000D6FC5 File Offset: 0x000D51C5
	public static int[] GetIntegerKeys(string key)
	{
		return Array.ConvertAll<string, int>(KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key))), (string str) => int.Parse(str));
	}

	// Token: 0x06001506 RID: 5382 RVA: 0x000D6FFB File Offset: 0x000D51FB
	public static string[] GetStringKeys(string key)
	{
		return KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key)));
	}

	// Token: 0x06001507 RID: 5383 RVA: 0x000D700D File Offset: 0x000D520D
	public static T[] GetEnumKeys<T>(string key) where T : struct, IConvertible
	{
		return Array.ConvertAll<string, T>(KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key))), (string str) => (T)((object)Enum.Parse(typeof(T), str)));
	}

	// Token: 0x06001508 RID: 5384 RVA: 0x000D7044 File Offset: 0x000D5244
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

	// Token: 0x06001509 RID: 5385 RVA: 0x000D70C0 File Offset: 0x000D52C0
	public static void AddIfMissing(string key, string id)
	{
		string keyListKey = KeysHelper.GetKeyListKey(key);
		string keyList = KeysHelper.GetKeyList(keyListKey);
		if (!KeysHelper.HasKey(KeysHelper.SplitList(keyList), id))
		{
			KeysHelper.AppendKey(keyListKey, keyList, id);
		}
	}

	// Token: 0x0600150A RID: 5386 RVA: 0x000D70F1 File Offset: 0x000D52F1
	public static void Delete(string key)
	{
		Globals.Delete(KeysHelper.GetKeyListKey(key));
	}

	// Token: 0x0600150B RID: 5387 RVA: 0x000D70FE File Offset: 0x000D52FE
	private static string GetKeyListKey(string key)
	{
		return key + "Keys";
	}

	// Token: 0x0600150C RID: 5388 RVA: 0x000D710B File Offset: 0x000D530B
	private static string GetKeyList(string keyListKey)
	{
		return PlayerPrefs.GetString(keyListKey);
	}

	// Token: 0x0600150D RID: 5389 RVA: 0x000D7113 File Offset: 0x000D5313
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

	// Token: 0x0600150E RID: 5390 RVA: 0x000D7136 File Offset: 0x000D5336
	private static int FindKey(string[] keyListStrings, string key)
	{
		return Array.IndexOf<string>(keyListStrings, key);
	}

	// Token: 0x0600150F RID: 5391 RVA: 0x000D713F File Offset: 0x000D533F
	private static bool HasKey(string[] keyListStrings, string key)
	{
		return KeysHelper.FindKey(keyListStrings, key) > -1;
	}

	// Token: 0x06001510 RID: 5392 RVA: 0x000D714C File Offset: 0x000D534C
	private static void AppendKey(string keyListKey, string keyList, string key)
	{
		string value = (keyList.Length == 0) ? (keyList + key) : (keyList + "|" + key);
		PlayerPrefs.SetString(keyListKey, value);
	}

	// Token: 0x0400217B RID: 8571
	private const string KeyListPrefix = "Keys";

	// Token: 0x0400217C RID: 8572
	private const char KeyListSeparator = '|';

	// Token: 0x0400217D RID: 8573
	public const char PairSeparator = '^';
}
