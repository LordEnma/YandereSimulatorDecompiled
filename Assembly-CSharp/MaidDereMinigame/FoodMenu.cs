using System;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B9 RID: 1465
	public class FoodMenu : MonoBehaviour
	{
		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x060024EC RID: 9452 RVA: 0x002027C8 File Offset: 0x002009C8
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

		// Token: 0x060024ED RID: 9453 RVA: 0x002027E8 File Offset: 0x002009E8
		private void Awake()
		{
			this.SetMenuIcons();
			this.menuSelectorTarget = this.menuSlots[0].position.x;
			this.startY = this.menuSelector.position.y;
			this.startZ = this.menuSelector.position.z;
		}

		// Token: 0x060024EE RID: 9454 RVA: 0x00202844 File Offset: 0x00200A44
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

		// Token: 0x060024EF RID: 9455 RVA: 0x002028BB File Offset: 0x00200ABB
		public void SetActive(int index)
		{
			this.menuSelectorTarget = this.menuSlots[index].position.x;
			this.interpolator = 0f;
			this.activeIndex = index;
		}

		// Token: 0x060024F0 RID: 9456 RVA: 0x002028EB File Offset: 0x00200AEB
		public Food GetActiveFood()
		{
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[this.activeIndex]);
			food.name = this.foodItems[this.activeIndex].name;
			return food;
		}

		// Token: 0x060024F1 RID: 9457 RVA: 0x00202920 File Offset: 0x00200B20
		public Food GetRandomFood()
		{
			int index = UnityEngine.Random.Range(0, this.foodItems.Count);
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[index]);
			food.name = this.foodItems[index].name;
			return food;
		}

		// Token: 0x060024F2 RID: 9458 RVA: 0x00202968 File Offset: 0x00200B68
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

		// Token: 0x060024F3 RID: 9459 RVA: 0x00202A1E File Offset: 0x00200C1E
		private void IncrementSelection()
		{
			this.SetActive((this.activeIndex + 1) % this.menuSlots.Count);
			SFXController.PlaySound(SFXController.Sounds.MenuSelect);
		}

		// Token: 0x060024F4 RID: 9460 RVA: 0x00202A41 File Offset: 0x00200C41
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

		// Token: 0x04004D59 RID: 19801
		private static FoodMenu instance;

		// Token: 0x04004D5A RID: 19802
		[Reorderable]
		public Foods foodItems;

		// Token: 0x04004D5B RID: 19803
		public Transform menuSelector;

		// Token: 0x04004D5C RID: 19804
		public Transform menuSlotParent;

		// Token: 0x04004D5D RID: 19805
		public float selectorMoveSpeed = 3f;

		// Token: 0x04004D5E RID: 19806
		private List<Transform> menuSlots;

		// Token: 0x04004D5F RID: 19807
		private float menuSelectorTarget;

		// Token: 0x04004D60 RID: 19808
		private float startY;

		// Token: 0x04004D61 RID: 19809
		private float startZ;

		// Token: 0x04004D62 RID: 19810
		private float interpolator;

		// Token: 0x04004D63 RID: 19811
		private int activeIndex;
	}
}
