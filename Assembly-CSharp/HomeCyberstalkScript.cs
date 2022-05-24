using System;
using UnityEngine;

// Token: 0x0200031E RID: 798
public class HomeCyberstalkScript : MonoBehaviour
{
	// Token: 0x06001895 RID: 6293 RVA: 0x000EE694 File Offset: 0x000EC894
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

	// Token: 0x040024CF RID: 9423
	public HomeDarknessScript HomeDarkness;
}
