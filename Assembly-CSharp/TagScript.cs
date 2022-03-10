using System;
using UnityEngine;

// Token: 0x02000463 RID: 1123
public class TagScript : MonoBehaviour
{
	// Token: 0x06001E7D RID: 7805 RVA: 0x001A526E File Offset: 0x001A346E
	private void Start()
	{
		this.Sprite.color = new Color(1f, 0f, 0f, 0f);
		this.MainCameraCamera = this.MainCamera.GetComponent<Camera>();
	}

	// Token: 0x06001E7E RID: 7806 RVA: 0x001A52A8 File Offset: 0x001A34A8
	private void Update()
	{
		if (this.Target != null && Vector3.Angle(this.MainCamera.forward, this.MainCamera.position - this.Target.position) > 90f)
		{
			Vector2 vector = this.MainCameraCamera.WorldToScreenPoint(this.Target.position);
			base.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
		}
	}

	// Token: 0x04003E9E RID: 16030
	public UISprite Sprite;

	// Token: 0x04003E9F RID: 16031
	public Camera UICamera;

	// Token: 0x04003EA0 RID: 16032
	public Camera MainCameraCamera;

	// Token: 0x04003EA1 RID: 16033
	public Transform MainCamera;

	// Token: 0x04003EA2 RID: 16034
	public Transform Target;
}
