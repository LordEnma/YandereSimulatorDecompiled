using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	public class ServingCounter : MonoBehaviour
	{
		public enum KitchenState
		{
			None = 0,
			SelectingInteraction = 1,
			Plates = 2,
			Chef = 3,
			Trash = 4
		}

		public FoodInstance platePrefab;

		public GameObject trash;

		public SpriteRenderer interactionIndicator;

		public SpriteRenderer kitchenModeHide;

		public SpriteMask chefMask;

		public SpriteMask trashMask;

		public SpriteMask counterMask;

		public SpriteMask plateMask;

		public int maxPlates = 7;

		public float plateSeparation = 0.214f;

		public float yPos = -1.328f;

		public float xPosStart = 2.812f;

		private KitchenState state;

		private List<FoodInstance> plates;

		private List<Transform> platePositions;

		private Vector3 interactionIndicatorStartingPos;

		private int selectedIndex;

		private bool interactionRange;

		private bool interacting;

		private bool isPaused;

		private void Awake()
		{
			plates = new List<FoodInstance>();
			interactionIndicator.gameObject.SetActive(false);
			interactionIndicatorStartingPos = interactionIndicator.transform.position;
			platePositions = new List<Transform>();
			kitchenModeHide.gameObject.SetActive(false);
			FoodMenu.Instance.gameObject.SetActive(false);
			for (int i = 0; i < maxPlates; i++)
			{
				Transform transform = new GameObject("Position " + i).transform;
				transform.parent = base.transform;
				transform.position = new Vector3(xPosStart - plateSeparation * (float)i, yPos, 0f);
				platePositions.Add(transform);
			}
		}

		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(SetPause));
		}

		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(SetPause));
		}

		private void Update()
		{
			switch (state)
			{
			case KitchenState.None:
				if (!isPaused && interactionRange && Input.GetButtonDown("A"))
				{
					state = KitchenState.SelectingInteraction;
					selectedIndex = ((plates.Count == 0) ? 2 : 0);
					kitchenModeHide.gameObject.SetActive(true);
					SetMask(selectedIndex);
					SFXController.PlaySound(SFXController.Sounds.MenuOpen);
					if (plates.Count == 0 && YandereController.Instance.heldItem == null)
					{
						interactionIndicator.transform.position = Chef.Instance.transform.position + Vector3.up * 0.8f;
						InteractionMenu.SetAButton(InteractionMenu.AButtonText.PlaceOrder);
						state = KitchenState.Chef;
						FoodMenu.Instance.gameObject.SetActive(true);
					}
					GameController.SetPause(true);
					InteractionMenu.SetBButton(true);
				}
				break;
			case KitchenState.SelectingInteraction:
				switch (selectedIndex)
				{
				case 0:
					interactionIndicator.transform.position = interactionIndicatorStartingPos;
					InteractionMenu.SetAButton(InteractionMenu.AButtonText.ChoosePlate);
					SetMask(selectedIndex);
					if (Input.GetButtonDown("A"))
					{
						state = KitchenState.Plates;
						selectedIndex = 0;
						InteractionMenu.SetAButton(InteractionMenu.AButtonText.GrabPlate);
						SFXController.PlaySound(SFXController.Sounds.MenuOpen);
					}
					break;
				case 1:
					interactionIndicator.transform.position = trash.transform.position + Vector3.up * 0.5f;
					InteractionMenu.SetAButton(InteractionMenu.AButtonText.TossPlate);
					SetMask(selectedIndex);
					if (Input.GetButtonDown("A"))
					{
						state = KitchenState.Trash;
						SFXController.PlaySound(SFXController.Sounds.MenuOpen);
					}
					break;
				case 2:
					interactionIndicator.transform.position = Chef.Instance.transform.position + Vector3.up * 0.8f;
					InteractionMenu.SetAButton(InteractionMenu.AButtonText.PlaceOrder);
					SetMask(selectedIndex);
					if (Input.GetButtonDown("A"))
					{
						state = KitchenState.Chef;
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
					state = KitchenState.None;
					GameController.SetPause(false);
					kitchenModeHide.gameObject.SetActive(false);
					interactionIndicator.transform.position = interactionIndicatorStartingPos;
					SFXController.PlaySound(SFXController.Sounds.MenuBack);
				}
				if (YandereController.rightButton)
				{
					selectedIndex = (selectedIndex + 1) % 3;
					if (selectedIndex == 0 && plates.Count == 0)
					{
						selectedIndex = (selectedIndex + 1) % 3;
					}
					if (selectedIndex == 1 && YandereController.Instance.heldItem == null)
					{
						selectedIndex = (selectedIndex + 1) % 3;
					}
					SFXController.PlaySound(SFXController.Sounds.MenuSelect);
				}
				if (YandereController.leftButton)
				{
					if (selectedIndex == 0)
					{
						selectedIndex = 2;
					}
					else
					{
						selectedIndex--;
					}
					if (selectedIndex == 1 && YandereController.Instance.heldItem == null)
					{
						selectedIndex--;
					}
					if (selectedIndex == 0 && plates.Count == 0)
					{
						selectedIndex = 2;
					}
					SFXController.PlaySound(SFXController.Sounds.MenuSelect);
				}
				break;
			case KitchenState.Plates:
				interactionIndicator.gameObject.SetActive(true);
				interactionIndicator.transform.position = plates[selectedIndex].transform.position + Vector3.up * 0.25f;
				SetMask(3);
				plateMask.transform.position = plates[selectedIndex].transform.position + Vector3.up * 0.05f;
				if (YandereController.rightButton)
				{
					if (selectedIndex == 0)
					{
						selectedIndex = plates.Count - 1;
					}
					else
					{
						selectedIndex--;
					}
					SFXController.PlaySound(SFXController.Sounds.MenuSelect);
				}
				else if (YandereController.leftButton)
				{
					selectedIndex = (selectedIndex + 1) % plates.Count;
					SFXController.PlaySound(SFXController.Sounds.MenuSelect);
				}
				if (Input.GetButtonDown("A") && YandereController.Instance.heldItem == null)
				{
					YandereController.Instance.PickUpTray(plates[selectedIndex].food);
					RemovePlate(selectedIndex);
					selectedIndex = 2;
					state = KitchenState.SelectingInteraction;
					SFXController.PlaySound(SFXController.Sounds.MenuOpen);
				}
				if (Input.GetButtonDown("B"))
				{
					state = KitchenState.SelectingInteraction;
					SFXController.PlaySound(SFXController.Sounds.MenuBack);
				}
				break;
			case KitchenState.Chef:
				if (Input.GetButtonDown("B"))
				{
					state = KitchenState.SelectingInteraction;
					FoodMenu.Instance.gameObject.SetActive(false);
					state = KitchenState.SelectingInteraction;
					SFXController.PlaySound(SFXController.Sounds.MenuBack);
				}
				if (Input.GetButtonDown("A"))
				{
					state = KitchenState.SelectingInteraction;
					Chef.AddToQueue(FoodMenu.Instance.GetActiveFood());
					FoodMenu.Instance.gameObject.SetActive(false);
					SFXController.PlaySound(SFXController.Sounds.MenuOpen);
				}
				break;
			case KitchenState.Trash:
				YandereController.Instance.DropTray();
				state = KitchenState.SelectingInteraction;
				selectedIndex = 2;
				break;
			}
		}

		public void SetMask(int position)
		{
			counterMask.gameObject.SetActive(position == 0);
			trashMask.gameObject.SetActive(position == 1);
			chefMask.gameObject.SetActive(position == 2);
			plateMask.gameObject.SetActive(position == 3);
		}

		public void AddPlate(Food food)
		{
			if (plates.Count >= maxPlates)
			{
				RemovePlate(maxPlates - 1);
				selectedIndex--;
			}
			for (int i = 0; i < plates.Count; i++)
			{
				FoodInstance foodInstance = plates[i];
				foodInstance.transform.parent = platePositions[i + 1];
				foodInstance.transform.localPosition = Vector3.zero;
			}
			SFXController.PlaySound(SFXController.Sounds.Plate);
			FoodInstance foodInstance2 = UnityEngine.Object.Instantiate(platePrefab);
			foodInstance2.transform.parent = platePositions[0];
			foodInstance2.transform.localPosition = Vector3.zero;
			foodInstance2.food = food;
			plates.Insert(0, foodInstance2);
		}

		public void RemovePlate(int index)
		{
			FoodInstance foodInstance = plates[index];
			plates.RemoveAt(index);
			UnityEngine.Object.Destroy(foodInstance.gameObject);
			for (int i = index; i < plates.Count; i++)
			{
				FoodInstance foodInstance2 = plates[i];
				foodInstance2.transform.parent = platePositions[i];
				foodInstance2.transform.localPosition = Vector3.zero;
			}
		}

		public void SetPause(bool toPause)
		{
			isPaused = toPause;
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			interactionIndicator.gameObject.SetActive(true);
			interactionIndicator.transform.position = interactionIndicatorStartingPos;
			interactionRange = true;
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.KitchenMenu);
		}

		private void OnTriggerExit2D(Collider2D collision)
		{
			interactionIndicator.gameObject.SetActive(false);
			interactionRange = false;
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
		}
	}
}
