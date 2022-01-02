using System;
using UnityEngine;

// Token: 0x0200045E RID: 1118
public class TagScript : MonoBehaviour
{
	// Token: 0x06001E57 RID: 7767 RVA: 0x001A1C3E File Offset: 0x0019FE3E
	private void Start()
	{
		this.Sprite.color = new Color(1f, 0f, 0f, 0f);
		this.MainCameraCamera = this.MainCamera.GetComponent<Camera>();
	}

	// Token: 0x06001E58 RID: 7768 RVA: 0x001A1C78 File Offset: 0x0019FE78
	private void Update()
	{
		if (this.Target != null && Vector3.Angle(this.MainCamera.forward, this.MainCamera.position - this.Target.position) > 90f)
		{
			Vector2 vector = this.MainCameraCamera.WorldToScreenPoint(this.Target.position);
			base.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
		}
	}

	// Token: 0x04003E43 RID: 15939
	public UISprite Sprite;

	// Token: 0x04003E44 RID: 15940
	public Camera UICamera;

	// Token: 0x04003E45 RID: 15941
	public Camera MainCameraCamera;

	// Token: 0x04003E46 RID: 15942
	public Transform MainCamera;

	// Token: 0x04003E47 RID: 15943
	public Transform Target;
}
