using System;
using UnityEngine;

// Token: 0x020002E8 RID: 744
public static class GlobalsHelper
{
	// Token: 0x0600150E RID: 5390 RVA: 0x000D8DC9 File Offset: 0x000D6FC9
	public static bool GetBool(string key)
	{
		return PlayerPrefs.GetInt(key) == 1;
	}

	// Token: 0x0600150F RID: 5391 RVA: 0x000D8DD4 File Offset: 0x000D6FD4
	public static void SetBool(string key, bool value)
	{
		PlayerPrefs.SetInt(key, value ? 1 : 0);
	}

	// Token: 0x06001510 RID: 5392 RVA: 0x000D8DE3 File Offset: 0x000D6FE3
	public static T GetEnum<T>(string key) where T : struct, IConvertible
	{
		return (T)((object)PlayerPrefs.GetInt(key));
	}

	// Token: 0x06001511 RID: 5393 RVA: 0x000D8DF5 File Offset: 0x000D6FF5
	public static void SetEnum<T>(string key, T value) where T : struct, IConvertible
	{
		PlayerPrefs.SetInt(key, (int)((object)value));
	}

	// Token: 0x06001512 RID: 5394 RVA: 0x000D8E08 File Offset: 0x000D7008
	public static Vector2 GetVector2(string key)
	{
		float @float = PlayerPrefs.GetFloat(key + "_X");
		float float2 = PlayerPrefs.GetFloat(key + "_Y");
		return new Vector2(@float, float2);
	}

	// Token: 0x06001513 RID: 5395 RVA: 0x000D8E3C File Offset: 0x000D703C
	public static void SetVector2(string key, Vector2 value)
	{
		PlayerPrefs.SetFloat(key + "_X", value.x);
		PlayerPrefs.SetFloat(key + "_Y", value.y);
	}

	// Token: 0x06001514 RID: 5396 RVA: 0x000D8E6A File Offset: 0x000D706A
	public static void DeleteVector2(string key)
	{
		Globals.Delete(key + "_X");
		Globals.Delete(key + "_Y");
	}

	// Token: 0x06001515 RID: 5397 RVA: 0x000D8E8C File Offset: 0x000D708C
	public static void DeleteVector2Collection(string key, int[] usedKeys)
	{
		foreach (int num in usedKeys)
		{
			GlobalsHelper.DeleteVector2(key + num.ToString());
		}
		KeysHelper.Delete(key);
	}

	// Token: 0x06001516 RID: 5398 RVA: 0x000D8EC8 File Offset: 0x000D70C8
	public static Vector3 GetVector3(string key)
	{
		float @float = PlayerPrefs.GetFloat(key + "_X");
		float float2 = PlayerPrefs.GetFloat(key + "_Y");
		float float3 = PlayerPrefs.GetFloat(key + "_Z");
		return new Vector3(@float, float2, float3);
	}

	// Token: 0x06001517 RID: 5399 RVA: 0x000D8F10 File Offset: 0x000D7110
	public static void SetVector3(string key, Vector3 value)
	{
		PlayerPrefs.SetFloat(key + "_X", value.x);
		PlayerPrefs.SetFloat(key + "_Y", value.y);
		PlayerPrefs.SetFloat(key + "_Z", value.z);
	}

	// Token: 0x06001518 RID: 5400 RVA: 0x000D8F5F File Offset: 0x000D715F
	public static void DeleteVector3(string key)
	{
		Globals.Delete(key + "_X");
		Globals.Delete(key + "_Y");
		Globals.Delete(key + "_Z");
	}

	// Token: 0x06001519 RID: 5401 RVA: 0x000D8F94 File Offset: 0x000D7194
	public static void DeleteVector3Collection(string key, int[] usedKeys)
	{
		foreach (int num in usedKeys)
		{
			GlobalsHelper.DeleteVector3(key + num.ToString());
		}
		KeysHelper.Delete(key);
	}

	// Token: 0x0600151A RID: 5402 RVA: 0x000D8FD0 File Offset: 0x000D71D0
	public static Vector4 GetVector4(string key)
	{
		float @float = PlayerPrefs.GetFloat(key + "_W");
		float float2 = PlayerPrefs.GetFloat(key + "_X");
		float float3 = PlayerPrefs.GetFloat(key + "_Y");
		float float4 = PlayerPrefs.GetFloat(key + "_Z");
		return new Vector4(@float, float2, float3, float4);
	}

	// Token: 0x0600151B RID: 5403 RVA: 0x000D9028 File Offset: 0x000D7228
	public static void SetVector4(string key, Vector4 value)
	{
		PlayerPrefs.SetFloat(key + "_W", value.w);
		PlayerPrefs.SetFloat(key + "_X", value.x);
		PlayerPrefs.SetFloat(key + "_Y", value.y);
		PlayerPrefs.SetFloat(key + "_Z", value.z);
	}

	// Token: 0x0600151C RID: 5404 RVA: 0x000D9090 File Offset: 0x000D7290
	public static void DeleteVector4(string key)
	{
		Globals.Delete(key + "_W");
		Globals.Delete(key + "_X");
		Globals.Delete(key + "_Y");
		Globals.Delete(key + "_Z");
	}

	// Token: 0x0600151D RID: 5405 RVA: 0x000D90E0 File Offset: 0x000D72E0
	public static Color GetColor(string key)
	{
		float @float = PlayerPrefs.GetFloat(key + "_R");
		float float2 = PlayerPrefs.GetFloat(key + "_G");
		float float3 = PlayerPrefs.GetFloat(key + "_B");
		float float4 = PlayerPrefs.GetFloat(key + "_A");
		return new Color(@float, float2, float3, float4);
	}

	// Token: 0x0600151E RID: 5406 RVA: 0x000D9138 File Offset: 0x000D7338
	public static void SetColor(string key, Color value)
	{
		PlayerPrefs.SetFloat(key + "_R", value.r);
		PlayerPrefs.SetFloat(key + "_G", value.g);
		PlayerPrefs.SetFloat(key + "_B", value.b);
		PlayerPrefs.SetFloat(key + "_A", value.a);
	}

	// Token: 0x0600151F RID: 5407 RVA: 0x000D91A0 File Offset: 0x000D73A0
	public static void DeleteColor(string key)
	{
		Globals.Delete(key + "_R");
		Globals.Delete(key + "_G");
		Globals.Delete(key + "_B");
		Globals.Delete(key + "_A");
	}

	// Token: 0x06001520 RID: 5408 RVA: 0x000D91F0 File Offset: 0x000D73F0
	public static void DeleteColorCollection(string key, int[] usedKeys)
	{
		foreach (int num in usedKeys)
		{
			GlobalsHelper.DeleteColor(key + num.ToString());
		}
		KeysHelper.Delete(key);
	}
}
