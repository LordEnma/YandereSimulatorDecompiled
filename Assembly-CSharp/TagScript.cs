using System;
using UnityEngine;

// Token: 0x0200046A RID: 1130
public class TagScript : MonoBehaviour
{
	// Token: 0x06001EAF RID: 7855 RVA: 0x001A9F0E File Offset: 0x001A810E
	private void Start()
	{
		this.Sprite.color = new Color(1f, 0f, 0f, 0f);
		this.MainCameraCamera = this.MainCamera.GetComponent<Camera>();
	}

	// Token: 0x06001EB0 RID: 7856 RVA: 0x001A9F48 File Offset: 0x001A8148
	private void Update()
	{
		if (this.Target != null && Vector3.Angle(this.MainCamera.forward, this.MainCamera.position - this.Target.position) > 90f)
		{
			Vector2 vector = this.MainCameraCamera.WorldToScreenPoint(this.Target.position);
			base.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
		}
	}

	// Token: 0x04003F3B RID: 16187
	public UISprite Sprite;

	// Token: 0x04003F3C RID: 16188
	public Camera UICamera;

	// Token: 0x04003F3D RID: 16189
	public Camera MainCameraCamera;

	// Token: 0x04003F3E RID: 16190
	public Transform MainCamera;

	// Token: 0x04003F3F RID: 16191
	public Transform Target;
}
