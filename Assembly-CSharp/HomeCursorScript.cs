using System;
using UnityEngine;

// Token: 0x02000317 RID: 791
public class HomeCursorScript : MonoBehaviour
{
	// Token: 0x0600185A RID: 6234 RVA: 0x000EB2F4 File Offset: 0x000E94F4
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

	// Token: 0x0600185B RID: 6235 RVA: 0x000EB374 File Offset: 0x000E9574
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

	// Token: 0x0600185C RID: 6236 RVA: 0x000EB48C File Offset: 0x000E968C
	private void PhotographNull()
	{
		this.Highlight.position = new Vector3(this.Highlight.position.x, 100f, this.Highlight.position.z);
		this.Photograph = null;
		this.PhotoGallery.UpdateButtonPrompts();
	}

	// Token: 0x04002449 RID: 9289
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x0400244A RID: 9290
	public GameObject Photograph;

	// Token: 0x0400244B RID: 9291
	public Transform Highlight;

	// Token: 0x0400244C RID: 9292
	public GameObject Tack;

	// Token: 0x0400244D RID: 9293
	public Transform CircleHighlight;
}
