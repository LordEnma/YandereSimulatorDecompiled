using System;
using UnityEngine;

// Token: 0x02000318 RID: 792
public class HomeCursorScript : MonoBehaviour
{
	// Token: 0x06001863 RID: 6243 RVA: 0x000EBFBC File Offset: 0x000EA1BC
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

	// Token: 0x06001864 RID: 6244 RVA: 0x000EC03C File Offset: 0x000EA23C
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

	// Token: 0x06001865 RID: 6245 RVA: 0x000EC154 File Offset: 0x000EA354
	private void PhotographNull()
	{
		this.Highlight.position = new Vector3(this.Highlight.position.x, 100f, this.Highlight.position.z);
		this.Photograph = null;
		this.PhotoGallery.UpdateButtonPrompts();
	}

	// Token: 0x0400245D RID: 9309
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x0400245E RID: 9310
	public GameObject Photograph;

	// Token: 0x0400245F RID: 9311
	public Transform Highlight;

	// Token: 0x04002460 RID: 9312
	public GameObject Tack;

	// Token: 0x04002461 RID: 9313
	public Transform CircleHighlight;
}
