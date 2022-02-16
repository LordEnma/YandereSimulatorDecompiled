using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A6 RID: 1446
	[RequireComponent(typeof(SpriteRenderer))]
	public class MenuButton : MonoBehaviour
	{
		// Token: 0x06002487 RID: 9351 RVA: 0x001FB05B File Offset: 0x001F925B
		public void Init()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x06002488 RID: 9352 RVA: 0x001FB069 File Offset: 0x001F9269
		private void OnMouseEnter()
		{
			this.menu.SetActiveMenuButton(this.index);
		}

		// Token: 0x06002489 RID: 9353 RVA: 0x001FB07C File Offset: 0x001F927C
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

		// Token: 0x04004C5A RID: 19546
		public MenuButton.ButtonType buttonType;

		// Token: 0x04004C5B RID: 19547
		public SceneObject targetScene;

		// Token: 0x04004C5C RID: 19548
		[HideInInspector]
		public int index;

		// Token: 0x04004C5D RID: 19549
		[HideInInspector]
		public Menu menu;

		// Token: 0x04004C5E RID: 19550
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x020006DE RID: 1758
		public enum ButtonType
		{
			// Token: 0x040051C9 RID: 20937
			Start,
			// Token: 0x040051CA RID: 20938
			Controls,
			// Token: 0x040051CB RID: 20939
			Credits,
			// Token: 0x040051CC RID: 20940
			Exit,
			// Token: 0x040051CD RID: 20941
			Easy,
			// Token: 0x040051CE RID: 20942
			Medium,
			// Token: 0x040051CF RID: 20943
			Hard
		}
	}
}
