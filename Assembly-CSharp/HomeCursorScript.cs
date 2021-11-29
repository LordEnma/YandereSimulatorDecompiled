using System;
using UnityEngine;

// Token: 0x02000316 RID: 790
public class HomeCursorScript : MonoBehaviour
{
	// Token: 0x06001853 RID: 6227 RVA: 0x000EAB34 File Offset: 0x000E8D34
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

	// Token: 0x06001854 RID: 6228 RVA: 0x000EABB4 File Offset: 0x000E8DB4
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

	// Token: 0x06001855 RID: 6229 RVA: 0x000EACCC File Offset: 0x000E8ECC
	private void PhotographNull()
	{
		this.Highlight.position = new Vector3(this.Highlight.position.x, 100f, this.Highlight.position.z);
		this.Photograph = null;
		this.PhotoGallery.UpdateButtonPrompts();
	}

	// Token: 0x04002429 RID: 9257
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x0400242A RID: 9258
	public GameObject Photograph;

	// Token: 0x0400242B RID: 9259
	public Transform Highlight;

	// Token: 0x0400242C RID: 9260
	public GameObject Tack;

	// Token: 0x0400242D RID: 9261
	public Transform CircleHighlight;
}
