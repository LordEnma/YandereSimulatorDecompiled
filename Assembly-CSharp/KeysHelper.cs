using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002E8 RID: 744
public static class KeysHelper
{
	// Token: 0x06001518 RID: 5400 RVA: 0x000D8589 File Offset: 0x000D6789
	public static int[] GetIntegerKeys(string key)
	{
		return Array.ConvertAll<string, int>(KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key))), (string str) => int.Parse(str));
	}

	// Token: 0x06001519 RID: 5401 RVA: 0x000D85BF File Offset: 0x000D67BF
	public static string[] GetStringKeys(string key)
	{
		return KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key)));
	}

	// Token: 0x0600151A RID: 5402 RVA: 0x000D85D1 File Offset: 0x000D67D1
	public static T[] GetEnumKeys<T>(string key) where T : struct, IConvertible
	{
		return Array.ConvertAll<string, T>(KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key))), (string str) => (T)((object)Enum.Parse(typeof(T), str)));
	}

	// Token: 0x0600151B RID: 5403 RVA: 0x000D8608 File Offset: 0x000D6808
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

	// Token: 0x0600151C RID: 5404 RVA: 0x000D8684 File Offset: 0x000D6884
	public static void AddIfMissing(string key, string id)
	{
		string keyListKey = KeysHelper.GetKeyListKey(key);
		string keyList = KeysHelper.GetKeyList(keyListKey);
		if (!KeysHelper.HasKey(KeysHelper.SplitList(keyList), id))
		{
			KeysHelper.AppendKey(keyListKey, keyList, id);
		}
	}

	// Token: 0x0600151D RID: 5405 RVA: 0x000D86B5 File Offset: 0x000D68B5
	public static void Delete(string key)
	{
		Globals.Delete(KeysHelper.GetKeyListKey(key));
	}

	// Token: 0x0600151E RID: 5406 RVA: 0x000D86C2 File Offset: 0x000D68C2
	private static string GetKeyListKey(string key)
	{
		return key + "Keys";
	}

	// Token: 0x0600151F RID: 5407 RVA: 0x000D86CF File Offset: 0x000D68CF
	private static string GetKeyList(string keyListKey)
	{
		return PlayerPrefs.GetString(keyListKey);
	}

	// Token: 0x06001520 RID: 5408 RVA: 0x000D86D7 File Offset: 0x000D68D7
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

	// Token: 0x06001521 RID: 5409 RVA: 0x000D86FA File Offset: 0x000D68FA
	private static int FindKey(string[] keyListStrings, string key)
	{
		return Array.IndexOf<string>(keyListStrings, key);
	}

	// Token: 0x06001522 RID: 5410 RVA: 0x000D8703 File Offset: 0x000D6903
	private static bool HasKey(string[] keyListStrings, string key)
	{
		return KeysHelper.FindKey(keyListStrings, key) > -1;
	}

	// Token: 0x06001523 RID: 5411 RVA: 0x000D8710 File Offset: 0x000D6910
	private static void AppendKey(string keyListKey, string keyList, string key)
	{
		string value = (keyList.Length == 0) ? (keyList + key) : (keyList + "|" + key);
		PlayerPrefs.SetString(keyListKey, value);
	}

	// Token: 0x040021A1 RID: 8609
	private const string KeyListPrefix = "Keys";

	// Token: 0x040021A2 RID: 8610
	private const char KeyListSeparator = '|';

	// Token: 0x040021A3 RID: 8611
	public const char PairSeparator = '^';
}
