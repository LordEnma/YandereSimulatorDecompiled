using System;
using UnityEngine;

// Token: 0x02000280 RID: 640
public class DetectClickScript : MonoBehaviour
{
	// Token: 0x06001389 RID: 5001 RVA: 0x000B43DF File Offset: 0x000B25DF
	private void Start()
	{
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalColor = this.Sprite.color;
	}

	// Token: 0x0600138A RID: 5002 RVA: 0x000B4404 File Offset: 0x000B2604
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(this.GUICamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider && this.Label.color.a == 1f)
		{
			this.Sprite.color = new Color(1f, 1f, 1f, 1f);
			this.Clicked = true;
		}
	}

	// Token: 0x0600138B RID: 5003 RVA: 0x000B448D File Offset: 0x000B268D
	private void OnTriggerEnter()
	{
		if (this.Label.color.a == 1f)
		{
			this.Sprite.color = Color.white;
		}
	}

	// Token: 0x0600138C RID: 5004 RVA: 0x000B44B6 File Offset: 0x000B26B6
	private void OnTriggerExit()
	{
		this.Sprite.color = this.OriginalColor;
	}

	// Token: 0x04001CE8 RID: 7400
	public Vector3 OriginalPosition;

	// Token: 0x04001CE9 RID: 7401
	public Color OriginalColor;

	// Token: 0x04001CEA RID: 7402
	public Collider MyCollider;

	// Token: 0x04001CEB RID: 7403
	public Camera GUICamera;

	// Token: 0x04001CEC RID: 7404
	public UISprite Sprite;

	// Token: 0x04001CED RID: 7405
	public UILabel Label;

	// Token: 0x04001CEE RID: 7406
	public bool Clicked;
}
