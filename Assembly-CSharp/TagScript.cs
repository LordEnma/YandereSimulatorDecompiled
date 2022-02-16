using System;
using UnityEngine;

// Token: 0x02000462 RID: 1122
public class TagScript : MonoBehaviour
{
	// Token: 0x06001E71 RID: 7793 RVA: 0x001A406E File Offset: 0x001A226E
	private void Start()
	{
		this.Sprite.color = new Color(1f, 0f, 0f, 0f);
		this.MainCameraCamera = this.MainCamera.GetComponent<Camera>();
	}

	// Token: 0x06001E72 RID: 7794 RVA: 0x001A40A8 File Offset: 0x001A22A8
	private void Update()
	{
		if (this.Target != null && Vector3.Angle(this.MainCamera.forward, this.MainCamera.position - this.Target.position) > 90f)
		{
			Vector2 vector = this.MainCameraCamera.WorldToScreenPoint(this.Target.position);
			base.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
		}
	}

	// Token: 0x04003E77 RID: 15991
	public UISprite Sprite;

	// Token: 0x04003E78 RID: 15992
	public Camera UICamera;

	// Token: 0x04003E79 RID: 15993
	public Camera MainCameraCamera;

	// Token: 0x04003E7A RID: 15994
	public Transform MainCamera;

	// Token: 0x04003E7B RID: 15995
	public Transform Target;
}
