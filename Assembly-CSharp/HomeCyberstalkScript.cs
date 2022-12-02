using UnityEngine;

public class HomeCyberstalkScript : MonoBehaviour
{
	public HomeDarknessScript HomeDarkness;

	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			HomeDarkness.Sprite.color = new Color(0f, 0f, 0f, 0f);
			HomeDarkness.Cyberstalking = true;
			HomeDarkness.FadeOut = true;
			base.gameObject.SetActive(false);
			int num = 1;
			for (num = 1; num < 26; num++)
			{
				ConversationGlobals.SetTopicLearnedByStudent(num, HomeDarkness.HomeCamera.HomeInternet.Student, true);
				ConversationGlobals.SetTopicDiscovered(num, true);
			}
		}
		if (Input.GetButtonDown("B"))
		{
			base.gameObject.SetActive(false);
		}
	}
}
