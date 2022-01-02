using System;
using UnityEngine;

// Token: 0x02000318 RID: 792
public class HomeCyberstalkScript : MonoBehaviour
{
	// Token: 0x06001860 RID: 6240 RVA: 0x000EB7CC File Offset: 0x000E99CC
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

	// Token: 0x04002452 RID: 9298
	public HomeDarknessScript HomeDarkness;
}
