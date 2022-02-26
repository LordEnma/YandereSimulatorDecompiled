using System;
using UnityEngine;

// Token: 0x0200031B RID: 795
public class HomeCyberstalkScript : MonoBehaviour
{
	// Token: 0x06001877 RID: 6263 RVA: 0x000ECC08 File Offset: 0x000EAE08
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

	// Token: 0x04002477 RID: 9335
	public HomeDarknessScript HomeDarkness;
}
