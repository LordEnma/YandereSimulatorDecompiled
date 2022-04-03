using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B1 RID: 1457
	[RequireComponent(typeof(SpriteRenderer))]
	public class MenuButton : MonoBehaviour
	{
		// Token: 0x060024BE RID: 9406 RVA: 0x001FFDEB File Offset: 0x001FDFEB
		public void Init()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x060024BF RID: 9407 RVA: 0x001FFDF9 File Offset: 0x001FDFF9
		private void OnMouseEnter()
		{
			this.menu.SetActiveMenuButton(this.index);
		}

		// Token: 0x060024C0 RID: 9408 RVA: 0x001FFE0C File Offset: 0x001FE00C
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

		// Token: 0x04004D18 RID: 19736
		public MenuButton.ButtonType buttonType;

		// Token: 0x04004D19 RID: 19737
		public SceneObject targetScene;

		// Token: 0x04004D1A RID: 19738
		[HideInInspector]
		public int index;

		// Token: 0x04004D1B RID: 19739
		[HideInInspector]
		public Menu menu;

		// Token: 0x04004D1C RID: 19740
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x020006EB RID: 1771
		public enum ButtonType
		{
			// Token: 0x0400528C RID: 21132
			Start,
			// Token: 0x0400528D RID: 21133
			Controls,
			// Token: 0x0400528E RID: 21134
			Credits,
			// Token: 0x0400528F RID: 21135
			Exit,
			// Token: 0x04005290 RID: 21136
			Easy,
			// Token: 0x04005291 RID: 21137
			Medium,
			// Token: 0x04005292 RID: 21138
			Hard
		}
	}
}
