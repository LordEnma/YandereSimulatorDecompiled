using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B4 RID: 1460
	[RequireComponent(typeof(SpriteRenderer))]
	public class MenuButton : MonoBehaviour
	{
		// Token: 0x060024E2 RID: 9442 RVA: 0x00203FCB File Offset: 0x002021CB
		public void Init()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x060024E3 RID: 9443 RVA: 0x00203FD9 File Offset: 0x002021D9
		private void OnMouseEnter()
		{
			this.menu.SetActiveMenuButton(this.index);
		}

		// Token: 0x060024E4 RID: 9444 RVA: 0x00203FEC File Offset: 0x002021EC
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

		// Token: 0x04004D7C RID: 19836
		public MenuButton.ButtonType buttonType;

		// Token: 0x04004D7D RID: 19837
		public SceneObject targetScene;

		// Token: 0x04004D7E RID: 19838
		[HideInInspector]
		public int index;

		// Token: 0x04004D7F RID: 19839
		[HideInInspector]
		public Menu menu;

		// Token: 0x04004D80 RID: 19840
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x020006EE RID: 1774
		public enum ButtonType
		{
			// Token: 0x040052F0 RID: 21232
			Start,
			// Token: 0x040052F1 RID: 21233
			Controls,
			// Token: 0x040052F2 RID: 21234
			Credits,
			// Token: 0x040052F3 RID: 21235
			Exit,
			// Token: 0x040052F4 RID: 21236
			Easy,
			// Token: 0x040052F5 RID: 21237
			Medium,
			// Token: 0x040052F6 RID: 21238
			Hard
		}
	}
}
