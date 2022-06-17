// Decompiled with JetBrains decompiler
// Type: LiquidColliderScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LiquidColliderScript : MonoBehaviour
{
  private GameObject NewPool;
  public AudioClip SplashSound;
  public GameObject GroundSplash;
  public GameObject Splash;
  public GameObject Pool;
  public bool AlreadyDoused;
  public bool Static;
  public bool Bucket;
  public bool Brown;
  public bool Blood;
  public bool Gas;

  private void Start()
  {
    if (!this.Bucket)
      return;
    this.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 400f);
  }

  private void Update()
  {
    if (this.Static)
      return;
    if (!this.Bucket)
    {
      if ((double) this.transform.position.y >= 0.0)
        return;
      Object.Instantiate<GameObject>(this.GroundSplash, new Vector3(this.transform.position.x, 0.0f, this.transform.position.z), Quaternion.identity);
      this.NewPool = Object.Instantiate<GameObject>(this.Pool, new Vector3(this.transform.position.x, 0.012f, this.transform.position.z), Quaternion.identity);
      this.NewPool.transform.localEulerAngles = new Vector3(90f, Random.Range(0.0f, 360f), 0.0f);
      if (this.Blood)
        this.NewPool.transform.parent = GameObject.Find("BloodParent").transform;
      Object.Destroy((Object) this.gameObject);
    }
    else
      this.transform.localScale = new Vector3(this.transform.localScale.x + Time.deltaTime * 2f, this.transform.localScale.y + Time.deltaTime * 2f, this.transform.localScale.z + Time.deltaTime * 2f);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (this.AlreadyDoused || other.gameObject.layer != 9)
      return;
    StudentScript component = other.gameObject.GetComponent<StudentScript>();
    if (!((Object) component != (Object) null))
      return;
    if (component.Wet || component.Fleeing || component.SenpaiWitnessingRivalDie || component.Schoolwear == 2 && !this.Brown && !this.Blood && !this.Gas || component.Club == ClubType.Sports && component.ClubAttire && component.Clock.Period > 5 && !this.Brown && !this.Blood && !this.Gas)
    {
      component.Yandere.NotificationManager.CustomText = "Didn't care.";
      component.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      if (component.Schoolwear != 2 && !component.ClubAttire)
        return;
      component.Subtitle.CustomText = "What a stupid prank! Oh, well. I was in my swimsuit, anyway...";
      component.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 4f);
    }
    else if (!component.BeenSplashed && component.StudentID > 1 && !component.Reflexes && !component.Teacher && component.Club != ClubType.Council && !component.GasWarned && component.CurrentAction != StudentActionType.Sunbathe)
    {
      AudioSource.PlayClipAtPoint(this.SplashSound, this.transform.position);
      Object.Instantiate<GameObject>(this.Splash, new Vector3(this.transform.position.x, 1.5f, this.transform.position.z), Quaternion.identity);
      if (this.Blood)
        component.Bloody = true;
      else if (this.Gas)
        component.Gas = true;
      else if (this.Brown)
        component.DyedBrown = true;
      component.GetWet();
      this.AlreadyDoused = true;
      Object.Destroy((Object) this.gameObject);
    }
    else
    {
      Debug.Log((object) (component.Name + " just dodged some liquid."));
      if (component.Investigating)
        component.StopInvestigating();
      if (component.ReturningMisplacedWeapon)
        component.DropMisplacedWeapon();
      if (component.EatingSnack)
      {
        Debug.Log((object) "This student was eating a snack at the point in time when they dodged the liquid, so they are forgetting about getting a drink.");
        component.StopDrinking();
        component.CurrentDestination = component.Destinations[component.Phase];
        component.Pathfinding.target = component.Destinations[component.Phase];
      }
      component.CharacterAnimation.CrossFade(component.DodgeAnim);
      component.Pathfinding.canSearch = false;
      component.Pathfinding.canMove = false;
      component.SentToLocker = false;
      component.Routine = false;
      component.DodgeSpeed = 2f;
      component.Dodging = true;
      if (component.Following)
      {
        component.Hearts.emission.enabled = false;
        component.FollowCountdown.gameObject.SetActive(false);
        component.Yandere.Follower = (StudentScript) null;
        --component.Yandere.Followers;
        component.Following = false;
        component.CurrentDestination = component.Destinations[component.Phase];
        component.Pathfinding.target = component.Destinations[component.Phase];
        component.Pathfinding.speed = 1f;
      }
      component.Yandere.NotificationManager.CustomText = "Anticipated the trap!";
      component.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
    }
  }
}
