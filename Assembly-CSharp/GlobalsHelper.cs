using System;
using UnityEngine;

// Token: 0x020002E7 RID: 743
public static class GlobalsHelper
{
	// Token: 0x06001505 RID: 5381 RVA: 0x000D8459 File Offset: 0x000D6659
	public static bool GetBool(string key)
	{
		return PlayerPrefs.GetInt(key) == 1;
	}

	// Token: 0x06001506 RID: 5382 RVA: 0x000D8464 File Offset: 0x000D6664
	public static void SetBool(string key, bool value)
	{
		PlayerPrefs.SetInt(key, value ? 1 : 0);
	}

	// Token: 0x06001507 RID: 5383 RVA: 0x000D8473 File Offset: 0x000D6673
	public static T GetEnum<T>(string key) where T : struct, IConvertible
	{
		return (T)((object)PlayerPrefs.GetInt(key));
	}

	// Token: 0x06001508 RID: 5384 RVA: 0x000D8485 File Offset: 0x000D6685
	public static void SetEnum<T>(string key, T value) where T : struct, IConvertible
	{
		PlayerPrefs.SetInt(key, (int)((object)value));
	}

	// Token: 0x06001509 RID: 5385 RVA: 0x000D8498 File Offset: 0x000D6698
	public static Vector2 GetVector2(string key)
	{
		float @float = PlayerPrefs.GetFloat(key + "_X");
		float float2 = PlayerPrefs.GetFloat(key + "_Y");
		return new Vector2(@float, float2);
	}

	// Token: 0x0600150A RID: 5386 RVA: 0x000D84CC File Offset: 0x000D66CC
	public static void SetVector2(string key, Vector2 value)
	{
		PlayerPrefs.SetFloat(key + "_X", value.x);
		PlayerPrefs.SetFloat(key + "_Y", value.y);
	}

	// Token: 0x0600150B RID: 5387 RVA: 0x000D84FA File Offset: 0x000D66FA
	public static void DeleteVector2(string key)
	{
		Globals.Delete(key + "_X");
		Globals.Delete(key + "_Y");
	}

	// Token: 0x0600150C RID: 5388 RVA: 0x000D851C File Offset: 0x000D671C
	public static void DeleteVector2Collection(string key, int[] usedKeys)
	{
		foreach (int num in usedKeys)
		{
			GlobalsHelper.DeleteVector2(key + num.ToString());
		}
		KeysHelper.Delete(key);
	}

	// Token: 0x0600150D RID: 5389 RVA: 0x000D8558 File Offset: 0x000D6758
	public static Vector3 GetVector3(string key)
	{
		float @float = PlayerPrefs.GetFloat(key + "_X");
		float float2 = PlayerPrefs.GetFloat(key + "_Y");
		float float3 = PlayerPrefs.GetFloat(key + "_Z");
		return new Vector3(@float, float2, float3);
	}

	// Token: 0x0600150E RID: 5390 RVA: 0x000D85A0 File Offset: 0x000D67A0
	public static void SetVector3(string key, Vector3 value)
	{
		PlayerPrefs.SetFloat(key + "_X", value.x);
		PlayerPrefs.SetFloat(key + "_Y", value.y);
		PlayerPrefs.SetFloat(key + "_Z", value.z);
	}

	// Token: 0x0600150F RID: 5391 RVA: 0x000D85EF File Offset: 0x000D67EF
	public static void DeleteVector3(string key)
	{
		Globals.Delete(key + "_X");
		Globals.Delete(key + "_Y");
		Globals.Delete(key + "_Z");
	}

	// Token: 0x06001510 RID: 5392 RVA: 0x000D8624 File Offset: 0x000D6824
	public static void DeleteVector3Collection(string key, int[] usedKeys)
	{
		foreach (int num in usedKeys)
		{
			GlobalsHelper.DeleteVector3(key + num.ToString());
		}
		KeysHelper.Delete(key);
	}

	// Token: 0x06001511 RID: 5393 RVA: 0x000D8660 File Offset: 0x000D6860
	public static Vector4 GetVector4(string key)
	{
		float @float = PlayerPrefs.GetFloat(key + "_W");
		float float2 = PlayerPrefs.GetFloat(key + "_X");
		float float3 = PlayerPrefs.GetFloat(key + "_Y");
		float float4 = PlayerPrefs.GetFloat(key + "_Z");
		return new Vector4(@float, float2, float3, float4);
	}

	// Token: 0x06001512 RID: 5394 RVA: 0x000D86B8 File Offset: 0x000D68B8
	public static void SetVector4(string key, Vector4 value)
	{
		PlayerPrefs.SetFloat(key + "_W", value.w);
		PlayerPrefs.SetFloat(key + "_X", value.x);
		PlayerPrefs.SetFloat(key + "_Y", value.y);
		PlayerPrefs.SetFloat(key + "_Z", value.z);
	}

	// Token: 0x06001513 RID: 5395 RVA: 0x000D8720 File Offset: 0x000D6920
	public static void DeleteVector4(string key)
	{
		Globals.Delete(key + "_W");
		Globals.Delete(key + "_X");
		Globals.Delete(key + "_Y");
		Globals.Delete(key + "_Z");
	}

	// Token: 0x06001514 RID: 5396 RVA: 0x000D8770 File Offset: 0x000D6970
	public static Color GetColor(string key)
	{
		float @float = PlayerPrefs.GetFloat(key + "_R");
		float float2 = PlayerPrefs.GetFloat(key + "_G");
		float float3 = PlayerPrefs.GetFloat(key + "_B");
		float float4 = PlayerPrefs.GetFloat(key + "_A");
		return new Color(@float, float2, float3, float4);
	}

	// Token: 0x06001515 RID: 5397 RVA: 0x000D87C8 File Offset: 0x000D69C8
	public static void SetColor(string key, Color value)
	{
		PlayerPrefs.SetFloat(key + "_R", value.r);
		PlayerPrefs.SetFloat(key + "_G", value.g);
		PlayerPrefs.SetFloat(key + "_B", value.b);
		PlayerPrefs.SetFloat(key + "_A", value.a);
	}

	// Token: 0x06001516 RID: 5398 RVA: 0x000D8830 File Offset: 0x000D6A30
	public static void DeleteColor(string key)
	{
		Globals.Delete(key + "_R");
		Globals.Delete(key + "_G");
		Globals.Delete(key + "_B");
		Globals.Delete(key + "_A");
	}

	// Token: 0x06001517 RID: 5399 RVA: 0x000D8880 File Offset: 0x000D6A80
	public static void DeleteColorCollection(string key, int[] usedKeys)
	{
		foreach (int num in usedKeys)
		{
			GlobalsHelper.DeleteColor(key + num.ToString());
		}
		KeysHelper.Delete(key);
	}
}
