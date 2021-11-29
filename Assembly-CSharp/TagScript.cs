using System;
using UnityEngine;

// Token: 0x0200045D RID: 1117
public class TagScript : MonoBehaviour
{
	// Token: 0x06001E4B RID: 7755 RVA: 0x001A0A7E File Offset: 0x0019EC7E
	private void Start()
	{
		this.Sprite.color = new Color(1f, 0f, 0f, 0f);
		this.MainCameraCamera = this.MainCamera.GetComponent<Camera>();
	}

	// Token: 0x06001E4C RID: 7756 RVA: 0x001A0AB8 File Offset: 0x0019ECB8
	private void Update()
	{
		if (this.Target != null && Vector3.Angle(this.MainCamera.forward, this.MainCamera.position - this.Target.position) > 90f)
		{
			Vector2 vector = this.MainCameraCamera.WorldToScreenPoint(this.Target.position);
			base.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
		}
	}

	// Token: 0x04003E0C RID: 15884
	public UISprite Sprite;

	// Token: 0x04003E0D RID: 15885
	public Camera UICamera;

	// Token: 0x04003E0E RID: 15886
	public Camera MainCameraCamera;

	// Token: 0x04003E0F RID: 15887
	public Transform MainCamera;

	// Token: 0x04003E10 RID: 15888
	public Transform Target;
}
