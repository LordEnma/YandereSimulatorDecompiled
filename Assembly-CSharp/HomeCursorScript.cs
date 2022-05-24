using System;
using UnityEngine;

// Token: 0x0200031D RID: 797
public class HomeCursorScript : MonoBehaviour
{
	// Token: 0x06001891 RID: 6289 RVA: 0x000EE4A0 File Offset: 0x000EC6A0
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

	// Token: 0x06001892 RID: 6290 RVA: 0x000EE520 File Offset: 0x000EC720
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

	// Token: 0x06001893 RID: 6291 RVA: 0x000EE638 File Offset: 0x000EC838
	private void PhotographNull()
	{
		this.Highlight.position = new Vector3(this.Highlight.position.x, 100f, this.Highlight.position.z);
		this.Photograph = null;
		this.PhotoGallery.UpdateButtonPrompts();
	}

	// Token: 0x040024CA RID: 9418
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x040024CB RID: 9419
	public GameObject Photograph;

	// Token: 0x040024CC RID: 9420
	public Transform Highlight;

	// Token: 0x040024CD RID: 9421
	public GameObject Tack;

	// Token: 0x040024CE RID: 9422
	public Transform CircleHighlight;
}
