using System;
using UnityEngine;

// Token: 0x02000318 RID: 792
public class HomeCursorScript : MonoBehaviour
{
	// Token: 0x06001860 RID: 6240 RVA: 0x000EB910 File Offset: 0x000E9B10
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

	// Token: 0x06001861 RID: 6241 RVA: 0x000EB990 File Offset: 0x000E9B90
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

	// Token: 0x06001862 RID: 6242 RVA: 0x000EBAA8 File Offset: 0x000E9CA8
	private void PhotographNull()
	{
		this.Highlight.position = new Vector3(this.Highlight.position.x, 100f, this.Highlight.position.z);
		this.Photograph = null;
		this.PhotoGallery.UpdateButtonPrompts();
	}

	// Token: 0x04002451 RID: 9297
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x04002452 RID: 9298
	public GameObject Photograph;

	// Token: 0x04002453 RID: 9299
	public Transform Highlight;

	// Token: 0x04002454 RID: 9300
	public GameObject Tack;

	// Token: 0x04002455 RID: 9301
	public Transform CircleHighlight;
}
