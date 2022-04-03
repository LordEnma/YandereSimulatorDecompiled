using System;
using UnityEngine;

// Token: 0x0200031B RID: 795
public class HomeCursorScript : MonoBehaviour
{
	// Token: 0x0600187E RID: 6270 RVA: 0x000ED7BC File Offset: 0x000EB9BC
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

	// Token: 0x0600187F RID: 6271 RVA: 0x000ED83C File Offset: 0x000EBA3C
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

	// Token: 0x06001880 RID: 6272 RVA: 0x000ED954 File Offset: 0x000EBB54
	private void PhotographNull()
	{
		this.Highlight.position = new Vector3(this.Highlight.position.x, 100f, this.Highlight.position.z);
		this.Photograph = null;
		this.PhotoGallery.UpdateButtonPrompts();
	}

	// Token: 0x040024AA RID: 9386
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x040024AB RID: 9387
	public GameObject Photograph;

	// Token: 0x040024AC RID: 9388
	public Transform Highlight;

	// Token: 0x040024AD RID: 9389
	public GameObject Tack;

	// Token: 0x040024AE RID: 9390
	public Transform CircleHighlight;
}
