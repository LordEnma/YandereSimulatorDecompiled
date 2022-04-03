using System;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B7 RID: 1463
	public class FoodMenu : MonoBehaviour
	{
		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x060024D3 RID: 9427 RVA: 0x002001A0 File Offset: 0x001FE3A0
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

		// Token: 0x060024D4 RID: 9428 RVA: 0x002001C0 File Offset: 0x001FE3C0
		private void Awake()
		{
			this.SetMenuIcons();
			this.menuSelectorTarget = this.menuSlots[0].position.x;
			this.startY = this.menuSelector.position.y;
			this.startZ = this.menuSelector.position.z;
		}

		// Token: 0x060024D5 RID: 9429 RVA: 0x0020021C File Offset: 0x001FE41C
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

		// Token: 0x060024D6 RID: 9430 RVA: 0x00200293 File Offset: 0x001FE493
		public void SetActive(int index)
		{
			this.menuSelectorTarget = this.menuSlots[index].position.x;
			this.interpolator = 0f;
			this.activeIndex = index;
		}

		// Token: 0x060024D7 RID: 9431 RVA: 0x002002C3 File Offset: 0x001FE4C3
		public Food GetActiveFood()
		{
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[this.activeIndex]);
			food.name = this.foodItems[this.activeIndex].name;
			return food;
		}

		// Token: 0x060024D8 RID: 9432 RVA: 0x002002F8 File Offset: 0x001FE4F8
		public Food GetRandomFood()
		{
			int index = UnityEngine.Random.Range(0, this.foodItems.Count);
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[index]);
			food.name = this.foodItems[index].name;
			return food;
		}

		// Token: 0x060024D9 RID: 9433 RVA: 0x00200340 File Offset: 0x001FE540
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

		// Token: 0x060024DA RID: 9434 RVA: 0x002003F6 File Offset: 0x001FE5F6
		private void IncrementSelection()
		{
			this.SetActive((this.activeIndex + 1) % this.menuSlots.Count);
			SFXController.PlaySound(SFXController.Sounds.MenuSelect);
		}

		// Token: 0x060024DB RID: 9435 RVA: 0x00200419 File Offset: 0x001FE619
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

		// Token: 0x04004D25 RID: 19749
		private static FoodMenu instance;

		// Token: 0x04004D26 RID: 19750
		[Reorderable]
		public Foods foodItems;

		// Token: 0x04004D27 RID: 19751
		public Transform menuSelector;

		// Token: 0x04004D28 RID: 19752
		public Transform menuSlotParent;

		// Token: 0x04004D29 RID: 19753
		public float selectorMoveSpeed = 3f;

		// Token: 0x04004D2A RID: 19754
		private List<Transform> menuSlots;

		// Token: 0x04004D2B RID: 19755
		private float menuSelectorTarget;

		// Token: 0x04004D2C RID: 19756
		private float startY;

		// Token: 0x04004D2D RID: 19757
		private float startZ;

		// Token: 0x04004D2E RID: 19758
		private float interpolator;

		// Token: 0x04004D2F RID: 19759
		private int activeIndex;
	}
}
