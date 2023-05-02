using UnityEngine;

public class VentilationSystemScript : MonoBehaviour
{
	public GameObject FirstFloorShadow;

	public GameObject ThirdFloorShadow;

	public GameObject StinkBombCloud;

	public GameObject Window;

	public PromptBarScript PromptBar;

	public UILabel ExplanationLabel;

	public string[] Floor1RoomNames;

	public string[] Floor2RoomNames;

	public string[] Floor3RoomNames;

	public string[] FloorNames;

	public UILabel[] RoomLabels;

	public PromptScript Prompt;

	public Transform Highlight;

	public UILabel FloorLabel;

	public Transform[] Rooms;

	public bool CanStink;

	public bool Eighties;

	public bool Show;

	public int RoomID;

	public int Floor = 1;

	public int Column = 3;

	public int Row = 1;

	private void Start()
	{
		Window.SetActive(value: false);
		UpdateHighlight();
		UpdateRoomNameLabels();
		if (GameGlobals.Eighties)
		{
			Floor3RoomNames[3] = "Newspaper Club";
			Eighties = true;
		}
	}

	private void Update()
	{
		if (Prompt.Circle[1].fillAmount == 0f)
		{
			Time.timeScale = 0.0001f;
			PromptBar.ClearButtons();
			PromptBar.Label[1].text = "Exit";
			PromptBar.Label[2].text = "Change Floor";
			PromptBar.Label[4].text = "Choose";
			PromptBar.Label[5].text = "Choose";
			PromptBar.UpdateButtons();
			PromptBar.Show = true;
			Prompt.Hide();
			Prompt.enabled = false;
			Prompt.Yandere.RPGCamera.enabled = false;
			Prompt.Yandere.CanMove = false;
			Window.SetActive(value: true);
			Show = true;
			CheckForStinkBombs();
		}
		if (!Show)
		{
			return;
		}
		if (CanStink && Input.GetButtonDown(InputNames.Xbox_A))
		{
			GameObject gameObject = Object.Instantiate(StinkBombCloud, Rooms[RoomID].position + Vector3.up * (Floor - 1) * 4f, Quaternion.identity);
			if (Column > 1 && Column < 5)
			{
				gameObject.transform.eulerAngles = new Vector3(0f, 90f, 0f);
			}
			PickUpScript pickUp = Prompt.Yandere.PickUp;
			Prompt.Yandere.PickUp.Drop();
			Object.Destroy(pickUp.gameObject);
			if (Floor == 3 && RoomID == 23)
			{
				Prompt.Yandere.StudentManager.Portal.GetComponent<PortalScript>().Headmaster.SetActive(value: false);
			}
			Exit();
		}
		if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			Exit();
		}
		if (Input.GetButtonDown(InputNames.Xbox_X))
		{
			Floor++;
			if (Floor > 3)
			{
				Floor = 1;
			}
			UpdateRoomNameLabels();
		}
		if (Prompt.Yandere.PauseScreen.InputManager.TappedRight)
		{
			if (Row == 1 || Row == 5)
			{
				Column++;
				if (Column > 4)
				{
					Column = 2;
				}
			}
			else if (Column == 1)
			{
				Column = 5;
			}
			else
			{
				Column = 1;
			}
			UpdateHighlight();
		}
		if (Prompt.Yandere.PauseScreen.InputManager.TappedLeft)
		{
			if (Row == 1 || Row == 5)
			{
				Column--;
				if (Column < 2)
				{
					Column = 4;
				}
			}
			else if (Column == 1)
			{
				Column = 5;
			}
			else
			{
				Column = 1;
			}
			UpdateHighlight();
		}
		if (Prompt.Yandere.PauseScreen.InputManager.TappedDown)
		{
			if (Row == 1)
			{
				if (Column == 2)
				{
					Column = 1;
				}
				else
				{
					Column = 5;
				}
			}
			else if (Row == 4)
			{
				if (Column == 1)
				{
					Column = 2;
				}
				else
				{
					Column = 4;
				}
			}
			Row++;
			if (Row > 5)
			{
				Row = 1;
			}
			UpdateHighlight();
		}
		if (!Prompt.Yandere.PauseScreen.InputManager.TappedUp)
		{
			return;
		}
		if (Row == 5)
		{
			if (Column == 2)
			{
				Column = 1;
			}
			else
			{
				Column = 5;
			}
		}
		else if (Row == 2)
		{
			if (Column == 1)
			{
				Column = 2;
			}
			else
			{
				Column = 4;
			}
		}
		Row--;
		if (Row < 1)
		{
			Row = 5;
		}
		UpdateHighlight();
	}

	private void CheckForStinkBombs()
	{
		CanStink = false;
		PromptBar.Label[0].text = "";
		if (Floor == 1 && RoomID == 6)
		{
			ExplanationLabel.text = "The guidance counselor is too professional to abandon her duties because of a bad smell.";
		}
		else if (Floor == 3 && RoomID == 3 && !Eighties)
		{
			ExplanationLabel.text = "It looks like Info-chan has hacked the ventilation system and made it impossible to send any gases into her room...";
		}
		else if (Prompt.Yandere.PickUp != null && Prompt.Yandere.PickUp.StinkBombs)
		{
			ExplanationLabel.text = "You have a box of stink bombs! Choose a room and press the 'accept' button to fill that room with a horrible stench, causing its inhabitants to evacuate it for a few minutes.";
			PromptBar.Label[0].text = "Accept";
			CanStink = true;
		}
		else
		{
			ExplanationLabel.text = "If you come here with a box of stink bombs, you can fill one room with a horrible stench, causing its inhabitants to evacuate it for a few minutes.";
		}
		PromptBar.UpdateButtons();
	}

	private void Exit()
	{
		Prompt.Yandere.RPGCamera.enabled = true;
		Prompt.Yandere.CanMove = true;
		PromptBar.ClearButtons();
		PromptBar.Show = false;
		Window.SetActive(value: false);
		Prompt.enabled = true;
		Time.timeScale = 1f;
		Show = false;
	}

	public void UpdateHighlight()
	{
		Highlight.localPosition = new Vector3(-540 + 180 * Column, 540 - 180 * Row, 0f);
		RoomID = Column + (Row - 1) * 5;
		CheckForStinkBombs();
	}

	public void UpdateRoomNameLabels()
	{
		FloorLabel.text = FloorNames[Floor];
		for (int i = 1; i < RoomLabels.Length; i++)
		{
			if (RoomLabels[i] != null)
			{
				if (Floor == 1)
				{
					RoomLabels[i].text = Floor1RoomNames[i];
				}
				else if (Floor == 2)
				{
					RoomLabels[i].text = Floor2RoomNames[i];
				}
				else if (Floor == 3)
				{
					RoomLabels[i].text = Floor3RoomNames[i];
				}
			}
		}
		if (Floor == 1)
		{
			FirstFloorShadow.SetActive(value: true);
			ThirdFloorShadow.SetActive(value: false);
		}
		else if (Floor == 3)
		{
			FirstFloorShadow.SetActive(value: false);
			if (!Eighties)
			{
				ThirdFloorShadow.SetActive(value: true);
			}
		}
		else
		{
			FirstFloorShadow.SetActive(value: false);
			ThirdFloorShadow.SetActive(value: false);
		}
		CheckForStinkBombs();
	}
}
