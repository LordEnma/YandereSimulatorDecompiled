using System;
using UnityEngine;

// Token: 0x02000468 RID: 1128
public class TagScript : MonoBehaviour
{
	// Token: 0x06001E97 RID: 7831 RVA: 0x001A7C96 File Offset: 0x001A5E96
	private void Start()
	{
		this.Sprite.color = new Color(1f, 0f, 0f, 0f);
		this.MainCameraCamera = this.MainCamera.GetComponent<Camera>();
	}

	// Token: 0x06001E98 RID: 7832 RVA: 0x001A7CD0 File Offset: 0x001A5ED0
	private void Update()
	{
		if (this.Target != null && Vector3.Angle(this.MainCamera.forward, this.MainCamera.position - this.Target.position) > 90f)
		{
			Vector2 vector = this.MainCameraCamera.WorldToScreenPoint(this.Target.position);
			base.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
		}
	}

	// Token: 0x04003F13 RID: 16147
	public UISprite Sprite;

	// Token: 0x04003F14 RID: 16148
	public Camera UICamera;

	// Token: 0x04003F15 RID: 16149
	public Camera MainCameraCamera;

	// Token: 0x04003F16 RID: 16150
	public Transform MainCamera;

	// Token: 0x04003F17 RID: 16151
	public Transform Target;
}
