using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005BB RID: 1467
	public class InteractionMenu : MonoBehaviour
	{
		// Token: 0x17000530 RID: 1328
		// (get) Token: 0x06002500 RID: 9472 RVA: 0x002040D8 File Offset: 0x002022D8
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

		// Token: 0x06002501 RID: 9473 RVA: 0x002040F6 File Offset: 0x002022F6
		private void Awake()
		{
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			InteractionMenu.SetBButton(false);
			InteractionMenu.SetADButton(true);
		}

		// Token: 0x06002502 RID: 9474 RVA: 0x0020410C File Offset: 0x0020230C
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

		// Token: 0x06002503 RID: 9475 RVA: 0x00204194 File Offset: 0x00202394
		public static void SetBButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.backButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x06002504 RID: 9476 RVA: 0x002041C8 File Offset: 0x002023C8
		public static void SetADButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.moveButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x04004D8B RID: 19851
		private static InteractionMenu instance;

		// Token: 0x04004D8C RID: 19852
		public GameObject interactObject;

		// Token: 0x04004D8D RID: 19853
		public GameObject backObject;

		// Token: 0x04004D8E RID: 19854
		public GameObject moveObject;

		// Token: 0x04004D8F RID: 19855
		public SpriteRenderer[] aButtons;

		// Token: 0x04004D90 RID: 19856
		public SpriteRenderer[] aButtonSprites;

		// Token: 0x04004D91 RID: 19857
		public SpriteRenderer[] backButtons;

		// Token: 0x04004D92 RID: 19858
		public SpriteRenderer[] moveButtons;

		// Token: 0x020006F1 RID: 1777
		public enum AButtonText
		{
			// Token: 0x040052F6 RID: 21238
			ChoosePlate,
			// Token: 0x040052F7 RID: 21239
			GrabPlate,
			// Token: 0x040052F8 RID: 21240
			KitchenMenu,
			// Token: 0x040052F9 RID: 21241
			PlaceOrder,
			// Token: 0x040052FA RID: 21242
			TakeOrder,
			// Token: 0x040052FB RID: 21243
			TossPlate,
			// Token: 0x040052FC RID: 21244
			GiveFood,
			// Token: 0x040052FD RID: 21245
			None
		}
	}
}
