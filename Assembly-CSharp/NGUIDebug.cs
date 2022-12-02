using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Internal/Debug")]
public class NGUIDebug : MonoBehaviour
{
	private static bool mRayDebug = false;

	private static List<string> mLines = new List<string>();

	private static NGUIDebug mInstance = null;

	public static bool debugRaycast
	{
		get
		{
			return mRayDebug;
		}
		set
		{
			mRayDebug = value;
			if (value && Application.isPlaying)
			{
				CreateInstance();
			}
		}
	}

	public static void CreateInstance()
	{
		if (mInstance == null)
		{
			GameObject obj = new GameObject("_NGUI Debug");
			mInstance = obj.AddComponent<NGUIDebug>();
			Object.DontDestroyOnLoad(obj);
		}
	}

	private static void LogString(string text)
	{
		if (Application.isPlaying)
		{
			if (mLines.Count > 20)
			{
				mLines.RemoveAt(0);
			}
			mLines.Add(text);
			CreateInstance();
		}
		else
		{
			Debug.Log(text);
		}
	}

	public static void Log(params object[] objs)
	{
		string text = "";
		for (int i = 0; i < objs.Length; i++)
		{
			text = ((i != 0) ? (text + ", " + objs[i].ToString()) : (text + objs[i].ToString()));
		}
		LogString(text);
	}

	public static void Log(string s)
	{
		if (!string.IsNullOrEmpty(s))
		{
			string[] array = s.Split('\n');
			for (int i = 0; i < array.Length; i++)
			{
				LogString(array[i]);
			}
		}
	}

	public static void Clear()
	{
		mLines.Clear();
	}

	public static void DrawBounds(Bounds b)
	{
		Vector3 center = b.center;
		Vector3 vector = b.center - b.extents;
		Vector3 vector2 = b.center + b.extents;
		Debug.DrawLine(new Vector3(vector.x, vector.y, center.z), new Vector3(vector2.x, vector.y, center.z), Color.red);
		Debug.DrawLine(new Vector3(vector.x, vector.y, center.z), new Vector3(vector.x, vector2.y, center.z), Color.red);
		Debug.DrawLine(new Vector3(vector2.x, vector.y, center.z), new Vector3(vector2.x, vector2.y, center.z), Color.red);
		Debug.DrawLine(new Vector3(vector.x, vector2.y, center.z), new Vector3(vector2.x, vector2.y, center.z), Color.red);
	}

	private void OnGUI()
	{
		Rect position = new Rect(5f, 5f, 1000f, 22f);
		if (mRayDebug)
		{
			string text = "Scheme: " + UICamera.currentScheme;
			GUI.color = Color.black;
			GUI.Label(position, text);
			position.y -= 1f;
			position.x -= 1f;
			GUI.color = Color.white;
			GUI.Label(position, text);
			position.y += 18f;
			position.x += 1f;
			text = "Hover: " + NGUITools.GetHierarchy(UICamera.hoveredObject).Replace("\"", "");
			GUI.color = Color.black;
			GUI.Label(position, text);
			position.y -= 1f;
			position.x -= 1f;
			GUI.color = Color.white;
			GUI.Label(position, text);
			position.y += 18f;
			position.x += 1f;
			text = "Selection: " + NGUITools.GetHierarchy(UICamera.selectedObject).Replace("\"", "");
			GUI.color = Color.black;
			GUI.Label(position, text);
			position.y -= 1f;
			position.x -= 1f;
			GUI.color = Color.white;
			GUI.Label(position, text);
			position.y += 18f;
			position.x += 1f;
			text = "Controller: " + NGUITools.GetHierarchy(UICamera.controllerNavigationObject).Replace("\"", "");
			GUI.color = Color.black;
			GUI.Label(position, text);
			position.y -= 1f;
			position.x -= 1f;
			GUI.color = Color.white;
			GUI.Label(position, text);
			position.y += 18f;
			position.x += 1f;
			text = "Active events: " + UICamera.CountInputSources();
			if (UICamera.disableController)
			{
				text += ", disabled controller";
			}
			if (UICamera.ignoreControllerInput)
			{
				text += ", ignore controller";
			}
			if (UICamera.inputHasFocus)
			{
				text += ", input focus";
			}
			GUI.color = Color.black;
			GUI.Label(position, text);
			position.y -= 1f;
			position.x -= 1f;
			GUI.color = Color.white;
			GUI.Label(position, text);
			position.y += 18f;
			position.x += 1f;
		}
		int i = 0;
		for (int count = mLines.Count; i < count; i++)
		{
			GUI.color = Color.black;
			GUI.Label(position, mLines[i]);
			position.y -= 1f;
			position.x -= 1f;
			GUI.color = Color.white;
			GUI.Label(position, mLines[i]);
			position.y += 18f;
			position.x += 1f;
		}
	}
}
