using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A2 RID: 1442
	[RequireComponent(typeof(SpriteRenderer))]
	public class MenuButton : MonoBehaviour
	{
		// Token: 0x06002467 RID: 9319 RVA: 0x001F818B File Offset: 0x001F638B
		public void Init()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x06002468 RID: 9320 RVA: 0x001F8199 File Offset: 0x001F6399
		private void OnMouseEnter()
		{
			this.menu.SetActiveMenuButton(this.index);
		}

		// Token: 0x06002469 RID: 9321 RVA: 0x001F81AC File Offset: 0x001F63AC
		public void DoClick()
		{
			switch (this.buttonType)
			{
			case MenuButton.ButtonType.Start:
				this.menu.flipBook.FlipToPage(2);
				return;
			case MenuButton.ButtonType.Controls:
				this.menu.flipBook.FlipToPage(3);
				return;
			case MenuButton.ButtonType.Credits:
				this.menu.flipBook.FlipToPage(4);
				return;
			case MenuButton.ButtonType.Exit:
				this.menu.StopInputs();
				GameController.GoToExitScene(true);
				return;
			case MenuButton.ButtonType.Easy:
				this.menu.StopInputs();
				GameController.Instance.activeDifficultyVariables = GameController.Instance.easyVariables;
				GameController.Instance.LoadScene(this.targetScene);
				SFXController.PlaySound(SFXController.Sounds.MenuConfirm);
				return;
			case MenuButton.ButtonType.Medium:
				this.menu.StopInputs();
				GameController.Instance.activeDifficultyVariables = GameController.Instance.mediumVariables;
				GameController.Instance.LoadScene(this.targetScene);
				SFXController.PlaySound(SFXController.Sounds.MenuConfirm);
				return;
			case MenuButton.ButtonType.Hard:
				this.menu.StopInputs();
				GameController.Instance.activeDifficultyVariables = GameController.Instance.hardVariables;
				GameController.Instance.LoadScene(this.targetScene);
				SFXController.PlaySound(SFXController.Sounds.MenuConfirm);
				return;
			default:
				return;
			}
		}

		// Token: 0x04004C19 RID: 19481
		public MenuButton.ButtonType buttonType;

		// Token: 0x04004C1A RID: 19482
		public SceneObject targetScene;

		// Token: 0x04004C1B RID: 19483
		[HideInInspector]
		public int index;

		// Token: 0x04004C1C RID: 19484
		[HideInInspector]
		public Menu menu;

		// Token: 0x04004C1D RID: 19485
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x020006E0 RID: 1760
		public enum ButtonType
		{
			// Token: 0x040051B6 RID: 20918
			Start,
			// Token: 0x040051B7 RID: 20919
			Controls,
			// Token: 0x040051B8 RID: 20920
			Credits,
			// Token: 0x040051B9 RID: 20921
			Exit,
			// Token: 0x040051BA RID: 20922
			Easy,
			// Token: 0x040051BB RID: 20923
			Medium,
			// Token: 0x040051BC RID: 20924
			Hard
		}
	}
}
