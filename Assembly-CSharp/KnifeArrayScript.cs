using System;
using UnityEngine;

// Token: 0x0200034E RID: 846
public class KnifeArrayScript : MonoBehaviour
{
	// Token: 0x0600196E RID: 6510 RVA: 0x000FFA08 File Offset: 0x000FDC08
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

	// Token: 0x04002844 RID: 10308
	public GlobalKnifeArrayScript GlobalKnifeArray;

	// Token: 0x04002845 RID: 10309
	public Transform KnifeTarget;

	// Token: 0x04002846 RID: 10310
	public float[] SpawnTimes;

	// Token: 0x04002847 RID: 10311
	public GameObject Knife;

	// Token: 0x04002848 RID: 10312
	public float Timer;

	// Token: 0x04002849 RID: 10313
	public int ID;
}
