using System;
using UnityEngine;

// Token: 0x02000316 RID: 790
public class HomeCorkboardScript : MonoBehaviour
{
	// Token: 0x0600185A RID: 6234 RVA: 0x000EB47C File Offset: 0x000E967C
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

	// Token: 0x04002447 RID: 9287
	public InputManagerScript InputManager;

	// Token: 0x04002448 RID: 9288
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x04002449 RID: 9289
	public HomeYandereScript HomeYandere;

	// Token: 0x0400244A RID: 9290
	public HomeCameraScript HomeCamera;

	// Token: 0x0400244B RID: 9291
	public HomeWindowScript HomeWindow;

	// Token: 0x0400244C RID: 9292
	public bool Loaded;
}
