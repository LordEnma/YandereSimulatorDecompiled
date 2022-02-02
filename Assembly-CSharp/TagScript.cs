using System;
using UnityEngine;

// Token: 0x02000461 RID: 1121
public class TagScript : MonoBehaviour
{
	// Token: 0x06001E65 RID: 7781 RVA: 0x001A3722 File Offset: 0x001A1922
	private void Start()
	{
		this.Sprite.color = new Color(1f, 0f, 0f, 0f);
		this.MainCameraCamera = this.MainCamera.GetComponent<Camera>();
	}

	// Token: 0x06001E66 RID: 7782 RVA: 0x001A375C File Offset: 0x001A195C
	private void Update()
	{
		if (this.Target != null && Vector3.Angle(this.MainCamera.forward, this.MainCamera.position - this.Target.position) > 90f)
		{
			Vector2 vector = this.MainCameraCamera.WorldToScreenPoint(this.Target.position);
			base.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
		}
	}

	// Token: 0x04003E65 RID: 15973
	public UISprite Sprite;

	// Token: 0x04003E66 RID: 15974
	public Camera UICamera;

	// Token: 0x04003E67 RID: 15975
	public Camera MainCameraCamera;

	// Token: 0x04003E68 RID: 15976
	public Transform MainCamera;

	// Token: 0x04003E69 RID: 15977
	public Transform Target;
}
