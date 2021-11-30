using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002E4 RID: 740
public static class KeysHelper
{
	// Token: 0x060014FE RID: 5374 RVA: 0x000D6805 File Offset: 0x000D4A05
	public static int[] GetIntegerKeys(string key)
	{
		return Array.ConvertAll<string, int>(KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key))), (string str) => int.Parse(str));
	}

	// Token: 0x060014FF RID: 5375 RVA: 0x000D683B File Offset: 0x000D4A3B
	public static string[] GetStringKeys(string key)
	{
		return KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key)));
	}

	// Token: 0x06001500 RID: 5376 RVA: 0x000D684D File Offset: 0x000D4A4D
	public static T[] GetEnumKeys<T>(string key) where T : struct, IConvertible
	{
		return Array.ConvertAll<string, T>(KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key))), (string str) => (!0)((object)Enum.Parse(typeof(!0), str)));
	}

	// Token: 0x06001501 RID: 5377 RVA: 0x000D6884 File Offset: 0x000D4A84
	public static KeyValuePair<T, U>[] GetKeys<T, U>(string key) where T : struct where U : struct
	{
		string[] array = KeysHelper.SplitList(KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key)));
		KeyValuePair<T, U>[] array2 = new KeyValuePair<!!0, !!1>[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			string[] array3 = array[i].Split(new char[]
			{
				'^'
			});
			array2[i] = new KeyValuePair<!!0, !!1>((!!0)((object)int.Parse(array3[0])), (!!1)((object)int.Parse(array3[1])));
		}
		return array2;
	}

	// Token: 0x06001502 RID: 5378 RVA: 0x000D6900 File Offset: 0x000D4B00
	public static void AddIfMissing(string key, string id)
	{
		string keyListKey = KeysHelper.GetKeyListKey(key);
		string keyList = KeysHelper.GetKeyList(keyListKey);
		if (!KeysHelper.HasKey(KeysHelper.SplitList(keyList), id))
		{
			KeysHelper.AppendKey(keyListKey, keyList, id);
		}
	}

	// Token: 0x06001503 RID: 5379 RVA: 0x000D6931 File Offset: 0x000D4B31
	public static void Delete(string key)
	{
		Globals.Delete(KeysHelper.GetKeyListKey(key));
	}

	// Token: 0x06001504 RID: 5380 RVA: 0x000D693E File Offset: 0x000D4B3E
	private static string GetKeyListKey(string key)
	{
		return key + "Keys";
	}

	// Token: 0x06001505 RID: 5381 RVA: 0x000D694B File Offset: 0x000D4B4B
	private static string GetKeyList(string keyListKey)
	{
		return PlayerPrefs.GetString(keyListKey);
	}

	// Token: 0x06001506 RID: 5382 RVA: 0x000D6953 File Offset: 0x000D4B53
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

	// Token: 0x06001507 RID: 5383 RVA: 0x000D6976 File Offset: 0x000D4B76
	private static int FindKey(string[] keyListStrings, string key)
	{
		return Array.IndexOf<string>(keyListStrings, key);
	}

	// Token: 0x06001508 RID: 5384 RVA: 0x000D697F File Offset: 0x000D4B7F
	private static bool HasKey(string[] keyListStrings, string key)
	{
		return KeysHelper.FindKey(keyListStrings, key) > -1;
	}

	// Token: 0x06001509 RID: 5385 RVA: 0x000D698C File Offset: 0x000D4B8C
	private static void AppendKey(string keyListKey, string keyList, string key)
	{
		string value = (keyList.Length == 0) ? (keyList + key) : (keyList + "|" + key);
		PlayerPrefs.SetString(keyListKey, value);
	}

	// Token: 0x0400215B RID: 8539
	private const string KeyListPrefix = "Keys";

	// Token: 0x0400215C RID: 8540
	private const char KeyListSeparator = '|';

	// Token: 0x0400215D RID: 8541
	public const char PairSeparator = '^';
}
