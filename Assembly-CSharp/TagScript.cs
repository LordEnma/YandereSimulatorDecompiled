using System;
using UnityEngine;

// Token: 0x0200045E RID: 1118
public class TagScript : MonoBehaviour
{
	// Token: 0x06001E55 RID: 7765 RVA: 0x001A17A2 File Offset: 0x0019F9A2
	private void Start()
	{
		this.Sprite.color = new Color(1f, 0f, 0f, 0f);
		this.MainCameraCamera = this.MainCamera.GetComponent<Camera>();
	}

	// Token: 0x06001E56 RID: 7766 RVA: 0x001A17DC File Offset: 0x0019F9DC
	private void Update()
	{
		if (this.Target != null && Vector3.Angle(this.MainCamera.forward, this.MainCamera.position - this.Target.position) > 90f)
		{
			Vector2 vector = this.MainCameraCamera.WorldToScreenPoint(this.Target.position);
			base.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
		}
	}

	// Token: 0x04003E3C RID: 15932
	public UISprite Sprite;

	// Token: 0x04003E3D RID: 15933
	public Camera UICamera;

	// Token: 0x04003E3E RID: 15934
	public Camera MainCameraCamera;

	// Token: 0x04003E3F RID: 15935
	public Transform MainCamera;

	// Token: 0x04003E40 RID: 15936
	public Transform Target;
}
