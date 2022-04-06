using System;
using UnityEngine;

// Token: 0x0200034D RID: 845
public class KnifeArrayScript : MonoBehaviour
{
	// Token: 0x06001960 RID: 6496 RVA: 0x000FEA68 File Offset: 0x000FCC68
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.ID < 10)
		{
			if (this.Timer > this.SpawnTimes[this.ID] && this.GlobalKnifeArray.ID < 1000)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Knife, base.transform.position, Quaternion.identity);
				gameObject.transform.parent = base.transform;
				gameObject.transform.localPosition = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(0.5f, 2f), UnityEngine.Random.Range(-0.75f, -1.75f));
				gameObject.transform.parent = null;
				gameObject.transform.LookAt(this.KnifeTarget);
				this.GlobalKnifeArray.Knives[this.GlobalKnifeArray.ID] = gameObject.GetComponent<TimeStopKnifeScript>();
				this.GlobalKnifeArray.ID++;
				this.ID++;
				return;
			}
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002822 RID: 10274
	public GlobalKnifeArrayScript GlobalKnifeArray;

	// Token: 0x04002823 RID: 10275
	public Transform KnifeTarget;

	// Token: 0x04002824 RID: 10276
	public float[] SpawnTimes;

	// Token: 0x04002825 RID: 10277
	public GameObject Knife;

	// Token: 0x04002826 RID: 10278
	public float Timer;

	// Token: 0x04002827 RID: 10279
	public int ID;
}
