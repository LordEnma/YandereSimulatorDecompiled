using System;
using UnityEngine;

// Token: 0x0200046B RID: 1131
public class TagScript : MonoBehaviour
{
	// Token: 0x06001EB8 RID: 7864 RVA: 0x001AB4A6 File Offset: 0x001A96A6
	private void Start()
	{
		this.Sprite.color = new Color(1f, 0f, 0f, 0f);
		this.MainCameraCamera = this.MainCamera.GetComponent<Camera>();
	}

	// Token: 0x06001EB9 RID: 7865 RVA: 0x001AB4E0 File Offset: 0x001A96E0
	private void Update()
	{
		if (this.Target != null && Vector3.Angle(this.MainCamera.forward, this.MainCamera.position - this.Target.position) > 90f)
		{
			Vector2 vector = this.MainCameraCamera.WorldToScreenPoint(this.Target.position);
			base.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
		}
	}

	// Token: 0x04003F62 RID: 16226
	public UISprite Sprite;

	// Token: 0x04003F63 RID: 16227
	public Camera UICamera;

	// Token: 0x04003F64 RID: 16228
	public Camera MainCameraCamera;

	// Token: 0x04003F65 RID: 16229
	public Transform MainCamera;

	// Token: 0x04003F66 RID: 16230
	public Transform Target;
}
