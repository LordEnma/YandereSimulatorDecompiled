using System;
using UnityEngine;

// Token: 0x02000319 RID: 793
public class HomeCyberstalkScript : MonoBehaviour
{
	// Token: 0x06001865 RID: 6245 RVA: 0x000EC0C4 File Offset: 0x000EA2C4
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

	// Token: 0x0400245F RID: 9311
	public HomeDarknessScript HomeDarkness;
}
