using System;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005BA RID: 1466
	public class FoodMenu : MonoBehaviour
	{
		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x060024F7 RID: 9463 RVA: 0x00204380 File Offset: 0x00202580
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

		// Token: 0x060024F8 RID: 9464 RVA: 0x002043A0 File Offset: 0x002025A0
		private void Awake()
		{
			this.SetMenuIcons();
			this.menuSelectorTarget = this.menuSlots[0].position.x;
			this.startY = this.menuSelector.position.y;
			this.startZ = this.menuSelector.position.z;
		}

		// Token: 0x060024F9 RID: 9465 RVA: 0x002043FC File Offset: 0x002025FC
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

		// Token: 0x060024FA RID: 9466 RVA: 0x00204473 File Offset: 0x00202673
		public void SetActive(int index)
		{
			this.menuSelectorTarget = this.menuSlots[index].position.x;
			this.interpolator = 0f;
			this.activeIndex = index;
		}

		// Token: 0x060024FB RID: 9467 RVA: 0x002044A3 File Offset: 0x002026A3
		public Food GetActiveFood()
		{
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[this.activeIndex]);
			food.name = this.foodItems[this.activeIndex].name;
			return food;
		}

		// Token: 0x060024FC RID: 9468 RVA: 0x002044D8 File Offset: 0x002026D8
		public Food GetRandomFood()
		{
			int index = UnityEngine.Random.Range(0, this.foodItems.Count);
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[index]);
			food.name = this.foodItems[index].name;
			return food;
		}

		// Token: 0x060024FD RID: 9469 RVA: 0x00204520 File Offset: 0x00202720
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

		// Token: 0x060024FE RID: 9470 RVA: 0x002045D6 File Offset: 0x002027D6
		private void IncrementSelection()
		{
			this.SetActive((this.activeIndex + 1) % this.menuSlots.Count);
			SFXController.PlaySound(SFXController.Sounds.MenuSelect);
		}

		// Token: 0x060024FF RID: 9471 RVA: 0x002045F9 File Offset: 0x002027F9
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

		// Token: 0x04004D89 RID: 19849
		private static FoodMenu instance;

		// Token: 0x04004D8A RID: 19850
		[Reorderable]
		public Foods foodItems;

		// Token: 0x04004D8B RID: 19851
		public Transform menuSelector;

		// Token: 0x04004D8C RID: 19852
		public Transform menuSlotParent;

		// Token: 0x04004D8D RID: 19853
		public float selectorMoveSpeed = 3f;

		// Token: 0x04004D8E RID: 19854
		private List<Transform> menuSlots;

		// Token: 0x04004D8F RID: 19855
		private float menuSelectorTarget;

		// Token: 0x04004D90 RID: 19856
		private float startY;

		// Token: 0x04004D91 RID: 19857
		private float startZ;

		// Token: 0x04004D92 RID: 19858
		private float interpolator;

		// Token: 0x04004D93 RID: 19859
		private int activeIndex;
	}
}
