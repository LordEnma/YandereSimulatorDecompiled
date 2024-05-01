using UnityEngine;

public class TextMessageManagerScript : MonoBehaviour
{
	public PauseScreenScript PauseScreen;

	public PromptBarScript PromptBar;

	public GameObject ServicesMenu;

	public string[] Messages;

	public string[] EmbarassingSecrets;

	public string[] DarkSecrets;

	private GameObject NewMessage;

	public GameObject Message;

	public int MessageHeight;

	public string MessageText = string.Empty;

	public void Start()
	{
		Messages[4] = EmbarassingSecrets[DateGlobals.Week];
		Messages[10] = DarkSecrets[DateGlobals.Week];
	}

	private void Update()
	{
		if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			Object.Destroy(NewMessage);
			PromptBar.ClearButtons();
			PromptBar.Label[0].text = "Accept";
			PromptBar.Label[1].text = "Exit";
			PromptBar.Label[5].text = "Choose";
			PromptBar.UpdateButtons();
			PauseScreen.Sideways = true;
			ServicesMenu.SetActive(value: true);
			base.gameObject.SetActive(value: false);
			PauseScreen.StudentInfoMenu.SendingHome = false;
			PauseScreen.Yandere.RPGCamera.enabled = true;
		}
	}

	public void SpawnMessage(int ServiceID)
	{
		PromptBar.ClearButtons();
		PromptBar.Label[1].text = "Exit";
		PromptBar.UpdateButtons();
		PauseScreen.Sideways = false;
		ServicesMenu.SetActive(value: false);
		base.gameObject.SetActive(value: true);
		if (NewMessage != null)
		{
			Object.Destroy(NewMessage);
		}
		NewMessage = Object.Instantiate(Message);
		NewMessage.transform.parent = base.transform;
		NewMessage.transform.localPosition = new Vector3(-225f, -275f, 0f);
		NewMessage.transform.localEulerAngles = Vector3.zero;
		NewMessage.transform.localScale = new Vector3(1f, 1f, 1f);
		MessageText = Messages[ServiceID];
		switch (ServiceID)
		{
		case 4:
		case 7:
			MessageHeight = 11;
			break;
		case 9:
			MessageHeight = 6;
			break;
		default:
			MessageHeight = 5;
			break;
		}
		NewMessage.GetComponent<UISprite>().height = 36 + 36 * MessageHeight;
		NewMessage.GetComponent<TextMessageScript>().Label.text = MessageText;
	}
}
