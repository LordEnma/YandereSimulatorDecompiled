// Decompiled with JetBrains decompiler
// Type: MapScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MapScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public InputDeviceScript InputDevice;
  public PauseScreenScript PauseScreen;
  public PromptBarScript PromptBar;
  public YandereScript Yandere;
  public GameObject Compass;
  public Transform YandereMapMarker;
  public Transform PortalMapMarker;
  public UILabel ElevationLabel;
  public UISprite Border;
  public Camera MyCamera;
  public float HorizontalLimit;
  public float VerticalLimit;
  public float X;
  public float Y;
  public float W;
  public float H;
  public bool Show;
  public Texture RyobaFace;
  public UILabel[] Labels;

  private void Start()
  {
    if (GameGlobals.Eighties)
    {
      this.YandereMapMarker.GetComponent<Renderer>().material.mainTexture = this.RyobaFace;
      this.Labels[0].text = "Newspaper Club";
      if (DateGlobals.Week > 10)
        this.gameObject.SetActive(false);
    }
    this.DisableCamera();
    this.X = 0.5f;
    this.Y = 0.5f;
  }

  private void Update()
  {
    if (Input.GetButtonDown("Back") && this.Yandere.CanMove && !this.Yandere.StudentManager.TutorialWindow.Show && (double) this.Yandere.Police.Darkness.color.a <= 0.0)
    {
      if (!this.Show)
      {
        if (!this.PauseScreen.Show)
        {
          this.PauseScreen.Show = true;
          this.Yandere.RPGCamera.enabled = false;
          this.ElevationLabel.enabled = true;
          this.Yandere.Blur.enabled = true;
          this.MyCamera.enabled = true;
          this.Compass.SetActive(true);
          Time.timeScale = 1f / 1000f;
          this.PromptBar.ClearButtons();
          this.PromptBar.Label[1].text = "Exit";
          this.PromptBar.Label[2].text = "Lower Floor";
          this.PromptBar.Label[3].text = "Higher Floor";
          this.PromptBar.UpdateButtons();
          this.PromptBar.Show = true;
          this.Show = true;
        }
      }
      else
      {
        this.Yandere.RPGCamera.enabled = true;
        this.ElevationLabel.enabled = false;
        this.Yandere.Blur.enabled = false;
        this.PauseScreen.Show = false;
        this.Compass.SetActive(false);
        Time.timeScale = 1f;
        this.PromptBar.ClearButtons();
        this.PromptBar.Show = false;
        this.Show = false;
      }
    }
    if (this.Show)
    {
      this.Border.transform.localScale = Vector3.Lerp(this.Border.transform.localScale, new Vector3(1.3f, 1.315f, 1.3f), Time.unscaledDeltaTime * 10f);
      this.X = Mathf.Lerp(this.X, 0.1f, Time.unscaledDeltaTime * 10f);
      this.Y = Mathf.Lerp(this.Y, 0.1f, Time.unscaledDeltaTime * 10f);
      this.W = Mathf.Lerp(this.W, 0.8f, Time.unscaledDeltaTime * 10f);
      this.H = Mathf.Lerp(this.H, 0.8f, Time.unscaledDeltaTime * 10f);
      this.MyCamera.rect = new Rect(this.X, this.Y, this.W, this.H);
      if ((double) this.Border.transform.localScale.x <= 1.20000004768372)
        return;
      if (this.InputDevice.Type == InputDeviceType.MouseAndKeyboard)
      {
        float axis = Input.GetAxis("Mouse Y");
        this.transform.position += new Vector3((float) ((double) Input.GetAxis("Mouse X") * (double) Time.unscaledDeltaTime * 50.0), 0.0f, (float) ((double) axis * (double) Time.unscaledDeltaTime * 50.0));
        this.MyCamera.orthographicSize -= (float) ((double) Input.GetAxis("Mouse ScrollWheel") * (double) Time.unscaledDeltaTime * 1000.0);
      }
      else
      {
        float axis = Input.GetAxis("Vertical");
        this.transform.position += new Vector3((float) ((double) Input.GetAxis("Horizontal") * (double) Time.unscaledDeltaTime * 100.0), 0.0f, (float) ((double) axis * (double) Time.unscaledDeltaTime * 100.0));
        this.MyCamera.orthographicSize -= (float) ((double) Input.GetAxis("Mouse Y") * (double) Time.unscaledDeltaTime * 100.0);
      }
      if ((double) this.MyCamera.orthographicSize < 4.0)
        this.MyCamera.orthographicSize = 4f;
      if ((double) this.MyCamera.orthographicSize > 40.75)
        this.MyCamera.orthographicSize = 40.75f;
      if (Input.GetButtonDown("X"))
      {
        this.transform.position += new Vector3(0.0f, -4f, 0.0f);
        if ((double) this.transform.position.y < 3.0)
          this.transform.position = new Vector3(this.transform.position.x, 3f, this.transform.position.z);
      }
      if (Input.GetButtonDown("Y"))
      {
        this.transform.position += new Vector3(0.0f, 4f, 0.0f);
        if ((double) this.transform.position.y > 15.0)
          this.transform.position = new Vector3(this.transform.position.x, 15f, this.transform.position.z);
      }
      if ((double) this.transform.position.y == 3.0)
        this.ElevationLabel.text = "Floor 1";
      else if ((double) this.transform.position.y == 7.0)
        this.ElevationLabel.text = "Floor 2";
      else if ((double) this.transform.position.y == 11.0)
        this.ElevationLabel.text = "Floor 3";
      else if ((double) this.transform.position.y == 15.0)
        this.ElevationLabel.text = "The Rooftop";
      this.HorizontalLimit = (float) (70.7200012207031 - (double) this.MyCamera.orthographicSize / 40.75 * 70.7200012207031);
      if ((double) this.transform.position.x > (double) this.HorizontalLimit)
        this.transform.position = new Vector3(this.HorizontalLimit, this.transform.position.y, this.transform.position.z);
      if ((double) this.transform.position.x < (double) this.HorizontalLimit * -1.0)
        this.transform.position = new Vector3(this.HorizontalLimit * -1f, this.transform.position.y, this.transform.position.z);
      this.VerticalLimit = (float) (102.0 - (double) this.MyCamera.orthographicSize / 40.75);
      if ((double) this.transform.position.z > (double) this.VerticalLimit)
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.VerticalLimit);
      if ((double) this.transform.position.z < (double) this.VerticalLimit * -1.0)
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.VerticalLimit * -1f);
      this.YandereMapMarker.localScale = new Vector3((float) ((double) this.MyCamera.orthographicSize / 40.75 * 10.0), (float) ((double) this.MyCamera.orthographicSize / 40.75 * 10.0), (float) ((double) this.MyCamera.orthographicSize / 40.75 * 10.0));
      this.PortalMapMarker.localScale = new Vector3((float) ((double) this.MyCamera.orthographicSize / 40.75 * 10.0), (float) ((double) this.MyCamera.orthographicSize / 40.75 * 10.0), (float) ((double) this.MyCamera.orthographicSize / 40.75 * 10.0));
      if ((Object) this.StudentManager.Students[1] != (Object) null)
      {
        this.StudentManager.Students[1].MapMarker.localScale = new Vector3((float) ((double) this.MyCamera.orthographicSize / 40.75 * 10.0), (float) ((double) this.MyCamera.orthographicSize / 40.75 * 10.0), (float) ((double) this.MyCamera.orthographicSize / 40.75 * 10.0));
        this.StudentManager.Students[1].MapMarker.eulerAngles = new Vector3(90f, 0.0f, 0.0f);
      }
      if (!Input.GetButtonDown("B"))
        return;
      this.ElevationLabel.enabled = false;
      this.Compass.SetActive(false);
      this.PauseScreen.Show = false;
      this.Yandere.Blur.enabled = false;
      Time.timeScale = 1f;
      this.PromptBar.ClearButtons();
      this.PromptBar.Show = false;
      this.Yandere.RPGCamera.enabled = true;
      this.Show = false;
    }
    else
    {
      if (!this.MyCamera.enabled)
        return;
      this.Border.transform.localScale = Vector3.Lerp(this.Border.transform.localScale, new Vector3(0.0f, 0.0f, 0.0f), Time.unscaledDeltaTime * 10f);
      this.X = Mathf.Lerp(this.X, 0.5f, Time.unscaledDeltaTime * 10f);
      this.Y = Mathf.Lerp(this.Y, 0.5f, Time.unscaledDeltaTime * 10f);
      this.W = Mathf.Lerp(this.W, 0.0f, Time.unscaledDeltaTime * 10f);
      this.H = Mathf.Lerp(this.H, 0.0f, Time.unscaledDeltaTime * 10f);
      this.MyCamera.rect = new Rect(this.X, this.Y, this.W, this.H);
      if ((double) this.W >= 0.00999999977648258)
        return;
      this.DisableCamera();
    }
  }

  private void DisableCamera()
  {
    this.Border.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
    this.MyCamera.rect = new Rect(0.5f, 0.5f, 0.0f, 0.0f);
    this.ElevationLabel.enabled = false;
    this.MyCamera.enabled = false;
  }
}
