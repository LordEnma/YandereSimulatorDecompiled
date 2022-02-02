using System;
using UnityEngine;

// Token: 0x0200005A RID: 90
[AddComponentMenu("NGUI/Interaction/Key Navigation")]
public class UIKeyNavigation : MonoBehaviour
{
	// Token: 0x1700001A RID: 26
	// (get) Token: 0x060001EE RID: 494 RVA: 0x00018328 File Offset: 0x00016528
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
	// (get) Token: 0x060001EF RID: 495 RVA: 0x0001834C File Offset: 0x0001654C
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

	// Token: 0x060001F0 RID: 496 RVA: 0x0001839F File Offset: 0x0001659F
	protected virtual void OnEnable()
	{
		UIKeyNavigation.list.Add(this);
		if (this.mStarted)
		{
			base.Invoke("Start", 0.001f);
		}
	}

	// Token: 0x060001F1 RID: 497 RVA: 0x000183C4 File Offset: 0x000165C4
	private void Start()
	{
		this.mStarted = true;
		if (this.startsSelected && this.isColliderEnabled)
		{
			UICamera.selectedObject = base.gameObject;
		}
	}

	// Token: 0x060001F2 RID: 498 RVA: 0x000183E8 File Offset: 0x000165E8
	protected virtual void OnDisable()
	{
		UIKeyNavigation.list.Remove(this);
	}

	// Token: 0x060001F3 RID: 499 RVA: 0x000183F8 File Offset: 0x000165F8
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

	// Token: 0x060001F4 RID: 500 RVA: 0x00018446 File Offset: 0x00016646
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

	// Token: 0x060001F5 RID: 501 RVA: 0x00018485 File Offset: 0x00016685
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

	// Token: 0x060001F6 RID: 502 RVA: 0x000184C4 File Offset: 0x000166C4
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

	// Token: 0x060001F7 RID: 503 RVA: 0x00018503 File Offset: 0x00016703
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

	// Token: 0x060001F8 RID: 504 RVA: 0x00018544 File Offset: 0x00016744
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

	// Token: 0x060001F9 RID: 505 RVA: 0x00018650 File Offset: 0x00016850
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

	// Token: 0x060001FA RID: 506 RVA: 0x0001870C File Offset: 0x0001690C
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

	// Token: 0x060001FB RID: 507 RVA: 0x0001878C File Offset: 0x0001698C
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

	// Token: 0x060001FC RID: 508 RVA: 0x00018891 File Offset: 0x00016A91
	protected virtual void OnClick()
	{
		if (NGUITools.GetActive(this.onClick))
		{
			UICamera.hoveredObject = this.onClick;
		}
	}

	// Token: 0x04000399 RID: 921
	public static BetterList<UIKeyNavigation> list = new BetterList<UIKeyNavigation>();

	// Token: 0x0400039A RID: 922
	public UIKeyNavigation.Constraint constraint;

	// Token: 0x0400039B RID: 923
	public GameObject onUp;

	// Token: 0x0400039C RID: 924
	public GameObject onDown;

	// Token: 0x0400039D RID: 925
	public GameObject onLeft;

	// Token: 0x0400039E RID: 926
	public GameObject onRight;

	// Token: 0x0400039F RID: 927
	public GameObject onClick;

	// Token: 0x040003A0 RID: 928
	public GameObject onTab;

	// Token: 0x040003A1 RID: 929
	public bool startsSelected;

	// Token: 0x040003A2 RID: 930
	[NonSerialized]
	private bool mStarted;

	// Token: 0x040003A3 RID: 931
	public static int mLastFrame = 0;

	// Token: 0x020005CC RID: 1484
	[DoNotObfuscateNGUI]
	public enum Constraint
	{
		// Token: 0x04004D24 RID: 19748
		None,
		// Token: 0x04004D25 RID: 19749
		Vertical,
		// Token: 0x04004D26 RID: 19750
		Horizontal,
		// Token: 0x04004D27 RID: 19751
		Explicit
	}
}
