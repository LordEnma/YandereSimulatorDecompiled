using System;
using UnityEngine;

// Token: 0x02000317 RID: 791
public class HomeCursorScript : MonoBehaviour
{
	// Token: 0x0600185C RID: 6236 RVA: 0x000EB5D8 File Offset: 0x000E97D8
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

	// Token: 0x0600185D RID: 6237 RVA: 0x000EB658 File Offset: 0x000E9858
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

	// Token: 0x0600185E RID: 6238 RVA: 0x000EB770 File Offset: 0x000E9970
	private void PhotographNull()
	{
		this.Highlight.position = new Vector3(this.Highlight.position.x, 100f, this.Highlight.position.z);
		this.Photograph = null;
		this.PhotoGallery.UpdateButtonPrompts();
	}

	// Token: 0x0400244D RID: 9293
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x0400244E RID: 9294
	public GameObject Photograph;

	// Token: 0x0400244F RID: 9295
	public Transform Highlight;

	// Token: 0x04002450 RID: 9296
	public GameObject Tack;

	// Token: 0x04002451 RID: 9297
	public Transform CircleHighlight;
}
