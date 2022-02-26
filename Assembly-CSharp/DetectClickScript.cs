using System;
using UnityEngine;

// Token: 0x02000280 RID: 640
public class DetectClickScript : MonoBehaviour
{
	// Token: 0x06001381 RID: 4993 RVA: 0x000B37FF File Offset: 0x000B19FF
	private void Start()
	{
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalColor = this.Sprite.color;
	}

	// Token: 0x06001382 RID: 4994 RVA: 0x000B3824 File Offset: 0x000B1A24
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(this.GUICamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider && this.Label.color.a == 1f)
		{
			this.Sprite.color = new Color(1f, 1f, 1f, 1f);
			this.Clicked = true;
		}
	}

	// Token: 0x06001383 RID: 4995 RVA: 0x000B38AD File Offset: 0x000B1AAD
	private void OnTriggerEnter()
	{
		if (this.Label.color.a == 1f)
		{
			this.Sprite.color = Color.white;
		}
	}

	// Token: 0x06001384 RID: 4996 RVA: 0x000B38D6 File Offset: 0x000B1AD6
	private void OnTriggerExit()
	{
		this.Sprite.color = this.OriginalColor;
	}

	// Token: 0x04001CC5 RID: 7365
	public Vector3 OriginalPosition;

	// Token: 0x04001CC6 RID: 7366
	public Color OriginalColor;

	// Token: 0x04001CC7 RID: 7367
	public Collider MyCollider;

	// Token: 0x04001CC8 RID: 7368
	public Camera GUICamera;

	// Token: 0x04001CC9 RID: 7369
	public UISprite Sprite;

	// Token: 0x04001CCA RID: 7370
	public UILabel Label;

	// Token: 0x04001CCB RID: 7371
	public bool Clicked;
}
