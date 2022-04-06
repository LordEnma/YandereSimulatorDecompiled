using System;
using UnityEngine;

// Token: 0x0200031C RID: 796
public class HomeCursorScript : MonoBehaviour
{
	// Token: 0x06001884 RID: 6276 RVA: 0x000ED8BC File Offset: 0x000EBABC
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

	// Token: 0x06001885 RID: 6277 RVA: 0x000ED93C File Offset: 0x000EBB3C
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

	// Token: 0x06001886 RID: 6278 RVA: 0x000EDA54 File Offset: 0x000EBC54
	private void PhotographNull()
	{
		this.Highlight.position = new Vector3(this.Highlight.position.x, 100f, this.Highlight.position.z);
		this.Photograph = null;
		this.PhotoGallery.UpdateButtonPrompts();
	}

	// Token: 0x040024AD RID: 9389
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x040024AE RID: 9390
	public GameObject Photograph;

	// Token: 0x040024AF RID: 9391
	public Transform Highlight;

	// Token: 0x040024B0 RID: 9392
	public GameObject Tack;

	// Token: 0x040024B1 RID: 9393
	public Transform CircleHighlight;
}
