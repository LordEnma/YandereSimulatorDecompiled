using System;
using UnityEngine;

// Token: 0x02000461 RID: 1121
public class TagScript : MonoBehaviour
{
	// Token: 0x06001E6A RID: 7786 RVA: 0x001A3C2A File Offset: 0x001A1E2A
	private void Start()
	{
		this.Sprite.color = new Color(1f, 0f, 0f, 0f);
		this.MainCameraCamera = this.MainCamera.GetComponent<Camera>();
	}

	// Token: 0x06001E6B RID: 7787 RVA: 0x001A3C64 File Offset: 0x001A1E64
	private void Update()
	{
		if (this.Target != null && Vector3.Angle(this.MainCamera.forward, this.MainCamera.position - this.Target.position) > 90f)
		{
			Vector2 vector = this.MainCameraCamera.WorldToScreenPoint(this.Target.position);
			base.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
		}
	}

	// Token: 0x04003E6E RID: 15982
	public UISprite Sprite;

	// Token: 0x04003E6F RID: 15983
	public Camera UICamera;

	// Token: 0x04003E70 RID: 15984
	public Camera MainCameraCamera;

	// Token: 0x04003E71 RID: 15985
	public Transform MainCamera;

	// Token: 0x04003E72 RID: 15986
	public Transform Target;
}
