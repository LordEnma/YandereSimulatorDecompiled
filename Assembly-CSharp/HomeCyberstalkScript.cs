using System;
using UnityEngine;

// Token: 0x02000318 RID: 792
public class HomeCyberstalkScript : MonoBehaviour
{
	// Token: 0x0600185E RID: 6238 RVA: 0x000EB4E8 File Offset: 0x000E96E8
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

	// Token: 0x0400244E RID: 9294
	public HomeDarknessScript HomeDarkness;
}
