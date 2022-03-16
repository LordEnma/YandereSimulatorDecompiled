using System;
using UnityEngine;

// Token: 0x0200031B RID: 795
public class HomeCyberstalkScript : MonoBehaviour
{
	// Token: 0x0600187C RID: 6268 RVA: 0x000ED3F8 File Offset: 0x000EB5F8
	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			this.HomeDarkness.Sprite.color = new Color(0f, 0f, 0f, 0f);
			this.HomeDarkness.Cyberstalking = true;
			this.HomeDarkness.FadeOut = true;
			base.gameObject.SetActive(false);
			for (int i = 1; i < 26; i++)
			{
				ConversationGlobals.SetTopicLearnedByStudent(i, this.HomeDarkness.HomeCamera.HomeInternet.Student, true);
				ConversationGlobals.SetTopicDiscovered(i, true);
			}
		}
		if (Input.GetButtonDown("B"))
		{
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x0400249C RID: 9372
	public HomeDarknessScript HomeDarkness;
}
