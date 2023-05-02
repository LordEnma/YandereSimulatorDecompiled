using UnityEngine;

public class YouTubeChatMenuScript : MonoBehaviour
{
	public YouTubeCommandTestScript CommandChecker;

	public PauseScreenScript PauseScreen;

	public UILabel InitializationLabel;

	public UILabel ValidURL;

	public UILabel URL;

	public GameObject InitializeWindow;

	public GameObject CommandWindow;

	public GameObject Button;

	public UISprite AutomaticSprite;

	public UISprite ManualSprite;

	public BoxCollider ClickHitbox;

	public UISprite[] Checkmarks;

	public string[] Descriptions;

	public Transform Highlight;

	public UILabel DescLabel;

	public YouTubeChat Chat;

	public bool[] Commands;

	public bool Automatic;

	public int Column;

	public int Row;

	public int Pushes;

	public int Frame;

	public int ID;

	public void Start()
	{
		UpdateHighlight();
		for (int i = 1; i < 26; i++)
		{
			if (Commands[i])
			{
				Checkmarks[i].spriteName = "Yes";
			}
			else
			{
				Checkmarks[i].spriteName = "No";
			}
		}
	}

	private void Update()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		if (Frame == 1)
		{
			InitializeWindow.SetActive(value: false);
			CommandWindow.SetActive(value: true);
			Chat.gameObject.SetActive(value: true);
			PauseScreen.PromptBar.Label[0].text = "Toggle";
			PauseScreen.PromptBar.Label[1].text = "Back";
			PauseScreen.PromptBar.Label[4].text = "Scroll";
			PauseScreen.PromptBar.UpdateButtons();
			Frame++;
		}
		else if (Frame == 3)
		{
			Chat.youtubeChatPopoutUrl = "";
			Chat.youtubeChatPopoutUrl = URL.text;
			Frame++;
		}
		else if (Frame == 4)
		{
			Chat.AssureDriverActivated();
			Frame++;
		}
		else if (Frame == 5)
		{
			if (Chat.isValidURL)
			{
				Chat.UpdateMessagesList(initialRun: false);
			}
			Frame++;
		}
		if (InitializeWindow.activeInHierarchy)
		{
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				if (PauseScreen.transform.localEulerAngles.z > 89f)
				{
					InitializationLabel.text = "Now initializing the chat-checking system! Please wait...";
					InitializationLabel.transform.localPosition = new Vector3(0f, 0f, 0f);
					PauseScreen.PromptBar.ClearButtons();
					Button.SetActive(value: false);
					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = true;
					Frame++;
				}
			}
			else if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				Exit();
			}
			return;
		}
		if (Frame == 6)
		{
			if (Chat.isValidURL)
			{
				ValidURL.text = "Connected to chat! Have fun!";
				ValidURL.color = new Color(0f, 1f, 0f, 1f);
			}
			else
			{
				ValidURL.text = "Check URL and try again.";
				ValidURL.color = new Color(1f, 0f, 0f, 1f);
			}
		}
		if (Input.GetButtonDown(InputNames.Xbox_A))
		{
			Debug.Log("Updating sprites...or trying to.");
			Commands[ID] = !Commands[ID];
			CommandChecker.Check[ID] = Commands[ID];
			if (Commands[ID])
			{
				Checkmarks[ID].spriteName = "Yes";
			}
			else
			{
				Checkmarks[ID].spriteName = "No";
			}
		}
		else if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			Exit();
		}
		else if (Input.GetButtonDown(InputNames.Xbox_X))
		{
			ValidURL.text = "Checking URL, please wait...";
			ValidURL.color = new Color(1f, 1f, 1f, 1f);
			Frame = 3;
		}
		else if (PauseScreen.InputManager.TappedLeft)
		{
			Column--;
			if (Column < 1)
			{
				Column = 3;
			}
			UpdateHighlight();
		}
		else if (PauseScreen.InputManager.TappedRight)
		{
			Column++;
			if (Column > 3)
			{
				Column = 1;
			}
			UpdateHighlight();
		}
		else if (PauseScreen.InputManager.TappedDown)
		{
			Row++;
			if (Column < 3)
			{
				if (Row > 10)
				{
					Row = 1;
				}
			}
			else if (Row > 5)
			{
				Row = 1;
			}
			UpdateHighlight();
		}
		else
		{
			if (!PauseScreen.InputManager.TappedUp)
			{
				return;
			}
			Row--;
			if (Column < 3)
			{
				if (Row < 1)
				{
					Row = 10;
				}
			}
			else if (Row < 1)
			{
				Row = 5;
			}
			UpdateHighlight();
		}
	}

	private void UpdateHighlight()
	{
		if (Column == 3 && Row > 5)
		{
			Row = 5;
		}
		Highlight.localPosition = new Vector3(-500 + (Column - 1) * 150, 37.5f - (float)(Row * 25), 0f);
		ID = Row + (Column - 1) * 10;
		DescLabel.text = Descriptions[ID];
	}

	private void Exit()
	{
		PauseScreen.PromptBar.Label[0].text = "Accept";
		PauseScreen.MainMenu.SetActive(value: true);
		PauseScreen.Sideways = false;
		base.gameObject.SetActive(value: false);
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
	}
}
