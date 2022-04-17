using System;
using UnityEngine;

// Token: 0x0200005A RID: 90
[AddComponentMenu("NGUI/Interaction/Key Navigation")]
public class UIKeyNavigation : MonoBehaviour
{
	// Token: 0x1700001A RID: 26
	// (get) Token: 0x060001EE RID: 494 RVA: 0x000184D8 File Offset: 0x000166D8
	public static UIKeyNavigation current
	{
		get
		{
			GameObject hoveredObject = UICamera.hoveredObject;
			if (hoveredObject == null)
			{
				return null;
			}
			return hoveredObject.GetComponent<UIKeyNavigation>();
		}
	}

	// Token: 0x1700001B RID: 27
	// (get) Token: 0x060001EF RID: 495 RVA: 0x000184FC File Offset: 0x000166FC
	public bool isColliderEnabled
	{
		get
		{
			if (!base.enabled || !base.gameObject.activeInHierarchy)
			{
				return false;
			}
			Collider component = base.GetComponent<Collider>();
			if (component != null)
			{
				return component.enabled;
			}
			Collider2D component2 = base.GetComponent<Collider2D>();
			return component2 != null && component2.enabled;
		}
	}

	// Token: 0x060001F0 RID: 496 RVA: 0x0001854F File Offset: 0x0001674F
	protected virtual void OnEnable()
	{
		UIKeyNavigation.list.Add(this);
		if (this.mStarted)
		{
			base.Invoke("Start", 0.001f);
		}
	}

	// Token: 0x060001F1 RID: 497 RVA: 0x00018574 File Offset: 0x00016774
	private void Start()
	{
		this.mStarted = true;
		if (this.startsSelected && this.isColliderEnabled)
		{
			UICamera.selectedObject = base.gameObject;
		}
	}

	// Token: 0x060001F2 RID: 498 RVA: 0x00018598 File Offset: 0x00016798
	protected virtual void OnDisable()
	{
		UIKeyNavigation.list.Remove(this);
	}

	// Token: 0x060001F3 RID: 499 RVA: 0x000185A8 File Offset: 0x000167A8
	private static bool IsActive(GameObject go)
	{
		if (!go || !go.activeInHierarchy)
		{
			return false;
		}
		Collider component = go.GetComponent<Collider>();
		if (component != null)
		{
			return component.enabled;
		}
		Collider2D component2 = go.GetComponent<Collider2D>();
		return component2 != null && component2.enabled;
	}

	// Token: 0x060001F4 RID: 500 RVA: 0x000185F6 File Offset: 0x000167F6
	public GameObject GetLeft()
	{
		if (UIKeyNavigation.IsActive(this.onLeft))
		{
			return this.onLeft;
		}
		if (this.constraint == UIKeyNavigation.Constraint.Vertical || this.constraint == UIKeyNavigation.Constraint.Explicit)
		{
			return null;
		}
		return this.Get(Vector3.left, 1f, 2f);
	}

	// Token: 0x060001F5 RID: 501 RVA: 0x00018635 File Offset: 0x00016835
	public GameObject GetRight()
	{
		if (UIKeyNavigation.IsActive(this.onRight))
		{
			return this.onRight;
		}
		if (this.constraint == UIKeyNavigation.Constraint.Vertical || this.constraint == UIKeyNavigation.Constraint.Explicit)
		{
			return null;
		}
		return this.Get(Vector3.right, 1f, 2f);
	}

	// Token: 0x060001F6 RID: 502 RVA: 0x00018674 File Offset: 0x00016874
	public GameObject GetUp()
	{
		if (UIKeyNavigation.IsActive(this.onUp))
		{
			return this.onUp;
		}
		if (this.constraint == UIKeyNavigation.Constraint.Horizontal || this.constraint == UIKeyNavigation.Constraint.Explicit)
		{
			return null;
		}
		return this.Get(Vector3.up, 2f, 1f);
	}

	// Token: 0x060001F7 RID: 503 RVA: 0x000186B3 File Offset: 0x000168B3
	public GameObject GetDown()
	{
		if (UIKeyNavigation.IsActive(this.onDown))
		{
			return this.onDown;
		}
		if (this.constraint == UIKeyNavigation.Constraint.Horizontal || this.constraint == UIKeyNavigation.Constraint.Explicit)
		{
			return null;
		}
		return this.Get(Vector3.down, 2f, 1f);
	}

	// Token: 0x060001F8 RID: 504 RVA: 0x000186F4 File Offset: 0x000168F4
	public GameObject Get(Vector3 myDir, float x = 1f, float y = 1f)
	{
		Transform transform = base.transform;
		myDir = transform.TransformDirection(myDir);
		Vector3 center = UIKeyNavigation.GetCenter(base.gameObject);
		float num = float.MaxValue;
		GameObject result = null;
		for (int i = 0; i < UIKeyNavigation.list.size; i++)
		{
			UIKeyNavigation uikeyNavigation = UIKeyNavigation.list.buffer[i];
			if (!(uikeyNavigation == this) && uikeyNavigation.constraint != UIKeyNavigation.Constraint.Explicit && uikeyNavigation.isColliderEnabled)
			{
				UIWidget component = uikeyNavigation.GetComponent<UIWidget>();
				if (!(component != null) || component.alpha != 0f)
				{
					Vector3 direction = UIKeyNavigation.GetCenter(uikeyNavigation.gameObject) - center;
					if (Vector3.Dot(myDir, direction.normalized) >= 0.707f)
					{
						direction = transform.InverseTransformDirection(direction);
						direction.x *= x;
						direction.y *= y;
						float sqrMagnitude = direction.sqrMagnitude;
						if (sqrMagnitude <= num)
						{
							result = uikeyNavigation.gameObject;
							num = sqrMagnitude;
						}
					}
				}
			}
		}
		return result;
	}

	// Token: 0x060001F9 RID: 505 RVA: 0x00018800 File Offset: 0x00016A00
	protected static Vector3 GetCenter(GameObject go)
	{
		UIWidget component = go.GetComponent<UIWidget>();
		UICamera uicamera = UICamera.FindCameraForLayer(go.layer);
		if (uicamera != null)
		{
			Vector3 vector = go.transform.position;
			if (component != null)
			{
				Vector3[] worldCorners = component.worldCorners;
				vector = (worldCorners[0] + worldCorners[2]) * 0.5f;
			}
			vector = uicamera.cachedCamera.WorldToScreenPoint(vector);
			vector.z = 0f;
			return vector;
		}
		if (component != null)
		{
			Vector3[] worldCorners2 = component.worldCorners;
			return (worldCorners2[0] + worldCorners2[2]) * 0.5f;
		}
		return go.transform.position;
	}

	// Token: 0x060001FA RID: 506 RVA: 0x000188BC File Offset: 0x00016ABC
	public virtual void OnNavigate(KeyCode key)
	{
		if (UIPopupList.isOpen)
		{
			return;
		}
		if (UIKeyNavigation.mLastFrame == Time.frameCount)
		{
			return;
		}
		UIKeyNavigation.mLastFrame = Time.frameCount;
		GameObject gameObject = null;
		switch (key)
		{
		case KeyCode.UpArrow:
			gameObject = this.GetUp();
			break;
		case KeyCode.DownArrow:
			gameObject = this.GetDown();
			break;
		case KeyCode.RightArrow:
			gameObject = this.GetRight();
			break;
		case KeyCode.LeftArrow:
			gameObject = this.GetLeft();
			break;
		}
		if (gameObject != null)
		{
			UICamera.hoveredObject = gameObject;
		}
	}

	// Token: 0x060001FB RID: 507 RVA: 0x0001893C File Offset: 0x00016B3C
	public virtual void OnKey(KeyCode key)
	{
		if (UIPopupList.isOpen)
		{
			return;
		}
		if (UIKeyNavigation.mLastFrame == Time.frameCount)
		{
			return;
		}
		UIKeyNavigation.mLastFrame = Time.frameCount;
		if (key == KeyCode.Tab)
		{
			GameObject gameObject = this.onTab;
			if (gameObject == null)
			{
				if (UICamera.GetKey(KeyCode.LeftShift) || UICamera.GetKey(KeyCode.RightShift))
				{
					gameObject = this.GetLeft();
					if (gameObject == null)
					{
						gameObject = this.GetUp();
					}
					if (gameObject == null)
					{
						gameObject = this.GetDown();
					}
					if (gameObject == null)
					{
						gameObject = this.GetRight();
					}
				}
				else
				{
					gameObject = this.GetRight();
					if (gameObject == null)
					{
						gameObject = this.GetDown();
					}
					if (gameObject == null)
					{
						gameObject = this.GetUp();
					}
					if (gameObject == null)
					{
						gameObject = this.GetLeft();
					}
				}
			}
			if (gameObject != null)
			{
				UICamera.currentScheme = UICamera.ControlScheme.Controller;
				UICamera.hoveredObject = gameObject;
				UIInput component = gameObject.GetComponent<UIInput>();
				if (component != null)
				{
					component.isSelected = true;
				}
			}
		}
	}

	// Token: 0x060001FC RID: 508 RVA: 0x00018A41 File Offset: 0x00016C41
	protected virtual void OnClick()
	{
		if (NGUITools.GetActive(this.onClick))
		{
			UICamera.hoveredObject = this.onClick;
		}
	}

	// Token: 0x040003A3 RID: 931
	public static BetterList<UIKeyNavigation> list = new BetterList<UIKeyNavigation>();

	// Token: 0x040003A4 RID: 932
	public UIKeyNavigation.Constraint constraint;

	// Token: 0x040003A5 RID: 933
	public GameObject onUp;

	// Token: 0x040003A6 RID: 934
	public GameObject onDown;

	// Token: 0x040003A7 RID: 935
	public GameObject onLeft;

	// Token: 0x040003A8 RID: 936
	public GameObject onRight;

	// Token: 0x040003A9 RID: 937
	public GameObject onClick;

	// Token: 0x040003AA RID: 938
	public GameObject onTab;

	// Token: 0x040003AB RID: 939
	public bool startsSelected;

	// Token: 0x040003AC RID: 940
	[NonSerialized]
	private bool mStarted;

	// Token: 0x040003AD RID: 941
	public static int mLastFrame = 0;

	// Token: 0x020005D9 RID: 1497
	[DoNotObfuscateNGUI]
	public enum Constraint
	{
		// Token: 0x04004E0A RID: 19978
		None,
		// Token: 0x04004E0B RID: 19979
		Vertical,
		// Token: 0x04004E0C RID: 19980
		Horizontal,
		// Token: 0x04004E0D RID: 19981
		Explicit
	}
}
