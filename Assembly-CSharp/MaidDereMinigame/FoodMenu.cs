using System;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A8 RID: 1448
	public class FoodMenu : MonoBehaviour
	{
		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x0600247C RID: 9340 RVA: 0x001F8540 File Offset: 0x001F6740
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

		// Token: 0x0600247D RID: 9341 RVA: 0x001F8560 File Offset: 0x001F6760
		private void Awake()
		{
			this.SetMenuIcons();
			this.menuSelectorTarget = this.menuSlots[0].position.x;
			this.startY = this.menuSelector.position.y;
			this.startZ = this.menuSelector.position.z;
		}

		// Token: 0x0600247E RID: 9342 RVA: 0x001F85BC File Offset: 0x001F67BC
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

		// Token: 0x0600247F RID: 9343 RVA: 0x001F8633 File Offset: 0x001F6833
		public void SetActive(int index)
		{
			this.menuSelectorTarget = this.menuSlots[index].position.x;
			this.interpolator = 0f;
			this.activeIndex = index;
		}

		// Token: 0x06002480 RID: 9344 RVA: 0x001F8663 File Offset: 0x001F6863
		public Food GetActiveFood()
		{
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[this.activeIndex]);
			food.name = this.foodItems[this.activeIndex].name;
			return food;
		}

		// Token: 0x06002481 RID: 9345 RVA: 0x001F8698 File Offset: 0x001F6898
		public Food GetRandomFood()
		{
			int index = UnityEngine.Random.Range(0, this.foodItems.Count);
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[index]);
			food.name = this.foodItems[index].name;
			return food;
		}

		// Token: 0x06002482 RID: 9346 RVA: 0x001F86E0 File Offset: 0x001F68E0
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

		// Token: 0x06002483 RID: 9347 RVA: 0x001F8796 File Offset: 0x001F6996
		private void IncrementSelection()
		{
			this.SetActive((this.activeIndex + 1) % this.menuSlots.Count);
			SFXController.PlaySound(SFXController.Sounds.MenuSelect);
		}

		// Token: 0x06002484 RID: 9348 RVA: 0x001F87B9 File Offset: 0x001F69B9
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

		// Token: 0x04004C26 RID: 19494
		private static FoodMenu instance;

		// Token: 0x04004C27 RID: 19495
		[Reorderable]
		public Foods foodItems;

		// Token: 0x04004C28 RID: 19496
		public Transform menuSelector;

		// Token: 0x04004C29 RID: 19497
		public Transform menuSlotParent;

		// Token: 0x04004C2A RID: 19498
		public float selectorMoveSpeed = 3f;

		// Token: 0x04004C2B RID: 19499
		private List<Transform> menuSlots;

		// Token: 0x04004C2C RID: 19500
		private float menuSelectorTarget;

		// Token: 0x04004C2D RID: 19501
		private float startY;

		// Token: 0x04004C2E RID: 19502
		private float startZ;

		// Token: 0x04004C2F RID: 19503
		private float interpolator;

		// Token: 0x04004C30 RID: 19504
		private int activeIndex;
	}
}
