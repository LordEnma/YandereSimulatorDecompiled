using System;
using UnityEngine;

// Token: 0x02000319 RID: 793
public class HomeCursorScript : MonoBehaviour
{
	// Token: 0x0600186A RID: 6250 RVA: 0x000EC130 File Offset: 0x000EA330
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

	// Token: 0x0600186B RID: 6251 RVA: 0x000EC1B0 File Offset: 0x000EA3B0
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

	// Token: 0x0600186C RID: 6252 RVA: 0x000EC2C8 File Offset: 0x000EA4C8
	private void PhotographNull()
	{
		this.Highlight.position = new Vector3(this.Highlight.position.x, 100f, this.Highlight.position.z);
		this.Photograph = null;
		this.PhotoGallery.UpdateButtonPrompts();
	}

	// Token: 0x04002463 RID: 9315
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x04002464 RID: 9316
	public GameObject Photograph;

	// Token: 0x04002465 RID: 9317
	public Transform Highlight;

	// Token: 0x04002466 RID: 9318
	public GameObject Tack;

	// Token: 0x04002467 RID: 9319
	public Transform CircleHighlight;
}
