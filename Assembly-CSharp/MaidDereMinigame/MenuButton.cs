using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A5 RID: 1445
	[RequireComponent(typeof(SpriteRenderer))]
	public class MenuButton : MonoBehaviour
	{
		// Token: 0x06002477 RID: 9335 RVA: 0x001F9DEB File Offset: 0x001F7FEB
		public void Init()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x06002478 RID: 9336 RVA: 0x001F9DF9 File Offset: 0x001F7FF9
		private void OnMouseEnter()
		{
			this.menu.SetActiveMenuButton(this.index);
		}

		// Token: 0x06002479 RID: 9337 RVA: 0x001F9E0C File Offset: 0x001F800C
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

		// Token: 0x04004C3D RID: 19517
		public MenuButton.ButtonType buttonType;

		// Token: 0x04004C3E RID: 19518
		public SceneObject targetScene;

		// Token: 0x04004C3F RID: 19519
		[HideInInspector]
		public int index;

		// Token: 0x04004C40 RID: 19520
		[HideInInspector]
		public Menu menu;

		// Token: 0x04004C41 RID: 19521
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x020006E3 RID: 1763
		public enum ButtonType
		{
			// Token: 0x040051DA RID: 20954
			Start,
			// Token: 0x040051DB RID: 20955
			Controls,
			// Token: 0x040051DC RID: 20956
			Credits,
			// Token: 0x040051DD RID: 20957
			Exit,
			// Token: 0x040051DE RID: 20958
			Easy,
			// Token: 0x040051DF RID: 20959
			Medium,
			// Token: 0x040051E0 RID: 20960
			Hard
		}
	}
}
