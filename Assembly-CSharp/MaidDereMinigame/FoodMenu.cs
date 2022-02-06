using System;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AB RID: 1451
	public class FoodMenu : MonoBehaviour
	{
		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x06002495 RID: 9365 RVA: 0x001FAF5C File Offset: 0x001F915C
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

		// Token: 0x06002496 RID: 9366 RVA: 0x001FAF7C File Offset: 0x001F917C
		private void Awake()
		{
			this.SetMenuIcons();
			this.menuSelectorTarget = this.menuSlots[0].position.x;
			this.startY = this.menuSelector.position.y;
			this.startZ = this.menuSelector.position.z;
		}

		// Token: 0x06002497 RID: 9367 RVA: 0x001FAFD8 File Offset: 0x001F91D8
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

		// Token: 0x06002498 RID: 9368 RVA: 0x001FB04F File Offset: 0x001F924F
		public void SetActive(int index)
		{
			this.menuSelectorTarget = this.menuSlots[index].position.x;
			this.interpolator = 0f;
			this.activeIndex = index;
		}

		// Token: 0x06002499 RID: 9369 RVA: 0x001FB07F File Offset: 0x001F927F
		public Food GetActiveFood()
		{
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[this.activeIndex]);
			food.name = this.foodItems[this.activeIndex].name;
			return food;
		}

		// Token: 0x0600249A RID: 9370 RVA: 0x001FB0B4 File Offset: 0x001F92B4
		public Food GetRandomFood()
		{
			int index = UnityEngine.Random.Range(0, this.foodItems.Count);
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[index]);
			food.name = this.foodItems[index].name;
			return food;
		}

		// Token: 0x0600249B RID: 9371 RVA: 0x001FB0FC File Offset: 0x001F92FC
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

		// Token: 0x0600249C RID: 9372 RVA: 0x001FB1B2 File Offset: 0x001F93B2
		private void IncrementSelection()
		{
			this.SetActive((this.activeIndex + 1) % this.menuSlots.Count);
			SFXController.PlaySound(SFXController.Sounds.MenuSelect);
		}

		// Token: 0x0600249D RID: 9373 RVA: 0x001FB1D5 File Offset: 0x001F93D5
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

		// Token: 0x04004C5E RID: 19550
		private static FoodMenu instance;

		// Token: 0x04004C5F RID: 19551
		[Reorderable]
		public Foods foodItems;

		// Token: 0x04004C60 RID: 19552
		public Transform menuSelector;

		// Token: 0x04004C61 RID: 19553
		public Transform menuSlotParent;

		// Token: 0x04004C62 RID: 19554
		public float selectorMoveSpeed = 3f;

		// Token: 0x04004C63 RID: 19555
		private List<Transform> menuSlots;

		// Token: 0x04004C64 RID: 19556
		private float menuSelectorTarget;

		// Token: 0x04004C65 RID: 19557
		private float startY;

		// Token: 0x04004C66 RID: 19558
		private float startZ;

		// Token: 0x04004C67 RID: 19559
		private float interpolator;

		// Token: 0x04004C68 RID: 19560
		private int activeIndex;
	}
}
