using System;
using UnityEngine;

// Token: 0x02000281 RID: 641
public class DetectClickScript : MonoBehaviour
{
	// Token: 0x0600138B RID: 5003 RVA: 0x000B465B File Offset: 0x000B285B
	private void Start()
	{
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalColor = this.Sprite.color;
	}

	// Token: 0x0600138C RID: 5004 RVA: 0x000B4680 File Offset: 0x000B2880
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(this.GUICamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider && this.Label.color.a == 1f)
		{
			this.Sprite.color = new Color(1f, 1f, 1f, 1f);
			this.Clicked = true;
		}
	}

	// Token: 0x0600138D RID: 5005 RVA: 0x000B4709 File Offset: 0x000B2909
	private void OnTriggerEnter()
	{
		if (this.Label.color.a == 1f)
		{
			this.Sprite.color = Color.white;
		}
	}

	// Token: 0x0600138E RID: 5006 RVA: 0x000B4732 File Offset: 0x000B2932
	private void OnTriggerExit()
	{
		this.Sprite.color = this.OriginalColor;
	}

	// Token: 0x04001CEF RID: 7407
	public Vector3 OriginalPosition;

	// Token: 0x04001CF0 RID: 7408
	public Color OriginalColor;

	// Token: 0x04001CF1 RID: 7409
	public Collider MyCollider;

	// Token: 0x04001CF2 RID: 7410
	public Camera GUICamera;

	// Token: 0x04001CF3 RID: 7411
	public UISprite Sprite;

	// Token: 0x04001CF4 RID: 7412
	public UILabel Label;

	// Token: 0x04001CF5 RID: 7413
	public bool Clicked;
}
