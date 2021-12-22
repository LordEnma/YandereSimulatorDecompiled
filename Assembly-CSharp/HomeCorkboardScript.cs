using System;
using UnityEngine;

// Token: 0x02000316 RID: 790
public class HomeCorkboardScript : MonoBehaviour
{
	// Token: 0x06001858 RID: 6232 RVA: 0x000EB198 File Offset: 0x000E9398
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

	// Token: 0x04002443 RID: 9283
	public InputManagerScript InputManager;

	// Token: 0x04002444 RID: 9284
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x04002445 RID: 9285
	public HomeYandereScript HomeYandere;

	// Token: 0x04002446 RID: 9286
	public HomeCameraScript HomeCamera;

	// Token: 0x04002447 RID: 9287
	public HomeWindowScript HomeWindow;

	// Token: 0x04002448 RID: 9288
	public bool Loaded;
}
