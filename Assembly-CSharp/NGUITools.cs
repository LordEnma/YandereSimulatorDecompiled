using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000079 RID: 121
public static class NGUITools
{
	// Token: 0x17000064 RID: 100
	// (get) Token: 0x060003DB RID: 987 RVA: 0x00028610 File Offset: 0x00026810
	// (set) Token: 0x060003DC RID: 988 RVA: 0x00028638 File Offset: 0x00026838
	public static float soundVolume
	{
		get
		{
			if (!NGUITools.mLoaded)
			{
				NGUITools.mLoaded = true;
				NGUITools.mGlobalVolume = PlayerPrefs.GetFloat("Sound", 1f);
			}
			return NGUITools.mGlobalVolume;
		}
		set
		{
			if (NGUITools.mGlobalVolume != value)
			{
				NGUITools.mLoaded = true;
				NGUITools.mGlobalVolume = value;
				PlayerPrefs.SetFloat("Sound", value);
			}
		}
	}

	// Token: 0x17000065 RID: 101
	// (get) Token: 0x060003DD RID: 989 RVA: 0x00028659 File Offset: 0x00026859
	public static bool fileAccess
	{
		get
		{
			return Application.platform != RuntimePlatform.WebGLPlayer;
		}
	}

	// Token: 0x060003DE RID: 990 RVA: 0x00028667 File Offset: 0x00026867
	public static AudioSource PlaySound(AudioClip clip)
	{
		return NGUITools.PlaySound(clip, 1f, 1f);
	}

	// Token: 0x060003DF RID: 991 RVA: 0x00028679 File Offset: 0x00026879
	public static AudioSource PlaySound(AudioClip clip, float volume)
	{
		return NGUITools.PlaySound(clip, volume, 1f);
	}

	// Token: 0x060003E0 RID: 992 RVA: 0x00028688 File Offset: 0x00026888
	public static AudioSource PlaySound(AudioClip clip, float volume, float pitch)
	{
		float time = RealTime.time;
		if (NGUITools.mLastClip == clip && NGUITools.mLastTimestamp + 0.1f > time)
		{
			return null;
		}
		NGUITools.mLastClip = clip;
		NGUITools.mLastTimestamp = time;
		volume *= NGUITools.soundVolume;
		if (clip != null && volume > 0.01f)
		{
			if (NGUITools.mListener == null || !NGUITools.GetActive(NGUITools.mListener))
			{
				AudioListener[] array = UnityEngine.Object.FindObjectsOfType(typeof(AudioListener)) as AudioListener[];
				if (array != null)
				{
					for (int i = 0; i < array.Length; i++)
					{
						if (NGUITools.GetActive(array[i]))
						{
							NGUITools.mListener = array[i];
							break;
						}
					}
				}
				if (NGUITools.mListener == null)
				{
					Camera camera = Camera.main;
					if (camera == null)
					{
						camera = (UnityEngine.Object.FindObjectOfType(typeof(Camera)) as Camera);
					}
					if (camera != null)
					{
						NGUITools.mListener = camera.gameObject.AddComponent<AudioListener>();
					}
				}
			}
			if (NGUITools.mListener != null && NGUITools.mListener.enabled && NGUITools.GetActive(NGUITools.mListener.gameObject))
			{
				if (!NGUITools.audioSource)
				{
					NGUITools.audioSource = NGUITools.mListener.GetComponent<AudioSource>();
					if (NGUITools.audioSource == null)
					{
						NGUITools.audioSource = NGUITools.mListener.gameObject.AddComponent<AudioSource>();
					}
				}
				NGUITools.audioSource.priority = 50;
				NGUITools.audioSource.pitch = pitch;
				NGUITools.audioSource.PlayOneShot(clip, volume);
				return NGUITools.audioSource;
			}
		}
		return null;
	}

	// Token: 0x060003E1 RID: 993 RVA: 0x00028817 File Offset: 0x00026A17
	public static int RandomRange(int min, int max)
	{
		if (min == max)
		{
			return min;
		}
		return UnityEngine.Random.Range(min, max + 1);
	}

	// Token: 0x060003E2 RID: 994 RVA: 0x00028828 File Offset: 0x00026A28
	public static string GetHierarchy(GameObject obj)
	{
		if (obj == null)
		{
			return "";
		}
		string text = obj.name;
		while (obj.transform.parent != null)
		{
			obj = obj.transform.parent.gameObject;
			text = obj.name + "\\" + text;
		}
		return text;
	}

	// Token: 0x060003E3 RID: 995 RVA: 0x00028885 File Offset: 0x00026A85
	public static T[] FindActive<T>() where T : Component
	{
		return UnityEngine.Object.FindObjectsOfType(typeof(T)) as T[];
	}

	// Token: 0x060003E4 RID: 996 RVA: 0x0002889C File Offset: 0x00026A9C
	public static Camera FindCameraForLayer(int layer)
	{
		int num = 1 << layer;
		Camera camera;
		for (int i = 0; i < UICamera.list.size; i++)
		{
			camera = UICamera.list.buffer[i].cachedCamera;
			if (camera && (camera.cullingMask & num) != 0)
			{
				return camera;
			}
		}
		camera = Camera.main;
		if (camera && (camera.cullingMask & num) != 0)
		{
			return camera;
		}
		Camera[] array = new Camera[Camera.allCamerasCount];
		int allCameras = Camera.GetAllCameras(array);
		for (int j = 0; j < allCameras; j++)
		{
			camera = array[j];
			if (camera && camera.enabled && (camera.cullingMask & num) != 0)
			{
				return camera;
			}
		}
		return null;
	}

	// Token: 0x060003E5 RID: 997 RVA: 0x0002894E File Offset: 0x00026B4E
	public static void AddWidgetCollider(GameObject go)
	{
		NGUITools.AddWidgetCollider(go, false);
	}

	// Token: 0x060003E6 RID: 998 RVA: 0x00028958 File Offset: 0x00026B58
	public static void AddWidgetCollider(GameObject go, bool considerInactive)
	{
		if (go != null)
		{
			Collider component = go.GetComponent<Collider>();
			BoxCollider boxCollider = component as BoxCollider;
			if (boxCollider != null)
			{
				NGUITools.UpdateWidgetCollider(boxCollider, considerInactive);
				return;
			}
			if (component != null)
			{
				return;
			}
			BoxCollider2D boxCollider2D = go.GetComponent<BoxCollider2D>();
			if (boxCollider2D != null)
			{
				NGUITools.UpdateWidgetCollider(boxCollider2D, considerInactive);
				return;
			}
			UICamera uicamera = UICamera.FindCameraForLayer(go.layer);
			if (uicamera != null && (uicamera.eventType == UICamera.EventType.World_2D || uicamera.eventType == UICamera.EventType.UI_2D))
			{
				boxCollider2D = go.AddComponent<BoxCollider2D>();
				boxCollider2D.isTrigger = true;
				UIWidget component2 = go.GetComponent<UIWidget>();
				if (component2 != null)
				{
					component2.autoResizeBoxCollider = true;
				}
				NGUITools.UpdateWidgetCollider(boxCollider2D, considerInactive);
				return;
			}
			boxCollider = go.AddComponent<BoxCollider>();
			boxCollider.isTrigger = true;
			UIWidget component3 = go.GetComponent<UIWidget>();
			if (component3 != null)
			{
				component3.autoResizeBoxCollider = true;
			}
			NGUITools.UpdateWidgetCollider(boxCollider, considerInactive);
		}
	}

	// Token: 0x060003E7 RID: 999 RVA: 0x00028A38 File Offset: 0x00026C38
	public static void UpdateWidgetCollider(GameObject go)
	{
		NGUITools.UpdateWidgetCollider(go, false);
	}

	// Token: 0x060003E8 RID: 1000 RVA: 0x00028A44 File Offset: 0x00026C44
	public static void UpdateWidgetCollider(GameObject go, bool considerInactive)
	{
		if (go != null)
		{
			BoxCollider component = go.GetComponent<BoxCollider>();
			if (component != null)
			{
				NGUITools.UpdateWidgetCollider(component, considerInactive);
				return;
			}
			BoxCollider2D component2 = go.GetComponent<BoxCollider2D>();
			if (component2 != null)
			{
				NGUITools.UpdateWidgetCollider(component2, considerInactive);
			}
		}
	}

	// Token: 0x060003E9 RID: 1001 RVA: 0x00028A8C File Offset: 0x00026C8C
	public static void UpdateWidgetCollider(BoxCollider box, bool considerInactive)
	{
		if (box != null)
		{
			GameObject gameObject = box.gameObject;
			UIWidget component = gameObject.GetComponent<UIWidget>();
			if (component != null)
			{
				Vector4 drawRegion = component.drawRegion;
				if (drawRegion.x != 0f || drawRegion.y != 0f || drawRegion.z != 1f || drawRegion.w != 1f)
				{
					Vector4 drawingDimensions = component.drawingDimensions;
					box.center = new Vector3((drawingDimensions.x + drawingDimensions.z) * 0.5f, (drawingDimensions.y + drawingDimensions.w) * 0.5f);
					box.size = new Vector3(drawingDimensions.z - drawingDimensions.x, drawingDimensions.w - drawingDimensions.y);
					return;
				}
				Vector3[] localCorners = component.localCorners;
				box.center = Vector3.Lerp(localCorners[0], localCorners[2], 0.5f);
				box.size = localCorners[2] - localCorners[0];
				return;
			}
			else
			{
				Bounds bounds = NGUIMath.CalculateRelativeWidgetBounds(gameObject.transform, considerInactive);
				box.center = bounds.center;
				box.size = new Vector3(bounds.size.x, bounds.size.y, 0f);
			}
		}
	}

	// Token: 0x060003EA RID: 1002 RVA: 0x00028BE0 File Offset: 0x00026DE0
	public static void UpdateWidgetCollider(UIWidget w)
	{
		if (w == null)
		{
			return;
		}
		BoxCollider component = w.GetComponent<BoxCollider>();
		if (component != null)
		{
			NGUITools.UpdateWidgetCollider(w, component);
			return;
		}
		NGUITools.UpdateWidgetCollider(w, w.GetComponent<BoxCollider2D>());
	}

	// Token: 0x060003EB RID: 1003 RVA: 0x00028C1C File Offset: 0x00026E1C
	public static void UpdateWidgetCollider(UIWidget w, BoxCollider box)
	{
		if (box != null && w != null)
		{
			Vector4 drawRegion = w.drawRegion;
			if (drawRegion.x != 0f || drawRegion.y != 0f || drawRegion.z != 1f || drawRegion.w != 1f)
			{
				Vector4 drawingDimensions = w.drawingDimensions;
				Vector3 vector = new Vector3((drawingDimensions.x + drawingDimensions.z) * 0.5f, (drawingDimensions.y + drawingDimensions.w) * 0.5f);
				Vector3 vector2 = new Vector3(drawingDimensions.z - drawingDimensions.x, drawingDimensions.w - drawingDimensions.y);
				if (vector != box.center || vector2 != box.size)
				{
					box.center = vector;
					box.size = vector2;
					NGUITools.SetDirty(box, "last change");
					return;
				}
			}
			else
			{
				Vector3[] localCorners = w.localCorners;
				Vector3 vector3 = Vector3.Lerp(localCorners[0], localCorners[2], 0.5f);
				Vector3 vector4 = localCorners[2] - localCorners[0];
				if (vector3 != box.center || vector4 != box.size)
				{
					box.center = vector3;
					box.size = vector4;
					NGUITools.SetDirty(box, "last change");
				}
			}
		}
	}

	// Token: 0x060003EC RID: 1004 RVA: 0x00028D84 File Offset: 0x00026F84
	public static void UpdateWidgetCollider(UIWidget w, BoxCollider2D box)
	{
		if (box != null && w != null)
		{
			Vector4 drawRegion = w.drawRegion;
			if (drawRegion.x != 0f || drawRegion.y != 0f || drawRegion.z != 1f || drawRegion.w != 1f)
			{
				Vector4 drawingDimensions = w.drawingDimensions;
				Vector2 vector = new Vector2((drawingDimensions.x + drawingDimensions.z) * 0.5f, (drawingDimensions.y + drawingDimensions.w) * 0.5f);
				Vector2 vector2 = new Vector2(drawingDimensions.z - drawingDimensions.x, drawingDimensions.w - drawingDimensions.y);
				if (vector != box.offset || vector2 != box.size)
				{
					box.offset = vector;
					box.size = vector2;
					NGUITools.SetDirty(box, "last change");
					return;
				}
			}
			else
			{
				Vector3[] localCorners = w.localCorners;
				Vector2 vector3 = Vector2.Lerp(localCorners[0], localCorners[2], 0.5f);
				Vector2 vector4 = localCorners[2] - localCorners[0];
				if (vector3 != box.offset || vector4 != box.size)
				{
					box.offset = vector3;
					box.size = vector4;
					NGUITools.SetDirty(box, "last change");
				}
			}
		}
	}

	// Token: 0x060003ED RID: 1005 RVA: 0x00028EF8 File Offset: 0x000270F8
	public static void UpdateWidgetCollider(BoxCollider2D box, bool considerInactive)
	{
		if (box != null)
		{
			GameObject gameObject = box.gameObject;
			UIWidget component = gameObject.GetComponent<UIWidget>();
			if (component != null)
			{
				Vector4 drawRegion = component.drawRegion;
				if (drawRegion.x != 0f || drawRegion.y != 0f || drawRegion.z != 1f || drawRegion.w != 1f)
				{
					Vector4 drawingDimensions = component.drawingDimensions;
					Vector2 vector = new Vector2((drawingDimensions.x + drawingDimensions.z) * 0.5f, (drawingDimensions.y + drawingDimensions.w) * 0.5f);
					Vector2 vector2 = new Vector2(drawingDimensions.z - drawingDimensions.x, drawingDimensions.w - drawingDimensions.y);
					if (vector != box.offset || vector2 != box.size)
					{
						box.offset = vector;
						box.size = vector2;
						NGUITools.SetDirty(box, "last change");
						return;
					}
				}
				else
				{
					Vector3[] localCorners = component.localCorners;
					Vector2 vector3 = Vector2.Lerp(localCorners[0], localCorners[2], 0.5f);
					Vector2 vector4 = localCorners[2] - localCorners[0];
					if (vector3 != box.offset || vector4 != box.size)
					{
						box.offset = vector3;
						box.size = vector4;
						NGUITools.SetDirty(box, "last change");
						return;
					}
				}
			}
			else
			{
				Bounds bounds = NGUIMath.CalculateRelativeWidgetBounds(gameObject.transform, considerInactive);
				box.offset = bounds.center;
				box.size = new Vector2(bounds.size.x, bounds.size.y);
			}
		}
	}

	// Token: 0x060003EE RID: 1006 RVA: 0x000290C4 File Offset: 0x000272C4
	public static string GetTypeName<T>()
	{
		string text = typeof(T).ToString();
		if (text.StartsWith("UI"))
		{
			text = text.Substring(2);
		}
		else if (text.StartsWith("UnityEngine."))
		{
			text = text.Substring(12);
		}
		return text;
	}

	// Token: 0x060003EF RID: 1007 RVA: 0x00029110 File Offset: 0x00027310
	public static string GetTypeName(UnityEngine.Object obj)
	{
		if (obj == null)
		{
			return "Null";
		}
		string text = obj.GetType().ToString();
		if (text.StartsWith("UI"))
		{
			text = text.Substring(2);
		}
		else if (text.StartsWith("UnityEngine."))
		{
			text = text.Substring(12);
		}
		return text;
	}

	// Token: 0x060003F0 RID: 1008 RVA: 0x00029166 File Offset: 0x00027366
	public static void RegisterUndo(UnityEngine.Object obj, string name)
	{
	}

	// Token: 0x060003F1 RID: 1009 RVA: 0x00029168 File Offset: 0x00027368
	public static void SetDirty(UnityEngine.Object obj, string undoName = "last change")
	{
	}

	// Token: 0x060003F2 RID: 1010 RVA: 0x0002916A File Offset: 0x0002736A
	public static void CheckForPrefabStage(GameObject gameObject)
	{
	}

	// Token: 0x060003F3 RID: 1011 RVA: 0x0002916C File Offset: 0x0002736C
	public static GameObject AddChild(GameObject parent)
	{
		return parent.AddChild(true, -1);
	}

	// Token: 0x060003F4 RID: 1012 RVA: 0x00029176 File Offset: 0x00027376
	public static GameObject AddChild(this GameObject parent, int layer)
	{
		return parent.AddChild(true, layer);
	}

	// Token: 0x060003F5 RID: 1013 RVA: 0x00029180 File Offset: 0x00027380
	public static GameObject AddChild(this GameObject parent, bool undo)
	{
		return parent.AddChild(undo, -1);
	}

	// Token: 0x060003F6 RID: 1014 RVA: 0x0002918C File Offset: 0x0002738C
	public static GameObject AddChild(this GameObject parent, bool undo, int layer)
	{
		GameObject gameObject = new GameObject();
		if (parent != null)
		{
			Transform transform = gameObject.transform;
			transform.parent = parent.transform;
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
			transform.localScale = Vector3.one;
			if (layer == -1)
			{
				gameObject.layer = parent.layer;
			}
			else if (layer > -1 && layer < 32)
			{
				gameObject.layer = layer;
			}
		}
		return gameObject;
	}

	// Token: 0x060003F7 RID: 1015 RVA: 0x00029200 File Offset: 0x00027400
	public static GameObject AddChild(this Transform parent, GameObject prefab)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(prefab, parent.transform);
		Transform transform = gameObject.transform;
		transform.parent = parent;
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
		transform.localScale = Vector3.one;
		gameObject.SetActive(true);
		return gameObject;
	}

	// Token: 0x060003F8 RID: 1016 RVA: 0x0002924D File Offset: 0x0002744D
	public static GameObject AddChild(this GameObject parent, GameObject prefab)
	{
		return parent.AddChild(prefab, -1);
	}

	// Token: 0x060003F9 RID: 1017 RVA: 0x00029258 File Offset: 0x00027458
	public static GameObject AddChild(this GameObject parent, GameObject prefab, int layer)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(prefab, parent.transform);
		if (gameObject != null)
		{
			Transform transform = gameObject.transform;
			gameObject.name = prefab.name;
			if (parent != null)
			{
				if (layer == -1)
				{
					gameObject.layer = parent.layer;
				}
				else if (layer > -1 && layer < 32)
				{
					gameObject.layer = layer;
				}
			}
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
			transform.localScale = Vector3.one;
			gameObject.SetActive(true);
		}
		return gameObject;
	}

	// Token: 0x060003FA RID: 1018 RVA: 0x000292E4 File Offset: 0x000274E4
	public static int CalculateRaycastDepth(GameObject go)
	{
		UIWidget component = go.GetComponent<UIWidget>();
		if (component != null)
		{
			return component.raycastDepth;
		}
		UIWidget[] componentsInChildren = go.GetComponentsInChildren<UIWidget>();
		if (componentsInChildren.Length == 0)
		{
			return 0;
		}
		int num = int.MaxValue;
		int i = 0;
		int num2 = componentsInChildren.Length;
		while (i < num2)
		{
			if (componentsInChildren[i].enabled)
			{
				num = Mathf.Min(num, componentsInChildren[i].raycastDepth);
			}
			i++;
		}
		return num;
	}

	// Token: 0x060003FB RID: 1019 RVA: 0x00029348 File Offset: 0x00027548
	public static int CalculateNextDepth(GameObject go)
	{
		if (go)
		{
			int num = -1;
			UIWidget[] componentsInChildren = go.GetComponentsInChildren<UIWidget>();
			int i = 0;
			int num2 = componentsInChildren.Length;
			while (i < num2)
			{
				num = Mathf.Max(num, componentsInChildren[i].depth);
				i++;
			}
			return num + 1;
		}
		return 0;
	}

	// Token: 0x060003FC RID: 1020 RVA: 0x0002938C File Offset: 0x0002758C
	public static int CalculateNextDepth(GameObject go, bool ignoreChildrenWithColliders)
	{
		if (go && ignoreChildrenWithColliders)
		{
			int num = -1;
			UIWidget[] componentsInChildren = go.GetComponentsInChildren<UIWidget>();
			int i = 0;
			int num2 = componentsInChildren.Length;
			while (i < num2)
			{
				UIWidget uiwidget = componentsInChildren[i];
				if (!(uiwidget.cachedGameObject != go) || (!(uiwidget.GetComponent<Collider>() != null) && !(uiwidget.GetComponent<Collider2D>() != null)))
				{
					num = Mathf.Max(num, uiwidget.depth);
				}
				i++;
			}
			return num + 1;
		}
		return NGUITools.CalculateNextDepth(go);
	}

	// Token: 0x060003FD RID: 1021 RVA: 0x00029408 File Offset: 0x00027608
	public static int AdjustDepth(GameObject go, int adjustment)
	{
		if (!(go != null))
		{
			return 0;
		}
		UIPanel uipanel = go.GetComponent<UIPanel>();
		if (uipanel != null)
		{
			UIPanel[] componentsInChildren = go.GetComponentsInChildren<UIPanel>(true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].depth += adjustment;
			}
			return 1;
		}
		uipanel = NGUITools.FindInParents<UIPanel>(go);
		if (uipanel == null)
		{
			return 0;
		}
		UIWidget[] componentsInChildren2 = go.GetComponentsInChildren<UIWidget>(true);
		int j = 0;
		int num = componentsInChildren2.Length;
		while (j < num)
		{
			UIWidget uiwidget = componentsInChildren2[j];
			if (!(uiwidget.panel != uipanel))
			{
				uiwidget.depth += adjustment;
			}
			j++;
		}
		return 2;
	}

	// Token: 0x060003FE RID: 1022 RVA: 0x000294B4 File Offset: 0x000276B4
	public static void BringForward(GameObject go)
	{
		int num = NGUITools.AdjustDepth(go, 1000);
		if (num == 1)
		{
			NGUITools.NormalizePanelDepths();
			return;
		}
		if (num == 2)
		{
			NGUITools.NormalizeWidgetDepths();
		}
	}

	// Token: 0x060003FF RID: 1023 RVA: 0x000294E0 File Offset: 0x000276E0
	public static void PushBack(GameObject go)
	{
		int num = NGUITools.AdjustDepth(go, -1000);
		if (num == 1)
		{
			NGUITools.NormalizePanelDepths();
			return;
		}
		if (num == 2)
		{
			NGUITools.NormalizeWidgetDepths();
		}
	}

	// Token: 0x06000400 RID: 1024 RVA: 0x0002950C File Offset: 0x0002770C
	public static void NormalizeDepths()
	{
		NGUITools.NormalizeWidgetDepths();
		NGUITools.NormalizePanelDepths();
	}

	// Token: 0x06000401 RID: 1025 RVA: 0x00029518 File Offset: 0x00027718
	public static void NormalizeWidgetDepths()
	{
		NGUITools.NormalizeWidgetDepths(NGUITools.FindActive<UIWidget>());
	}

	// Token: 0x06000402 RID: 1026 RVA: 0x00029524 File Offset: 0x00027724
	public static void NormalizeWidgetDepths(GameObject go)
	{
		NGUITools.NormalizeWidgetDepths(go.GetComponentsInChildren<UIWidget>());
	}

	// Token: 0x06000403 RID: 1027 RVA: 0x00029534 File Offset: 0x00027734
	public static void NormalizeWidgetDepths(UIWidget[] list)
	{
		int num = list.Length;
		if (num > 0)
		{
			Array.Sort<UIWidget>(list, new Comparison<UIWidget>(UIWidget.FullCompareFunc));
			int num2 = 0;
			int depth = list[0].depth;
			for (int i = 0; i < num; i++)
			{
				UIWidget uiwidget = list[i];
				if (uiwidget.depth == depth)
				{
					uiwidget.depth = num2;
				}
				else
				{
					depth = uiwidget.depth;
					num2 = (uiwidget.depth = num2 + 1);
				}
			}
		}
	}

	// Token: 0x06000404 RID: 1028 RVA: 0x000295A0 File Offset: 0x000277A0
	public static void NormalizePanelDepths()
	{
		UIPanel[] array = NGUITools.FindActive<UIPanel>();
		int num = array.Length;
		if (num > 0)
		{
			Array.Sort<UIPanel>(array, new Comparison<UIPanel>(UIPanel.CompareFunc));
			int num2 = 0;
			int depth = array[0].depth;
			for (int i = 0; i < num; i++)
			{
				UIPanel uipanel = array[i];
				if (uipanel.depth == depth)
				{
					uipanel.depth = num2;
				}
				else
				{
					depth = uipanel.depth;
					num2 = (uipanel.depth = num2 + 1);
				}
			}
		}
	}

	// Token: 0x06000405 RID: 1029 RVA: 0x00029616 File Offset: 0x00027816
	public static UIPanel CreateUI(bool advanced3D)
	{
		return NGUITools.CreateUI(null, advanced3D, -1);
	}

	// Token: 0x06000406 RID: 1030 RVA: 0x00029620 File Offset: 0x00027820
	public static UIPanel CreateUI(bool advanced3D, int layer)
	{
		return NGUITools.CreateUI(null, advanced3D, layer);
	}

	// Token: 0x06000407 RID: 1031 RVA: 0x0002962C File Offset: 0x0002782C
	public static UIPanel CreateUI(Transform trans, bool advanced3D, int layer)
	{
		UIRoot uiroot = (trans != null) ? NGUITools.FindInParents<UIRoot>(trans.gameObject) : null;
		if (uiroot == null && UIRoot.list.Count > 0)
		{
			foreach (UIRoot uiroot2 in UIRoot.list)
			{
				if (uiroot2.gameObject.layer == layer)
				{
					uiroot = uiroot2;
					break;
				}
			}
		}
		if (uiroot == null)
		{
			int i = 0;
			int count = UIPanel.list.Count;
			while (i < count)
			{
				UIPanel uipanel = UIPanel.list[i];
				GameObject gameObject = uipanel.gameObject;
				if (gameObject.hideFlags == HideFlags.None && gameObject.layer == layer)
				{
					trans.parent = uipanel.transform;
					trans.localScale = Vector3.one;
					return uipanel;
				}
				i++;
			}
		}
		if (uiroot != null)
		{
			UICamera componentInChildren = uiroot.GetComponentInChildren<UICamera>();
			if (componentInChildren != null && componentInChildren.GetComponent<Camera>().orthographic == advanced3D)
			{
				trans = null;
				uiroot = null;
			}
		}
		if (uiroot == null)
		{
			GameObject gameObject2 = NGUITools.AddChild((GameObject)null, false);
			uiroot = gameObject2.AddComponent<UIRoot>();
			if (layer == -1)
			{
				layer = LayerMask.NameToLayer("UI");
			}
			if (layer == -1)
			{
				layer = LayerMask.NameToLayer("2D UI");
			}
			gameObject2.layer = layer;
			if (advanced3D)
			{
				gameObject2.name = "UI Root (3D)";
				uiroot.scalingStyle = UIRoot.Scaling.Constrained;
			}
			else
			{
				gameObject2.name = "UI Root";
				uiroot.scalingStyle = UIRoot.Scaling.Flexible;
			}
			uiroot.UpdateScale(true);
		}
		UIPanel uipanel2 = uiroot.GetComponentInChildren<UIPanel>();
		if (uipanel2 == null)
		{
			Camera[] array = NGUITools.FindActive<Camera>();
			float num = -1f;
			bool flag = false;
			int num2 = 1 << uiroot.gameObject.layer;
			foreach (Camera camera in array)
			{
				if (camera.clearFlags == CameraClearFlags.Color || camera.clearFlags == CameraClearFlags.Skybox)
				{
					flag = true;
				}
				num = Mathf.Max(num, camera.depth);
				camera.cullingMask &= ~num2;
			}
			Camera camera2 = uiroot.gameObject.AddChild(false);
			camera2.gameObject.AddComponent<UICamera>();
			camera2.clearFlags = (flag ? CameraClearFlags.Depth : CameraClearFlags.Color);
			camera2.backgroundColor = Color.grey;
			camera2.cullingMask = num2;
			camera2.depth = num + 1f;
			if (advanced3D)
			{
				camera2.nearClipPlane = 0.1f;
				camera2.farClipPlane = 4f;
				camera2.transform.localPosition = new Vector3(0f, 0f, -700f);
			}
			else
			{
				camera2.orthographic = true;
				camera2.orthographicSize = 1f;
				camera2.nearClipPlane = -10f;
				camera2.farClipPlane = 10f;
			}
			AudioListener[] array2 = NGUITools.FindActive<AudioListener>();
			if (array2 == null || array2.Length == 0)
			{
				camera2.gameObject.AddComponent<AudioListener>();
			}
			uipanel2 = uiroot.gameObject.AddComponent<UIPanel>();
		}
		if (trans != null)
		{
			while (trans.parent != null)
			{
				trans = trans.parent;
			}
			if (NGUITools.IsChild(trans, uipanel2.transform))
			{
				uipanel2 = trans.gameObject.AddComponent<UIPanel>();
			}
			else
			{
				trans.parent = uipanel2.transform;
				trans.localScale = Vector3.one;
				trans.localPosition = Vector3.zero;
				uipanel2.cachedTransform.SetChildLayer(uipanel2.cachedGameObject.layer);
			}
		}
		return uipanel2;
	}

	// Token: 0x06000408 RID: 1032 RVA: 0x000299A4 File Offset: 0x00027BA4
	public static void SetChildLayer(this Transform t, int layer)
	{
		for (int i = 0; i < t.childCount; i++)
		{
			Transform child = t.GetChild(i);
			child.gameObject.layer = layer;
			child.SetChildLayer(layer);
		}
	}

	// Token: 0x06000409 RID: 1033 RVA: 0x000299DC File Offset: 0x00027BDC
	public static T AddChild<T>(this GameObject parent) where T : Component
	{
		GameObject gameObject = NGUITools.AddChild(parent);
		string typeName;
		if (!NGUITools.mTypeNames.TryGetValue(typeof(T), out typeName) || typeName == null)
		{
			typeName = NGUITools.GetTypeName<T>();
			NGUITools.mTypeNames[typeof(T)] = typeName;
		}
		gameObject.name = typeName;
		return gameObject.AddComponent<T>();
	}

	// Token: 0x0600040A RID: 1034 RVA: 0x00029A34 File Offset: 0x00027C34
	public static T AddChild<T>(this GameObject parent, bool undo) where T : Component
	{
		GameObject gameObject = parent.AddChild(undo);
		string typeName;
		if (!NGUITools.mTypeNames.TryGetValue(typeof(T), out typeName) || typeName == null)
		{
			typeName = NGUITools.GetTypeName<T>();
			NGUITools.mTypeNames[typeof(T)] = typeName;
		}
		gameObject.name = typeName;
		return gameObject.AddComponent<T>();
	}

	// Token: 0x0600040B RID: 1035 RVA: 0x00029A8A File Offset: 0x00027C8A
	public static T AddWidget<T>(this GameObject go, int depth = 2147483647) where T : UIWidget
	{
		if (depth == 2147483647)
		{
			depth = NGUITools.CalculateNextDepth(go);
		}
		T t = go.AddChild<T>();
		t.width = 100;
		t.height = 100;
		t.depth = depth;
		return t;
	}

	// Token: 0x0600040C RID: 1036 RVA: 0x00029AC8 File Offset: 0x00027CC8
	public static UISprite AddSprite(this GameObject go, INGUIAtlas atlas, string spriteName, int depth = 2147483647)
	{
		UISpriteData uispriteData = (atlas != null) ? atlas.GetSprite(spriteName) : null;
		UISprite uisprite = go.AddWidget(depth);
		uisprite.type = ((uispriteData == null || !uispriteData.hasBorder) ? UIBasicSprite.Type.Simple : UIBasicSprite.Type.Sliced);
		uisprite.atlas = atlas;
		uisprite.spriteName = spriteName;
		return uisprite;
	}

	// Token: 0x0600040D RID: 1037 RVA: 0x00029B10 File Offset: 0x00027D10
	public static GameObject GetRoot(GameObject go)
	{
		Transform transform = go.transform;
		for (;;)
		{
			Transform parent = transform.parent;
			if (parent == null)
			{
				break;
			}
			transform = parent;
		}
		return transform.gameObject;
	}

	// Token: 0x0600040E RID: 1038 RVA: 0x00029B40 File Offset: 0x00027D40
	public static T FindInParents<T>(GameObject go) where T : Component
	{
		if (go == null)
		{
			return default(T);
		}
		return go.GetComponentInParent<T>();
	}

	// Token: 0x0600040F RID: 1039 RVA: 0x00029B68 File Offset: 0x00027D68
	public static T FindInParents<T>(Transform trans) where T : Component
	{
		if (trans == null)
		{
			return default(T);
		}
		return trans.GetComponentInParent<T>();
	}

	// Token: 0x06000410 RID: 1040 RVA: 0x00029B90 File Offset: 0x00027D90
	public static void Destroy(UnityEngine.Object obj)
	{
		if (obj)
		{
			if (obj is Transform)
			{
				Transform transform = obj as Transform;
				GameObject gameObject = transform.gameObject;
				if (Application.isPlaying)
				{
					gameObject.SetActive(false);
					transform.parent = null;
					UnityEngine.Object.Destroy(gameObject);
					return;
				}
				UnityEngine.Object.DestroyImmediate(gameObject);
				return;
			}
			else if (obj is GameObject)
			{
				GameObject gameObject2 = obj as GameObject;
				Transform transform2 = gameObject2.transform;
				if (Application.isPlaying)
				{
					gameObject2.SetActive(false);
					transform2.parent = null;
					UnityEngine.Object.Destroy(gameObject2);
					return;
				}
				UnityEngine.Object.DestroyImmediate(gameObject2);
				return;
			}
			else
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(obj);
					return;
				}
				UnityEngine.Object.DestroyImmediate(obj);
			}
		}
	}

	// Token: 0x06000411 RID: 1041 RVA: 0x00029C30 File Offset: 0x00027E30
	public static void DestroyChildren(this Transform t)
	{
		bool isPlaying = Application.isPlaying;
		while (t.childCount != 0)
		{
			Transform child = t.GetChild(0);
			if (isPlaying)
			{
				child.parent = null;
				UnityEngine.Object.Destroy(child.gameObject);
			}
			else
			{
				UnityEngine.Object.DestroyImmediate(child.gameObject);
			}
		}
	}

	// Token: 0x06000412 RID: 1042 RVA: 0x00029C77 File Offset: 0x00027E77
	public static void DestroyImmediate(UnityEngine.Object obj)
	{
		if (obj != null)
		{
			if (Application.isEditor)
			{
				UnityEngine.Object.DestroyImmediate(obj);
				return;
			}
			UnityEngine.Object.Destroy(obj);
		}
	}

	// Token: 0x06000413 RID: 1043 RVA: 0x00029C98 File Offset: 0x00027E98
	public static void Broadcast(string funcName)
	{
		GameObject[] array = UnityEngine.Object.FindObjectsOfType(typeof(GameObject)) as GameObject[];
		int i = 0;
		int num = array.Length;
		while (i < num)
		{
			array[i].SendMessage(funcName, SendMessageOptions.DontRequireReceiver);
			i++;
		}
	}

	// Token: 0x06000414 RID: 1044 RVA: 0x00029CD4 File Offset: 0x00027ED4
	public static void Broadcast(string funcName, object param)
	{
		GameObject[] array = UnityEngine.Object.FindObjectsOfType(typeof(GameObject)) as GameObject[];
		int i = 0;
		int num = array.Length;
		while (i < num)
		{
			array[i].SendMessage(funcName, param, SendMessageOptions.DontRequireReceiver);
			i++;
		}
	}

	// Token: 0x06000415 RID: 1045 RVA: 0x00029D11 File Offset: 0x00027F11
	public static bool IsChild(Transform parent, Transform child)
	{
		return child.IsChildOf(parent);
	}

	// Token: 0x06000416 RID: 1046 RVA: 0x00029D1A File Offset: 0x00027F1A
	private static void Activate(Transform t)
	{
		NGUITools.Activate(t, false);
	}

	// Token: 0x06000417 RID: 1047 RVA: 0x00029D24 File Offset: 0x00027F24
	private static void Activate(Transform t, bool compatibilityMode)
	{
		NGUITools.SetActiveSelf(t.gameObject, true);
		if (compatibilityMode)
		{
			int i = 0;
			int childCount = t.childCount;
			while (i < childCount)
			{
				if (t.GetChild(i).gameObject.activeSelf)
				{
					return;
				}
				i++;
			}
			int j = 0;
			int childCount2 = t.childCount;
			while (j < childCount2)
			{
				NGUITools.Activate(t.GetChild(j), true);
				j++;
			}
		}
	}

	// Token: 0x06000418 RID: 1048 RVA: 0x00029D87 File Offset: 0x00027F87
	private static void Deactivate(Transform t)
	{
		NGUITools.SetActiveSelf(t.gameObject, false);
	}

	// Token: 0x06000419 RID: 1049 RVA: 0x00029D95 File Offset: 0x00027F95
	public static void SetActive(GameObject go, bool state)
	{
		NGUITools.SetActive(go, state, true);
	}

	// Token: 0x0600041A RID: 1050 RVA: 0x00029D9F File Offset: 0x00027F9F
	public static void SetActive(GameObject go, bool state, bool compatibilityMode)
	{
		if (go)
		{
			if (state)
			{
				NGUITools.Activate(go.transform, compatibilityMode);
				NGUITools.CallCreatePanel(go.transform);
				return;
			}
			NGUITools.Deactivate(go.transform);
		}
	}

	// Token: 0x0600041B RID: 1051 RVA: 0x00029DD0 File Offset: 0x00027FD0
	[DebuggerHidden]
	[DebuggerStepThrough]
	private static void CallCreatePanel(Transform t)
	{
		UIWidget component = t.GetComponent<UIWidget>();
		if (component != null)
		{
			component.CreatePanel();
		}
		int i = 0;
		int childCount = t.childCount;
		while (i < childCount)
		{
			NGUITools.CallCreatePanel(t.GetChild(i));
			i++;
		}
	}

	// Token: 0x0600041C RID: 1052 RVA: 0x00029E14 File Offset: 0x00028014
	public static void SetActiveChildren(GameObject go, bool state)
	{
		Transform transform = go.transform;
		if (state)
		{
			int i = 0;
			int childCount = transform.childCount;
			while (i < childCount)
			{
				NGUITools.Activate(transform.GetChild(i));
				i++;
			}
			return;
		}
		int j = 0;
		int childCount2 = transform.childCount;
		while (j < childCount2)
		{
			NGUITools.Deactivate(transform.GetChild(j));
			j++;
		}
	}

	// Token: 0x0600041D RID: 1053 RVA: 0x00029E6C File Offset: 0x0002806C
	[Obsolete("Use NGUITools.GetActive instead")]
	public static bool IsActive(Behaviour mb)
	{
		return mb != null && mb.enabled && mb.gameObject.activeInHierarchy;
	}

	// Token: 0x0600041E RID: 1054 RVA: 0x00029E8C File Offset: 0x0002808C
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static bool GetActive(Behaviour mb)
	{
		return mb && mb.enabled && mb.gameObject.activeInHierarchy;
	}

	// Token: 0x0600041F RID: 1055 RVA: 0x00029EAB File Offset: 0x000280AB
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static bool GetActive(GameObject go)
	{
		return go && go.activeInHierarchy;
	}

	// Token: 0x06000420 RID: 1056 RVA: 0x00029EBD File Offset: 0x000280BD
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static void SetActiveSelf(GameObject go, bool state)
	{
		go.SetActive(state);
	}

	// Token: 0x06000421 RID: 1057 RVA: 0x00029EC8 File Offset: 0x000280C8
	public static void SetLayer(GameObject go, int layer)
	{
		go.layer = layer;
		Transform transform = go.transform;
		int i = 0;
		int childCount = transform.childCount;
		while (i < childCount)
		{
			NGUITools.SetLayer(transform.GetChild(i).gameObject, layer);
			i++;
		}
	}

	// Token: 0x06000422 RID: 1058 RVA: 0x00029F08 File Offset: 0x00028108
	public static Vector3 Round(Vector3 v)
	{
		v.x = Mathf.Round(v.x);
		v.y = Mathf.Round(v.y);
		v.z = Mathf.Round(v.z);
		return v;
	}

	// Token: 0x06000423 RID: 1059 RVA: 0x00029F44 File Offset: 0x00028144
	public static void MakePixelPerfect(Transform t)
	{
		UIWidget component = t.GetComponent<UIWidget>();
		if (component != null)
		{
			component.MakePixelPerfect();
		}
		if (t.GetComponent<UIAnchor>() == null && t.GetComponent<UIRoot>() == null)
		{
			t.localPosition = NGUITools.Round(t.localPosition);
			t.localScale = NGUITools.Round(t.localScale);
		}
		int i = 0;
		int childCount = t.childCount;
		while (i < childCount)
		{
			NGUITools.MakePixelPerfect(t.GetChild(i));
			i++;
		}
	}

	// Token: 0x06000424 RID: 1060 RVA: 0x00029FC4 File Offset: 0x000281C4
	public static void FitOnScreen(this Camera cam, Transform t, bool considerInactive = false, bool considerChildren = true)
	{
		Bounds bounds = NGUIMath.CalculateRelativeWidgetBounds(t, t, considerInactive, considerChildren);
		Vector3 a = cam.WorldToScreenPoint(t.position);
		Vector3 vector = a + bounds.min;
		Vector3 vector2 = a + bounds.max;
		int width = Screen.width;
		int height = Screen.height;
		Vector2 zero = Vector2.zero;
		if (vector.x < 0f)
		{
			zero.x = -vector.x;
		}
		else if (vector2.x > (float)width)
		{
			zero.x = (float)width - vector2.x;
		}
		if (vector.y < 0f)
		{
			zero.y = -vector.y;
		}
		else if (vector2.y > (float)height)
		{
			zero.y = (float)height - vector2.y;
		}
		if (zero.sqrMagnitude > 0f)
		{
			t.localPosition += new Vector3(zero.x, zero.y, 0f);
		}
	}

	// Token: 0x06000425 RID: 1061 RVA: 0x0002A0BD File Offset: 0x000282BD
	public static void FitOnScreen(this Camera cam, Transform transform, Vector3 pos)
	{
		cam.FitOnScreen(transform, transform, pos, false);
	}

	// Token: 0x06000426 RID: 1062 RVA: 0x0002A0CC File Offset: 0x000282CC
	public static void FitOnScreen(this Camera cam, Transform transform, Transform content, Vector3 pos, bool considerInactive = false)
	{
		Bounds bounds;
		cam.FitOnScreen(transform, content, pos, out bounds, considerInactive);
	}

	// Token: 0x06000427 RID: 1063 RVA: 0x0002A0E8 File Offset: 0x000282E8
	public static void FitOnScreen(this Camera cam, Transform transform, Transform content, Vector3 pos, out Bounds bounds, bool considerInactive = false)
	{
		bounds = NGUIMath.CalculateRelativeWidgetBounds(transform, content, considerInactive, true);
		Vector3 min = bounds.min;
		Vector3 vector = bounds.max;
		Vector3 size = bounds.size;
		size.x += min.x;
		size.y -= vector.y;
		if (cam != null)
		{
			pos.x = Mathf.Clamp01(pos.x / (float)Screen.width);
			pos.y = Mathf.Clamp01(pos.y / (float)Screen.height);
			float num = cam.orthographicSize / transform.parent.lossyScale.y;
			float num2 = (float)Screen.height * 0.5f / num;
			vector = new Vector2(num2 * size.x / (float)Screen.width, num2 * size.y / (float)Screen.height);
			pos.x = Mathf.Min(pos.x, 1f - vector.x);
			pos.y = Mathf.Max(pos.y, vector.y);
			transform.position = cam.ViewportToWorldPoint(pos);
			pos = transform.localPosition;
			pos.x = Mathf.Round(pos.x);
			pos.y = Mathf.Round(pos.y);
		}
		else
		{
			if (pos.x + size.x > (float)Screen.width)
			{
				pos.x = (float)Screen.width - size.x;
			}
			if (pos.y - size.y < 0f)
			{
				pos.y = size.y;
			}
			pos.x -= (float)Screen.width * 0.5f;
			pos.y -= (float)Screen.height * 0.5f;
		}
		transform.localPosition = pos;
	}

	// Token: 0x06000428 RID: 1064 RVA: 0x0002A2C4 File Offset: 0x000284C4
	public static bool Save(string fileName, byte[] bytes)
	{
		if (!NGUITools.fileAccess)
		{
			return false;
		}
		string path = Application.persistentDataPath + "/" + fileName;
		if (bytes == null)
		{
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			return true;
		}
		FileStream fileStream = null;
		try
		{
			fileStream = File.Create(path);
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError(ex.Message);
			return false;
		}
		fileStream.Write(bytes, 0, bytes.Length);
		fileStream.Close();
		return true;
	}

	// Token: 0x06000429 RID: 1065 RVA: 0x0002A33C File Offset: 0x0002853C
	public static byte[] Load(string fileName)
	{
		if (!NGUITools.fileAccess)
		{
			return null;
		}
		string path = Application.persistentDataPath + "/" + fileName;
		if (File.Exists(path))
		{
			return File.ReadAllBytes(path);
		}
		return null;
	}

	// Token: 0x0600042A RID: 1066 RVA: 0x0002A374 File Offset: 0x00028574
	public static Color ApplyPMA(Color c)
	{
		if (c.a != 1f)
		{
			c.r *= c.a;
			c.g *= c.a;
			c.b *= c.a;
		}
		return c;
	}

	// Token: 0x0600042B RID: 1067 RVA: 0x0002A3C4 File Offset: 0x000285C4
	public static void MarkParentAsChanged(GameObject go)
	{
		UIRect[] componentsInChildren = go.GetComponentsInChildren<UIRect>();
		int i = 0;
		int num = componentsInChildren.Length;
		while (i < num)
		{
			componentsInChildren[i].ParentHasChanged();
			i++;
		}
	}

	// Token: 0x17000066 RID: 102
	// (get) Token: 0x0600042C RID: 1068 RVA: 0x0002A3F0 File Offset: 0x000285F0
	// (set) Token: 0x0600042D RID: 1069 RVA: 0x0002A403 File Offset: 0x00028603
	public static string clipboard
	{
		get
		{
			TextEditor textEditor = new TextEditor();
			textEditor.Paste();
			return textEditor.text;
		}
		set
		{
			TextEditor textEditor = new TextEditor();
			textEditor.text = value;
			textEditor.OnFocus();
			textEditor.Copy();
		}
	}

	// Token: 0x0600042E RID: 1070 RVA: 0x0002A41C File Offset: 0x0002861C
	[Obsolete("Use NGUIText.EncodeColor instead")]
	public static string EncodeColor(Color c)
	{
		return NGUIText.EncodeColor24(c);
	}

	// Token: 0x0600042F RID: 1071 RVA: 0x0002A424 File Offset: 0x00028624
	[Obsolete("Use NGUIText.ParseColor instead")]
	public static Color ParseColor(string text, int offset)
	{
		return NGUIText.ParseColor24(text, offset);
	}

	// Token: 0x06000430 RID: 1072 RVA: 0x0002A42D File Offset: 0x0002862D
	[Obsolete("Use NGUIText.StripSymbols instead")]
	public static string StripSymbols(string text)
	{
		return NGUIText.StripSymbols(text);
	}

	// Token: 0x06000431 RID: 1073 RVA: 0x0002A438 File Offset: 0x00028638
	public static T AddMissingComponent<T>(this GameObject go) where T : Component
	{
		T t = go.GetComponent<T>();
		if (t == null)
		{
			t = go.AddComponent<T>();
		}
		return t;
	}

	// Token: 0x06000432 RID: 1074 RVA: 0x0002A462 File Offset: 0x00028662
	public static Vector3[] GetSides(this Camera cam)
	{
		return cam.GetSides(Mathf.Lerp(cam.nearClipPlane, cam.farClipPlane, 0.5f), null);
	}

	// Token: 0x06000433 RID: 1075 RVA: 0x0002A481 File Offset: 0x00028681
	public static Vector3[] GetSides(this Camera cam, float depth)
	{
		return cam.GetSides(depth, null);
	}

	// Token: 0x06000434 RID: 1076 RVA: 0x0002A48B File Offset: 0x0002868B
	public static Vector3[] GetSides(this Camera cam, Transform relativeTo)
	{
		return cam.GetSides(Mathf.Lerp(cam.nearClipPlane, cam.farClipPlane, 0.5f), relativeTo);
	}

	// Token: 0x06000435 RID: 1077 RVA: 0x0002A4AC File Offset: 0x000286AC
	public static Vector3[] GetSides(this Camera cam, float depth, Transform relativeTo)
	{
		if (cam.orthographic)
		{
			float orthographicSize = cam.orthographicSize;
			float num = -orthographicSize;
			float num2 = orthographicSize;
			float y = -orthographicSize;
			float y2 = orthographicSize;
			Rect rect = cam.rect;
			Vector2 screenSize = NGUITools.screenSize;
			float num3 = screenSize.x / screenSize.y;
			num3 *= rect.width / rect.height;
			num *= num3;
			num2 *= num3;
			Transform transform = cam.transform;
			Quaternion rotation = transform.rotation;
			Vector3 position = transform.position;
			int num4 = Mathf.RoundToInt(screenSize.x);
			int num5 = Mathf.RoundToInt(screenSize.y);
			if ((num4 & 1) == 1)
			{
				position.x -= 1f / screenSize.x;
			}
			if ((num5 & 1) == 1)
			{
				position.y += 1f / screenSize.y;
			}
			NGUITools.mSides[0] = rotation * new Vector3(num, 0f, depth) + position;
			NGUITools.mSides[1] = rotation * new Vector3(0f, y2, depth) + position;
			NGUITools.mSides[2] = rotation * new Vector3(num2, 0f, depth) + position;
			NGUITools.mSides[3] = rotation * new Vector3(0f, y, depth) + position;
		}
		else
		{
			NGUITools.mSides[0] = cam.ViewportToWorldPoint(new Vector3(0f, 0.5f, depth));
			NGUITools.mSides[1] = cam.ViewportToWorldPoint(new Vector3(0.5f, 1f, depth));
			NGUITools.mSides[2] = cam.ViewportToWorldPoint(new Vector3(1f, 0.5f, depth));
			NGUITools.mSides[3] = cam.ViewportToWorldPoint(new Vector3(0.5f, 0f, depth));
		}
		if (relativeTo != null)
		{
			for (int i = 0; i < 4; i++)
			{
				NGUITools.mSides[i] = relativeTo.InverseTransformPoint(NGUITools.mSides[i]);
			}
		}
		return NGUITools.mSides;
	}

	// Token: 0x06000436 RID: 1078 RVA: 0x0002A6D8 File Offset: 0x000288D8
	public static Vector3[] GetWorldCorners(this Camera cam)
	{
		float depth = Mathf.Lerp(cam.nearClipPlane, cam.farClipPlane, 0.5f);
		return cam.GetWorldCorners(depth, null);
	}

	// Token: 0x06000437 RID: 1079 RVA: 0x0002A704 File Offset: 0x00028904
	public static Vector3[] GetWorldCorners(this Camera cam, float depth)
	{
		return cam.GetWorldCorners(depth, null);
	}

	// Token: 0x06000438 RID: 1080 RVA: 0x0002A70E File Offset: 0x0002890E
	public static Vector3[] GetWorldCorners(this Camera cam, Transform relativeTo)
	{
		return cam.GetWorldCorners(Mathf.Lerp(cam.nearClipPlane, cam.farClipPlane, 0.5f), relativeTo);
	}

	// Token: 0x06000439 RID: 1081 RVA: 0x0002A730 File Offset: 0x00028930
	public static Vector3[] GetWorldCorners(this Camera cam, float depth, Transform relativeTo)
	{
		if (cam.orthographic)
		{
			float orthographicSize = cam.orthographicSize;
			float num = -orthographicSize;
			float num2 = orthographicSize;
			float y = -orthographicSize;
			float y2 = orthographicSize;
			Rect rect = cam.rect;
			Vector2 screenSize = NGUITools.screenSize;
			float num3 = screenSize.x / screenSize.y;
			num3 *= rect.width / rect.height;
			num *= num3;
			num2 *= num3;
			Transform transform = cam.transform;
			Quaternion rotation = transform.rotation;
			Vector3 position = transform.position;
			NGUITools.mSides[0] = rotation * new Vector3(num, y, depth) + position;
			NGUITools.mSides[1] = rotation * new Vector3(num, y2, depth) + position;
			NGUITools.mSides[2] = rotation * new Vector3(num2, y2, depth) + position;
			NGUITools.mSides[3] = rotation * new Vector3(num2, y, depth) + position;
		}
		else
		{
			NGUITools.mSides[0] = cam.ViewportToWorldPoint(new Vector3(0f, 0f, depth));
			NGUITools.mSides[1] = cam.ViewportToWorldPoint(new Vector3(0f, 1f, depth));
			NGUITools.mSides[2] = cam.ViewportToWorldPoint(new Vector3(1f, 1f, depth));
			NGUITools.mSides[3] = cam.ViewportToWorldPoint(new Vector3(1f, 0f, depth));
		}
		if (relativeTo != null)
		{
			for (int i = 0; i < 4; i++)
			{
				NGUITools.mSides[i] = relativeTo.InverseTransformPoint(NGUITools.mSides[i]);
			}
		}
		return NGUITools.mSides;
	}

	// Token: 0x0600043A RID: 1082 RVA: 0x0002A8F4 File Offset: 0x00028AF4
	public static string GetFuncName(object obj, string method)
	{
		if (obj == null)
		{
			return "<null>";
		}
		string text = obj.GetType().ToString();
		int num = text.LastIndexOf('/');
		if (num > 0)
		{
			text = text.Substring(num + 1);
		}
		if (!string.IsNullOrEmpty(method))
		{
			return text + "/" + method;
		}
		return text;
	}

	// Token: 0x0600043B RID: 1083 RVA: 0x0002A944 File Offset: 0x00028B44
	public static void Execute<T>(GameObject go, string funcName) where T : Component
	{
		foreach (T t in go.GetComponents<T>())
		{
			MethodInfo method = t.GetType().GetMethod(funcName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (method != null)
			{
				method.Invoke(t, null);
			}
		}
	}

	// Token: 0x0600043C RID: 1084 RVA: 0x0002A99C File Offset: 0x00028B9C
	public static void ExecuteAll<T>(GameObject root, string funcName) where T : Component
	{
		NGUITools.Execute<T>(root, funcName);
		Transform transform = root.transform;
		int i = 0;
		int childCount = transform.childCount;
		while (i < childCount)
		{
			NGUITools.ExecuteAll<T>(transform.GetChild(i).gameObject, funcName);
			i++;
		}
	}

	// Token: 0x0600043D RID: 1085 RVA: 0x0002A9DC File Offset: 0x00028BDC
	public static void ImmediatelyCreateDrawCalls(GameObject root)
	{
		NGUITools.ExecuteAll<UIWidget>(root, "Start");
		NGUITools.ExecuteAll<UIPanel>(root, "Start");
		NGUITools.ExecuteAll<UIWidget>(root, "Update");
		NGUITools.ExecuteAll<UIPanel>(root, "Update");
		NGUITools.ExecuteAll<UIPanel>(root, "LateUpdate");
	}

	// Token: 0x17000067 RID: 103
	// (get) Token: 0x0600043E RID: 1086 RVA: 0x0002AA15 File Offset: 0x00028C15
	public static Vector2 screenSize
	{
		get
		{
			return new Vector2((float)Screen.width, (float)Screen.height);
		}
	}

	// Token: 0x0600043F RID: 1087 RVA: 0x0002AA28 File Offset: 0x00028C28
	public static string KeyToCaption(KeyCode key)
	{
		switch (key)
		{
		case KeyCode.None:
			return null;
		case (KeyCode)1:
		case (KeyCode)2:
		case (KeyCode)3:
		case (KeyCode)4:
		case (KeyCode)5:
		case (KeyCode)6:
		case (KeyCode)7:
		case (KeyCode)10:
		case (KeyCode)11:
		case (KeyCode)14:
		case (KeyCode)15:
		case (KeyCode)16:
		case (KeyCode)17:
		case (KeyCode)18:
		case (KeyCode)20:
		case (KeyCode)21:
		case (KeyCode)22:
		case (KeyCode)23:
		case (KeyCode)24:
		case (KeyCode)25:
		case (KeyCode)26:
		case (KeyCode)28:
		case (KeyCode)29:
		case (KeyCode)30:
		case (KeyCode)31:
		case KeyCode.Percent:
		case (KeyCode)65:
		case (KeyCode)66:
		case (KeyCode)67:
		case (KeyCode)68:
		case (KeyCode)69:
		case (KeyCode)70:
		case (KeyCode)71:
		case (KeyCode)72:
		case (KeyCode)73:
		case (KeyCode)74:
		case (KeyCode)75:
		case (KeyCode)76:
		case (KeyCode)77:
		case (KeyCode)78:
		case (KeyCode)79:
		case (KeyCode)80:
		case (KeyCode)81:
		case (KeyCode)82:
		case (KeyCode)83:
		case (KeyCode)84:
		case (KeyCode)85:
		case (KeyCode)86:
		case (KeyCode)87:
		case (KeyCode)88:
		case (KeyCode)89:
		case (KeyCode)90:
		case KeyCode.LeftCurlyBracket:
		case KeyCode.Pipe:
		case KeyCode.RightCurlyBracket:
		case KeyCode.Tilde:
			break;
		case KeyCode.Backspace:
			return "Backspace";
		case KeyCode.Tab:
			return "Tab";
		case KeyCode.Clear:
			return "Clear";
		case KeyCode.Return:
			return "Return";
		case KeyCode.Pause:
			return "PS";
		case KeyCode.Escape:
			return "Esc";
		case KeyCode.Space:
			return "Space";
		case KeyCode.Exclaim:
			return "!";
		case KeyCode.DoubleQuote:
			return "''";
		case KeyCode.Hash:
			return "#";
		case KeyCode.Dollar:
			return "$";
		case KeyCode.Ampersand:
			return "&";
		case KeyCode.Quote:
			return "'";
		case KeyCode.LeftParen:
			return "(";
		case KeyCode.RightParen:
			return ")";
		case KeyCode.Asterisk:
			return "*";
		case KeyCode.Plus:
			return "+";
		case KeyCode.Comma:
			return ",";
		case KeyCode.Minus:
			return "-";
		case KeyCode.Period:
			return ".";
		case KeyCode.Slash:
			return "/";
		case KeyCode.Alpha0:
			return "0";
		case KeyCode.Alpha1:
			return "1";
		case KeyCode.Alpha2:
			return "2";
		case KeyCode.Alpha3:
			return "3";
		case KeyCode.Alpha4:
			return "4";
		case KeyCode.Alpha5:
			return "5";
		case KeyCode.Alpha6:
			return "6";
		case KeyCode.Alpha7:
			return "7";
		case KeyCode.Alpha8:
			return "8";
		case KeyCode.Alpha9:
			return "9";
		case KeyCode.Colon:
			return ":";
		case KeyCode.Semicolon:
			return ";";
		case KeyCode.Less:
			return "<";
		case KeyCode.Equals:
			return "=";
		case KeyCode.Greater:
			return ">";
		case KeyCode.Question:
			return "?";
		case KeyCode.At:
			return "@";
		case KeyCode.LeftBracket:
			return "[";
		case KeyCode.Backslash:
			return "\\";
		case KeyCode.RightBracket:
			return "]";
		case KeyCode.Caret:
			return "^";
		case KeyCode.Underscore:
			return "_";
		case KeyCode.BackQuote:
			return "`";
		case KeyCode.A:
			return "A";
		case KeyCode.B:
			return "B";
		case KeyCode.C:
			return "C";
		case KeyCode.D:
			return "D";
		case KeyCode.E:
			return "E";
		case KeyCode.F:
			return "F";
		case KeyCode.G:
			return "G";
		case KeyCode.H:
			return "H";
		case KeyCode.I:
			return "I";
		case KeyCode.J:
			return "J";
		case KeyCode.K:
			return "K";
		case KeyCode.L:
			return "L";
		case KeyCode.M:
			return "M";
		case KeyCode.N:
			return "N";
		case KeyCode.O:
			return "O";
		case KeyCode.P:
			return "P";
		case KeyCode.Q:
			return "Q";
		case KeyCode.R:
			return "R";
		case KeyCode.S:
			return "S";
		case KeyCode.T:
			return "T";
		case KeyCode.U:
			return "U";
		case KeyCode.V:
			return "V";
		case KeyCode.W:
			return "W";
		case KeyCode.X:
			return "X";
		case KeyCode.Y:
			return "Y";
		case KeyCode.Z:
			return "Z";
		case KeyCode.Delete:
			return "Del";
		default:
			switch (key)
			{
			case KeyCode.Keypad0:
				return "K0";
			case KeyCode.Keypad1:
				return "K1";
			case KeyCode.Keypad2:
				return "K2";
			case KeyCode.Keypad3:
				return "K3";
			case KeyCode.Keypad4:
				return "K4";
			case KeyCode.Keypad5:
				return "K5";
			case KeyCode.Keypad6:
				return "K6";
			case KeyCode.Keypad7:
				return "K7";
			case KeyCode.Keypad8:
				return "K8";
			case KeyCode.Keypad9:
				return "K9";
			case KeyCode.KeypadPeriod:
				return "K.";
			case KeyCode.KeypadDivide:
				return "K/";
			case KeyCode.KeypadMultiply:
				return "K*";
			case KeyCode.KeypadMinus:
				return "K-";
			case KeyCode.KeypadPlus:
				return "K+";
			case KeyCode.KeypadEnter:
				return "KE";
			case KeyCode.KeypadEquals:
				return "KQ";
			case KeyCode.UpArrow:
				return "UP";
			case KeyCode.DownArrow:
				return "DN";
			case KeyCode.RightArrow:
				return "LT";
			case KeyCode.LeftArrow:
				return "RT";
			case KeyCode.Insert:
				return "Ins";
			case KeyCode.Home:
				return "Home";
			case KeyCode.End:
				return "End";
			case KeyCode.PageUp:
				return "PU";
			case KeyCode.PageDown:
				return "PD";
			case KeyCode.F1:
				return "F1";
			case KeyCode.F2:
				return "F2";
			case KeyCode.F3:
				return "F3";
			case KeyCode.F4:
				return "F4";
			case KeyCode.F5:
				return "F5";
			case KeyCode.F6:
				return "F6";
			case KeyCode.F7:
				return "F7";
			case KeyCode.F8:
				return "F8";
			case KeyCode.F9:
				return "F9";
			case KeyCode.F10:
				return "F10";
			case KeyCode.F11:
				return "F11";
			case KeyCode.F12:
				return "F12";
			case KeyCode.F13:
				return "F13";
			case KeyCode.F14:
				return "F14";
			case KeyCode.F15:
				return "F15";
			case KeyCode.Numlock:
				return "Num";
			case KeyCode.CapsLock:
				return "Cap";
			case KeyCode.ScrollLock:
				return "Scr";
			case KeyCode.RightShift:
				return "RS";
			case KeyCode.LeftShift:
				return "LS";
			case KeyCode.RightControl:
				return "RC";
			case KeyCode.LeftControl:
				return "LC";
			case KeyCode.RightAlt:
				return "RA";
			case KeyCode.LeftAlt:
				return "LA";
			case KeyCode.Mouse0:
				return "M0";
			case KeyCode.Mouse1:
				return "M1";
			case KeyCode.Mouse2:
				return "M2";
			case KeyCode.Mouse3:
				return "M3";
			case KeyCode.Mouse4:
				return "M4";
			case KeyCode.Mouse5:
				return "M5";
			case KeyCode.Mouse6:
				return "M6";
			case KeyCode.JoystickButton0:
				return "(A)";
			case KeyCode.JoystickButton1:
				return "(B)";
			case KeyCode.JoystickButton2:
				return "(X)";
			case KeyCode.JoystickButton3:
				return "(Y)";
			case KeyCode.JoystickButton4:
				return "(RB)";
			case KeyCode.JoystickButton5:
				return "(LB)";
			case KeyCode.JoystickButton6:
				return "(Back)";
			case KeyCode.JoystickButton7:
				return "(Start)";
			case KeyCode.JoystickButton8:
				return "(LS)";
			case KeyCode.JoystickButton9:
				return "(RS)";
			case KeyCode.JoystickButton10:
				return "J10";
			case KeyCode.JoystickButton11:
				return "J11";
			case KeyCode.JoystickButton12:
				return "J12";
			case KeyCode.JoystickButton13:
				return "J13";
			case KeyCode.JoystickButton14:
				return "J14";
			case KeyCode.JoystickButton15:
				return "J15";
			case KeyCode.JoystickButton16:
				return "J16";
			case KeyCode.JoystickButton17:
				return "J17";
			case KeyCode.JoystickButton18:
				return "J18";
			case KeyCode.JoystickButton19:
				return "J19";
			}
			break;
		}
		return null;
	}

	// Token: 0x06000440 RID: 1088 RVA: 0x0002B140 File Offset: 0x00029340
	public static KeyCode CaptionToKey(string caption)
	{
		if (string.IsNullOrEmpty(caption))
		{
			return KeyCode.None;
		}
		if (caption == "Backspace")
		{
			return KeyCode.Backspace;
		}
		if (caption == "Tab")
		{
			return KeyCode.Tab;
		}
		if (caption == "Clear")
		{
			return KeyCode.Clear;
		}
		if (caption == "Return")
		{
			return KeyCode.Return;
		}
		if (caption == "Pause")
		{
			return KeyCode.Pause;
		}
		if (caption == "Esc")
		{
			return KeyCode.Escape;
		}
		if (caption == "Space")
		{
			return KeyCode.Space;
		}
		if (caption == "!")
		{
			return KeyCode.Exclaim;
		}
		if (caption == "''")
		{
			return KeyCode.DoubleQuote;
		}
		if (caption == "#")
		{
			return KeyCode.Hash;
		}
		if (caption == "$")
		{
			return KeyCode.Dollar;
		}
		if (caption == "&")
		{
			return KeyCode.Ampersand;
		}
		if (caption == "'")
		{
			return KeyCode.Quote;
		}
		if (caption == "(")
		{
			return KeyCode.LeftParen;
		}
		if (caption == ")")
		{
			return KeyCode.RightParen;
		}
		if (caption == "*")
		{
			return KeyCode.Asterisk;
		}
		if (caption == "+")
		{
			return KeyCode.Plus;
		}
		if (caption == ",")
		{
			return KeyCode.Comma;
		}
		if (caption == "-")
		{
			return KeyCode.Minus;
		}
		if (caption == ".")
		{
			return KeyCode.Period;
		}
		if (caption == "/")
		{
			return KeyCode.Slash;
		}
		if (caption == "0")
		{
			return KeyCode.Alpha0;
		}
		if (caption == "1")
		{
			return KeyCode.Alpha1;
		}
		if (caption == "2")
		{
			return KeyCode.Alpha2;
		}
		if (caption == "3")
		{
			return KeyCode.Alpha3;
		}
		if (caption == "4")
		{
			return KeyCode.Alpha4;
		}
		if (caption == "5")
		{
			return KeyCode.Alpha5;
		}
		if (caption == "6")
		{
			return KeyCode.Alpha6;
		}
		if (caption == "7")
		{
			return KeyCode.Alpha7;
		}
		if (caption == "8")
		{
			return KeyCode.Alpha8;
		}
		if (caption == "9")
		{
			return KeyCode.Alpha9;
		}
		if (caption == ";//")
		{
			return KeyCode.Colon;
		}
		if (caption == ";")
		{
			return KeyCode.Semicolon;
		}
		if (caption == "<")
		{
			return KeyCode.Less;
		}
		if (caption == "=")
		{
			return KeyCode.Equals;
		}
		if (caption == ">")
		{
			return KeyCode.Greater;
		}
		if (caption == "?")
		{
			return KeyCode.Question;
		}
		if (caption == "@")
		{
			return KeyCode.At;
		}
		if (caption == "[")
		{
			return KeyCode.LeftBracket;
		}
		if (caption == "\\")
		{
			return KeyCode.Backslash;
		}
		if (caption == "]")
		{
			return KeyCode.RightBracket;
		}
		if (caption == "^")
		{
			return KeyCode.Caret;
		}
		if (caption == "_")
		{
			return KeyCode.Underscore;
		}
		if (caption == "`")
		{
			return KeyCode.BackQuote;
		}
		if (caption == "A")
		{
			return KeyCode.A;
		}
		if (caption == "B")
		{
			return KeyCode.B;
		}
		if (caption == "C")
		{
			return KeyCode.C;
		}
		if (caption == "D")
		{
			return KeyCode.D;
		}
		if (caption == "E")
		{
			return KeyCode.E;
		}
		if (caption == "F")
		{
			return KeyCode.F;
		}
		if (caption == "G")
		{
			return KeyCode.G;
		}
		if (caption == "H")
		{
			return KeyCode.H;
		}
		if (caption == "I")
		{
			return KeyCode.I;
		}
		if (caption == "J")
		{
			return KeyCode.J;
		}
		if (caption == "K")
		{
			return KeyCode.K;
		}
		if (caption == "L")
		{
			return KeyCode.L;
		}
		if (caption == "M")
		{
			return KeyCode.M;
		}
		if (caption == "N")
		{
			return KeyCode.N;
		}
		if (caption == "O")
		{
			return KeyCode.O;
		}
		if (caption == "P")
		{
			return KeyCode.P;
		}
		if (caption == "Q")
		{
			return KeyCode.Q;
		}
		if (caption == "R")
		{
			return KeyCode.R;
		}
		if (caption == "S")
		{
			return KeyCode.S;
		}
		if (caption == "T")
		{
			return KeyCode.T;
		}
		if (caption == "U")
		{
			return KeyCode.U;
		}
		if (caption == "V")
		{
			return KeyCode.V;
		}
		if (caption == "W")
		{
			return KeyCode.W;
		}
		if (caption == "X")
		{
			return KeyCode.X;
		}
		if (caption == "Y")
		{
			return KeyCode.Y;
		}
		if (caption == "Z")
		{
			return KeyCode.Z;
		}
		if (caption == "Del")
		{
			return KeyCode.Delete;
		}
		if (caption == "K0")
		{
			return KeyCode.Keypad0;
		}
		if (caption == "K1")
		{
			return KeyCode.Keypad1;
		}
		if (caption == "K2")
		{
			return KeyCode.Keypad2;
		}
		if (caption == "K3")
		{
			return KeyCode.Keypad3;
		}
		if (caption == "K4")
		{
			return KeyCode.Keypad4;
		}
		if (caption == "K5")
		{
			return KeyCode.Keypad5;
		}
		if (caption == "K6")
		{
			return KeyCode.Keypad6;
		}
		if (caption == "K7")
		{
			return KeyCode.Keypad7;
		}
		if (caption == "K8")
		{
			return KeyCode.Keypad8;
		}
		if (caption == "K9")
		{
			return KeyCode.Keypad9;
		}
		if (caption == "K.")
		{
			return KeyCode.KeypadPeriod;
		}
		if (caption == "K/")
		{
			return KeyCode.KeypadDivide;
		}
		if (caption == "K*")
		{
			return KeyCode.KeypadMultiply;
		}
		if (caption == "K-")
		{
			return KeyCode.KeypadMinus;
		}
		if (caption == "K+")
		{
			return KeyCode.KeypadPlus;
		}
		if (caption == "KE")
		{
			return KeyCode.KeypadEnter;
		}
		if (caption == "KQ")
		{
			return KeyCode.KeypadEquals;
		}
		if (caption == "UP")
		{
			return KeyCode.UpArrow;
		}
		if (caption == "DN")
		{
			return KeyCode.DownArrow;
		}
		if (caption == "LT")
		{
			return KeyCode.RightArrow;
		}
		if (caption == "RT")
		{
			return KeyCode.LeftArrow;
		}
		if (caption == "Ins")
		{
			return KeyCode.Insert;
		}
		if (caption == "Home")
		{
			return KeyCode.Home;
		}
		if (caption == "End")
		{
			return KeyCode.End;
		}
		if (caption == "PU")
		{
			return KeyCode.PageUp;
		}
		if (caption == "PD")
		{
			return KeyCode.PageDown;
		}
		if (caption == "F1")
		{
			return KeyCode.F1;
		}
		if (caption == "F2")
		{
			return KeyCode.F2;
		}
		if (caption == "F3")
		{
			return KeyCode.F3;
		}
		if (caption == "F4")
		{
			return KeyCode.F4;
		}
		if (caption == "F5")
		{
			return KeyCode.F5;
		}
		if (caption == "F6")
		{
			return KeyCode.F6;
		}
		if (caption == "F7")
		{
			return KeyCode.F7;
		}
		if (caption == "F8")
		{
			return KeyCode.F8;
		}
		if (caption == "F9")
		{
			return KeyCode.F9;
		}
		if (caption == "F10")
		{
			return KeyCode.F10;
		}
		if (caption == "F11")
		{
			return KeyCode.F11;
		}
		if (caption == "F12")
		{
			return KeyCode.F12;
		}
		if (caption == "F13")
		{
			return KeyCode.F13;
		}
		if (caption == "F14")
		{
			return KeyCode.F14;
		}
		if (caption == "F15")
		{
			return KeyCode.F15;
		}
		if (caption == "Num")
		{
			return KeyCode.Numlock;
		}
		if (caption == "Cap")
		{
			return KeyCode.CapsLock;
		}
		if (caption == "Scr")
		{
			return KeyCode.ScrollLock;
		}
		if (caption == "RS")
		{
			return KeyCode.RightShift;
		}
		if (caption == "LS")
		{
			return KeyCode.LeftShift;
		}
		if (caption == "RC")
		{
			return KeyCode.RightControl;
		}
		if (caption == "LC")
		{
			return KeyCode.LeftControl;
		}
		if (caption == "RA")
		{
			return KeyCode.RightAlt;
		}
		if (caption == "LA")
		{
			return KeyCode.LeftAlt;
		}
		if (caption == "M0")
		{
			return KeyCode.Mouse0;
		}
		if (caption == "M1")
		{
			return KeyCode.Mouse1;
		}
		if (caption == "M2")
		{
			return KeyCode.Mouse2;
		}
		if (caption == "M3")
		{
			return KeyCode.Mouse3;
		}
		if (caption == "M4")
		{
			return KeyCode.Mouse4;
		}
		if (caption == "M5")
		{
			return KeyCode.Mouse5;
		}
		if (caption == "M6")
		{
			return KeyCode.Mouse6;
		}
		if (caption == "(A)")
		{
			return KeyCode.JoystickButton0;
		}
		if (caption == "(B)")
		{
			return KeyCode.JoystickButton1;
		}
		if (caption == "(X)")
		{
			return KeyCode.JoystickButton2;
		}
		if (caption == "(Y)")
		{
			return KeyCode.JoystickButton3;
		}
		if (caption == "(RB)")
		{
			return KeyCode.JoystickButton4;
		}
		if (caption == "(LB)")
		{
			return KeyCode.JoystickButton5;
		}
		if (caption == "(Back)")
		{
			return KeyCode.JoystickButton6;
		}
		if (caption == "(Start)")
		{
			return KeyCode.JoystickButton7;
		}
		if (caption == "(LS)")
		{
			return KeyCode.JoystickButton8;
		}
		if (caption == "(RS)")
		{
			return KeyCode.JoystickButton9;
		}
		if (caption == "J10")
		{
			return KeyCode.JoystickButton10;
		}
		if (caption == "J11")
		{
			return KeyCode.JoystickButton11;
		}
		if (caption == "J12")
		{
			return KeyCode.JoystickButton12;
		}
		if (caption == "J13")
		{
			return KeyCode.JoystickButton13;
		}
		if (caption == "J14")
		{
			return KeyCode.JoystickButton14;
		}
		if (caption == "J15")
		{
			return KeyCode.JoystickButton15;
		}
		if (caption == "J16")
		{
			return KeyCode.JoystickButton16;
		}
		if (caption == "J17")
		{
			return KeyCode.JoystickButton17;
		}
		if (caption == "J18")
		{
			return KeyCode.JoystickButton18;
		}
		if (caption == "J19")
		{
			return KeyCode.JoystickButton19;
		}
		return KeyCode.None;
	}

	// Token: 0x06000441 RID: 1089 RVA: 0x0002BB80 File Offset: 0x00029D80
	public static T Draw<T>(string id, NGUITools.OnInitFunc<T> onInit = null) where T : UIWidget
	{
		UIWidget uiwidget;
		if (NGUITools.mWidgets.TryGetValue(id, out uiwidget) && uiwidget)
		{
			return (T)((object)uiwidget);
		}
		if (NGUITools.mRoot == null)
		{
			UICamera x = null;
			UIRoot uiroot = null;
			for (int i = 0; i < UIRoot.list.Count; i++)
			{
				UIRoot uiroot2 = UIRoot.list[i];
				if (uiroot2)
				{
					UICamera uicamera = UICamera.FindCameraForLayer(uiroot2.gameObject.layer);
					if (uicamera && uicamera.cachedCamera.orthographic)
					{
						x = uicamera;
						uiroot = uiroot2;
						break;
					}
				}
			}
			if (x == null)
			{
				NGUITools.mRoot = NGUITools.CreateUI(false, LayerMask.NameToLayer("UI"));
			}
			else
			{
				NGUITools.mRoot = uiroot.gameObject.AddChild<UIPanel>();
			}
			NGUITools.mRoot.depth = 100000;
			NGUITools.mGo = NGUITools.mRoot.gameObject;
			NGUITools.mGo.name = "Immediate Mode GUI";
		}
		uiwidget = NGUITools.mGo.AddWidget(int.MaxValue);
		uiwidget.name = id;
		NGUITools.mWidgets[id] = uiwidget;
		if (onInit != null)
		{
			onInit((T)((object)uiwidget));
		}
		return (T)((object)uiwidget);
	}

	// Token: 0x06000442 RID: 1090 RVA: 0x0002BCB8 File Offset: 0x00029EB8
	public static Color GammaToLinearSpace(this Color c)
	{
		if (NGUITools.mColorSpace == ColorSpace.Uninitialized)
		{
			NGUITools.mColorSpace = QualitySettings.activeColorSpace;
		}
		if (NGUITools.mColorSpace == ColorSpace.Linear)
		{
			return new Color(Mathf.GammaToLinearSpace(c.r), Mathf.GammaToLinearSpace(c.g), Mathf.GammaToLinearSpace(c.b), Mathf.GammaToLinearSpace(c.a));
		}
		return c;
	}

	// Token: 0x06000443 RID: 1091 RVA: 0x0002BD14 File Offset: 0x00029F14
	public static Color LinearToGammaSpace(this Color c)
	{
		if (NGUITools.mColorSpace == ColorSpace.Uninitialized)
		{
			NGUITools.mColorSpace = QualitySettings.activeColorSpace;
		}
		if (NGUITools.mColorSpace == ColorSpace.Linear)
		{
			return new Color(Mathf.LinearToGammaSpace(c.r), Mathf.LinearToGammaSpace(c.g), Mathf.LinearToGammaSpace(c.b), Mathf.LinearToGammaSpace(c.a));
		}
		return c;
	}

	// Token: 0x06000444 RID: 1092 RVA: 0x0002BD6E File Offset: 0x00029F6E
	public static bool CheckIfRelated(INGUIAtlas a, INGUIAtlas b)
	{
		return a != null && b != null && (a == b || a.References(b) || b.References(a));
	}

	// Token: 0x06000445 RID: 1093 RVA: 0x0002BD90 File Offset: 0x00029F90
	public static void Replace(INGUIAtlas before, INGUIAtlas after)
	{
		UISprite[] array = NGUITools.FindActive<UISprite>();
		int i = 0;
		int num = array.Length;
		while (i < num)
		{
			UISprite uisprite = array[i];
			if (uisprite.atlas == before)
			{
				uisprite.atlas = after;
			}
			i++;
		}
		UIFont[] array2 = Resources.FindObjectsOfTypeAll<UIFont>();
		int j = 0;
		int num2 = array2.Length;
		while (j < num2)
		{
			UIFont uifont = array2[j];
			if (uifont.atlas == before)
			{
				uifont.atlas = after;
			}
			j++;
		}
		NGUIFont[] array3 = Resources.FindObjectsOfTypeAll<NGUIFont>();
		int k = 0;
		int num3 = array3.Length;
		while (k < num3)
		{
			NGUIFont nguifont = array3[k];
			if (nguifont.atlas == before)
			{
				nguifont.atlas = after;
			}
			k++;
		}
		UILabel[] array4 = NGUITools.FindActive<UILabel>();
		int l = 0;
		int num4 = array4.Length;
		while (l < num4)
		{
			UILabel uilabel = array4[l];
			if (uilabel.bitmapFont != null && uilabel.atlas == before)
			{
				uilabel.atlas = after;
			}
			l++;
		}
	}

	// Token: 0x06000446 RID: 1094 RVA: 0x0002BE78 File Offset: 0x0002A078
	public static bool CheckIfRelated(INGUIFont a, INGUIFont b)
	{
		return a != null && b != null && ((a.isDynamic && b.isDynamic && a.dynamicFont.fontNames[0] == b.dynamicFont.fontNames[0]) || a == b || a.References(b) || b.References(a));
	}

	// Token: 0x06000447 RID: 1095 RVA: 0x0002BED8 File Offset: 0x0002A0D8
	// Note: this type is marked as 'beforefieldinit'.
	static NGUITools()
	{
		KeyCode[] array = new KeyCode[145];
		RuntimeHelpers.InitializeArray(array, fieldof(<PrivateImplementationDetails>.6383AD8D3ACB5400C9BB99B6431A223D7472A06120C1C15C09458B0FCB291E2B).FieldHandle);
		NGUITools.keys = array;
		NGUITools.mWidgets = new Dictionary<string, UIWidget>();
		NGUITools.mColorSpace = ColorSpace.Uninitialized;
	}

	// Token: 0x040004DD RID: 1245
	[NonSerialized]
	private static AudioListener mListener;

	// Token: 0x040004DE RID: 1246
	[NonSerialized]
	public static AudioSource audioSource;

	// Token: 0x040004DF RID: 1247
	private static bool mLoaded = false;

	// Token: 0x040004E0 RID: 1248
	private static float mGlobalVolume = 1f;

	// Token: 0x040004E1 RID: 1249
	private static float mLastTimestamp = 0f;

	// Token: 0x040004E2 RID: 1250
	private static AudioClip mLastClip;

	// Token: 0x040004E3 RID: 1251
	private static Dictionary<Type, string> mTypeNames = new Dictionary<Type, string>();

	// Token: 0x040004E4 RID: 1252
	private static Vector3[] mSides = new Vector3[4];

	// Token: 0x040004E5 RID: 1253
	public static KeyCode[] keys;

	// Token: 0x040004E6 RID: 1254
	private static Dictionary<string, UIWidget> mWidgets;

	// Token: 0x040004E7 RID: 1255
	private static UIPanel mRoot;

	// Token: 0x040004E8 RID: 1256
	private static GameObject mGo;

	// Token: 0x040004E9 RID: 1257
	private static ColorSpace mColorSpace;

	// Token: 0x020005EF RID: 1519
	// (Invoke) Token: 0x0600254A RID: 9546
	public delegate void OnInitFunc<T>(T w) where T : UIWidget;
}
