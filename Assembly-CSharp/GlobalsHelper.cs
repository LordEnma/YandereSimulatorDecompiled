using System;
using UnityEngine;

public static class GlobalsHelper
{
	public static bool GetBool(string key)
	{
		return PlayerPrefs.GetInt(key) == 1;
	}

	public static void SetBool(string key, bool value)
	{
		PlayerPrefs.SetInt(key, value ? 1 : 0);
	}

	public static T GetEnum<T>(string key) where T : struct, IConvertible
	{
		return (T)(object)PlayerPrefs.GetInt(key);
	}

	public static void SetEnum<T>(string key, T value) where T : struct, IConvertible
	{
		PlayerPrefs.SetInt(key, (int)(object)value);
	}

	public static Vector2 GetVector2(string key)
	{
		float x = PlayerPrefs.GetFloat(key + "_X");
		float y = PlayerPrefs.GetFloat(key + "_Y");
		return new Vector2(x, y);
	}

	public static void SetVector2(string key, Vector2 value)
	{
		PlayerPrefs.SetFloat(key + "_X", value.x);
		PlayerPrefs.SetFloat(key + "_Y", value.y);
	}

	public static void DeleteVector2(string key)
	{
		Globals.Delete(key + "_X");
		Globals.Delete(key + "_Y");
	}

	public static void DeleteVector2Collection(string key, int[] usedKeys)
	{
		foreach (int num in usedKeys)
		{
			DeleteVector2(key + num);
		}
		KeysHelper.Delete(key);
	}

	public static Vector3 GetVector3(string key)
	{
		float x = PlayerPrefs.GetFloat(key + "_X");
		float y = PlayerPrefs.GetFloat(key + "_Y");
		float z = PlayerPrefs.GetFloat(key + "_Z");
		return new Vector3(x, y, z);
	}

	public static void SetVector3(string key, Vector3 value)
	{
		PlayerPrefs.SetFloat(key + "_X", value.x);
		PlayerPrefs.SetFloat(key + "_Y", value.y);
		PlayerPrefs.SetFloat(key + "_Z", value.z);
	}

	public static void DeleteVector3(string key)
	{
		Globals.Delete(key + "_X");
		Globals.Delete(key + "_Y");
		Globals.Delete(key + "_Z");
	}

	public static void DeleteVector3Collection(string key, int[] usedKeys)
	{
		foreach (int num in usedKeys)
		{
			DeleteVector3(key + num);
		}
		KeysHelper.Delete(key);
	}

	public static Vector4 GetVector4(string key)
	{
		float x = PlayerPrefs.GetFloat(key + "_W");
		float y = PlayerPrefs.GetFloat(key + "_X");
		float z = PlayerPrefs.GetFloat(key + "_Y");
		float w = PlayerPrefs.GetFloat(key + "_Z");
		return new Vector4(x, y, z, w);
	}

	public static void SetVector4(string key, Vector4 value)
	{
		PlayerPrefs.SetFloat(key + "_W", value.w);
		PlayerPrefs.SetFloat(key + "_X", value.x);
		PlayerPrefs.SetFloat(key + "_Y", value.y);
		PlayerPrefs.SetFloat(key + "_Z", value.z);
	}

	public static void DeleteVector4(string key)
	{
		Globals.Delete(key + "_W");
		Globals.Delete(key + "_X");
		Globals.Delete(key + "_Y");
		Globals.Delete(key + "_Z");
	}

	public static Color GetColor(string key)
	{
		float r = PlayerPrefs.GetFloat(key + "_R");
		float g = PlayerPrefs.GetFloat(key + "_G");
		float b = PlayerPrefs.GetFloat(key + "_B");
		float a = PlayerPrefs.GetFloat(key + "_A");
		return new Color(r, g, b, a);
	}

	public static void SetColor(string key, Color value)
	{
		PlayerPrefs.SetFloat(key + "_R", value.r);
		PlayerPrefs.SetFloat(key + "_G", value.g);
		PlayerPrefs.SetFloat(key + "_B", value.b);
		PlayerPrefs.SetFloat(key + "_A", value.a);
	}

	public static void DeleteColor(string key)
	{
		Globals.Delete(key + "_R");
		Globals.Delete(key + "_G");
		Globals.Delete(key + "_B");
		Globals.Delete(key + "_A");
	}

	public static void DeleteColorCollection(string key, int[] usedKeys)
	{
		foreach (int num in usedKeys)
		{
			DeleteColor(key + num);
		}
		KeysHelper.Delete(key);
	}
}
