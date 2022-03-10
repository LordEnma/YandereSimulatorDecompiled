using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A8 RID: 1448
	[RequireComponent(typeof(SpriteRenderer))]
	public class MenuButton : MonoBehaviour
	{
		// Token: 0x06002496 RID: 9366 RVA: 0x001FC613 File Offset: 0x001FA813
		public void Init()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x06002497 RID: 9367 RVA: 0x001FC621 File Offset: 0x001FA821
		private void OnMouseEnter()
		{
			this.menu.SetActiveMenuButton(this.index);
		}

		// Token: 0x06002498 RID: 9368 RVA: 0x001FC634 File Offset: 0x001FA834
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

		// Token: 0x04004C87 RID: 19591
		public MenuButton.ButtonType buttonType;

		// Token: 0x04004C88 RID: 19592
		public SceneObject targetScene;

		// Token: 0x04004C89 RID: 19593
		[HideInInspector]
		public int index;

		// Token: 0x04004C8A RID: 19594
		[HideInInspector]
		public Menu menu;

		// Token: 0x04004C8B RID: 19595
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x020006E2 RID: 1762
		public enum ButtonType
		{
			// Token: 0x040051FB RID: 20987
			Start,
			// Token: 0x040051FC RID: 20988
			Controls,
			// Token: 0x040051FD RID: 20989
			Credits,
			// Token: 0x040051FE RID: 20990
			Exit,
			// Token: 0x040051FF RID: 20991
			Easy,
			// Token: 0x04005200 RID: 20992
			Medium,
			// Token: 0x04005201 RID: 20993
			Hard
		}
	}
}
