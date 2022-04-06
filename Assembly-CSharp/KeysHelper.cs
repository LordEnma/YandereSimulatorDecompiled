using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002EA RID: 746
public static class KeysHelper
{
	// Token: 0x06001527 RID: 5415 RVA: 0x000D9339 File Offset: 0x000D7539
	public static int[] GetIntegerKeys(string key)
	{
		return Array.ConvertAll<string, int>(KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key))), (string str) => int.Parse(str));
	}

	// Token: 0x06001528 RID: 5416 RVA: 0x000D936F File Offset: 0x000D756F
	public static string[] GetStringKeys(string key)
	{
		return KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key)));
	}

	// Token: 0x06001529 RID: 5417 RVA: 0x000D9381 File Offset: 0x000D7581
	public static T[] GetEnumKeys<T>(string key) where T : struct, IConvertible
	{
		return Array.ConvertAll<string, T>(KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key))), (string str) => (T)((object)Enum.Parse(typeof(T), str)));
	}

	// Token: 0x0600152A RID: 5418 RVA: 0x000D93B8 File Offset: 0x000D75B8
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

	// Token: 0x0600152B RID: 5419 RVA: 0x000D9434 File Offset: 0x000D7634
	public static void AddIfMissing(string key, string id)
	{
		string keyListKey = KeysHelper.GetKeyListKey(key);
		string keyList = KeysHelper.GetKeyList(keyListKey);
		if (!KeysHelper.HasKey(KeysHelper.SplitList(keyList), id))
		{
			KeysHelper.AppendKey(keyListKey, keyList, id);
		}
	}

	// Token: 0x0600152C RID: 5420 RVA: 0x000D9465 File Offset: 0x000D7665
	public static void Delete(string key)
	{
		Globals.Delete(KeysHelper.GetKeyListKey(key));
	}

	// Token: 0x0600152D RID: 5421 RVA: 0x000D9472 File Offset: 0x000D7672
	private static string GetKeyListKey(string key)
	{
		return key + "Keys";
	}

	// Token: 0x0600152E RID: 5422 RVA: 0x000D947F File Offset: 0x000D767F
	private static string GetKeyList(string keyListKey)
	{
		return PlayerPrefs.GetString(keyListKey);
	}

	// Token: 0x0600152F RID: 5423 RVA: 0x000D9487 File Offset: 0x000D7687
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

	// Token: 0x06001530 RID: 5424 RVA: 0x000D94AA File Offset: 0x000D76AA
	private static int FindKey(string[] keyListStrings, string key)
	{
		return Array.IndexOf<string>(keyListStrings, key);
	}

	// Token: 0x06001531 RID: 5425 RVA: 0x000D94B3 File Offset: 0x000D76B3
	private static bool HasKey(string[] keyListStrings, string key)
	{
		return KeysHelper.FindKey(keyListStrings, key) > -1;
	}

	// Token: 0x06001532 RID: 5426 RVA: 0x000D94C0 File Offset: 0x000D76C0
	private static void AppendKey(string keyListKey, string keyList, string key)
	{
		string value = (keyList.Length == 0) ? (keyList + key) : (keyList + "|" + key);
		PlayerPrefs.SetString(keyListKey, value);
	}

	// Token: 0x040021D5 RID: 8661
	private const string KeyListPrefix = "Keys";

	// Token: 0x040021D6 RID: 8662
	private const char KeyListSeparator = '|';

	// Token: 0x040021D7 RID: 8663
	public const char PairSeparator = '^';
}
