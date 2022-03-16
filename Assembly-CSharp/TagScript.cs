using System;
using UnityEngine;

// Token: 0x02000465 RID: 1125
public class TagScript : MonoBehaviour
{
	// Token: 0x06001E8D RID: 7821 RVA: 0x001A697A File Offset: 0x001A4B7A
	private void Start()
	{
		this.Sprite.color = new Color(1f, 0f, 0f, 0f);
		this.MainCameraCamera = this.MainCamera.GetComponent<Camera>();
	}

	// Token: 0x06001E8E RID: 7822 RVA: 0x001A69B4 File Offset: 0x001A4BB4
	private void Update()
	{
		if (this.Target != null && Vector3.Angle(this.MainCamera.forward, this.MainCamera.position - this.Target.position) > 90f)
		{
			Vector2 vector = this.MainCameraCamera.WorldToScreenPoint(this.Target.position);
			base.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
		}
	}

	// Token: 0x04003EE8 RID: 16104
	public UISprite Sprite;

	// Token: 0x04003EE9 RID: 16105
	public Camera UICamera;

	// Token: 0x04003EEA RID: 16106
	public Camera MainCameraCamera;

	// Token: 0x04003EEB RID: 16107
	public Transform MainCamera;

	// Token: 0x04003EEC RID: 16108
	public Transform Target;
}
