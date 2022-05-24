using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000505 RID: 1285
public class Drawer_Pull_Z : MonoBehaviour
{
	// Token: 0x0600215A RID: 8538 RVA: 0x001EE7D3 File Offset: 0x001EC9D3
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x0600215B RID: 8539 RVA: 0x001EE7DC File Offset: 0x001EC9DC
	private void OnMouseOver()
	{
		if (this.Player && Vector3.Distance(this.Player.position, base.transform.position) < 10f)
		{
			MonoBehaviour.print("object name");
			if (!this.open)
			{
				if (Input.GetMouseButtonDown(0))
				{
					base.StartCoroutine(this.opening());
					return;
				}
			}
			else if (this.open && Input.GetMouseButtonDown(0))
			{
				base.StartCoroutine(this.closing());
			}
		}
	}

	// Token: 0x0600215C RID: 8540 RVA: 0x001EE85D File Offset: 0x001ECA5D
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull.Play("openpull");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0600215D RID: 8541 RVA: 0x001EE86C File Offset: 0x001ECA6C
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull.Play("closepush");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040049BA RID: 18874
	public Animator pull;

	// Token: 0x040049BB RID: 18875
	public bool open;

	// Token: 0x040049BC RID: 18876
	public Transform Player;
}
