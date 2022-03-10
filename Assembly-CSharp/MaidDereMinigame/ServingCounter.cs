using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000595 RID: 1429
	public class ServingCounter : MonoBehaviour
	{
		// Token: 0x06002444 RID: 9284 RVA: 0x001FB1C4 File Offset: 0x001F93C4
		private void Awake()
		{
			this.plates = new List<FoodInstance>();
			this.interactionIndicator.gameObject.SetActive(false);
			this.interactionIndicatorStartingPos = this.interactionIndicator.transform.position;
			this.platePositions = new List<Transform>();
			this.kitchenModeHide.gameObject.SetActive(false);
			FoodMenu.Instance.gameObject.SetActive(false);
			for (int i = 0; i < this.maxPlates; i++)
			{
				Transform transform = new GameObject("Position " + i.ToString()).transform;
				transform.parent = base.transform;
				transform.position = new Vector3(this.xPosStart - this.plateSeparation * (float)i, this.yPos, 0f);
				this.platePositions.Add(transform);
			}
		}

		// Token: 0x06002445 RID: 9285 RVA: 0x001FB29A File Offset: 0x001F949A
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x06002446 RID: 9286 RVA: 0x001FB2BC File Offset: 0x001F94BC
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x06002447 RID: 9287 RVA: 0x001FB2E0 File Offset: 0x001F94E0
		private void Update()
		{
			switch (this.state)
			{
			case ServingCounter.KitchenState.None:
				if (this.isPaused)
				{
					return;
				}
				if (this.interactionRange && Input.GetButtonDown("A"))
				{
					this.state = ServingCounter.KitchenState.SelectingInteraction;
					this.selectedIndex = ((this.plates.Count == 0) ? 2 : 0);
					this.kitchenModeHide.gameObject.SetActive(true);
					this.SetMask(this.selectedIndex);
					SFXController.PlaySound(SFXController.Sounds.MenuOpen);
					if (this.plates.Count == 0 && YandereController.Instance.heldItem == null)
					{
						this.interactionIndicator.transform.position = Chef.Instance.transform.position + Vector3.up * 0.8f;
						InteractionMenu.SetAButton(InteractionMenu.AButtonText.PlaceOrder);
						this.state = ServingCounter.KitchenState.Chef;
						FoodMenu.Instance.gameObject.SetActive(true);
					}
					GameController.SetPause(true);
					InteractionMenu.SetBButton(true);
					return;
				}
				break;
			case ServingCounter.KitchenState.SelectingInteraction:
				switch (this.selectedIndex)
				{
				case 0:
					this.interactionIndicator.transform.position = this.interactionIndicatorStartingPos;
					InteractionMenu.SetAButton(InteractionMenu.AButtonText.ChoosePlate);
					this.SetMask(this.selectedIndex);
					if (Input.GetButtonDown("A"))
					{
						this.state = ServingCounter.KitchenState.Plates;
						this.selectedIndex = 0;
						InteractionMenu.SetAButton(InteractionMenu.AButtonText.GrabPlate);
						SFXController.PlaySound(SFXController.Sounds.MenuOpen);
					}
					break;
				case 1:
					this.interactionIndicator.transform.position = this.trash.transform.position + Vector3.up * 0.5f;
					InteractionMenu.SetAButton(InteractionMenu.AButtonText.TossPlate);
					this.SetMask(this.selectedIndex);
					if (Input.GetButtonDown("A"))
					{
						this.state = ServingCounter.KitchenState.Trash;
						SFXController.PlaySound(SFXController.Sounds.MenuOpen);
					}
					break;
				case 2:
					this.interactionIndicator.transform.position = Chef.Instance.transform.position + Vector3.up * 0.8f;
					InteractionMenu.SetAButton(InteractionMenu.AButtonText.PlaceOrder);
					this.SetMask(this.selectedIndex);
					if (Input.GetButtonDown("A"))
					{
						this.state = ServingCounter.KitchenState.Chef;
						InteractionMenu.SetAButton(InteractionMenu.AButtonText.PlaceOrder);
						FoodMenu.Instance.gameObject.SetActive(true);
						SFXController.PlaySound(SFXController.Sounds.MenuOpen);
					}
					break;
				}
				if (Input.GetButtonDown("B"))
				{
					InteractionMenu.SetBButton(false);
					InteractionMenu.SetAButton(InteractionMenu.AButtonText.KitchenMenu);
					this.state = ServingCounter.KitchenState.None;
					GameController.SetPause(false);
					this.kitchenModeHide.gameObject.SetActive(false);
					this.interactionIndicator.transform.position = this.interactionIndicatorStartingPos;
					SFXController.PlaySound(SFXController.Sounds.MenuBack);
				}
				if (YandereController.rightButton)
				{
					this.selectedIndex = (this.selectedIndex + 1) % 3;
					if (this.selectedIndex == 0 && this.plates.Count == 0)
					{
						this.selectedIndex = (this.selectedIndex + 1) % 3;
					}
					if (this.selectedIndex == 1 && YandereController.Instance.heldItem == null)
					{
						this.selectedIndex = (this.selectedIndex + 1) % 3;
					}
					SFXController.PlaySound(SFXController.Sounds.MenuSelect);
				}
				if (YandereController.leftButton)
				{
					if (this.selectedIndex == 0)
					{
						this.selectedIndex = 2;
					}
					else
					{
						this.selectedIndex--;
					}
					if (this.selectedIndex == 1 && YandereController.Instance.heldItem == null)
					{
						this.selectedIndex--;
					}
					if (this.selectedIndex == 0 && this.plates.Count == 0)
					{
						this.selectedIndex = 2;
					}
					SFXController.PlaySound(SFXController.Sounds.MenuSelect);
					return;
				}
				break;
			case ServingCounter.KitchenState.Plates:
				this.interactionIndicator.gameObject.SetActive(true);
				this.interactionIndicator.transform.position = this.plates[this.selectedIndex].transform.position + Vector3.up * 0.25f;
				this.SetMask(3);
				this.plateMask.transform.position = this.plates[this.selectedIndex].transform.position + Vector3.up * 0.05f;
				if (YandereController.rightButton)
				{
					if (this.selectedIndex == 0)
					{
						this.selectedIndex = this.plates.Count - 1;
					}
					else
					{
						this.selectedIndex--;
					}
					SFXController.PlaySound(SFXController.Sounds.MenuSelect);
				}
				else if (YandereController.leftButton)
				{
					this.selectedIndex = (this.selectedIndex + 1) % this.plates.Count;
					SFXController.PlaySound(SFXController.Sounds.MenuSelect);
				}
				if (Input.GetButtonDown("A") && YandereController.Instance.heldItem == null)
				{
					YandereController.Instance.PickUpTray(this.plates[this.selectedIndex].food);
					this.RemovePlate(this.selectedIndex);
					this.selectedIndex = 2;
					this.state = ServingCounter.KitchenState.SelectingInteraction;
					SFXController.PlaySound(SFXController.Sounds.MenuOpen);
				}
				if (Input.GetButtonDown("B"))
				{
					this.state = ServingCounter.KitchenState.SelectingInteraction;
					SFXController.PlaySound(SFXController.Sounds.MenuBack);
					return;
				}
				break;
			case ServingCounter.KitchenState.Chef:
				if (Input.GetButtonDown("B"))
				{
					this.state = ServingCounter.KitchenState.SelectingInteraction;
					FoodMenu.Instance.gameObject.SetActive(false);
					this.state = ServingCounter.KitchenState.SelectingInteraction;
					SFXController.PlaySound(SFXController.Sounds.MenuBack);
				}
				if (Input.GetButtonDown("A"))
				{
					this.state = ServingCounter.KitchenState.SelectingInteraction;
					Chef.AddToQueue(FoodMenu.Instance.GetActiveFood());
					FoodMenu.Instance.gameObject.SetActive(false);
					SFXController.PlaySound(SFXController.Sounds.MenuOpen);
					return;
				}
				break;
			case ServingCounter.KitchenState.Trash:
				YandereController.Instance.DropTray();
				this.state = ServingCounter.KitchenState.SelectingInteraction;
				this.selectedIndex = 2;
				break;
			default:
				return;
			}
		}

		// Token: 0x06002448 RID: 9288 RVA: 0x001FB86C File Offset: 0x001F9A6C
		public void SetMask(int position)
		{
			this.counterMask.gameObject.SetActive(position == 0);
			this.trashMask.gameObject.SetActive(position == 1);
			this.chefMask.gameObject.SetActive(position == 2);
			this.plateMask.gameObject.SetActive(position == 3);
		}

		// Token: 0x06002449 RID: 9289 RVA: 0x001FB8CC File Offset: 0x001F9ACC
		public void AddPlate(Food food)
		{
			if (this.plates.Count >= this.maxPlates)
			{
				this.RemovePlate(this.maxPlates - 1);
				this.selectedIndex--;
			}
			for (int i = 0; i < this.plates.Count; i++)
			{
				FoodInstance foodInstance = this.plates[i];
				foodInstance.transform.parent = this.platePositions[i + 1];
				foodInstance.transform.localPosition = Vector3.zero;
			}
			SFXController.PlaySound(SFXController.Sounds.Plate);
			FoodInstance foodInstance2 = UnityEngine.Object.Instantiate<FoodInstance>(this.platePrefab);
			foodInstance2.transform.parent = this.platePositions[0];
			foodInstance2.transform.localPosition = Vector3.zero;
			foodInstance2.food = food;
			this.plates.Insert(0, foodInstance2);
		}

		// Token: 0x0600244A RID: 9290 RVA: 0x001FB9A0 File Offset: 0x001F9BA0
		public void RemovePlate(int index)
		{
			Component component = this.plates[index];
			this.plates.RemoveAt(index);
			UnityEngine.Object.Destroy(component.gameObject);
			for (int i = index; i < this.plates.Count; i++)
			{
				FoodInstance foodInstance = this.plates[i];
				foodInstance.transform.parent = this.platePositions[i];
				foodInstance.transform.localPosition = Vector3.zero;
			}
		}

		// Token: 0x0600244B RID: 9291 RVA: 0x001FBA17 File Offset: 0x001F9C17
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x0600244C RID: 9292 RVA: 0x001FBA20 File Offset: 0x001F9C20
		private void OnTriggerEnter2D(Collider2D collision)
		{
			this.interactionIndicator.gameObject.SetActive(true);
			this.interactionIndicator.transform.position = this.interactionIndicatorStartingPos;
			this.interactionRange = true;
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.KitchenMenu);
		}

		// Token: 0x0600244D RID: 9293 RVA: 0x001FBA56 File Offset: 0x001F9C56
		private void OnTriggerExit2D(Collider2D collision)
		{
			this.interactionIndicator.gameObject.SetActive(false);
			this.interactionRange = false;
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
		}

		// Token: 0x04004C30 RID: 19504
		public FoodInstance platePrefab;

		// Token: 0x04004C31 RID: 19505
		public GameObject trash;

		// Token: 0x04004C32 RID: 19506
		public SpriteRenderer interactionIndicator;

		// Token: 0x04004C33 RID: 19507
		public SpriteRenderer kitchenModeHide;

		// Token: 0x04004C34 RID: 19508
		public SpriteMask chefMask;

		// Token: 0x04004C35 RID: 19509
		public SpriteMask trashMask;

		// Token: 0x04004C36 RID: 19510
		public SpriteMask counterMask;

		// Token: 0x04004C37 RID: 19511
		public SpriteMask plateMask;

		// Token: 0x04004C38 RID: 19512
		public int maxPlates = 7;

		// Token: 0x04004C39 RID: 19513
		public float plateSeparation = 0.214f;

		// Token: 0x04004C3A RID: 19514
		public float yPos = -1.328f;

		// Token: 0x04004C3B RID: 19515
		public float xPosStart = 2.812f;

		// Token: 0x04004C3C RID: 19516
		private ServingCounter.KitchenState state;

		// Token: 0x04004C3D RID: 19517
		private List<FoodInstance> plates;

		// Token: 0x04004C3E RID: 19518
		private List<Transform> platePositions;

		// Token: 0x04004C3F RID: 19519
		private Vector3 interactionIndicatorStartingPos;

		// Token: 0x04004C40 RID: 19520
		private int selectedIndex;

		// Token: 0x04004C41 RID: 19521
		private bool interactionRange;

		// Token: 0x04004C42 RID: 19522
		private bool interacting;

		// Token: 0x04004C43 RID: 19523
		private bool isPaused;

		// Token: 0x020006DA RID: 1754
		public enum KitchenState
		{
			// Token: 0x040051CC RID: 20940
			None,
			// Token: 0x040051CD RID: 20941
			SelectingInteraction,
			// Token: 0x040051CE RID: 20942
			Plates,
			// Token: 0x040051CF RID: 20943
			Chef,
			// Token: 0x040051D0 RID: 20944
			Trash
		}
	}
}
