using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002EA RID: 746
public static class KeysHelper
{
	// Token: 0x06001529 RID: 5417 RVA: 0x000D9521 File Offset: 0x000D7721
	public static int[] GetIntegerKeys(string key)
	{
		return Array.ConvertAll<string, int>(KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key))), (string str) => int.Parse(str));
	}

	// Token: 0x0600152A RID: 5418 RVA: 0x000D9557 File Offset: 0x000D7757
	public static string[] GetStringKeys(string key)
	{
		return KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key)));
	}

	// Token: 0x0600152B RID: 5419 RVA: 0x000D9569 File Offset: 0x000D7769
	public static T[] GetEnumKeys<T>(string key) where T : struct, IConvertible
	{
		return Array.ConvertAll<string, T>(KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key))), (string str) => (T)((object)Enum.Parse(typeof(T), str)));
	}

	// Token: 0x0600152C RID: 5420 RVA: 0x000D95A0 File Offset: 0x000D77A0
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

	// Token: 0x0600152D RID: 5421 RVA: 0x000D961C File Offset: 0x000D781C
	public static void AddIfMissing(string key, string id)
	{
		string keyListKey = KeysHelper.GetKeyListKey(key);
		string keyList = KeysHelper.GetKeyList(keyListKey);
		if (!KeysHelper.HasKey(KeysHelper.SplitList(keyList), id))
		{
			KeysHelper.AppendKey(keyListKey, keyList, id);
		}
	}

	// Token: 0x0600152E RID: 5422 RVA: 0x000D964D File Offset: 0x000D784D
	public static void Delete(string key)
	{
		Globals.Delete(KeysHelper.GetKeyListKey(key));
	}

	// Token: 0x0600152F RID: 5423 RVA: 0x000D965A File Offset: 0x000D785A
	private static string GetKeyListKey(string key)
	{
		return key + "Keys";
	}

	// Token: 0x06001530 RID: 5424 RVA: 0x000D9667 File Offset: 0x000D7867
	private static string GetKeyList(string keyListKey)
	{
		return PlayerPrefs.GetString(keyListKey);
	}

	// Token: 0x06001531 RID: 5425 RVA: 0x000D966F File Offset: 0x000D786F
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

	// Token: 0x06001532 RID: 5426 RVA: 0x000D9692 File Offset: 0x000D7892
	private static int FindKey(string[] keyListStrings, string key)
	{
		return Array.IndexOf<string>(keyListStrings, key);
	}

	// Token: 0x06001533 RID: 5427 RVA: 0x000D969B File Offset: 0x000D789B
	private static bool HasKey(string[] keyListStrings, string key)
	{
		return KeysHelper.FindKey(keyListStrings, key) > -1;
	}

	// Token: 0x06001534 RID: 5428 RVA: 0x000D96A8 File Offset: 0x000D78A8
	private static void AppendKey(string keyListKey, string keyList, string key)
	{
		string value = (keyList.Length == 0) ? (keyList + key) : (keyList + "|" + key);
		PlayerPrefs.SetString(keyListKey, value);
	}

	// Token: 0x040021D7 RID: 8663
	private const string KeyListPrefix = "Keys";

	// Token: 0x040021D8 RID: 8664
	private const char KeyListSeparator = '|';

	// Token: 0x040021D9 RID: 8665
	public const char PairSeparator = '^';
}
