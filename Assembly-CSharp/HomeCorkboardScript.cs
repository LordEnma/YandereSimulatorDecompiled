using System;
using UnityEngine;

// Token: 0x02000318 RID: 792
public class HomeCorkboardScript : MonoBehaviour
{
	// Token: 0x06001868 RID: 6248 RVA: 0x000EBFD4 File Offset: 0x000EA1D4
	private void Update()
	{
		if (!this.HomeYandere.CanMove)
		{
			if (!this.Loaded)
			{
				this.PhotoGallery.LoadingScreen.SetActive(false);
				this.PhotoGallery.UpdateButtonPrompts();
				this.PhotoGallery.enabled = true;
				this.PhotoGallery.gameObject.SetActive(true);
				this.Loaded = true;
			}
			if (!this.PhotoGallery.Adjusting && !this.PhotoGallery.Viewing && !this.PhotoGallery.LoadingScreen.activeInHierarchy && Input.GetButtonDown("B"))
			{
				this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
				this.HomeCamera.Target = this.HomeCamera.Targets[0];
				this.HomeCamera.CorkboardLabel.SetActive(true);
				this.PhotoGallery.PromptBar.Show = false;
				this.PhotoGallery.enabled = false;
				this.HomeYandere.CanMove = true;
				this.HomeYandere.gameObject.SetActive(true);
				this.HomeWindow.Show = false;
				base.enabled = false;
				this.Loaded = false;
				this.PhotoGallery.SaveAllPhotographs();
				this.PhotoGallery.SaveAllStrings();
			}
		}
	}

	// Token: 0x0400245D RID: 9309
	public InputManagerScript InputManager;

	// Token: 0x0400245E RID: 9310
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x0400245F RID: 9311
	public HomeYandereScript HomeYandere;

	// Token: 0x04002460 RID: 9312
	public HomeCameraScript HomeCamera;

	// Token: 0x04002461 RID: 9313
	public HomeWindowScript HomeWindow;

	// Token: 0x04002462 RID: 9314
	public bool Loaded;
}
