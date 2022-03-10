using System;
using UnityEngine;

// Token: 0x02000296 RID: 662
public class GameController : MonoBehaviour
{
	// Token: 0x060013D3 RID: 5075 RVA: 0x000BC2C4 File Offset: 0x000BA4C4
	private void Update()
	{
		this.m_Player.transform.Rotate(new Vector3(0f, Input.GetAxis("Horizontal") * Time.deltaTime * 200f, 0f));
		this.m_Player.transform.Translate(base.transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * 4f);
	}

	// Token: 0x060013D4 RID: 5076 RVA: 0x000BC344 File Offset: 0x000BA544
	private void OnGUI()
	{
		GUI.Label(new Rect(50f, 50f, 200f, 20f), "Press arrow key to move");
		Animation componentInChildren = this.m_Player.GetComponentInChildren<Animation>();
		componentInChildren.enabled = GUI.Toggle(new Rect(50f, 70f, 200f, 20f), componentInChildren.enabled, "Play Animation");
		DynamicBone[] components = this.m_Player.GetComponents<DynamicBone>();
		GUI.Label(new Rect(50f, 100f, 200f, 20f), "Choose dynamic bone:");
		components[0].enabled = (components[1].enabled = GUI.Toggle(new Rect(50f, 120f, 100f, 20f), components[0].enabled, "Breasts"));
		components[2].enabled = GUI.Toggle(new Rect(50f, 140f, 100f, 20f), components[2].enabled, "Tail");
	}

	// Token: 0x04001D9E RID: 7582
	public GameObject m_Player;
}
