using System;
using UnityEngine;

// Token: 0x02000451 RID: 1105
public class StringTrapScript : MonoBehaviour
{
	// Token: 0x06001D51 RID: 7505 RVA: 0x00160464 File Offset: 0x0015E664
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			Debug.Log("A character just came into contact with a tripwire trap!");
			if (this.WaterCooler.BrownPaint)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.BrownPaint, this.Spawn.position, this.WaterCooler.transform.rotation);
				this.Puddle = this.BrownPaintPuddle;
			}
			else if (this.WaterCooler.Blood)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.Blood, this.Spawn.position, this.WaterCooler.transform.rotation);
				this.Puddle = this.BloodPuddle;
			}
			else if (this.WaterCooler.Gasoline)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.Gasoline, this.Spawn.position, this.WaterCooler.transform.rotation);
				this.Puddle = this.GasolinePuddle;
			}
			else
			{
				UnityEngine.Object.Instantiate<GameObject>(this.Water, this.Spawn.position, this.WaterCooler.transform.rotation);
				this.Puddle = this.WaterPuddle;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Puddle, this.PuddleSpawn[1].position, Quaternion.identity);
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.Puddle, this.PuddleSpawn[2].position, Quaternion.identity);
			GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.Puddle, this.PuddleSpawn[3].position, Quaternion.identity);
			gameObject.transform.eulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
			gameObject2.transform.eulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
			gameObject3.transform.eulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
			if (this.WaterCooler.Blood)
			{
				gameObject.transform.parent = this.WaterCooler.Yandere.Police.BloodParent;
				gameObject2.transform.parent = this.WaterCooler.Yandere.Police.BloodParent;
				gameObject3.transform.parent = this.WaterCooler.Yandere.Police.BloodParent;
			}
			else
			{
				gameObject.transform.parent = this.WaterCooler.Yandere.StudentManager.PuddleParent.transform;
				gameObject2.transform.parent = this.WaterCooler.Yandere.StudentManager.PuddleParent.transform;
				gameObject3.transform.parent = this.WaterCooler.Yandere.StudentManager.PuddleParent.transform;
			}
			this.WaterCooler.Prompt.enabled = true;
			this.WaterCooler.BrownPaint = false;
			this.WaterCooler.Blood = false;
			this.WaterCooler.Gasoline = false;
			this.WaterCooler.Water = false;
			this.WaterCooler.TrapSet = false;
			this.WaterCooler.Empty = true;
			this.WaterCooler.Timer = 1f;
			this.WaterCooler.Prompt.Label[1].text = "     Create Tripwire Trap";
			base.transform.parent.gameObject.SetActive(false);
			this.WaterCooler.Prompt.HideButton[3] = false;
			this.WaterCooler.PickUp.enabled = true;
		}
	}

	// Token: 0x040035DF RID: 13791
	public WaterCoolerScript WaterCooler;

	// Token: 0x040035E0 RID: 13792
	public GameObject BrownPaintPuddle;

	// Token: 0x040035E1 RID: 13793
	public GameObject GasolinePuddle;

	// Token: 0x040035E2 RID: 13794
	public GameObject BloodPuddle;

	// Token: 0x040035E3 RID: 13795
	public GameObject WaterPuddle;

	// Token: 0x040035E4 RID: 13796
	public GameObject BrownPaint;

	// Token: 0x040035E5 RID: 13797
	public GameObject Gasoline;

	// Token: 0x040035E6 RID: 13798
	public GameObject Blood;

	// Token: 0x040035E7 RID: 13799
	public GameObject Water;

	// Token: 0x040035E8 RID: 13800
	public GameObject Puddle;

	// Token: 0x040035E9 RID: 13801
	public Transform[] PuddleSpawn;

	// Token: 0x040035EA RID: 13802
	public Transform Spawn;
}
