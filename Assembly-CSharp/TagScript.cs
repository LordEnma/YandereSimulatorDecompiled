using System;
using UnityEngine;

// Token: 0x02000460 RID: 1120
public class TagScript : MonoBehaviour
{
	// Token: 0x06001E62 RID: 7778 RVA: 0x001A25BE File Offset: 0x001A07BE
	private void Start()
	{
		this.Sprite.color = new Color(1f, 0f, 0f, 0f);
		this.MainCameraCamera = this.MainCamera.GetComponent<Camera>();
	}

	// Token: 0x06001E63 RID: 7779 RVA: 0x001A25F8 File Offset: 0x001A07F8
	private void Update()
	{
		if (this.Target != null && Vector3.Angle(this.MainCamera.forward, this.MainCamera.position - this.Target.position) > 90f)
		{
			Vector2 vector = this.MainCameraCamera.WorldToScreenPoint(this.Target.position);
			base.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
		}
	}

	// Token: 0x04003E57 RID: 15959
	public UISprite Sprite;

	// Token: 0x04003E58 RID: 15960
	public Camera UICamera;

	// Token: 0x04003E59 RID: 15961
	public Camera MainCameraCamera;

	// Token: 0x04003E5A RID: 15962
	public Transform MainCamera;

	// Token: 0x04003E5B RID: 15963
	public Transform Target;
}
