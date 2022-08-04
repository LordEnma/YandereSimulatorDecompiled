// Decompiled with JetBrains decompiler
// Type: HomePantyChangerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HomePantyChangerScript : MonoBehaviour
{
  public InputManagerScript InputManager;
  public HomeYandereScript HomeYandere;
  public HomeCameraScript HomeCamera;
  public HomeWindowScript HomeWindow;
  private GameObject NewPanties;
  public UILabel PantyNameLabel;
  public UILabel PantyDescLabel;
  public UILabel PantyBuffLabel;
  public UILabel ButtonLabel;
  public Transform PantyParent;
  public bool DestinationReached;
  public float TargetRotation;
  public float Rotation;
  public int TotalPanties;
  public int Selected;
  public GameObject[] PantyModels;
  public string[] PantyNames;
  public string[] PantyDescs;
  public string[] PantyBuffs;
  public AudioClip ChangeSelection;
  public AudioClip MakeSelection;
  public AudioClip CloseDrawer;

  private void Start()
  {
    for (int index = 0; index < this.TotalPanties; ++index)
    {
      this.NewPanties = Object.Instantiate<GameObject>(this.PantyModels[index], new Vector3(this.transform.position.x, this.transform.position.y - 0.85f, this.transform.position.z - 1f), Quaternion.identity);
      this.NewPanties.transform.parent = this.PantyParent;
      this.NewPanties.GetComponent<HomePantiesScript>().PantyChanger = this;
      this.NewPanties.GetComponent<HomePantiesScript>().ID = index;
      this.PantyParent.transform.localEulerAngles = new Vector3(this.PantyParent.transform.localEulerAngles.x, this.PantyParent.transform.localEulerAngles.y + 360f / (float) this.TotalPanties, this.PantyParent.transform.localEulerAngles.z);
    }
    this.PantyParent.transform.localEulerAngles = new Vector3(this.PantyParent.transform.localEulerAngles.x, 0.0f, this.PantyParent.transform.localEulerAngles.z);
    this.PantyParent.transform.localPosition = new Vector3(this.PantyParent.transform.localPosition.x, this.PantyParent.transform.localPosition.y, 1.8f);
    this.UpdatePantyLabels();
    this.PantyParent.transform.localScale = Vector3.zero;
    this.PantyParent.gameObject.SetActive(false);
  }

  private void Update()
  {
    if (this.HomeWindow.Show)
    {
      this.PantyParent.localScale = Vector3.Lerp(this.PantyParent.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.PantyParent.gameObject.SetActive(true);
      if (this.InputManager.TappedRight)
      {
        this.DestinationReached = false;
        this.TargetRotation += 360f / (float) this.TotalPanties;
        ++this.Selected;
        if (this.Selected > this.TotalPanties - 1)
          this.Selected = 0;
        AudioSource.PlayClipAtPoint(this.ChangeSelection, this.transform.position);
        this.UpdatePantyLabels();
      }
      if (this.InputManager.TappedLeft)
      {
        this.DestinationReached = false;
        this.TargetRotation -= 360f / (float) this.TotalPanties;
        --this.Selected;
        if (this.Selected < 0)
          this.Selected = this.TotalPanties - 1;
        AudioSource.PlayClipAtPoint(this.ChangeSelection, this.transform.position);
        this.UpdatePantyLabels();
      }
      this.Rotation = Mathf.Lerp(this.Rotation, this.TargetRotation, Time.deltaTime * 10f);
      this.PantyParent.localEulerAngles = new Vector3(this.PantyParent.localEulerAngles.x, this.Rotation, this.PantyParent.localEulerAngles.z);
      if (Input.GetButtonDown("A"))
      {
        if (this.Selected == 0 || CollectibleGlobals.GetPantyPurchased(this.Selected))
        {
          PlayerGlobals.PantiesEquipped = this.Selected;
          Debug.Log((object) ("Yandere-chan should now be equipped with Panties #" + PlayerGlobals.PantiesEquipped.ToString()));
          AudioSource.PlayClipAtPoint(this.MakeSelection, this.transform.position);
        }
        else
          Debug.Log((object) "Yandere-chan doesn't own those panties.");
        this.UpdatePantyLabels();
      }
      if (!Input.GetButtonDown("B"))
        return;
      this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
      this.HomeCamera.Target = this.HomeCamera.Targets[0];
      this.HomeYandere.CanMove = true;
      this.HomeWindow.Show = false;
      AudioSource.PlayClipAtPoint(this.CloseDrawer, this.transform.position);
    }
    else
    {
      this.PantyParent.localScale = Vector3.Lerp(this.PantyParent.localScale, Vector3.zero, Time.deltaTime * 10f);
      if ((double) this.PantyParent.localScale.x >= 0.0099999997764825821)
        return;
      this.PantyParent.gameObject.SetActive(false);
    }
  }

  private void UpdatePantyLabels()
  {
    if (this.Selected == 0 || CollectibleGlobals.GetPantyPurchased(this.Selected))
    {
      this.PantyNameLabel.text = this.PantyNames[this.Selected];
      this.PantyDescLabel.text = this.PantyDescs[this.Selected];
      this.PantyBuffLabel.text = this.PantyBuffs[this.Selected];
    }
    else
    {
      this.PantyNameLabel.text = "?????";
      this.PantyBuffLabel.text = "?????";
      this.PantyDescLabel.text = this.Selected >= 11 ? "Unlock these panties by locating them and picking them up!" : "Unlock these panties by purchasing them from the lingerie store in town!";
    }
    if (this.Selected == 0 || CollectibleGlobals.GetPantyPurchased(this.Selected))
      this.ButtonLabel.text = this.Selected == PlayerGlobals.PantiesEquipped ? "Equipped" : "Wear";
    else
      this.ButtonLabel.text = "Unavailable";
  }
}
