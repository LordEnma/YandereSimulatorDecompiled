// Decompiled with JetBrains decompiler
// Type: BloodPoolSpawnerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class BloodPoolSpawnerScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public RagdollScript Ragdoll;
  public GameObject LastBloodPool;
  public GameObject BloodPool;
  public Transform BloodParent;
  public Transform Hips;
  public Collider MyCollider;
  public Collider GardenArea;
  public Collider TreeArea;
  public Collider NEStairs;
  public Collider NWStairs;
  public Collider SEStairs;
  public Collider SWStairs;
  public Vector3[] Positions;
  public bool CanSpawn;
  public bool Falling;
  public int PoolsSpawned;
  public int NearbyBlood;
  public float FallTimer;
  public float Height;
  public float Timer;
  public LayerMask Mask;

  public void Start()
  {
    if (SceneManager.GetActiveScene().name == "SchoolScene")
    {
      this.PoolsSpawned = this.Ragdoll.Student.BloodPoolsSpawned;
      if ((Object) this.StudentManager == (Object) null)
        this.StudentManager = this.Ragdoll.Student.StudentManager;
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
    this.Positions[1] = new Vector3(0.5f, 0.012f, 0.0f);
    this.Positions[2] = new Vector3(-0.5f, 0.012f, 0.0f);
    this.Positions[3] = new Vector3(0.0f, 0.012f, 0.5f);
    this.Positions[4] = new Vector3(0.0f, 0.012f, -0.5f);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (!(other.gameObject.name == "BloodPool(Clone)"))
      return;
    this.LastBloodPool = other.gameObject;
    ++this.NearbyBlood;
  }

  private void OnTriggerExit(Collider other)
  {
    if (!(other.gameObject.name == "BloodPool(Clone)"))
      return;
    --this.NearbyBlood;
  }

  private void Update()
  {
    if (!this.Falling)
    {
      if (!this.MyCollider.enabled)
        return;
      if ((double) this.Timer > 0.0)
        this.Timer -= Time.deltaTime;
      this.SetHeight();
      Vector3 position = this.transform.position;
      if (SceneManager.GetActiveScene().name == "SchoolScene")
        this.CanSpawn = !this.GardenArea.bounds.Contains(position) && !this.TreeArea.bounds.Contains(position) && !this.NEStairs.bounds.Contains(position) && !this.NWStairs.bounds.Contains(position) && !this.SEStairs.bounds.Contains(position) && !this.SWStairs.bounds.Contains(position);
      if (!this.CanSpawn || (double) position.y >= (double) this.Height + 0.3333333432674408)
        return;
      if (this.NearbyBlood > 0 && (Object) this.LastBloodPool == (Object) null)
        --this.NearbyBlood;
      if (this.NearbyBlood >= 1 || (double) this.Timer > 0.0)
        return;
      this.Timer = 0.1f;
      GameObject gameObject = (GameObject) null;
      if (this.PoolsSpawned < 10)
      {
        gameObject = Object.Instantiate<GameObject>(this.BloodPool, new Vector3(position.x, this.Height + 0.012f, position.z), Quaternion.identity);
        gameObject.transform.localEulerAngles = new Vector3(90f, Random.Range(0.0f, 360f), 0.0f);
        gameObject.transform.parent = this.BloodParent;
        gameObject.GetComponent<BloodPoolScript>().StudentBloodID = this.Ragdoll.StudentID;
        ++this.PoolsSpawned;
        ++this.Ragdoll.Student.BloodPoolsSpawned;
      }
      else if (this.PoolsSpawned < 20)
      {
        gameObject = Object.Instantiate<GameObject>(this.BloodPool, new Vector3(position.x, this.Height + 0.012f, position.z), Quaternion.identity);
        gameObject.transform.localEulerAngles = new Vector3(90f, Random.Range(0.0f, 360f), 0.0f);
        gameObject.transform.parent = this.BloodParent;
        gameObject.GetComponent<BloodPoolScript>().StudentBloodID = this.Ragdoll.StudentID;
        ++this.PoolsSpawned;
        ++this.Ragdoll.Student.BloodPoolsSpawned;
        gameObject.GetComponent<BloodPoolScript>().TargetSize = (float) (1.0 - (double) (this.PoolsSpawned - 10) * 0.10000000149011612);
        if (this.PoolsSpawned == 20)
          this.gameObject.SetActive(false);
      }
      if (!((Object) gameObject != (Object) null) || !this.StudentManager.EastBathroomArea.bounds.Contains(this.transform.position) && !this.StudentManager.WestBathroomArea.bounds.Contains(this.transform.position))
        return;
      gameObject.GetComponent<BloodPoolScript>().TargetSize = gameObject.GetComponent<BloodPoolScript>().TargetSize * 0.5f;
    }
    else
    {
      this.FallTimer += Time.deltaTime;
      if ((double) this.FallTimer <= 10.0)
        return;
      this.Falling = false;
    }
  }

  public void SpawnBigPool()
  {
    this.SetHeight();
    Vector3 vector3 = new Vector3(this.Hips.position.x, this.Height + 0.012f, this.Hips.position.z);
    for (int index = 0; index < 5; ++index)
    {
      if (this.Positions.Length == 0)
        this.Start();
      GameObject gameObject = Object.Instantiate<GameObject>(this.BloodPool, vector3 + this.Positions[index], Quaternion.identity);
      gameObject.transform.localEulerAngles = new Vector3(90f, Random.Range(0.0f, 360f), 0.0f);
      gameObject.transform.parent = this.BloodParent;
      gameObject.GetComponent<BloodPoolScript>().StudentBloodID = this.Ragdoll.StudentID;
    }
  }

  private void SpawnRow(Transform Location)
  {
    Vector3 position = Location.position;
    Vector3 forward = Location.forward;
    GameObject gameObject1 = Object.Instantiate<GameObject>(this.BloodPool, position + forward * 2f, Quaternion.identity);
    gameObject1.transform.localEulerAngles = new Vector3(90f, Random.Range(0.0f, 360f), 0.0f);
    gameObject1.transform.parent = this.BloodParent;
    gameObject1.GetComponent<BloodPoolScript>().StudentBloodID = this.Ragdoll.StudentID;
    GameObject gameObject2 = Object.Instantiate<GameObject>(this.BloodPool, position + forward * 2.5f, Quaternion.identity);
    gameObject2.transform.localEulerAngles = new Vector3(90f, Random.Range(0.0f, 360f), 0.0f);
    gameObject2.transform.parent = this.BloodParent;
    gameObject2.GetComponent<BloodPoolScript>().StudentBloodID = this.Ragdoll.StudentID;
    GameObject gameObject3 = Object.Instantiate<GameObject>(this.BloodPool, position + forward * 3f, Quaternion.identity);
    gameObject3.transform.localEulerAngles = new Vector3(90f, Random.Range(0.0f, 360f), 0.0f);
    gameObject3.transform.parent = this.BloodParent;
    gameObject3.GetComponent<BloodPoolScript>().StudentBloodID = this.Ragdoll.StudentID;
  }

  public void SpawnPool(Transform Location)
  {
    GameObject gameObject = Object.Instantiate<GameObject>(this.BloodPool, Location.position + Location.forward + new Vector3(0.0f, 0.0001f, 0.0f), Quaternion.identity);
    gameObject.transform.localEulerAngles = new Vector3(90f, Random.Range(0.0f, 360f), 0.0f);
    gameObject.transform.parent = this.BloodParent;
    gameObject.GetComponent<BloodPoolScript>().StudentBloodID = this.Ragdoll.StudentID;
  }

  private void SetHeight()
  {
    float y = this.transform.position.y;
    if ((double) y < 4.0)
      this.Height = 0.0f;
    else if ((double) y < 8.0)
      this.Height = 4f;
    else if ((double) y < 12.0)
      this.Height = 8f;
    else
      this.Height = 12f;
  }
}
