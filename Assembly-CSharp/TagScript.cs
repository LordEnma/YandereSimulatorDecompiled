using System;
using UnityEngine;

// Token: 0x0200046B RID: 1131
public class TagScript : MonoBehaviour
{
	// Token: 0x06001EB7 RID: 7863 RVA: 0x001AB086 File Offset: 0x001A9286
	private void Start()
	{
		this.Sprite.color = new Color(1f, 0f, 0f, 0f);
		this.MainCameraCamera = this.MainCamera.GetComponent<Camera>();
	}

	// Token: 0x06001EB8 RID: 7864 RVA: 0x001AB0C0 File Offset: 0x001A92C0
	private void Update()
	{
		if (this.Target != null && Vector3.Angle(this.MainCamera.forward, this.MainCamera.position - this.Target.position) > 90f)
		{
			Vector2 vector = this.MainCameraCamera.WorldToScreenPoint(this.Target.position);
			base.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
		}
	}

	// Token: 0x04003F59 RID: 16217
	public UISprite Sprite;

	// Token: 0x04003F5A RID: 16218
	public Camera UICamera;

	// Token: 0x04003F5B RID: 16219
	public Camera MainCameraCamera;

	// Token: 0x04003F5C RID: 16220
	public Transform MainCamera;

	// Token: 0x04003F5D RID: 16221
	public Transform Target;
}
