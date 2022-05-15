using System;
using UnityEngine;

// Token: 0x0200031C RID: 796
public class HomeCorkboardScript : MonoBehaviour
{
	// Token: 0x0600188F RID: 6287 RVA: 0x000EE1C8 File Offset: 0x000EC3C8
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

	// Token: 0x040024C3 RID: 9411
	public InputManagerScript InputManager;

	// Token: 0x040024C4 RID: 9412
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x040024C5 RID: 9413
	public HomeYandereScript HomeYandere;

	// Token: 0x040024C6 RID: 9414
	public HomeCameraScript HomeCamera;

	// Token: 0x040024C7 RID: 9415
	public HomeWindowScript HomeWindow;

	// Token: 0x040024C8 RID: 9416
	public bool Loaded;
}
