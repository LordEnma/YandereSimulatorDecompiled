using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002E9 RID: 745
public static class KeysHelper
{
	// Token: 0x06001521 RID: 5409 RVA: 0x000D9229 File Offset: 0x000D7429
	public static int[] GetIntegerKeys(string key)
	{
		return Array.ConvertAll<string, int>(KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key))), (string str) => int.Parse(str));
	}

	// Token: 0x06001522 RID: 5410 RVA: 0x000D925F File Offset: 0x000D745F
	public static string[] GetStringKeys(string key)
	{
		return KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key)));
	}

	// Token: 0x06001523 RID: 5411 RVA: 0x000D9271 File Offset: 0x000D7471
	public static T[] GetEnumKeys<T>(string key) where T : struct, IConvertible
	{
		return Array.ConvertAll<string, T>(KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key))), (string str) => (T)((object)Enum.Parse(typeof(T), str)));
	}

	// Token: 0x06001524 RID: 5412 RVA: 0x000D92A8 File Offset: 0x000D74A8
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

	// Token: 0x06001525 RID: 5413 RVA: 0x000D9324 File Offset: 0x000D7524
	public static void AddIfMissing(string key, string id)
	{
		string keyListKey = KeysHelper.GetKeyListKey(key);
		string keyList = KeysHelper.GetKeyList(keyListKey);
		if (!KeysHelper.HasKey(KeysHelper.SplitList(keyList), id))
		{
			KeysHelper.AppendKey(keyListKey, keyList, id);
		}
	}

	// Token: 0x06001526 RID: 5414 RVA: 0x000D9355 File Offset: 0x000D7555
	public static void Delete(string key)
	{
		Globals.Delete(KeysHelper.GetKeyListKey(key));
	}

	// Token: 0x06001527 RID: 5415 RVA: 0x000D9362 File Offset: 0x000D7562
	private static string GetKeyListKey(string key)
	{
		return key + "Keys";
	}

	// Token: 0x06001528 RID: 5416 RVA: 0x000D936F File Offset: 0x000D756F
	private static string GetKeyList(string keyListKey)
	{
		return PlayerPrefs.GetString(keyListKey);
	}

	// Token: 0x06001529 RID: 5417 RVA: 0x000D9377 File Offset: 0x000D7577
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

	// Token: 0x0600152A RID: 5418 RVA: 0x000D939A File Offset: 0x000D759A
	private static int FindKey(string[] keyListStrings, string key)
	{
		return Array.IndexOf<string>(keyListStrings, key);
	}

	// Token: 0x0600152B RID: 5419 RVA: 0x000D93A3 File Offset: 0x000D75A3
	private static bool HasKey(string[] keyListStrings, string key)
	{
		return KeysHelper.FindKey(keyListStrings, key) > -1;
	}

	// Token: 0x0600152C RID: 5420 RVA: 0x000D93B0 File Offset: 0x000D75B0
	private static void AppendKey(string keyListKey, string keyList, string key)
	{
		string value = (keyList.Length == 0) ? (keyList + key) : (keyList + "|" + key);
		PlayerPrefs.SetString(keyListKey, value);
	}

	// Token: 0x040021D3 RID: 8659
	private const string KeyListPrefix = "Keys";

	// Token: 0x040021D4 RID: 8660
	private const char KeyListSeparator = '|';

	// Token: 0x040021D5 RID: 8661
	public const char PairSeparator = '^';
}
