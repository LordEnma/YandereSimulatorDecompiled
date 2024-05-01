using UnityEngine;

public class TextMessageScript : MonoBehaviour
{
	public UILabel Label;

	public GameObject Image;

	public bool Attachment;

	public bool Right;

	public UITexture AttachmentTexture;

	public Texture[] RivalPhotos;

	private void Start()
	{
		if (!Attachment)
		{
			if (Image != null)
			{
				Image.SetActive(value: false);
			}
		}
		else if (DateGlobals.Week > 2)
		{
			AttachmentTexture.mainTexture = RivalPhotos[DateGlobals.Week];
		}
		if (Right && EventGlobals.OsanaConversation)
		{
			if (DateGlobals.Week == 1)
			{
				base.gameObject.GetComponent<UISprite>().color = new Color(1f, 0.5f, 0f);
				Label.color = new Color(1f, 1f, 1f);
			}
			else
			{
				base.gameObject.GetComponent<UISprite>().spriteName = "MessageRightGrey";
				base.gameObject.GetComponent<UISprite>().color = new Color(0.75f, 1f, 0.75f);
			}
		}
	}

	private void Update()
	{
		base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
	}
}
