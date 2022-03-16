using System;
using UnityEngine;

// Token: 0x0200034B RID: 843
public class KnifeArrayScript : MonoBehaviour
{
	// Token: 0x06001954 RID: 6484 RVA: 0x000FE2DC File Offset: 0x000FC4DC
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

	// Token: 0x0400280C RID: 10252
	public GlobalKnifeArrayScript GlobalKnifeArray;

	// Token: 0x0400280D RID: 10253
	public Transform KnifeTarget;

	// Token: 0x0400280E RID: 10254
	public float[] SpawnTimes;

	// Token: 0x0400280F RID: 10255
	public GameObject Knife;

	// Token: 0x04002810 RID: 10256
	public float Timer;

	// Token: 0x04002811 RID: 10257
	public int ID;
}
