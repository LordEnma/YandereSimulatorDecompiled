// Decompiled with JetBrains decompiler
// Type: PhotoGalleryScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class PhotoGalleryScript : MonoBehaviour
{
  public HomeCorkboardPhotoScript[] CorkboardPhotographs;
  public StringScript[] CorkboardStrings;
  public int PhotoID;
  public InputManagerScript InputManager;
  public PauseScreenScript PauseScreen;
  public TaskManagerScript TaskManager;
  public InputDeviceScript InputDevice;
  public HomeCursorScript HomeCursor;
  public PromptBarScript PromptBar;
  public YandereScript Yandere;
  public StringScript String;
  public GameObject MovingPhotograph;
  public GameObject LoadingScreen;
  public GameObject Photograph;
  public GameObject StringSet;
  public Transform CorkboardPanel;
  public Transform Destination;
  public Transform Highlight;
  public Transform Gallery;
  public Transform StringParent;
  public UITexture[] Photographs;
  public UISprite[] Hearts;
  public AudioClip[] Sighs;
  public UITexture ViewPhoto;
  public Texture NoPhoto;
  public Vector2 PreviousPosition;
  public Vector2 MouseDelta;
  public bool DoNotRaisePromptBar;
  public bool SpawnedPhotos;
  public bool MovingString;
  public bool NamingBully;
  public bool Adjusting;
  public bool CanAdjust;
  public bool Corkboard;
  public bool GotPhotos;
  public bool Viewing;
  public bool Moving;
  public bool Reset;
  public int StringPhase;
  public int Strings;
  public int Photos;
  public int Column;
  public int Row;
  public float MaxPhotoX = 4150f;
  public float MaxPhotoY = 2500f;
  private const float MaxCursorX = 4788f;
  private const float MaxCursorY = 3122f;
  private const float CorkboardAspectRatio = 1.533632f;
  public float SpeedLimit;

  private void Start()
  {
    if ((Object) this.HomeCursor != (Object) null)
    {
      this.HomeCursor.gameObject.SetActive(false);
      this.enabled = false;
    }
    if (!this.Corkboard)
      return;
    this.StartCoroutine(this.GetPhotos());
  }

  private int CurrentIndex => this.Column + (this.Row - 1) * 5;

  private float LerpSpeed => Time.unscaledDeltaTime * 10f;

  private float HighlightX => (float) (150.0 * (double) this.Column - 450.0);

  private float HighlightY => (float) (225.0 - 75.0 * (double) this.Row);

  private float MovingPhotoXPercent
  {
    get
    {
      float num = -this.MaxPhotoX;
      float maxPhotoX = this.MaxPhotoX;
      return (float) (((double) this.MovingPhotograph.transform.localPosition.x - (double) num) / ((double) maxPhotoX - (double) num));
    }
    set => this.MovingPhotograph.transform.localPosition = new Vector3((float) (-(double) this.MaxPhotoX + 2.0 * ((double) this.MaxPhotoX * (double) Mathf.Clamp01(value))), this.MovingPhotograph.transform.localPosition.y, this.MovingPhotograph.transform.localPosition.z);
  }

  private float MovingPhotoYPercent
  {
    get
    {
      float num = -this.MaxPhotoY;
      float maxPhotoY = this.MaxPhotoY;
      return (float) (((double) this.MovingPhotograph.transform.localPosition.y - (double) num) / ((double) maxPhotoY - (double) num));
    }
    set => this.MovingPhotograph.transform.localPosition = new Vector3(this.MovingPhotograph.transform.localPosition.x, (float) (-(double) this.MaxPhotoY + 2.0 * ((double) this.MaxPhotoY * (double) Mathf.Clamp01(value))), this.MovingPhotograph.transform.localPosition.z);
  }

  private float MovingPhotoRotation
  {
    get => this.MovingPhotograph.transform.localEulerAngles.z;
    set => this.MovingPhotograph.transform.localEulerAngles = new Vector3(this.MovingPhotograph.transform.localEulerAngles.x, this.MovingPhotograph.transform.localEulerAngles.y, value);
  }

  private float CursorXPercent
  {
    get
    {
      float num1 = -4788f;
      float num2 = 4788f;
      return (float) (((double) this.HomeCursor.transform.localPosition.x - (double) num1) / ((double) num2 - (double) num1));
    }
    set => this.HomeCursor.transform.localPosition = new Vector3((float) (2.0 * (4788.0 * (double) Mathf.Clamp01(value)) - 4788.0), this.HomeCursor.transform.localPosition.y, this.HomeCursor.transform.localPosition.z);
  }

  private float CursorYPercent
  {
    get
    {
      float num1 = -3122f;
      float num2 = 3122f;
      return (float) (((double) this.HomeCursor.transform.localPosition.y - (double) num1) / ((double) num2 - (double) num1));
    }
    set => this.HomeCursor.transform.localPosition = new Vector3(this.HomeCursor.transform.localPosition.x, (float) (2.0 * (3122.0 * (double) Mathf.Clamp01(value)) - 3122.0), this.HomeCursor.transform.localPosition.z);
  }

  private void UpdatePhotoSelection()
  {
    if (Input.GetButtonDown("A"))
    {
      if (!this.NamingBully)
      {
        UITexture photograph = this.Photographs[this.CurrentIndex];
        if ((Object) photograph.mainTexture != (Object) this.NoPhoto)
        {
          this.ViewPhoto.mainTexture = photograph.mainTexture;
          this.ViewPhoto.transform.position = photograph.transform.position;
          this.ViewPhoto.transform.localScale = photograph.transform.localScale;
          this.Destination.position = photograph.transform.position;
          this.Viewing = true;
          if (!this.Corkboard)
          {
            for (int index = 1; index < 26; ++index)
              this.Hearts[index].gameObject.SetActive(false);
          }
          this.CanAdjust = false;
        }
        this.UpdateButtonPrompts();
      }
      else if ((Object) this.Photographs[this.CurrentIndex].mainTexture != (Object) this.NoPhoto && PlayerGlobals.GetBullyPhoto(this.CurrentIndex) > 0)
      {
        this.Yandere.Police.EndOfDay.FragileTarget = PlayerGlobals.GetBullyPhoto(this.CurrentIndex);
        this.Yandere.StudentManager.FragileOfferHelp.Continue();
        this.PauseScreen.MainMenu.SetActive(true);
        this.Yandere.RPGCamera.enabled = true;
        this.gameObject.SetActive(false);
        this.PauseScreen.Show = false;
        this.PromptBar.Show = false;
        this.NamingBully = false;
        Time.timeScale = 1f;
      }
    }
    if (!this.NamingBully && Input.GetButtonDown("B"))
    {
      this.PromptBar.ClearButtons();
      this.PromptBar.Label[0].text = "Accept";
      this.PromptBar.Label[1].text = "Exit";
      this.PromptBar.Label[4].text = "Choose";
      this.PromptBar.Label[5].text = "Choose";
      this.PromptBar.UpdateButtons();
      this.PauseScreen.MainMenu.SetActive(true);
      this.PauseScreen.Sideways = false;
      this.PauseScreen.PressedB = true;
      this.gameObject.SetActive(false);
      this.UpdateButtonPrompts();
    }
    if (Input.GetButtonDown("X"))
    {
      this.ViewPhoto.mainTexture = (Texture) null;
      int currentIndex = this.CurrentIndex;
      if ((Object) this.Photographs[currentIndex].mainTexture != (Object) this.NoPhoto)
      {
        this.Photographs[currentIndex].mainTexture = this.NoPhoto;
        PlayerGlobals.SetPhoto(currentIndex, false);
        PlayerGlobals.SetSenpaiPhoto(currentIndex, false);
        TaskGlobals.SetGuitarPhoto(currentIndex, false);
        TaskGlobals.SetKittenPhoto(currentIndex, false);
        this.Hearts[currentIndex].gameObject.SetActive(false);
        this.TaskManager.UpdateTaskStatus();
      }
      this.UpdateButtonPrompts();
    }
    if (this.Corkboard)
    {
      if (Input.GetButtonDown("Y"))
      {
        this.CanAdjust = false;
        this.HomeCursor.gameObject.SetActive(true);
        this.Adjusting = true;
        this.UpdateButtonPrompts();
      }
    }
    else if (Input.GetButtonDown("Y") && PlayerGlobals.GetSenpaiPhoto(this.CurrentIndex))
    {
      int currentIndex = this.CurrentIndex;
      --PlayerGlobals.SenpaiShots;
      --this.Yandere.Inventory.SenpaiShots;
      PlayerGlobals.SetPhoto(currentIndex, false);
      PlayerGlobals.SetSenpaiPhoto(currentIndex, false);
      this.Hearts[currentIndex].gameObject.SetActive(false);
      this.Photographs[currentIndex].mainTexture = this.NoPhoto;
      this.TaskManager.UpdateTaskStatus();
      this.CanAdjust = false;
      this.Yandere.Sanity += 20f;
      this.UpdateButtonPrompts();
      AudioSource.PlayClipAtPoint(this.Sighs[Random.Range(0, this.Sighs.Length)], this.Yandere.Head.position);
    }
    if (this.InputManager.TappedRight)
      this.Column = this.Column < 5 ? this.Column + 1 : 1;
    if (this.InputManager.TappedLeft)
      this.Column = this.Column > 1 ? this.Column - 1 : 5;
    if (this.InputManager.TappedUp)
      this.Row = this.Row > 1 ? this.Row - 1 : 5;
    if (this.InputManager.TappedDown)
      this.Row = this.Row < 5 ? this.Row + 1 : 1;
    if (((this.InputManager.TappedRight ? 1 : (this.InputManager.TappedLeft ? 1 : 0)) | (this.InputManager.TappedUp ? (true ? 1 : 0) : (this.InputManager.TappedDown ? 1 : 0))) != 0)
    {
      this.Highlight.transform.localPosition = new Vector3(this.HighlightX, this.HighlightY, this.Highlight.transform.localPosition.z);
      this.UpdateButtonPrompts();
    }
    this.ViewPhoto.transform.localScale = Vector3.Lerp(this.ViewPhoto.transform.localScale, new Vector3(1f, 1f, 1f), this.LerpSpeed);
    this.ViewPhoto.transform.position = Vector3.Lerp(this.ViewPhoto.transform.position, this.Destination.position, this.LerpSpeed);
    if (!this.Corkboard)
      return;
    this.Gallery.transform.localPosition = new Vector3(this.Gallery.transform.localPosition.x, Mathf.Lerp(this.Gallery.transform.localPosition.y, 0.0f, Time.deltaTime * 10f), this.Gallery.transform.localPosition.z);
  }

  private void UpdatePhotoViewing()
  {
    this.ViewPhoto.transform.localScale = Vector3.Lerp(this.ViewPhoto.transform.localScale, this.Corkboard ? new Vector3(5.8f, 5.8f, 5.8f) : new Vector3(6.5f, 6.5f, 6.5f), this.LerpSpeed);
    this.ViewPhoto.transform.localPosition = Vector3.Lerp(this.ViewPhoto.transform.localPosition, Vector3.zero, this.LerpSpeed);
    if ((!this.Corkboard ? 0 : (Input.GetButtonDown("A") ? 1 : 0)) != 0)
    {
      GameObject gameObject = Object.Instantiate<GameObject>(this.Photograph, this.transform.position, Quaternion.identity);
      gameObject.transform.parent = this.CorkboardPanel;
      gameObject.transform.localEulerAngles = Vector3.zero;
      gameObject.transform.localPosition = Vector3.zero;
      gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
      gameObject.GetComponent<UITexture>().mainTexture = this.Photographs[this.CurrentIndex].mainTexture;
      this.MovingPhotograph = gameObject;
      this.CanAdjust = false;
      this.Adjusting = true;
      this.Viewing = false;
      this.Moving = true;
      this.CorkboardPhotographs[this.Photos] = gameObject.GetComponent<HomeCorkboardPhotoScript>();
      this.CorkboardPhotographs[this.Photos].ID = this.CurrentIndex;
      this.CorkboardPhotographs[this.Photos].ArrayID = this.Photos;
      ++this.Photos;
      this.UpdateButtonPrompts();
    }
    if (!Input.GetButtonDown("B"))
      return;
    this.Viewing = false;
    if (this.Corkboard)
    {
      this.HomeCursor.Highlight.transform.position = new Vector3(this.HomeCursor.Highlight.transform.position.x, 100f, this.HomeCursor.Highlight.transform.position.z);
      this.CanAdjust = true;
    }
    else
    {
      for (int photoID = 1; photoID < 26; ++photoID)
      {
        if (PlayerGlobals.GetSenpaiPhoto(photoID))
        {
          this.Hearts[photoID].gameObject.SetActive(true);
          this.CanAdjust = true;
        }
      }
    }
    this.UpdateButtonPrompts();
  }

  private void UpdateCorkboardPhoto()
  {
    Cursor.lockState = CursorLockMode.None;
    if (Input.GetMouseButton(1))
      this.MovingPhotoRotation += this.MouseDelta.x;
    else
      this.MovingPhotograph.transform.localPosition = new Vector3(this.MovingPhotograph.transform.localPosition.x + this.MouseDelta.x * 8.66666f, this.MovingPhotograph.transform.localPosition.y + this.MouseDelta.y * 8.66666f, 0.0f);
    if (Input.GetButton("LB"))
      this.MovingPhotoRotation += Time.deltaTime * 100f;
    if (Input.GetButton("RB"))
      this.MovingPhotoRotation -= Time.deltaTime * 100f;
    if (Input.GetButton("Y"))
    {
      this.MovingPhotograph.transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
      if ((double) this.MovingPhotograph.transform.localScale.x > 2.0)
        this.MovingPhotograph.transform.localScale = new Vector3(2f, 2f, 2f);
    }
    if (Input.GetButton("X"))
    {
      this.MovingPhotograph.transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
      if ((double) this.MovingPhotograph.transform.localScale.x < 1.0)
        this.MovingPhotograph.transform.localScale = new Vector3(1f, 1f, 1f);
    }
    Vector2 vector2_1 = new Vector2(this.MovingPhotograph.transform.localPosition.x, this.MovingPhotograph.transform.localPosition.y);
    Vector2 vector2_2 = new Vector2(Input.GetAxis("Horizontal") * 86.66666f * this.SpeedLimit, Input.GetAxis("Vertical") * 86.66666f * this.SpeedLimit);
    this.MovingPhotograph.transform.localPosition = new Vector3(Mathf.Clamp(vector2_1.x + vector2_2.x, -this.MaxPhotoX, this.MaxPhotoX), Mathf.Clamp(vector2_1.y + vector2_2.y, -this.MaxPhotoY, this.MaxPhotoY), this.MovingPhotograph.transform.localPosition.z);
    if (!Input.GetButtonDown("A"))
      return;
    this.HomeCursor.transform.localPosition = this.MovingPhotograph.transform.localPosition;
    this.HomeCursor.gameObject.SetActive(true);
    this.Moving = false;
    this.UpdateButtonPrompts();
    ++this.PhotoID;
  }

  private void UpdateString()
  {
    this.MouseDelta.x += Input.GetAxis("Horizontal") * 8.66666f * this.SpeedLimit;
    this.MouseDelta.y += Input.GetAxis("Vertical") * 8.66666f * this.SpeedLimit;
    Transform transform;
    if (this.StringPhase == 0)
    {
      transform = this.String.Origin;
      this.String.Target.position = this.String.Origin.position;
    }
    else
      transform = this.String.Target;
    transform.localPosition = new Vector3(transform.localPosition.x - (float) ((double) this.MouseDelta.x * (double) Time.deltaTime * 0.333330005407333), transform.localPosition.y + (float) ((double) this.MouseDelta.y * (double) Time.deltaTime * 0.333330005407333), 0.0f);
    if ((double) transform.localPosition.x > 0.971000015735626)
      transform.localPosition = new Vector3(0.971f, transform.localPosition.y, transform.localPosition.z);
    else if ((double) transform.localPosition.x < -0.971000015735626)
      transform.localPosition = new Vector3(-0.971f, transform.localPosition.y, transform.localPosition.z);
    if ((double) transform.localPosition.y > 0.637000024318695)
      transform.localPosition = new Vector3(transform.localPosition.x, 0.637f, transform.localPosition.z);
    else if ((double) transform.localPosition.y < -0.637000024318695)
      transform.localPosition = new Vector3(transform.localPosition.x, -0.637f, transform.localPosition.z);
    if (!Input.GetButtonDown("A"))
      return;
    if (this.StringPhase == 0)
    {
      ++this.StringPhase;
    }
    else
    {
      if (this.StringPhase != 1)
        return;
      this.HomeCursor.transform.localPosition = transform.localPosition;
      this.HomeCursor.gameObject.SetActive(true);
      this.MovingString = false;
      this.StringPhase = 0;
      this.UpdateButtonPrompts();
    }
  }

  private void UpdateCorkboardCursor()
  {
    Vector2 vector2_1 = new Vector2(this.HomeCursor.transform.localPosition.x, this.HomeCursor.transform.localPosition.y);
    Vector2 vector2_2 = new Vector2((float) ((double) this.MouseDelta.x * 8.66666030883789 + (double) Input.GetAxis("Horizontal") * 8.66666030883789 * (double) this.SpeedLimit), (float) ((double) this.MouseDelta.y * 8.66666030883789 + (double) Input.GetAxis("Vertical") * 8.66666030883789 * (double) this.SpeedLimit)) * 5f;
    this.HomeCursor.transform.localPosition = new Vector3(Mathf.Clamp(vector2_1.x + vector2_2.x, -4788f, 4788f), Mathf.Clamp(vector2_1.y + vector2_2.y, -3122f, 3122f), this.HomeCursor.transform.localPosition.z);
    if (Input.GetButtonDown("A") && (Object) this.HomeCursor.Photograph != (Object) null)
    {
      this.HomeCursor.Highlight.transform.position = new Vector3(this.HomeCursor.Highlight.transform.position.x, 100f, this.HomeCursor.Highlight.transform.position.z);
      this.MovingPhotograph = this.HomeCursor.Photograph;
      this.HomeCursor.gameObject.SetActive(false);
      this.Moving = true;
      this.UpdateButtonPrompts();
    }
    if (Input.GetButtonDown("Y"))
    {
      GameObject gameObject = Object.Instantiate<GameObject>(this.StringSet, this.transform.position, Quaternion.identity);
      gameObject.transform.parent = this.StringParent;
      gameObject.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
      gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
      this.String = gameObject.GetComponent<StringScript>();
      this.HomeCursor.gameObject.SetActive(false);
      this.MovingString = true;
      this.CorkboardStrings[this.Strings] = this.String.GetComponent<StringScript>();
      this.CorkboardStrings[this.Strings].ArrayID = this.Strings;
      ++this.Strings;
      this.UpdateButtonPrompts();
    }
    if (Input.GetButtonDown("B"))
    {
      if ((Object) this.HomeCursor.Photograph != (Object) null)
        this.HomeCursor.Photograph = (GameObject) null;
      this.HomeCursor.transform.localPosition = new Vector3(0.0f, 0.0f, this.HomeCursor.transform.localPosition.z);
      this.HomeCursor.Highlight.transform.position = new Vector3(this.HomeCursor.Highlight.transform.position.x, 100f, this.HomeCursor.Highlight.transform.position.z);
      this.CanAdjust = true;
      this.HomeCursor.gameObject.SetActive(false);
      this.Adjusting = false;
      this.UpdateButtonPrompts();
    }
    if (!Input.GetButtonDown("X"))
      return;
    if ((Object) this.HomeCursor.Photograph != (Object) null)
    {
      this.HomeCursor.Highlight.transform.position = new Vector3(this.HomeCursor.Highlight.transform.position.x, 100f, this.HomeCursor.Highlight.transform.position.z);
      this.Shuffle(this.HomeCursor.Photograph.GetComponent<HomeCorkboardPhotoScript>().ArrayID);
      Object.Destroy((Object) this.HomeCursor.Photograph);
      --this.Photos;
      this.HomeCursor.Photograph = (GameObject) null;
      this.UpdateButtonPrompts();
    }
    if (!((Object) this.HomeCursor.Tack != (Object) null))
      return;
    this.HomeCursor.CircleHighlight.transform.position = new Vector3(this.HomeCursor.CircleHighlight.transform.position.x, 100f, this.HomeCursor.CircleHighlight.transform.position.z);
    this.ShuffleStrings(this.HomeCursor.Tack.transform.parent.GetComponent<StringScript>().ArrayID);
    Object.Destroy((Object) this.HomeCursor.Tack.transform.parent.gameObject);
    --this.Strings;
    this.HomeCursor.Tack = (GameObject) null;
    this.UpdateButtonPrompts();
  }

  private void Update()
  {
    if (this.GotPhotos && this.Corkboard && !this.SpawnedPhotos)
    {
      this.SpawnPhotographs();
      this.SpawnStrings();
      this.enabled = false;
      this.gameObject.SetActive(false);
      this.PromptBar.Label[0].text = string.Empty;
      this.PromptBar.Label[1].text = string.Empty;
      this.PromptBar.Label[2].text = string.Empty;
      this.PromptBar.Label[3].text = string.Empty;
      this.PromptBar.Label[4].text = string.Empty;
      this.PromptBar.Label[5].text = string.Empty;
      this.PromptBar.UpdateButtons();
      this.PromptBar.Show = false;
    }
    if (!this.Adjusting)
    {
      if (!this.Viewing)
        this.UpdatePhotoSelection();
      else
        this.UpdatePhotoViewing();
    }
    else
    {
      if (this.Corkboard)
        this.Gallery.transform.localPosition = new Vector3(this.Gallery.transform.localPosition.x, Mathf.Lerp(this.Gallery.transform.localPosition.y, 1000f, Time.deltaTime * 10f), this.Gallery.transform.localPosition.z);
      this.MouseDelta = new Vector2(Input.mousePosition.x - this.PreviousPosition.x, Input.mousePosition.y - this.PreviousPosition.y);
      this.SpeedLimit = this.InputDevice.Type != InputDeviceType.MouseAndKeyboard ? 1f : 0.1f;
      if (this.Moving)
        this.UpdateCorkboardPhoto();
      else if (this.MovingString)
        this.UpdateString();
      else
        this.UpdateCorkboardCursor();
    }
    this.PreviousPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
  }

  public IEnumerator GetPhotos()
  {
    PhotoGalleryScript photoGalleryScript = this;
    if (!photoGalleryScript.Corkboard)
    {
      for (int index = 1; index < 26; ++index)
        photoGalleryScript.Hearts[index].gameObject.SetActive(false);
    }
    for (int ID = 1; ID < 26; ++ID)
    {
      if (PlayerGlobals.GetPhoto(ID))
      {
        WWW www = new WWW("file:///" + Application.streamingAssetsPath + "/Photographs/Photo_" + ID.ToString() + ".png");
        yield return (object) www;
        if (www.error == null)
        {
          photoGalleryScript.Photographs[ID].mainTexture = (Texture) www.texture;
          if (!photoGalleryScript.Corkboard && PlayerGlobals.GetSenpaiPhoto(ID))
            photoGalleryScript.Hearts[ID].gameObject.SetActive(true);
        }
        else
        {
          Debug.Log((object) ("Could not retrieve Photo " + ID.ToString() + ". Maybe it was deleted from Streaming Assets? Setting Photo " + ID.ToString() + " to ''false''."));
          PlayerGlobals.SetPhoto(ID, false);
        }
        www = (WWW) null;
      }
    }
    photoGalleryScript.LoadingScreen.SetActive(false);
    if (!photoGalleryScript.Corkboard)
      photoGalleryScript.PauseScreen.Sideways = true;
    photoGalleryScript.UpdateButtonPrompts();
    photoGalleryScript.enabled = true;
    photoGalleryScript.gameObject.SetActive(true);
    photoGalleryScript.GotPhotos = true;
  }

  public void UpdateButtonPrompts()
  {
    if (this.NamingBully)
    {
      this.PromptBar.Label[0].text = !((Object) this.Photographs[this.CurrentIndex].mainTexture != (Object) this.NoPhoto) || PlayerGlobals.GetBullyPhoto(this.CurrentIndex) <= 0 ? string.Empty : (PlayerGlobals.GetBullyPhoto(this.CurrentIndex) <= 0 ? string.Empty : "Name Bully");
      this.PromptBar.Label[1].text = string.Empty;
      this.PromptBar.Label[2].text = string.Empty;
      this.PromptBar.Label[3].text = string.Empty;
      this.PromptBar.Label[4].text = "Move";
      this.PromptBar.Label[5].text = "Move";
    }
    else if (this.Moving || this.MovingString)
    {
      this.PromptBar.Label[0].text = "Place";
      this.PromptBar.Label[1].text = string.Empty;
      this.PromptBar.Label[2].text = string.Empty;
      this.PromptBar.Label[3].text = string.Empty;
      this.PromptBar.Label[4].text = "Move";
      this.PromptBar.Label[5].text = "Move";
      if (!this.MovingString)
      {
        this.PromptBar.Label[2].text = "Resize";
        this.PromptBar.Label[3].text = "Resize";
      }
    }
    else if (this.Adjusting)
    {
      if ((Object) this.HomeCursor.Photograph != (Object) null)
      {
        this.PromptBar.Label[0].text = "Adjust";
        this.PromptBar.Label[1].text = string.Empty;
        this.PromptBar.Label[2].text = "Remove";
        this.PromptBar.Label[3].text = string.Empty;
      }
      else if ((Object) this.HomeCursor.Tack != (Object) null)
      {
        this.PromptBar.Label[2].text = "Remove";
      }
      else
      {
        this.PromptBar.Label[0].text = string.Empty;
        this.PromptBar.Label[2].text = string.Empty;
      }
      this.PromptBar.Label[1].text = "Back";
      this.PromptBar.Label[3].text = "Place Pin";
      this.PromptBar.Label[4].text = "Move";
      this.PromptBar.Label[5].text = "Move";
    }
    else if (!this.Viewing)
    {
      int currentIndex = this.CurrentIndex;
      if ((Object) this.Photographs[currentIndex].mainTexture != (Object) this.NoPhoto)
      {
        this.PromptBar.Label[0].text = "View";
        this.PromptBar.Label[2].text = "Delete";
      }
      else
      {
        this.PromptBar.Label[0].text = string.Empty;
        this.PromptBar.Label[2].text = string.Empty;
      }
      this.PromptBar.Label[3].text = this.Corkboard ? "Corkboard" : (PlayerGlobals.GetSenpaiPhoto(currentIndex) ? "Use" : string.Empty);
      this.PromptBar.Label[1].text = "Back";
      this.PromptBar.Label[4].text = "Choose";
      this.PromptBar.Label[5].text = "Choose";
    }
    else
    {
      this.PromptBar.Label[0].text = !this.Corkboard ? string.Empty : "Place";
      this.PromptBar.Label[2].text = string.Empty;
      this.PromptBar.Label[3].text = string.Empty;
      this.PromptBar.Label[4].text = string.Empty;
      this.PromptBar.Label[5].text = string.Empty;
    }
    this.PromptBar.UpdateButtons();
    this.PromptBar.Show = true;
  }

  private void Shuffle(int Start)
  {
    for (int index = Start; index < this.CorkboardPhotographs.Length - 1; ++index)
    {
      if ((Object) this.CorkboardPhotographs[index] != (Object) null)
      {
        --this.CorkboardPhotographs[index].ArrayID;
        this.CorkboardPhotographs[index] = this.CorkboardPhotographs[index + 1];
      }
    }
  }

  private void ShuffleStrings(int Start)
  {
    for (int index = Start; index < this.CorkboardPhotographs.Length - 1; ++index)
    {
      if ((Object) this.CorkboardStrings[index] != (Object) null)
      {
        --this.CorkboardStrings[index].ArrayID;
        this.CorkboardStrings[index] = this.CorkboardStrings[index + 1];
      }
    }
  }

  public void SaveAllPhotographs()
  {
    int profile;
    for (int index = 0; index < 100; ++index)
    {
      if ((Object) this.CorkboardPhotographs[index] != (Object) null)
      {
        string[] strArray1 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        profile = GameGlobals.Profile;
        strArray1[1] = profile.ToString();
        strArray1[2] = "_CorkboardPhoto_";
        strArray1[3] = index.ToString();
        strArray1[4] = "_Exists";
        PlayerPrefs.SetInt(string.Concat(strArray1), 1);
        string[] strArray2 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        profile = GameGlobals.Profile;
        strArray2[1] = profile.ToString();
        strArray2[2] = "_CorkboardPhoto_";
        strArray2[3] = index.ToString();
        strArray2[4] = "_PhotoID";
        PlayerPrefs.SetInt(string.Concat(strArray2), this.CorkboardPhotographs[index].ID);
        string[] strArray3 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        profile = GameGlobals.Profile;
        strArray3[1] = profile.ToString();
        strArray3[2] = "_CorkboardPhoto_";
        strArray3[3] = index.ToString();
        strArray3[4] = "_PositionX";
        PlayerPrefs.SetFloat(string.Concat(strArray3), this.CorkboardPhotographs[index].transform.localPosition.x);
        string[] strArray4 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        profile = GameGlobals.Profile;
        strArray4[1] = profile.ToString();
        strArray4[2] = "_CorkboardPhoto_";
        strArray4[3] = index.ToString();
        strArray4[4] = "_PositionY";
        PlayerPrefs.SetFloat(string.Concat(strArray4), this.CorkboardPhotographs[index].transform.localPosition.y);
        string[] strArray5 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        profile = GameGlobals.Profile;
        strArray5[1] = profile.ToString();
        strArray5[2] = "_CorkboardPhoto_";
        strArray5[3] = index.ToString();
        strArray5[4] = "_PositionZ";
        PlayerPrefs.SetFloat(string.Concat(strArray5), this.CorkboardPhotographs[index].transform.localPosition.z);
        string[] strArray6 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        profile = GameGlobals.Profile;
        strArray6[1] = profile.ToString();
        strArray6[2] = "_CorkboardPhoto_";
        strArray6[3] = index.ToString();
        strArray6[4] = "_RotationX";
        PlayerPrefs.SetFloat(string.Concat(strArray6), this.CorkboardPhotographs[index].transform.localEulerAngles.x);
        string[] strArray7 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        profile = GameGlobals.Profile;
        strArray7[1] = profile.ToString();
        strArray7[2] = "_CorkboardPhoto_";
        strArray7[3] = index.ToString();
        strArray7[4] = "_RotationY";
        PlayerPrefs.SetFloat(string.Concat(strArray7), this.CorkboardPhotographs[index].transform.localEulerAngles.y);
        string[] strArray8 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        profile = GameGlobals.Profile;
        strArray8[1] = profile.ToString();
        strArray8[2] = "_CorkboardPhoto_";
        strArray8[3] = index.ToString();
        strArray8[4] = "_RotationZ";
        PlayerPrefs.SetFloat(string.Concat(strArray8), this.CorkboardPhotographs[index].transform.localEulerAngles.z);
        string[] strArray9 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        profile = GameGlobals.Profile;
        strArray9[1] = profile.ToString();
        strArray9[2] = "_CorkboardPhoto_";
        strArray9[3] = index.ToString();
        strArray9[4] = "_ScaleX";
        PlayerPrefs.SetFloat(string.Concat(strArray9), this.CorkboardPhotographs[index].transform.localScale.x);
        string[] strArray10 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        profile = GameGlobals.Profile;
        strArray10[1] = profile.ToString();
        strArray10[2] = "_CorkboardPhoto_";
        strArray10[3] = index.ToString();
        strArray10[4] = "_ScaleY";
        PlayerPrefs.SetFloat(string.Concat(strArray10), this.CorkboardPhotographs[index].transform.localScale.y);
        string[] strArray11 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        profile = GameGlobals.Profile;
        strArray11[1] = profile.ToString();
        strArray11[2] = "_CorkboardPhoto_";
        strArray11[3] = index.ToString();
        strArray11[4] = "_ScaleZ";
        PlayerPrefs.SetFloat(string.Concat(strArray11), this.CorkboardPhotographs[index].transform.localScale.z);
      }
      else
      {
        string[] strArray = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        profile = GameGlobals.Profile;
        strArray[1] = profile.ToString();
        strArray[2] = "_CorkboardPhoto_";
        strArray[3] = index.ToString();
        strArray[4] = "_Exists";
        PlayerPrefs.SetInt(string.Concat(strArray), 0);
      }
    }
  }

  public void SpawnPhotographs()
  {
    for (int index1 = 0; index1 < 100; ++index1)
    {
      if (PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardPhoto_" + index1.ToString() + "_Exists") == 1)
      {
        GameObject gameObject = Object.Instantiate<GameObject>(this.Photograph, this.transform.position, Quaternion.identity);
        gameObject.transform.parent = this.CorkboardPanel;
        Transform transform1 = gameObject.transform;
        double x1 = (double) PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardPhoto_" + index1.ToString() + "_PositionX");
        string[] strArray1 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        int profile1 = GameGlobals.Profile;
        strArray1[1] = profile1.ToString();
        strArray1[2] = "_CorkboardPhoto_";
        strArray1[3] = index1.ToString();
        strArray1[4] = "_PositionY";
        double y1 = (double) PlayerPrefs.GetFloat(string.Concat(strArray1));
        string[] strArray2 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        profile1 = GameGlobals.Profile;
        strArray2[1] = profile1.ToString();
        strArray2[2] = "_CorkboardPhoto_";
        strArray2[3] = index1.ToString();
        strArray2[4] = "_PositionZ";
        double z1 = (double) PlayerPrefs.GetFloat(string.Concat(strArray2));
        Vector3 vector3_1 = new Vector3((float) x1, (float) y1, (float) z1);
        transform1.localPosition = vector3_1;
        Transform transform2 = gameObject.transform;
        string[] strArray3 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        profile1 = GameGlobals.Profile;
        strArray3[1] = profile1.ToString();
        strArray3[2] = "_CorkboardPhoto_";
        strArray3[3] = index1.ToString();
        strArray3[4] = "_RotationX";
        double x2 = (double) PlayerPrefs.GetFloat(string.Concat(strArray3));
        string[] strArray4 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        int profile2 = GameGlobals.Profile;
        strArray4[1] = profile2.ToString();
        strArray4[2] = "_CorkboardPhoto_";
        strArray4[3] = index1.ToString();
        strArray4[4] = "_RotationY";
        double y2 = (double) PlayerPrefs.GetFloat(string.Concat(strArray4));
        string[] strArray5 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        profile2 = GameGlobals.Profile;
        strArray5[1] = profile2.ToString();
        strArray5[2] = "_CorkboardPhoto_";
        strArray5[3] = index1.ToString();
        strArray5[4] = "_RotationZ";
        double z2 = (double) PlayerPrefs.GetFloat(string.Concat(strArray5));
        Vector3 vector3_2 = new Vector3((float) x2, (float) y2, (float) z2);
        transform2.localEulerAngles = vector3_2;
        Transform transform3 = gameObject.transform;
        string[] strArray6 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        profile2 = GameGlobals.Profile;
        strArray6[1] = profile2.ToString();
        strArray6[2] = "_CorkboardPhoto_";
        strArray6[3] = index1.ToString();
        strArray6[4] = "_ScaleX";
        double x3 = (double) PlayerPrefs.GetFloat(string.Concat(strArray6));
        string[] strArray7 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        int profile3 = GameGlobals.Profile;
        strArray7[1] = profile3.ToString();
        strArray7[2] = "_CorkboardPhoto_";
        strArray7[3] = index1.ToString();
        strArray7[4] = "_ScaleY";
        double y3 = (double) PlayerPrefs.GetFloat(string.Concat(strArray7));
        string[] strArray8 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        profile3 = GameGlobals.Profile;
        strArray8[1] = profile3.ToString();
        strArray8[2] = "_CorkboardPhoto_";
        strArray8[3] = index1.ToString();
        strArray8[4] = "_ScaleZ";
        double z3 = (double) PlayerPrefs.GetFloat(string.Concat(strArray8));
        Vector3 vector3_3 = new Vector3((float) x3, (float) y3, (float) z3);
        transform3.localScale = vector3_3;
        UITexture component = gameObject.GetComponent<UITexture>();
        UITexture[] photographs = this.Photographs;
        string[] strArray9 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        profile3 = GameGlobals.Profile;
        strArray9[1] = profile3.ToString();
        strArray9[2] = "_CorkboardPhoto_";
        strArray9[3] = index1.ToString();
        strArray9[4] = "_PhotoID";
        int index2 = PlayerPrefs.GetInt(string.Concat(strArray9));
        Texture mainTexture = photographs[index2].mainTexture;
        component.mainTexture = mainTexture;
        this.CorkboardPhotographs[this.Photos] = gameObject.GetComponent<HomeCorkboardPhotoScript>();
        this.CorkboardPhotographs[this.Photos].ID = PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardPhoto_" + index1.ToString() + "_PhotoID");
        this.CorkboardPhotographs[this.Photos].ArrayID = this.Photos;
        ++this.Photos;
      }
    }
    this.SpawnedPhotos = true;
  }

  public void SaveAllStrings()
  {
    Debug.Log((object) "Saved strings.");
    for (int index = 0; index < 100; ++index)
    {
      if ((Object) this.CorkboardStrings[index] != (Object) null)
      {
        Debug.Log((object) ("Now saving the data for StringSet #" + index.ToString()));
        PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardString_" + index.ToString() + "_Exists", 1);
        PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardString_" + index.ToString() + "_PositionX", this.CorkboardStrings[index].Origin.localPosition.x);
        PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardString_" + index.ToString() + "_PositionY", this.CorkboardStrings[index].Origin.localPosition.y);
        PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardString_" + index.ToString() + "_PositionZ", this.CorkboardStrings[index].Origin.localPosition.z);
        PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardString2_" + index.ToString() + "_PositionX", this.CorkboardStrings[index].Target.localPosition.x);
        PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardString2_" + index.ToString() + "_PositionY", this.CorkboardStrings[index].Target.localPosition.y);
        PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardString2_" + index.ToString() + "_PositionZ", this.CorkboardStrings[index].Target.localPosition.z);
        Debug.Log((object) ("Saved Origin should be " + this.CorkboardStrings[index].Origin.localPosition.ToString()));
        Debug.Log((object) ("Saved Target should be " + this.CorkboardStrings[index].Target.localPosition.ToString()));
      }
      else
        PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardString_" + index.ToString() + "_Exists", 0);
    }
  }

  public void SpawnStrings()
  {
    for (int index = 0; index < 100; ++index)
    {
      if (PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardString_" + index.ToString() + "_Exists") == 1)
      {
        Debug.Log((object) ("Now loading the data for StringSet #" + index.ToString()));
        GameObject gameObject = Object.Instantiate<GameObject>(this.StringSet, this.transform.position, Quaternion.identity);
        gameObject.transform.parent = this.StringParent;
        gameObject.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        this.String = gameObject.GetComponent<StringScript>();
        Transform origin = this.String.Origin;
        double x1 = (double) PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardString_" + index.ToString() + "_PositionX");
        string[] strArray1 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        int profile1 = GameGlobals.Profile;
        strArray1[1] = profile1.ToString();
        strArray1[2] = "_CorkboardString_";
        strArray1[3] = index.ToString();
        strArray1[4] = "_PositionY";
        double y1 = (double) PlayerPrefs.GetFloat(string.Concat(strArray1));
        string[] strArray2 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        profile1 = GameGlobals.Profile;
        strArray2[1] = profile1.ToString();
        strArray2[2] = "_CorkboardString_";
        strArray2[3] = index.ToString();
        strArray2[4] = "_PositionZ";
        double z1 = (double) PlayerPrefs.GetFloat(string.Concat(strArray2));
        Vector3 vector3_1 = new Vector3((float) x1, (float) y1, (float) z1);
        origin.localPosition = vector3_1;
        Transform target = this.String.Target;
        string[] strArray3 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        profile1 = GameGlobals.Profile;
        strArray3[1] = profile1.ToString();
        strArray3[2] = "_CorkboardString2_";
        strArray3[3] = index.ToString();
        strArray3[4] = "_PositionX";
        double x2 = (double) PlayerPrefs.GetFloat(string.Concat(strArray3));
        string[] strArray4 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        int profile2 = GameGlobals.Profile;
        strArray4[1] = profile2.ToString();
        strArray4[2] = "_CorkboardString2_";
        strArray4[3] = index.ToString();
        strArray4[4] = "_PositionY";
        double y2 = (double) PlayerPrefs.GetFloat(string.Concat(strArray4));
        string[] strArray5 = new string[5]
        {
          "Profile_",
          null,
          null,
          null,
          null
        };
        profile2 = GameGlobals.Profile;
        strArray5[1] = profile2.ToString();
        strArray5[2] = "_CorkboardString2_";
        strArray5[3] = index.ToString();
        strArray5[4] = "_PositionZ";
        double z2 = (double) PlayerPrefs.GetFloat(string.Concat(strArray5));
        Vector3 vector3_2 = new Vector3((float) x2, (float) y2, (float) z2);
        target.localPosition = vector3_2;
        Debug.Log((object) ("Loaded Origin should be " + this.String.Origin.localPosition.ToString()));
        Debug.Log((object) ("Loaded Target should be " + this.String.Target.localPosition.ToString()));
        this.CorkboardStrings[this.Strings] = this.String.GetComponent<StringScript>();
        this.CorkboardStrings[this.Strings].ArrayID = this.Strings;
        ++this.Strings;
      }
      else
        PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardString_" + index.ToString() + "_Exists", 0);
    }
  }
}
