using System;
using UnityEngine;

// Token: 0x0200027F RID: 639
public class DetectClickScript : MonoBehaviour
{
	// Token: 0x0600137C RID: 4988 RVA: 0x000B31FB File Offset: 0x000B13FB
	private void Start()
	{
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalColor = this.Sprite.color;
	}

	// Token: 0x0600137D RID: 4989 RVA: 0x000B3220 File Offset: 0x000B1420
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(this.GUICamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider && this.Label.color.a == 1f)
		{
			this.Sprite.color = new Color(1f, 1f, 1f, 1f);
			this.Clicked = true;
		}
	}

	// Token: 0x0600137E RID: 4990 RVA: 0x000B32A9 File Offset: 0x000B14A9
	private void OnTriggerEnter()
	{
		if (this.Label.color.a == 1f)
		{
			this.Sprite.color = Color.white;
		}
	}

	// Token: 0x0600137F RID: 4991 RVA: 0x000B32D2 File Offset: 0x000B14D2
	private void OnTriggerExit()
	{
		this.Sprite.color = this.OriginalColor;
	}

	// Token: 0x04001CB6 RID: 7350
	public Vector3 OriginalPosition;

	// Token: 0x04001CB7 RID: 7351
	public Color OriginalColor;

	// Token: 0x04001CB8 RID: 7352
	public Collider MyCollider;

	// Token: 0x04001CB9 RID: 7353
	public Camera GUICamera;

	// Token: 0x04001CBA RID: 7354
	public UISprite Sprite;

	// Token: 0x04001CBB RID: 7355
	public UILabel Label;

	// Token: 0x04001CBC RID: 7356
	public bool Clicked;
}
