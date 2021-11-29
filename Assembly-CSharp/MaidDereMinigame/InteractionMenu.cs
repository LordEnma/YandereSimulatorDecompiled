using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A7 RID: 1447
	public class InteractionMenu : MonoBehaviour
	{
		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x06002475 RID: 9333 RVA: 0x001F70CC File Offset: 0x001F52CC
		public static InteractionMenu Instance
		{
			get
			{
				if (InteractionMenu.instance == null)
				{
					InteractionMenu.instance = UnityEngine.Object.FindObjectOfType<InteractionMenu>();
				}
				return InteractionMenu.instance;
			}
		}

		// Token: 0x06002476 RID: 9334 RVA: 0x001F70EA File Offset: 0x001F52EA
		private void Awake()
		{
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			InteractionMenu.SetBButton(false);
			InteractionMenu.SetADButton(true);
		}

		// Token: 0x06002477 RID: 9335 RVA: 0x001F7100 File Offset: 0x001F5300
		public static void SetAButton(InteractionMenu.AButtonText text)
		{
			for (int i = 0; i < InteractionMenu.Instance.aButtonSprites.Length; i++)
			{
				if (i == (int)text)
				{
					InteractionMenu.Instance.aButtonSprites[i].gameObject.SetActive(true);
				}
				else
				{
					InteractionMenu.Instance.aButtonSprites[i].gameObject.SetActive(false);
				}
			}
			SpriteRenderer[] array = InteractionMenu.Instance.aButtons;
			for (int j = 0; j < array.Length; j++)
			{
				array[j].gameObject.SetActive(text != InteractionMenu.AButtonText.None);
			}
		}

		// Token: 0x06002478 RID: 9336 RVA: 0x001F7188 File Offset: 0x001F5388
		public static void SetBButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.backButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x06002479 RID: 9337 RVA: 0x001F71BC File Offset: 0x001F53BC
		public static void SetADButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.moveButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x04004BF2 RID: 19442
		private static InteractionMenu instance;

		// Token: 0x04004BF3 RID: 19443
		public GameObject interactObject;

		// Token: 0x04004BF4 RID: 19444
		public GameObject backObject;

		// Token: 0x04004BF5 RID: 19445
		public GameObject moveObject;

		// Token: 0x04004BF6 RID: 19446
		public SpriteRenderer[] aButtons;

		// Token: 0x04004BF7 RID: 19447
		public SpriteRenderer[] aButtonSprites;

		// Token: 0x04004BF8 RID: 19448
		public SpriteRenderer[] backButtons;

		// Token: 0x04004BF9 RID: 19449
		public SpriteRenderer[] moveButtons;

		// Token: 0x020006E0 RID: 1760
		public enum AButtonText
		{
			// Token: 0x0400517A RID: 20858
			ChoosePlate,
			// Token: 0x0400517B RID: 20859
			GrabPlate,
			// Token: 0x0400517C RID: 20860
			KitchenMenu,
			// Token: 0x0400517D RID: 20861
			PlaceOrder,
			// Token: 0x0400517E RID: 20862
			TakeOrder,
			// Token: 0x0400517F RID: 20863
			TossPlate,
			// Token: 0x04005180 RID: 20864
			GiveFood,
			// Token: 0x04005181 RID: 20865
			None
		}
	}
}
