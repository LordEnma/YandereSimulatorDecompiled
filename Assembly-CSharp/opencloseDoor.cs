using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000502 RID: 1282
public class opencloseDoor : MonoBehaviour
{
	// Token: 0x0600214B RID: 8523 RVA: 0x001EE5D3 File Offset: 0x001EC7D3
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x0600214C RID: 8524 RVA: 0x001EE5DC File Offset: 0x001EC7DC
	private void OnMouseOver()
	{
		if (this.Player && Vector3.Distance(this.Player.position, base.transform.position) < 15f)
		{
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

	// Token: 0x0600214D RID: 8525 RVA: 0x001EE653 File Offset: 0x001EC853
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose.Play("Opening");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0600214E RID: 8526 RVA: 0x001EE662 File Offset: 0x001EC862
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose.Play("Closing");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040049B1 RID: 18865
	public Animator openandclose;

	// Token: 0x040049B2 RID: 18866
	public bool open;

	// Token: 0x040049B3 RID: 18867
	public Transform Player;
}
