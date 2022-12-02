using UnityEngine;

public class EventEditorScript : MonoBehaviour
{
	[SerializeField]
	private UIPanel mainPanel;

	[SerializeField]
	private UIPanel eventPanel;

	[SerializeField]
	private UILabel titleLabel;

	[SerializeField]
	private PromptBarScript promptBar;

	private InputManagerScript inputManager;

	private void Awake()
	{
		inputManager = Object.FindObjectOfType<InputManagerScript>();
	}

	private void OnEnable()
	{
		promptBar.Label[0].text = string.Empty;
		promptBar.Label[1].text = "Back";
		promptBar.Label[4].text = string.Empty;
		promptBar.UpdateButtons();
	}

	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			mainPanel.gameObject.SetActive(true);
			eventPanel.gameObject.SetActive(false);
		}
	}

	private void Update()
	{
		HandleInput();
	}
}
