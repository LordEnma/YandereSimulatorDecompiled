using System;
using UnityEngine;

// Token: 0x0200031C RID: 796
public class HomeCursorScript : MonoBehaviour
{
	// Token: 0x0600188C RID: 6284 RVA: 0x000EE058 File Offset: 0x000EC258
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject == this.Photograph)
		{
			this.PhotographNull();
		}
		if (other.gameObject == this.Tack)
		{
			this.CircleHighlight.position = new Vector3(this.CircleHighlight.position.x, 100f, this.Highlight.position.z);
			this.Tack = null;
			this.PhotoGallery.UpdateButtonPrompts();
		}
	}

	// Token: 0x0600188D RID: 6285 RVA: 0x000EE0D8 File Offset: 0x000EC2D8
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 16)
		{
			if (this.Tack == null)
			{
				this.Photograph = other.gameObject;
				this.Highlight.localEulerAngles = this.Photograph.transform.localEulerAngles;
				this.Highlight.localPosition = this.Photograph.transform.localPosition;
				this.Highlight.localScale = new Vector3(this.Photograph.transform.localScale.x * 1.12f, this.Photograph.transform.localScale.y * 1.2f, 1f);
				this.PhotoGallery.UpdateButtonPrompts();
				return;
			}
		}
		else if (other.gameObject.name != "SouthWall")
		{
			this.Tack = other.gameObject;
			this.CircleHighlight.position = this.Tack.transform.position;
			this.PhotoGallery.UpdateButtonPrompts();
			this.PhotographNull();
		}
	}

	// Token: 0x0600188E RID: 6286 RVA: 0x000EE1F0 File Offset: 0x000EC3F0
	private void PhotographNull()
	{
		this.Highlight.position = new Vector3(this.Highlight.position.x, 100f, this.Highlight.position.z);
		this.Photograph = null;
		this.PhotoGallery.UpdateButtonPrompts();
	}

	// Token: 0x040024BE RID: 9406
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x040024BF RID: 9407
	public GameObject Photograph;

	// Token: 0x040024C0 RID: 9408
	public Transform Highlight;

	// Token: 0x040024C1 RID: 9409
	public GameObject Tack;

	// Token: 0x040024C2 RID: 9410
	public Transform CircleHighlight;
}
