using System;
using UnityEngine;

// Token: 0x02000297 RID: 663
public class GameController : MonoBehaviour
{
	// Token: 0x060013E1 RID: 5089 RVA: 0x000BCEE4 File Offset: 0x000BB0E4
	private void Update()
	{
		this.m_Player.transform.Rotate(new Vector3(0f, Input.GetAxis("Horizontal") * Time.deltaTime * 200f, 0f));
		this.m_Player.transform.Translate(base.transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * 4f);
	}

	// Token: 0x060013E2 RID: 5090 RVA: 0x000BCF64 File Offset: 0x000BB164
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

	// Token: 0x04001DBC RID: 7612
	public GameObject m_Player;
}
