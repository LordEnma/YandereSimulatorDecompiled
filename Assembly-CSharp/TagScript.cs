using System;
using UnityEngine;

// Token: 0x02000463 RID: 1123
public class TagScript : MonoBehaviour
{
	// Token: 0x06001E7A RID: 7802 RVA: 0x001A4BAA File Offset: 0x001A2DAA
	private void Start()
	{
		this.Sprite.color = new Color(1f, 0f, 0f, 0f);
		this.MainCameraCamera = this.MainCamera.GetComponent<Camera>();
	}

	// Token: 0x06001E7B RID: 7803 RVA: 0x001A4BE4 File Offset: 0x001A2DE4
	private void Update()
	{
		if (this.Target != null && Vector3.Angle(this.MainCamera.forward, this.MainCamera.position - this.Target.position) > 90f)
		{
			Vector2 vector = this.MainCameraCamera.WorldToScreenPoint(this.Target.position);
			base.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
		}
	}

	// Token: 0x04003E87 RID: 16007
	public UISprite Sprite;

	// Token: 0x04003E88 RID: 16008
	public Camera UICamera;

	// Token: 0x04003E89 RID: 16009
	public Camera MainCameraCamera;

	// Token: 0x04003E8A RID: 16010
	public Transform MainCamera;

	// Token: 0x04003E8B RID: 16011
	public Transform Target;
}
