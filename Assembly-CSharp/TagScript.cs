using System;
using UnityEngine;

// Token: 0x02000469 RID: 1129
public class TagScript : MonoBehaviour
{
	// Token: 0x06001E9F RID: 7839 RVA: 0x001A818A File Offset: 0x001A638A
	private void Start()
	{
		this.Sprite.color = new Color(1f, 0f, 0f, 0f);
		this.MainCameraCamera = this.MainCamera.GetComponent<Camera>();
	}

	// Token: 0x06001EA0 RID: 7840 RVA: 0x001A81C4 File Offset: 0x001A63C4
	private void Update()
	{
		if (this.Target != null && Vector3.Angle(this.MainCamera.forward, this.MainCamera.position - this.Target.position) > 90f)
		{
			Vector2 vector = this.MainCameraCamera.WorldToScreenPoint(this.Target.position);
			base.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
		}
	}

	// Token: 0x04003F16 RID: 16150
	public UISprite Sprite;

	// Token: 0x04003F17 RID: 16151
	public Camera UICamera;

	// Token: 0x04003F18 RID: 16152
	public Camera MainCameraCamera;

	// Token: 0x04003F19 RID: 16153
	public Transform MainCamera;

	// Token: 0x04003F1A RID: 16154
	public Transform Target;
}
