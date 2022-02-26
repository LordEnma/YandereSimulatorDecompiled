using System;
using UnityEngine;

// Token: 0x0200031A RID: 794
public class HomeCursorScript : MonoBehaviour
{
	// Token: 0x06001873 RID: 6259 RVA: 0x000ECA14 File Offset: 0x000EAC14
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

	// Token: 0x06001874 RID: 6260 RVA: 0x000ECA94 File Offset: 0x000EAC94
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

	// Token: 0x06001875 RID: 6261 RVA: 0x000ECBAC File Offset: 0x000EADAC
	private void PhotographNull()
	{
		this.Highlight.position = new Vector3(this.Highlight.position.x, 100f, this.Highlight.position.z);
		this.Photograph = null;
		this.PhotoGallery.UpdateButtonPrompts();
	}

	// Token: 0x04002472 RID: 9330
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x04002473 RID: 9331
	public GameObject Photograph;

	// Token: 0x04002474 RID: 9332
	public Transform Highlight;

	// Token: 0x04002475 RID: 9333
	public GameObject Tack;

	// Token: 0x04002476 RID: 9334
	public Transform CircleHighlight;
}
