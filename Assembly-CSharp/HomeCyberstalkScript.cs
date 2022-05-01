using System;
using UnityEngine;

// Token: 0x0200031D RID: 797
public class HomeCyberstalkScript : MonoBehaviour
{
	// Token: 0x06001890 RID: 6288 RVA: 0x000EE24C File Offset: 0x000EC44C
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

	// Token: 0x040024C3 RID: 9411
	public HomeDarknessScript HomeDarkness;
}
