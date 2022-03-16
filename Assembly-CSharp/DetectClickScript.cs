using System;
using UnityEngine;

// Token: 0x02000280 RID: 640
public class DetectClickScript : MonoBehaviour
{
	// Token: 0x06001384 RID: 4996 RVA: 0x000B3D43 File Offset: 0x000B1F43
	private void Start()
	{
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalColor = this.Sprite.color;
	}

	// Token: 0x06001385 RID: 4997 RVA: 0x000B3D68 File Offset: 0x000B1F68
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(this.GUICamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider && this.Label.color.a == 1f)
		{
			this.Sprite.color = new Color(1f, 1f, 1f, 1f);
			this.Clicked = true;
		}
	}

	// Token: 0x06001386 RID: 4998 RVA: 0x000B3DF1 File Offset: 0x000B1FF1
	private void OnTriggerEnter()
	{
		if (this.Label.color.a == 1f)
		{
			this.Sprite.color = Color.white;
		}
	}

	// Token: 0x06001387 RID: 4999 RVA: 0x000B3E1A File Offset: 0x000B201A
	private void OnTriggerExit()
	{
		this.Sprite.color = this.OriginalColor;
	}

	// Token: 0x04001CDC RID: 7388
	public Vector3 OriginalPosition;

	// Token: 0x04001CDD RID: 7389
	public Color OriginalColor;

	// Token: 0x04001CDE RID: 7390
	public Collider MyCollider;

	// Token: 0x04001CDF RID: 7391
	public Camera GUICamera;

	// Token: 0x04001CE0 RID: 7392
	public UISprite Sprite;

	// Token: 0x04001CE1 RID: 7393
	public UILabel Label;

	// Token: 0x04001CE2 RID: 7394
	public bool Clicked;
}
