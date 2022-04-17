using System;
using UnityEngine;

// Token: 0x02000280 RID: 640
public class DetectClickScript : MonoBehaviour
{
	// Token: 0x06001385 RID: 4997 RVA: 0x000B3F7B File Offset: 0x000B217B
	private void Start()
	{
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalColor = this.Sprite.color;
	}

	// Token: 0x06001386 RID: 4998 RVA: 0x000B3FA0 File Offset: 0x000B21A0
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(this.GUICamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider && this.Label.color.a == 1f)
		{
			this.Sprite.color = new Color(1f, 1f, 1f, 1f);
			this.Clicked = true;
		}
	}

	// Token: 0x06001387 RID: 4999 RVA: 0x000B4029 File Offset: 0x000B2229
	private void OnTriggerEnter()
	{
		if (this.Label.color.a == 1f)
		{
			this.Sprite.color = Color.white;
		}
	}

	// Token: 0x06001388 RID: 5000 RVA: 0x000B4052 File Offset: 0x000B2252
	private void OnTriggerExit()
	{
		this.Sprite.color = this.OriginalColor;
	}

	// Token: 0x04001CE0 RID: 7392
	public Vector3 OriginalPosition;

	// Token: 0x04001CE1 RID: 7393
	public Color OriginalColor;

	// Token: 0x04001CE2 RID: 7394
	public Collider MyCollider;

	// Token: 0x04001CE3 RID: 7395
	public Camera GUICamera;

	// Token: 0x04001CE4 RID: 7396
	public UISprite Sprite;

	// Token: 0x04001CE5 RID: 7397
	public UILabel Label;

	// Token: 0x04001CE6 RID: 7398
	public bool Clicked;
}
