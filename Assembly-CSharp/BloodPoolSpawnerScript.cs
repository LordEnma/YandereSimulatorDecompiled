using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020000EA RID: 234
public class BloodPoolSpawnerScript : MonoBehaviour
{
	// Token: 0x06000A3C RID: 2620 RVA: 0x0005AB34 File Offset: 0x00058D34
	public void Start()
	{
		if (SceneManager.GetActiveScene().name == "SchoolScene")
		{
			this.PoolsSpawned = this.Ragdoll.Student.BloodPoolsSpawned;
			if (this.StudentManager == null)
			{
				this.StudentManager = this.Ragdoll.Student.StudentManager;
			}
			this.GardenArea = this.StudentManager.GardenArea;
			this.TreeArea = this.StudentManager.TreeArea;
			this.NEStairs = this.StudentManager.NEStairs;
			this.NWStairs = this.StudentManager.NWStairs;
			this.SEStairs = this.StudentManager.SEStairs;
			this.SWStairs = this.StudentManager.SWStairs;
		}
		this.BloodParent = GameObject.Find("BloodParent").transform;
		this.Positions = new Vector3[5];
		this.Positions[0] = Vector3.zero;
		this.Positions[1] = new Vector3(0.5f, 0.012f, 0f);
		this.Positions[2] = new Vector3(-0.5f, 0.012f, 0f);
		this.Positions[3] = new Vector3(0f, 0.012f, 0.5f);
		this.Positions[4] = new Vector3(0f, 0.012f, -0.5f);
	}

	// Token: 0x06000A3D RID: 2621 RVA: 0x0005ACAF File Offset: 0x00058EAF
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.LastBloodPool = other.gameObject;
			this.NearbyBlood++;
		}
	}

	// Token: 0x06000A3E RID: 2622 RVA: 0x0005ACE2 File Offset: 0x00058EE2
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.NearbyBlood--;
		}
	}

	// Token: 0x06000A3F RID: 2623 RVA: 0x0005AD0C File Offset: 0x00058F0C
	private void Update()
	{
		if (!this.Falling)
		{
			if (this.MyCollider.enabled)
			{
				if (this.Timer > 0f)
				{
					this.Timer -= Time.deltaTime;
				}
				this.SetHeight();
				Vector3 position = base.transform.position;
				if (SceneManager.GetActiveScene().name == "SchoolScene")
				{
					this.CanSpawn = (!this.GardenArea.bounds.Contains(position) && !this.TreeArea.bounds.Contains(position) && !this.NEStairs.bounds.Contains(position) && !this.NWStairs.bounds.Contains(position) && !this.SEStairs.bounds.Contains(position) && !this.SWStairs.bounds.Contains(position));
				}
				if (this.CanSpawn && position.y < this.Height + 0.33333334f)
				{
					if (this.NearbyBlood > 0 && this.LastBloodPool == null)
					{
						this.NearbyBlood--;
					}
					if (this.NearbyBlood < 1 && this.Timer <= 0f)
					{
						this.Timer = 0.1f;
						GameObject gameObject = null;
						if (this.PoolsSpawned < 10)
						{
							gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, new Vector3(position.x, this.Height + 0.012f, position.z), Quaternion.identity);
							gameObject.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
							gameObject.transform.parent = this.BloodParent;
							this.PoolsSpawned++;
							this.Ragdoll.Student.BloodPoolsSpawned++;
						}
						else if (this.PoolsSpawned < 20)
						{
							gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, new Vector3(position.x, this.Height + 0.012f, position.z), Quaternion.identity);
							gameObject.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
							gameObject.transform.parent = this.BloodParent;
							this.PoolsSpawned++;
							this.Ragdoll.Student.BloodPoolsSpawned++;
							gameObject.GetComponent<BloodPoolScript>().TargetSize = 1f - (float)(this.PoolsSpawned - 10) * 0.1f;
							if (this.PoolsSpawned == 20)
							{
								base.gameObject.SetActive(false);
							}
						}
						if (gameObject != null && (this.StudentManager.EastBathroomArea.bounds.Contains(base.transform.position) || this.StudentManager.WestBathroomArea.bounds.Contains(base.transform.position)))
						{
							gameObject.GetComponent<BloodPoolScript>().TargetSize = gameObject.GetComponent<BloodPoolScript>().TargetSize * 0.5f;
							return;
						}
					}
				}
			}
		}
		else
		{
			this.FallTimer += Time.deltaTime;
			if (this.FallTimer > 10f)
			{
				this.Falling = false;
			}
		}
	}

	// Token: 0x06000A40 RID: 2624 RVA: 0x0005B08C File Offset: 0x0005928C
	public void SpawnBigPool()
	{
		this.SetHeight();
		Vector3 a = new Vector3(this.Hips.position.x, this.Height + 0.012f, this.Hips.position.z);
		for (int i = 0; i < 5; i++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, a + this.Positions[i], Quaternion.identity);
			gameObject.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
			gameObject.transform.parent = this.BloodParent;
		}
	}

	// Token: 0x06000A41 RID: 2625 RVA: 0x0005B13C File Offset: 0x0005933C
	private void SpawnRow(Transform Location)
	{
		Vector3 position = Location.position;
		Vector3 forward = Location.forward;
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, position + forward * 2f, Quaternion.identity);
		gameObject.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
		gameObject.transform.parent = this.BloodParent;
		GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, position + forward * 2.5f, Quaternion.identity);
		gameObject2.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
		gameObject2.transform.parent = this.BloodParent;
		GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, position + forward * 3f, Quaternion.identity);
		gameObject3.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
		gameObject3.transform.parent = this.BloodParent;
	}

	// Token: 0x06000A42 RID: 2626 RVA: 0x0005B268 File Offset: 0x00059468
	public void SpawnPool(Transform Location)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, Location.position + Location.forward + new Vector3(0f, 0.0001f, 0f), Quaternion.identity);
		gameObject.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
		gameObject.transform.parent = this.BloodParent;
	}

	// Token: 0x06000A43 RID: 2627 RVA: 0x0005B2E8 File Offset: 0x000594E8
	private void SetHeight()
	{
		float y = base.transform.position.y;
		if (y < 4f)
		{
			this.Height = 0f;
			return;
		}
		if (y < 8f)
		{
			this.Height = 4f;
			return;
		}
		if (y < 12f)
		{
			this.Height = 8f;
			return;
		}
		this.Height = 12f;
	}

	// Token: 0x04000B9E RID: 2974
	public StudentManagerScript StudentManager;

	// Token: 0x04000B9F RID: 2975
	public RagdollScript Ragdoll;

	// Token: 0x04000BA0 RID: 2976
	public GameObject LastBloodPool;

	// Token: 0x04000BA1 RID: 2977
	public GameObject BloodPool;

	// Token: 0x04000BA2 RID: 2978
	public Transform BloodParent;

	// Token: 0x04000BA3 RID: 2979
	public Transform Hips;

	// Token: 0x04000BA4 RID: 2980
	public Collider MyCollider;

	// Token: 0x04000BA5 RID: 2981
	public Collider GardenArea;

	// Token: 0x04000BA6 RID: 2982
	public Collider TreeArea;

	// Token: 0x04000BA7 RID: 2983
	public Collider NEStairs;

	// Token: 0x04000BA8 RID: 2984
	public Collider NWStairs;

	// Token: 0x04000BA9 RID: 2985
	public Collider SEStairs;

	// Token: 0x04000BAA RID: 2986
	public Collider SWStairs;

	// Token: 0x04000BAB RID: 2987
	public Vector3[] Positions;

	// Token: 0x04000BAC RID: 2988
	public bool CanSpawn;

	// Token: 0x04000BAD RID: 2989
	public bool Falling;

	// Token: 0x04000BAE RID: 2990
	public int PoolsSpawned;

	// Token: 0x04000BAF RID: 2991
	public int NearbyBlood;

	// Token: 0x04000BB0 RID: 2992
	public float FallTimer;

	// Token: 0x04000BB1 RID: 2993
	public float Height;

	// Token: 0x04000BB2 RID: 2994
	public float Timer;

	// Token: 0x04000BB3 RID: 2995
	public LayerMask Mask;
}
