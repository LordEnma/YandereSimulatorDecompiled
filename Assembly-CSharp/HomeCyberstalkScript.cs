using System;
using UnityEngine;

// Token: 0x02000319 RID: 793
public class HomeCyberstalkScript : MonoBehaviour
{
	// Token: 0x06001864 RID: 6244 RVA: 0x000EBBF0 File Offset: 0x000E9DF0
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

	// Token: 0x04002459 RID: 9305
	public HomeDarknessScript HomeDarkness;
}
