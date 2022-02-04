using System;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AB RID: 1451
	public class FoodMenu : MonoBehaviour
	{
		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x06002492 RID: 9362 RVA: 0x001FAD58 File Offset: 0x001F8F58
		public static FoodMenu Instance
		{
			get
			{
				if (FoodMenu.instance == null)
				{
					FoodMenu.instance = UnityEngine.Object.FindObjectOfType<FoodMenu>();
				}
				return FoodMenu.instance;
			}
		}

		// Token: 0x06002493 RID: 9363 RVA: 0x001FAD78 File Offset: 0x001F8F78
		private void Awake()
		{
			this.SetMenuIcons();
			this.menuSelectorTarget = this.menuSlots[0].position.x;
			this.startY = this.menuSelector.position.y;
			this.startZ = this.menuSelector.position.z;
		}

		// Token: 0x06002494 RID: 9364 RVA: 0x001FADD4 File Offset: 0x001F8FD4
		public void SetMenuIcons()
		{
			this.menuSlots = new List<Transform>();
			for (int i = 0; i < this.menuSlotParent.childCount; i++)
			{
				Transform child = this.menuSlotParent.GetChild(i);
				this.menuSlots.Add(child);
				if (this.foodItems.Count >= i)
				{
					child.GetChild(0).GetComponent<SpriteRenderer>().sprite = this.foodItems[i].largeSprite;
				}
			}
		}

		// Token: 0x06002495 RID: 9365 RVA: 0x001FAE4B File Offset: 0x001F904B
		public void SetActive(int index)
		{
			this.menuSelectorTarget = this.menuSlots[index].position.x;
			this.interpolator = 0f;
			this.activeIndex = index;
		}

		// Token: 0x06002496 RID: 9366 RVA: 0x001FAE7B File Offset: 0x001F907B
		public Food GetActiveFood()
		{
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[this.activeIndex]);
			food.name = this.foodItems[this.activeIndex].name;
			return food;
		}

		// Token: 0x06002497 RID: 9367 RVA: 0x001FAEB0 File Offset: 0x001F90B0
		public Food GetRandomFood()
		{
			int index = UnityEngine.Random.Range(0, this.foodItems.Count);
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[index]);
			food.name = this.foodItems[index].name;
			return food;
		}

		// Token: 0x06002498 RID: 9368 RVA: 0x001FAEF8 File Offset: 0x001F90F8
		private void Update()
		{
			if (this.interpolator < 1f)
			{
				float x = Mathf.Lerp(this.menuSelector.position.x, this.menuSelectorTarget, this.interpolator);
				this.menuSelector.position = new Vector3(x, this.startY, this.startZ);
				this.interpolator += Time.deltaTime * this.selectorMoveSpeed;
			}
			else
			{
				this.menuSelector.transform.position = new Vector3(this.menuSelectorTarget, this.startY, this.startZ);
			}
			if (YandereController.rightButton)
			{
				this.IncrementSelection();
				return;
			}
			if (YandereController.leftButton)
			{
				this.DecrementSelection();
			}
		}

		// Token: 0x06002499 RID: 9369 RVA: 0x001FAFAE File Offset: 0x001F91AE
		private void IncrementSelection()
		{
			this.SetActive((this.activeIndex + 1) % this.menuSlots.Count);
			SFXController.PlaySound(SFXController.Sounds.MenuSelect);
		}

		// Token: 0x0600249A RID: 9370 RVA: 0x001FAFD1 File Offset: 0x001F91D1
		private void DecrementSelection()
		{
			if (this.activeIndex == 0)
			{
				this.SetActive(this.menuSlots.Count - 1);
			}
			else
			{
				this.SetActive(this.activeIndex - 1);
			}
			SFXController.PlaySound(SFXController.Sounds.MenuSelect);
		}

		// Token: 0x04004C5B RID: 19547
		private static FoodMenu instance;

		// Token: 0x04004C5C RID: 19548
		[Reorderable]
		public Foods foodItems;

		// Token: 0x04004C5D RID: 19549
		public Transform menuSelector;

		// Token: 0x04004C5E RID: 19550
		public Transform menuSlotParent;

		// Token: 0x04004C5F RID: 19551
		public float selectorMoveSpeed = 3f;

		// Token: 0x04004C60 RID: 19552
		private List<Transform> menuSlots;

		// Token: 0x04004C61 RID: 19553
		private float menuSelectorTarget;

		// Token: 0x04004C62 RID: 19554
		private float startY;

		// Token: 0x04004C63 RID: 19555
		private float startZ;

		// Token: 0x04004C64 RID: 19556
		private float interpolator;

		// Token: 0x04004C65 RID: 19557
		private int activeIndex;
	}
}
