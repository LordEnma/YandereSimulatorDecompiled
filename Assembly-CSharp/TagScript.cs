using System;
using UnityEngine;

// Token: 0x02000461 RID: 1121
public class TagScript : MonoBehaviour
{
	// Token: 0x06001E64 RID: 7780 RVA: 0x001A328E File Offset: 0x001A148E
	private void Start()
	{
		this.Sprite.color = new Color(1f, 0f, 0f, 0f);
		this.MainCameraCamera = this.MainCamera.GetComponent<Camera>();
	}

	// Token: 0x06001E65 RID: 7781 RVA: 0x001A32C8 File Offset: 0x001A14C8
	private void Update()
	{
		if (this.Target != null && Vector3.Angle(this.MainCamera.forward, this.MainCamera.position - this.Target.position) > 90f)
		{
			Vector2 vector = this.MainCameraCamera.WorldToScreenPoint(this.Target.position);
			base.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
		}
	}

	// Token: 0x04003E5E RID: 15966
	public UISprite Sprite;

	// Token: 0x04003E5F RID: 15967
	public Camera UICamera;

	// Token: 0x04003E60 RID: 15968
	public Camera MainCameraCamera;

	// Token: 0x04003E61 RID: 15969
	public Transform MainCamera;

	// Token: 0x04003E62 RID: 15970
	public Transform Target;
}
