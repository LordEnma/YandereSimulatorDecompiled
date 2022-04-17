using System;
using UnityEngine;

// Token: 0x0200031C RID: 796
public class HomeCursorScript : MonoBehaviour
{
	// Token: 0x06001888 RID: 6280 RVA: 0x000EDB5C File Offset: 0x000EBD5C
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

	// Token: 0x06001889 RID: 6281 RVA: 0x000EDBDC File Offset: 0x000EBDDC
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

	// Token: 0x0600188A RID: 6282 RVA: 0x000EDCF4 File Offset: 0x000EBEF4
	private void PhotographNull()
	{
		this.Highlight.position = new Vector3(this.Highlight.position.x, 100f, this.Highlight.position.z);
		this.Photograph = null;
		this.PhotoGallery.UpdateButtonPrompts();
	}

	// Token: 0x040024B5 RID: 9397
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x040024B6 RID: 9398
	public GameObject Photograph;

	// Token: 0x040024B7 RID: 9399
	public Transform Highlight;

	// Token: 0x040024B8 RID: 9400
	public GameObject Tack;

	// Token: 0x040024B9 RID: 9401
	public Transform CircleHighlight;
}
