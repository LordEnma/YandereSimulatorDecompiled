using System;
using UnityEngine;

// Token: 0x02000469 RID: 1129
public class TagScript : MonoBehaviour
{
	// Token: 0x06001EA5 RID: 7845 RVA: 0x001A8B62 File Offset: 0x001A6D62
	private void Start()
	{
		this.Sprite.color = new Color(1f, 0f, 0f, 0f);
		this.MainCameraCamera = this.MainCamera.GetComponent<Camera>();
	}

	// Token: 0x06001EA6 RID: 7846 RVA: 0x001A8B9C File Offset: 0x001A6D9C
	private void Update()
	{
		if (this.Target != null && Vector3.Angle(this.MainCamera.forward, this.MainCamera.position - this.Target.position) > 90f)
		{
			Vector2 vector = this.MainCameraCamera.WorldToScreenPoint(this.Target.position);
			base.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
		}
	}

	// Token: 0x04003F26 RID: 16166
	public UISprite Sprite;

	// Token: 0x04003F27 RID: 16167
	public Camera UICamera;

	// Token: 0x04003F28 RID: 16168
	public Camera MainCameraCamera;

	// Token: 0x04003F29 RID: 16169
	public Transform MainCamera;

	// Token: 0x04003F2A RID: 16170
	public Transform Target;
}
