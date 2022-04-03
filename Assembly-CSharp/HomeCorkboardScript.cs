using System;
using UnityEngine;

// Token: 0x0200031A RID: 794
public class HomeCorkboardScript : MonoBehaviour
{
	// Token: 0x0600187C RID: 6268 RVA: 0x000ED660 File Offset: 0x000EB860
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

	// Token: 0x040024A4 RID: 9380
	public InputManagerScript InputManager;

	// Token: 0x040024A5 RID: 9381
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x040024A6 RID: 9382
	public HomeYandereScript HomeYandere;

	// Token: 0x040024A7 RID: 9383
	public HomeCameraScript HomeCamera;

	// Token: 0x040024A8 RID: 9384
	public HomeWindowScript HomeWindow;

	// Token: 0x040024A9 RID: 9385
	public bool Loaded;
}
