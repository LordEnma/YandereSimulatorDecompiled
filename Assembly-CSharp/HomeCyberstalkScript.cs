using System;
using UnityEngine;

// Token: 0x0200031A RID: 794
public class HomeCyberstalkScript : MonoBehaviour
{
	// Token: 0x0600186E RID: 6254 RVA: 0x000EC324 File Offset: 0x000EA524
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

	// Token: 0x04002468 RID: 9320
	public HomeDarknessScript HomeDarkness;
}
