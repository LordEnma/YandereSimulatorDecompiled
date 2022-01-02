using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A2 RID: 1442
	[RequireComponent(typeof(SpriteRenderer))]
	public class MenuButton : MonoBehaviour
	{
		// Token: 0x0600246A RID: 9322 RVA: 0x001F877B File Offset: 0x001F697B
		public void Init()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x0600246B RID: 9323 RVA: 0x001F8789 File Offset: 0x001F6989
		private void OnMouseEnter()
		{
			this.menu.SetActiveMenuButton(this.index);
		}

		// Token: 0x0600246C RID: 9324 RVA: 0x001F879C File Offset: 0x001F699C
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

		// Token: 0x04004C22 RID: 19490
		public MenuButton.ButtonType buttonType;

		// Token: 0x04004C23 RID: 19491
		public SceneObject targetScene;

		// Token: 0x04004C24 RID: 19492
		[HideInInspector]
		public int index;

		// Token: 0x04004C25 RID: 19493
		[HideInInspector]
		public Menu menu;

		// Token: 0x04004C26 RID: 19494
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x020006E0 RID: 1760
		public enum ButtonType
		{
			// Token: 0x040051BF RID: 20927
			Start,
			// Token: 0x040051C0 RID: 20928
			Controls,
			// Token: 0x040051C1 RID: 20929
			Credits,
			// Token: 0x040051C2 RID: 20930
			Exit,
			// Token: 0x040051C3 RID: 20931
			Easy,
			// Token: 0x040051C4 RID: 20932
			Medium,
			// Token: 0x040051C5 RID: 20933
			Hard
		}
	}
}
