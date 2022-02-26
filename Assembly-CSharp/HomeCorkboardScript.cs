using System;
using UnityEngine;

// Token: 0x02000319 RID: 793
public class HomeCorkboardScript : MonoBehaviour
{
	// Token: 0x06001871 RID: 6257 RVA: 0x000EC8B8 File Offset: 0x000EAAB8
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

	// Token: 0x0400246C RID: 9324
	public InputManagerScript InputManager;

	// Token: 0x0400246D RID: 9325
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x0400246E RID: 9326
	public HomeYandereScript HomeYandere;

	// Token: 0x0400246F RID: 9327
	public HomeCameraScript HomeCamera;

	// Token: 0x04002470 RID: 9328
	public HomeWindowScript HomeWindow;

	// Token: 0x04002471 RID: 9329
	public bool Loaded;
}
