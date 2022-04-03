using System;
using UnityEngine;

// Token: 0x0200031C RID: 796
public class HomeCyberstalkScript : MonoBehaviour
{
	// Token: 0x06001882 RID: 6274 RVA: 0x000ED9B0 File Offset: 0x000EBBB0
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

	// Token: 0x040024AF RID: 9391
	public HomeDarknessScript HomeDarkness;
}
