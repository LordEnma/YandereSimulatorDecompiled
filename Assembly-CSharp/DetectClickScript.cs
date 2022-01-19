using System;
using UnityEngine;

// Token: 0x0200027F RID: 639
public class DetectClickScript : MonoBehaviour
{
	// Token: 0x0600137C RID: 4988 RVA: 0x000B34AB File Offset: 0x000B16AB
	private void Start()
	{
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalColor = this.Sprite.color;
	}

	// Token: 0x0600137D RID: 4989 RVA: 0x000B34D0 File Offset: 0x000B16D0
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(this.GUICamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider && this.Label.color.a == 1f)
		{
			this.Sprite.color = new Color(1f, 1f, 1f, 1f);
			this.Clicked = true;
		}
	}

	// Token: 0x0600137E RID: 4990 RVA: 0x000B3559 File Offset: 0x000B1759
	private void OnTriggerEnter()
	{
		if (this.Label.color.a == 1f)
		{
			this.Sprite.color = Color.white;
		}
	}

	// Token: 0x0600137F RID: 4991 RVA: 0x000B3582 File Offset: 0x000B1782
	private void OnTriggerExit()
	{
		this.Sprite.color = this.OriginalColor;
	}

	// Token: 0x04001CBB RID: 7355
	public Vector3 OriginalPosition;

	// Token: 0x04001CBC RID: 7356
	public Color OriginalColor;

	// Token: 0x04001CBD RID: 7357
	public Collider MyCollider;

	// Token: 0x04001CBE RID: 7358
	public Camera GUICamera;

	// Token: 0x04001CBF RID: 7359
	public UISprite Sprite;

	// Token: 0x04001CC0 RID: 7360
	public UILabel Label;

	// Token: 0x04001CC1 RID: 7361
	public bool Clicked;
}
