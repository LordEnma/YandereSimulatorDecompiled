using System;
using UnityEngine;

// Token: 0x0200031A RID: 794
public class HomeCursorScript : MonoBehaviour
{
	// Token: 0x06001878 RID: 6264 RVA: 0x000ED204 File Offset: 0x000EB404
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

	// Token: 0x06001879 RID: 6265 RVA: 0x000ED284 File Offset: 0x000EB484
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

	// Token: 0x0600187A RID: 6266 RVA: 0x000ED39C File Offset: 0x000EB59C
	private void PhotographNull()
	{
		this.Highlight.position = new Vector3(this.Highlight.position.x, 100f, this.Highlight.position.z);
		this.Photograph = null;
		this.PhotoGallery.UpdateButtonPrompts();
	}

	// Token: 0x04002497 RID: 9367
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x04002498 RID: 9368
	public GameObject Photograph;

	// Token: 0x04002499 RID: 9369
	public Transform Highlight;

	// Token: 0x0400249A RID: 9370
	public GameObject Tack;

	// Token: 0x0400249B RID: 9371
	public Transform CircleHighlight;
}
