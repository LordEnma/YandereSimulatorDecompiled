using System;
using UnityEngine;

// Token: 0x02000461 RID: 1121
public class TagScript : MonoBehaviour
{
	// Token: 0x06001E67 RID: 7783 RVA: 0x001A3A2E File Offset: 0x001A1C2E
	private void Start()
	{
		this.Sprite.color = new Color(1f, 0f, 0f, 0f);
		this.MainCameraCamera = this.MainCamera.GetComponent<Camera>();
	}

	// Token: 0x06001E68 RID: 7784 RVA: 0x001A3A68 File Offset: 0x001A1C68
	private void Update()
	{
		if (this.Target != null && Vector3.Angle(this.MainCamera.forward, this.MainCamera.position - this.Target.position) > 90f)
		{
			Vector2 vector = this.MainCameraCamera.WorldToScreenPoint(this.Target.position);
			base.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
		}
	}

	// Token: 0x04003E6B RID: 15979
	public UISprite Sprite;

	// Token: 0x04003E6C RID: 15980
	public Camera UICamera;

	// Token: 0x04003E6D RID: 15981
	public Camera MainCameraCamera;

	// Token: 0x04003E6E RID: 15982
	public Transform MainCamera;

	// Token: 0x04003E6F RID: 15983
	public Transform Target;
}
