using UnityEngine;

public class SocialMediaPostScript : MonoBehaviour
{
	public SocialMediaScript SocialMedia;

	public UILabel Title;

	public UILabel Date;

	public UILabel Text;

	public int ID;

	private void Start()
	{
		Title.text = SocialMedia.Titles[ID];
		Date.text = SocialMedia.Dates[ID];
		Text.text = SocialMedia.Texts[ID];
	}

	private void Update()
	{
	}
}
