using UnityEngine;

public class TextMessageScript : MonoBehaviour
{
	public UILabel Label;

	public GameObject Image;

	public bool Attachment;

	public bool Right;

	private void Start()
	{
		if (!Attachment && Image != null)
		{
			Image.SetActive(value: false);
		}
		if (Right && EventGlobals.OsanaConversation)
		{
			base.gameObject.GetComponent<UISprite>().color = new Color(1f, 0.5f, 0f);
			Label.color = new Color(1f, 1f, 1f);
		}
	}

	private void Update()
	{
		base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
	}
}
