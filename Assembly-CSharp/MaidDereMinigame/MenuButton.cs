using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A5 RID: 1445
	[RequireComponent(typeof(SpriteRenderer))]
	public class MenuButton : MonoBehaviour
	{
		// Token: 0x0600247B RID: 9339 RVA: 0x001FA68B File Offset: 0x001F888B
		public void Init()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x0600247C RID: 9340 RVA: 0x001FA699 File Offset: 0x001F8899
		private void OnMouseEnter()
		{
			this.menu.SetActiveMenuButton(this.index);
		}

		// Token: 0x0600247D RID: 9341 RVA: 0x001FA6AC File Offset: 0x001F88AC
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

		// Token: 0x04004C48 RID: 19528
		public MenuButton.ButtonType buttonType;

		// Token: 0x04004C49 RID: 19529
		public SceneObject targetScene;

		// Token: 0x04004C4A RID: 19530
		[HideInInspector]
		public int index;

		// Token: 0x04004C4B RID: 19531
		[HideInInspector]
		public Menu menu;

		// Token: 0x04004C4C RID: 19532
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x020006DD RID: 1757
		public enum ButtonType
		{
			// Token: 0x040051B7 RID: 20919
			Start,
			// Token: 0x040051B8 RID: 20920
			Controls,
			// Token: 0x040051B9 RID: 20921
			Credits,
			// Token: 0x040051BA RID: 20922
			Exit,
			// Token: 0x040051BB RID: 20923
			Easy,
			// Token: 0x040051BC RID: 20924
			Medium,
			// Token: 0x040051BD RID: 20925
			Hard
		}
	}
}
