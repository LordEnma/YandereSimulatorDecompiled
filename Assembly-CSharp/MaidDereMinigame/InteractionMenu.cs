using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005BB RID: 1467
	public class InteractionMenu : MonoBehaviour
	{
		// Token: 0x17000530 RID: 1328
		// (get) Token: 0x06002501 RID: 9473 RVA: 0x00204640 File Offset: 0x00202840
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

		// Token: 0x06002502 RID: 9474 RVA: 0x0020465E File Offset: 0x0020285E
		private void Awake()
		{
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			InteractionMenu.SetBButton(false);
			InteractionMenu.SetADButton(true);
		}

		// Token: 0x06002503 RID: 9475 RVA: 0x00204674 File Offset: 0x00202874
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

		// Token: 0x06002504 RID: 9476 RVA: 0x002046FC File Offset: 0x002028FC
		public static void SetBButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.backButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x06002505 RID: 9477 RVA: 0x00204730 File Offset: 0x00202930
		public static void SetADButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.moveButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x04004D94 RID: 19860
		private static InteractionMenu instance;

		// Token: 0x04004D95 RID: 19861
		public GameObject interactObject;

		// Token: 0x04004D96 RID: 19862
		public GameObject backObject;

		// Token: 0x04004D97 RID: 19863
		public GameObject moveObject;

		// Token: 0x04004D98 RID: 19864
		public SpriteRenderer[] aButtons;

		// Token: 0x04004D99 RID: 19865
		public SpriteRenderer[] aButtonSprites;

		// Token: 0x04004D9A RID: 19866
		public SpriteRenderer[] backButtons;

		// Token: 0x04004D9B RID: 19867
		public SpriteRenderer[] moveButtons;

		// Token: 0x020006F1 RID: 1777
		public enum AButtonText
		{
			// Token: 0x040052FF RID: 21247
			ChoosePlate,
			// Token: 0x04005300 RID: 21248
			GrabPlate,
			// Token: 0x04005301 RID: 21249
			KitchenMenu,
			// Token: 0x04005302 RID: 21250
			PlaceOrder,
			// Token: 0x04005303 RID: 21251
			TakeOrder,
			// Token: 0x04005304 RID: 21252
			TossPlate,
			// Token: 0x04005305 RID: 21253
			GiveFood,
			// Token: 0x04005306 RID: 21254
			None
		}
	}
}
