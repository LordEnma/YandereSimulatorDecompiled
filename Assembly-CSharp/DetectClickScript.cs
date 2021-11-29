using System;
using UnityEngine;

// Token: 0x0200027E RID: 638
public class DetectClickScript : MonoBehaviour
{
	// Token: 0x06001375 RID: 4981 RVA: 0x000B2C83 File Offset: 0x000B0E83
	private void Start()
	{
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalColor = this.Sprite.color;
	}

	// Token: 0x06001376 RID: 4982 RVA: 0x000B2CA8 File Offset: 0x000B0EA8
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(this.GUICamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider && this.Label.color.a == 1f)
		{
			this.Sprite.color = new Color(1f, 1f, 1f, 1f);
			this.Clicked = true;
		}
	}

	// Token: 0x06001377 RID: 4983 RVA: 0x000B2D31 File Offset: 0x000B0F31
	private void OnTriggerEnter()
	{
		if (this.Label.color.a == 1f)
		{
			this.Sprite.color = Color.white;
		}
	}

	// Token: 0x06001378 RID: 4984 RVA: 0x000B2D5A File Offset: 0x000B0F5A
	private void OnTriggerExit()
	{
		this.Sprite.color = this.OriginalColor;
	}

	// Token: 0x04001C96 RID: 7318
	public Vector3 OriginalPosition;

	// Token: 0x04001C97 RID: 7319
	public Color OriginalColor;

	// Token: 0x04001C98 RID: 7320
	public Collider MyCollider;

	// Token: 0x04001C99 RID: 7321
	public Camera GUICamera;

	// Token: 0x04001C9A RID: 7322
	public UISprite Sprite;

	// Token: 0x04001C9B RID: 7323
	public UILabel Label;

	// Token: 0x04001C9C RID: 7324
	public bool Clicked;
}
