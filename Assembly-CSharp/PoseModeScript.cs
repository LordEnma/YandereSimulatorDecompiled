// Decompiled with JetBrains decompiler
// Type: PoseModeScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PoseModeScript : MonoBehaviour
{
  public InputManagerScript InputManager;
  public PromptBarScript PromptBar;
  public ParticleSystem Marker;
  public StudentScript Student;
  public YandereScript Yandere;
  public UIPanel Panel;
  public UILabel[] OptionLabels;
  public UILabel HeaderLabel;
  public Transform Highlight;
  public Transform Bone;
  public GameObject Warning;
  public Camera PoseModeCamera;
  public bool ChoosingBodyRegion;
  public bool ChoosingAction = true;
  public bool ChoosingBone = true;
  public bool SavingLoading;
  public bool Customizing;
  public bool EditingFace;
  public bool Animating;
  public bool Placing;
  public bool Posing;
  public bool Show;
  public int SaveSlot = 1;
  public int Selected = 1;
  public int Region = 1;
  public int AnimID = 1;
  public int Degree = 1;
  public int Offset;
  public int Limit;
  public int Value;
  public string[] StockingNames;
  public int StockingID;
  public string[] AnimationArray;

  private void Start()
  {
    this.PoseModeCamera.gameObject.SetActive(false);
    this.transform.localScale = Vector3.zero;
    this.Panel.enabled = false;
  }

  private void Update()
  {
    if (this.Show)
    {
      this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      if (this.InputManager.TappedUp)
      {
        --this.Selected;
        this.UpdateHighlight();
      }
      else if (this.InputManager.TappedDown)
      {
        ++this.Selected;
        this.UpdateHighlight();
      }
      if (this.ChoosingAction)
      {
        if (Input.GetButtonDown("A") && (double) this.OptionLabels[this.Selected].color.a == 1.0)
        {
          this.ChoosingAction = false;
          if (this.Selected == 1)
          {
            this.ChoosingBodyRegion = true;
            this.UpdateLabels();
          }
          else if (this.Selected == 2)
          {
            this.PromptBar.ClearButtons();
            this.PromptBar.Label[0].text = "Place";
            this.PromptBar.Label[1].text = "Cancel";
            this.PromptBar.UpdateButtons();
            this.Marker.emission.enabled = true;
            this.Marker.Play();
            this.Yandere.CanMove = true;
            this.ChoosingAction = true;
            this.Placing = true;
            this.Show = false;
            this.Selected = 1;
            this.UpdateHighlight();
          }
          else if (this.Selected == 3)
          {
            this.Customizing = true;
            this.UpdateLabels();
            this.Selected = 1;
            this.UpdateHighlight();
          }
          else if (this.Selected == 4)
          {
            this.PromptBar.Label[2].text = "Page Down";
            this.PromptBar.Label[3].text = "Page Up";
            this.PromptBar.UpdateButtons();
            this.CreateAnimationArray();
            this.Animating = true;
            this.UpdateLabels();
            this.Selected = 1;
            this.UpdateHighlight();
          }
          else if (this.Selected == 5)
          {
            this.Student.CharacterAnimation.Stop();
            this.ChoosingAction = true;
          }
          else if (this.Selected == 6)
          {
            this.PoseModeCamera.gameObject.SetActive(true);
            this.PoseModeCamera.transform.parent = this.Student.Head;
            this.PoseModeCamera.transform.localPosition = new Vector3(0.0f, 0.0f, 0.5f);
            this.PoseModeCamera.transform.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
            this.PromptBar.Label[2].text = "Set to 0";
            this.PromptBar.Label[3].text = "Set to 100";
            this.PromptBar.UpdateButtons();
            this.EditingFace = true;
            this.UpdateLabels();
            this.Selected = 1;
            this.UpdateHighlight();
          }
          else if (this.Selected == 7)
          {
            this.SavingLoading = true;
            this.UpdateLabels();
            this.Selected = 1;
            this.UpdateHighlight();
          }
          else if (this.Selected == 8)
          {
            this.Student.MyController.enabled = true;
            this.Student.Pathfinding.canSearch = true;
            this.Student.Pathfinding.canMove = true;
            this.Student.Posing = false;
            this.Student.Stop = false;
            this.Exit();
          }
          else if (this.Selected == 9)
          {
            this.ChoosingAction = true;
            for (int index = 1; index < 100; ++index)
            {
              if ((Object) this.Student.StudentManager.Students[index] != (Object) null)
              {
                this.Student.StudentManager.Students[index].Pathfinding.canSearch = false;
                this.Student.StudentManager.Students[index].Pathfinding.canMove = false;
                this.Student.StudentManager.Students[index].MyController.enabled = false;
                this.Student.StudentManager.Students[index].Posing = true;
                this.Student.StudentManager.Students[index].Stop = true;
              }
            }
          }
        }
        if (!Input.GetButtonDown("B"))
          return;
        this.Exit();
      }
      else if (this.ChoosingBodyRegion)
      {
        if (Input.GetButtonDown("A") && (double) this.OptionLabels[this.Selected].color.a == 1.0)
        {
          this.ChoosingBodyRegion = false;
          if (this.Selected == 1)
          {
            this.Bone = this.Student.transform;
            this.RememberPose();
            this.Posing = true;
            this.UpdateLabels();
          }
          else
          {
            this.ChoosingBone = true;
            this.Region = this.Selected;
            this.UpdateLabels();
            this.Selected = 1;
            this.UpdateHighlight();
          }
        }
        if (!Input.GetButtonDown("B"))
          return;
        this.ChoosingBodyRegion = false;
        this.ChoosingAction = true;
        this.Region = 1;
        this.UpdateLabels();
        this.Selected = 1;
        this.UpdateHighlight();
      }
      else if (this.ChoosingBone)
      {
        if (Input.GetButtonDown("A"))
        {
          this.ChoosingBone = false;
          this.Posing = true;
          if (this.Region == 2)
            this.Bone = this.Student.BoneSets.BoneSet1[this.Selected];
          else if (this.Region == 3)
            this.Bone = this.Student.BoneSets.BoneSet2[this.Selected];
          else if (this.Region == 4)
            this.Bone = this.Student.BoneSets.BoneSet3[this.Selected];
          else if (this.Region == 5)
            this.Bone = this.Student.BoneSets.BoneSet4[this.Selected];
          else if (this.Region == 6)
            this.Bone = this.Student.BoneSets.BoneSet5[this.Selected];
          else if (this.Region == 7)
            this.Bone = this.Student.BoneSets.BoneSet6[this.Selected];
          else if (this.Region == 8)
            this.Bone = this.Student.BoneSets.BoneSet7[this.Selected];
          else if (this.Region == 9)
            this.Bone = this.Student.BoneSets.BoneSet8[this.Selected];
          else if (this.Region == 10)
            this.Bone = this.Student.BoneSets.BoneSet9[this.Selected];
          this.RememberPose();
          this.UpdateLabels();
        }
        if (!Input.GetButtonDown("B"))
          return;
        this.ChoosingBodyRegion = true;
        this.ChoosingBone = false;
        this.Region = 1;
        this.UpdateLabels();
        this.Selected = 1;
        this.UpdateHighlight();
      }
      else if (this.Posing)
      {
        if ((double) Input.GetAxis("Horizontal") > 0.5 || (double) Input.GetAxis("Horizontal") < -0.5 || (double) Input.GetAxis("DpadX") > 0.5 || (double) Input.GetAxis("DpadX") < -0.5 || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
          this.CalculateValue();
          if (this.Selected == 1)
            this.Bone.localPosition = new Vector3(this.Bone.localPosition.x + (float) ((double) Time.deltaTime * (double) this.Value * (double) this.Degree * 0.10000000149011612), this.Bone.localPosition.y, this.Bone.localPosition.z);
          else if (this.Selected == 2)
            this.Bone.localPosition = new Vector3(this.Bone.localPosition.x, this.Bone.localPosition.y + (float) ((double) Time.deltaTime * (double) this.Value * (double) this.Degree * 0.10000000149011612), this.Bone.localPosition.z);
          else if (this.Selected == 3)
            this.Bone.localPosition = new Vector3(this.Bone.localPosition.x, this.Bone.localPosition.y, this.Bone.localPosition.z + (float) ((double) Time.deltaTime * (double) this.Value * (double) this.Degree * 0.10000000149011612));
          else if (this.Selected == 4)
            this.Bone.Rotate(Vector3.right * (float) ((double) Time.deltaTime * (double) this.Value * (double) this.Degree * 36.0));
          else if (this.Selected == 5)
            this.Bone.Rotate(Vector3.up * (float) ((double) Time.deltaTime * (double) this.Value * (double) this.Degree * 36.0));
          else if (this.Selected == 6)
            this.Bone.Rotate(Vector3.forward * (float) ((double) Time.deltaTime * (double) this.Value * (double) this.Degree * 36.0));
          else if (this.Selected == 7)
            this.Bone.localScale = new Vector3(this.Bone.localScale.x + (float) ((double) Time.deltaTime * (double) this.Value * (double) this.Degree * 0.10000000149011612), this.Bone.localScale.y, this.Bone.localScale.z);
          else if (this.Selected == 8)
            this.Bone.localScale = new Vector3(this.Bone.localScale.x, this.Bone.localScale.y + (float) ((double) Time.deltaTime * (double) this.Value * (double) this.Degree * 0.10000000149011612), this.Bone.localScale.z);
          else if (this.Selected == 9)
            this.Bone.localScale = new Vector3(this.Bone.localScale.x, this.Bone.localScale.y, this.Bone.localScale.z + (float) ((double) Time.deltaTime * (double) this.Value * (double) this.Degree * 0.10000000149011612));
        }
        if (this.Selected == 10)
        {
          if (this.InputManager.TappedRight)
          {
            if (this.Degree < 10)
              ++this.Degree;
            this.UpdateLabels();
          }
          else if (this.InputManager.TappedLeft)
          {
            if (this.Degree > 1)
              --this.Degree;
            this.UpdateLabels();
          }
        }
        else if (this.Selected == 11 && Input.GetButtonDown("A"))
          this.ResetPose();
        if (!Input.GetButtonDown("B"))
          return;
        if (this.Region == 1)
          this.ChoosingBodyRegion = true;
        else
          this.ChoosingBone = true;
        this.Posing = false;
        this.UpdateLabels();
        this.Selected = 1;
        this.UpdateHighlight();
      }
      else if (this.Customizing)
      {
        if (this.Selected == 1)
        {
          if (this.InputManager.TappedRight)
          {
            this.Student.Cosmetic.Direction = 1;
            ++this.Student.Cosmetic.Hairstyle;
            if (!this.Student.Male)
            {
              if (!this.Student.Teacher)
              {
                if (this.Student.Cosmetic.Hairstyle == this.Student.Cosmetic.FemaleHair.Length)
                  this.Student.Cosmetic.Hairstyle = 1;
              }
              else if (this.Student.Cosmetic.Hairstyle == this.Student.Cosmetic.TeacherHair.Length)
                this.Student.Cosmetic.Hairstyle = 1;
            }
            else if (this.Student.Cosmetic.Hairstyle == this.Student.Cosmetic.MaleHair.Length)
              this.Student.Cosmetic.Hairstyle = 1;
            this.Student.Cosmetic.Start();
            this.UpdateLabels();
          }
          if (this.InputManager.TappedLeft)
          {
            this.Student.Cosmetic.Direction = -1;
            --this.Student.Cosmetic.Hairstyle;
            if (this.Student.Cosmetic.Hairstyle == 0)
              this.Student.Cosmetic.Hairstyle = this.Student.Male ? this.Student.Cosmetic.MaleHair.Length - 1 : (this.Student.Teacher ? this.Student.Cosmetic.TeacherHair.Length - 1 : this.Student.Cosmetic.FemaleHair.Length - 1);
            this.Student.Cosmetic.Start();
            this.UpdateLabels();
          }
        }
        else if (this.Selected == 2)
        {
          if (this.InputManager.TappedRight)
          {
            ++this.Student.Cosmetic.Accessory;
            if (!this.Student.Male)
            {
              if (this.Student.Cosmetic.Accessory == this.Student.Cosmetic.FemaleAccessories.Length)
                this.Student.Cosmetic.Accessory = 0;
            }
            else if (this.Student.Cosmetic.Accessory == this.Student.Cosmetic.MaleAccessories.Length)
              this.Student.Cosmetic.Accessory = 0;
            this.Student.Cosmetic.Start();
            this.UpdateLabels();
          }
          if (this.InputManager.TappedLeft)
          {
            --this.Student.Cosmetic.Accessory;
            if (this.Student.Cosmetic.Accessory < 0)
              this.Student.Cosmetic.Accessory = this.Student.Male ? this.Student.Cosmetic.MaleAccessories.Length - 1 : this.Student.Cosmetic.FemaleAccessories.Length - 1;
            this.Student.Cosmetic.Start();
            this.UpdateLabels();
          }
        }
        else if (this.Selected == 3)
        {
          if (this.InputManager.TappedRight)
          {
            ++this.Student.Schoolwear;
            if (this.Student.Schoolwear > 3)
              this.Student.Schoolwear = 1;
            this.Student.ChangeSchoolwear();
            this.UpdateLabels();
          }
          if (this.InputManager.TappedLeft)
          {
            --this.Student.Schoolwear;
            if (this.Student.Schoolwear < 1)
              this.Student.Schoolwear = 3;
            this.Student.ChangeSchoolwear();
            this.UpdateLabels();
          }
        }
        else if (this.Selected == 10)
        {
          if (this.InputManager.TappedRight)
          {
            if (this.Degree < 10)
              ++this.Degree;
            this.UpdateLabels();
          }
          else if (this.InputManager.TappedLeft)
          {
            if (this.Degree > 1)
              --this.Degree;
            this.UpdateLabels();
          }
        }
        else if (this.Selected == 11)
        {
          if (!this.Student.Male)
          {
            if (this.InputManager.TappedRight)
            {
              ++this.StockingID;
              if (this.StockingID == this.StockingNames.Length)
                this.StockingID = 0;
              this.Student.Cosmetic.Stockings = this.StockingNames[this.StockingID];
              this.StartCoroutine(this.Student.Cosmetic.PutOnStockings());
              this.UpdateLabels();
            }
            else if (this.InputManager.TappedLeft)
            {
              --this.StockingID;
              if (this.StockingID < 0)
                this.StockingID = this.StockingNames.Length - 1;
              this.Student.Cosmetic.Stockings = this.StockingNames[this.StockingID];
              this.StartCoroutine(this.Student.Cosmetic.PutOnStockings());
              this.UpdateLabels();
            }
          }
        }
        else if (this.Selected == 12)
        {
          if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
          {
            this.Student.LiquidProjector.material.mainTexture = this.Student.BloodTexture;
            this.Student.LiquidProjector.enabled = !this.Student.LiquidProjector.enabled;
            this.Student.LiquidProjector.gameObject.SetActive(this.Student.LiquidProjector.enabled);
            this.UpdateLabels();
          }
        }
        else if ((double) Input.GetAxis("Horizontal") > 0.5 || (double) Input.GetAxis("Horizontal") < -0.5 || (double) Input.GetAxis("DpadX") > 0.5 || (double) Input.GetAxis("DpadX") < -0.5 || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
          this.CalculateValue();
          Material material1 = this.Student.Cosmetic.HairRenderer.material;
          Material material2 = this.Student.Cosmetic.RightEyeRenderer.material;
          if (this.Selected == 4)
            material1.color = new Color(material1.color.r + (float) this.Degree * 0.003921569f * (float) this.Value, material1.color.g, material1.color.b, material1.color.a);
          else if (this.Selected == 5)
            material1.color = new Color(material1.color.r, material1.color.g + (float) this.Degree * 0.003921569f * (float) this.Value, material1.color.b, material1.color.a);
          else if (this.Selected == 6)
            material1.color = new Color(material1.color.r, material1.color.g, material1.color.b + (float) this.Degree * 0.003921569f * (float) this.Value, material1.color.a);
          else if (this.Selected == 7)
            material2.color = new Color(material2.color.r + (float) this.Degree * 0.003921569f * (float) this.Value, material2.color.g, material2.color.b, material2.color.a);
          else if (this.Selected == 8)
            material2.color = new Color(material2.color.r, material2.color.g + (float) this.Degree * 0.003921569f * (float) this.Value, material2.color.b, material2.color.a);
          else if (this.Selected == 9)
            material2.color = new Color(material2.color.r, material2.color.g, material2.color.b + (float) this.Degree * 0.003921569f * (float) this.Value, material2.color.a);
          this.CapColors();
          this.UpdateLabels();
        }
        if (!Input.GetButtonDown("B"))
          return;
        this.ChoosingAction = true;
        this.Customizing = false;
        this.UpdateLabels();
        this.Selected = 1;
        this.UpdateHighlight();
      }
      else if (this.Animating)
      {
        if (Input.GetButtonDown("X"))
        {
          this.Offset += 16;
          this.UpdateHighlight();
        }
        if (Input.GetButtonDown("Y"))
        {
          this.Offset -= 16;
          this.UpdateHighlight();
        }
        if (Input.GetButtonDown("A"))
        {
          this.Student.CharacterAnimation.Stop();
          this.Student.CharacterAnimation.CrossFade(this.AnimationArray[this.Selected + this.Offset]);
        }
        if (!Input.GetButtonDown("B"))
          return;
        this.PromptBar.Label[2].text = string.Empty;
        this.PromptBar.Label[3].text = string.Empty;
        this.PromptBar.UpdateButtons();
        this.ChoosingAction = true;
        this.Animating = false;
        this.UpdateLabels();
        this.Selected = 1;
        this.UpdateHighlight();
      }
      else if (this.EditingFace)
      {
        if (this.Selected == 18)
        {
          if (this.InputManager.TappedRight)
          {
            if (this.Degree < 10)
              ++this.Degree;
            this.UpdateLabels();
          }
          else if (this.InputManager.TappedLeft)
          {
            if (this.Degree > 1)
              --this.Degree;
            this.UpdateLabels();
          }
        }
        else
        {
          if (this.InputManager.TappedRight)
          {
            this.Student.MyRenderer.SetBlendShapeWeight(this.Selected - 1, this.Student.MyRenderer.GetBlendShapeWeight(this.Selected - 1) + (float) this.Degree);
            if ((double) this.Student.MyRenderer.GetBlendShapeWeight(this.Selected - 1) > 100.0)
              this.Student.MyRenderer.SetBlendShapeWeight(this.Selected - 1, 100f);
            this.UpdateLabels();
          }
          else if (this.InputManager.TappedLeft)
          {
            this.Student.MyRenderer.SetBlendShapeWeight(this.Selected - 1, this.Student.MyRenderer.GetBlendShapeWeight(this.Selected - 1) - (float) this.Degree);
            if ((double) this.Student.MyRenderer.GetBlendShapeWeight(this.Selected - 1) < 0.0)
              this.Student.MyRenderer.SetBlendShapeWeight(this.Selected - 1, 0.0f);
            this.UpdateLabels();
          }
          if (Input.GetButtonDown("X"))
          {
            this.Student.MyRenderer.SetBlendShapeWeight(this.Selected - 1, 0.0f);
            this.UpdateLabels();
          }
          if (Input.GetButtonDown("Y"))
          {
            this.Student.MyRenderer.SetBlendShapeWeight(this.Selected - 1, 100f);
            this.UpdateLabels();
          }
        }
        if (!Input.GetButtonDown("B"))
          return;
        this.PromptBar.Label[2].text = string.Empty;
        this.PromptBar.Label[3].text = string.Empty;
        this.PromptBar.UpdateButtons();
        this.PoseModeCamera.gameObject.SetActive(false);
        this.ChoosingAction = true;
        this.EditingFace = false;
        this.UpdateLabels();
        this.Selected = 1;
        this.UpdateHighlight();
      }
      else
      {
        if (!this.SavingLoading)
          return;
        if (this.Selected == 1)
        {
          if (this.InputManager.TappedRight)
          {
            ++this.SaveSlot;
            this.UpdateLabels();
          }
          else if (this.InputManager.TappedLeft)
          {
            if (this.SaveSlot > 1)
              --this.SaveSlot;
            this.UpdateLabels();
          }
        }
        if (Input.GetButtonDown("A"))
        {
          if (this.Selected == 2)
          {
            PoseSerializer.SerializePose(this.Student.Cosmetic, this.Student.transform, this.SaveSlot.ToString() ?? "");
            this.Yandere.NotificationManager.CustomText = "Pose Saved!";
            this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          }
          else if (this.Selected == 3)
          {
            Debug.Log((object) ("Our intention is to change the Cosmetic data for: " + this.Student.Name));
            PoseSerializer.DeserializePose(this.Student.Cosmetic, this.Student.transform, this.SaveSlot.ToString() ?? "");
          }
        }
        if (!Input.GetButtonDown("B"))
          return;
        this.PromptBar.Label[2].text = string.Empty;
        this.PromptBar.Label[3].text = string.Empty;
        this.PromptBar.UpdateButtons();
        this.PoseModeCamera.gameObject.SetActive(false);
        this.ChoosingAction = true;
        this.SavingLoading = false;
        this.UpdateLabels();
        this.Selected = 1;
        this.UpdateHighlight();
      }
    }
    else
    {
      if ((double) this.transform.localScale.x > 0.10000000149011612)
        this.transform.localScale = Vector3.Lerp(this.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
      else if (this.Panel.enabled)
      {
        this.transform.localScale = Vector3.zero;
        this.Panel.enabled = false;
      }
      if (!this.Placing || !Input.GetButtonDown("A") && !Input.GetButtonDown("B"))
        return;
      if (Input.GetButtonDown("A"))
        this.Student.transform.position = this.Marker.transform.position;
      this.Marker.emission.enabled = false;
      this.Placing = false;
      this.PromptBar.ClearButtons();
      this.PromptBar.Show = false;
    }
  }

  private void UpdateHighlight()
  {
    if (!this.Animating)
    {
      if (this.Selected > this.Limit)
        this.Selected = 1;
      else if (this.Selected < 1)
        this.Selected = this.Limit;
    }
    else
    {
      if (this.Selected > this.Limit)
      {
        this.Selected = this.Limit;
        ++this.Offset;
      }
      else if (this.Selected < 1)
      {
        this.Selected = 1;
        --this.Offset;
      }
      if (this.Offset < 0)
      {
        this.Offset = this.AnimID - this.Limit;
        this.Selected = this.Limit;
      }
      else if (this.Offset > this.AnimID - this.Limit)
      {
        this.Offset = 0;
        this.Selected = 1;
      }
      this.UpdateLabels();
    }
    this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (400.0 - (double) this.Selected * 50.0), this.Highlight.localPosition.z);
  }

  public void UpdateLabels()
  {
    for (int index = 1; index < this.OptionLabels.Length; ++index)
    {
      UILabel optionLabel = this.OptionLabels[index];
      optionLabel.color = new Color(optionLabel.color.r, optionLabel.color.g, optionLabel.color.b, 1f);
      optionLabel.text = string.Empty;
    }
    this.Warning.SetActive(false);
    if (this.ChoosingAction)
    {
      this.Warning.SetActive(true);
      this.HeaderLabel.text = "Choose Action";
      this.OptionLabels[1].text = "Pose";
      this.OptionLabels[2].text = "Re-Position";
      this.OptionLabels[3].text = "Customize Appearance";
      this.OptionLabels[4].text = "Perform Animation";
      this.OptionLabels[5].text = "Stop Animation";
      this.OptionLabels[6].text = "Edit Face";
      this.OptionLabels[7].text = "Save/Load Pose";
      this.OptionLabels[8].text = "Release Student";
      this.OptionLabels[9].text = "Freeze All Students";
      this.Limit = 9;
      if (!this.Student.Male)
        return;
      this.OptionLabels[6].color = new Color(1f, 1f, 1f, 0.5f);
    }
    else if (this.ChoosingBodyRegion)
    {
      this.HeaderLabel.text = "Choose Body Region";
      this.OptionLabels[1].text = "Root";
      this.OptionLabels[2].text = "Spine";
      this.OptionLabels[3].text = "Right Leg";
      this.OptionLabels[4].text = "Left Leg";
      this.OptionLabels[5].text = "Right Arm";
      this.OptionLabels[6].text = "Left Arm";
      this.OptionLabels[7].text = "Right Fingers";
      this.OptionLabels[8].text = "Left Fingers";
      this.OptionLabels[9].text = "Face";
      this.OptionLabels[10].text = "Female Only";
      this.Limit = 10;
      UILabel optionLabel = this.OptionLabels[10];
      optionLabel.color = new Color(optionLabel.color.r, optionLabel.color.g, optionLabel.color.b, this.Student.Male ? 0.5f : 1f);
    }
    else if (this.ChoosingBone)
    {
      this.HeaderLabel.text = "Choose Bone";
      if (this.Region == 2)
      {
        this.OptionLabels[1].text = "Hips";
        this.OptionLabels[2].text = "Spine 1";
        this.OptionLabels[3].text = "Spine 2";
        this.OptionLabels[4].text = "Spine 3";
        this.OptionLabels[5].text = "Spine 4";
        this.OptionLabels[6].text = "Neck";
        this.OptionLabels[7].text = "Head";
        this.Limit = 7;
      }
      else if (this.Region == 3)
      {
        this.OptionLabels[1].text = "Right Leg";
        this.OptionLabels[2].text = "Right Knee";
        this.OptionLabels[3].text = "Right Foot";
        this.OptionLabels[4].text = "Right Toe";
        this.Limit = 4;
      }
      else if (this.Region == 4)
      {
        this.OptionLabels[1].text = "Left Leg";
        this.OptionLabels[2].text = "Left Knee";
        this.OptionLabels[3].text = "Left Foot";
        this.OptionLabels[4].text = "Left Toe";
        this.Limit = 4;
      }
      else if (this.Region == 5)
      {
        this.OptionLabels[1].text = "Right Clavicle";
        this.OptionLabels[2].text = "Right Arm";
        this.OptionLabels[3].text = "Right Elbow";
        this.OptionLabels[4].text = "Right Wrist";
        this.Limit = 4;
      }
      else if (this.Region == 6)
      {
        this.OptionLabels[1].text = "Left Clavicle";
        this.OptionLabels[2].text = "Left Arm";
        this.OptionLabels[3].text = "Left Elbow";
        this.OptionLabels[4].text = "Left Wrist";
        this.Limit = 4;
      }
      else if (this.Region == 7)
      {
        this.OptionLabels[1].text = "Right Pinky 1";
        this.OptionLabels[2].text = "Right Pinky 2";
        this.OptionLabels[3].text = "Right Pinky 3";
        this.OptionLabels[4].text = "Right Ring 1";
        this.OptionLabels[5].text = "Right Ring 2";
        this.OptionLabels[6].text = "Right Ring 3";
        this.OptionLabels[7].text = "Right Middle 1";
        this.OptionLabels[8].text = "Right Middle 2";
        this.OptionLabels[9].text = "Right Middle 3";
        this.OptionLabels[10].text = "Right Index 1";
        this.OptionLabels[11].text = "Right Index 2";
        this.OptionLabels[12].text = "Right Index 3";
        this.OptionLabels[13].text = "Right Thumb 1";
        this.OptionLabels[14].text = "Right Thumb 2";
        this.OptionLabels[15].text = "Right Thumb 3";
        this.Limit = 15;
      }
      else if (this.Region == 8)
      {
        this.OptionLabels[1].text = "Left Pinky 1";
        this.OptionLabels[2].text = "Left Pinky 2";
        this.OptionLabels[3].text = "Left Pinky 3";
        this.OptionLabels[4].text = "Left Ring 1";
        this.OptionLabels[5].text = "Left Ring 2";
        this.OptionLabels[6].text = "Left Ring 3";
        this.OptionLabels[7].text = "Left Middle 1";
        this.OptionLabels[8].text = "Left Middle 2";
        this.OptionLabels[9].text = "Left Middle 3";
        this.OptionLabels[10].text = "Left Index 1";
        this.OptionLabels[11].text = "Left Index 2";
        this.OptionLabels[12].text = "Left Index 3";
        this.OptionLabels[13].text = "Left Thumb 1";
        this.OptionLabels[14].text = "Left Thumb 2";
        this.OptionLabels[15].text = "Left Thumb 3";
        this.Limit = 15;
      }
      else if (this.Region == 9)
      {
        this.OptionLabels[1].text = "Right Eye";
        this.OptionLabels[2].text = "Left Eye";
        this.OptionLabels[3].text = "Right Eyebrow";
        this.OptionLabels[4].text = "Left Eyebrow";
        this.OptionLabels[5].text = "Jaw";
        this.Limit = 5;
      }
      else
      {
        if (this.Region != 10)
          return;
        this.OptionLabels[1].text = "Front Skirt 1";
        this.OptionLabels[2].text = "Front Skirt 2";
        this.OptionLabels[3].text = "Front Skirt 3";
        this.OptionLabels[4].text = "Back Skirt 1";
        this.OptionLabels[5].text = "Back Skirt 2";
        this.OptionLabels[6].text = "Back Skirt 3";
        this.OptionLabels[7].text = "Right Skirt 1";
        this.OptionLabels[8].text = "Right Skirt 2";
        this.OptionLabels[9].text = "Right Skirt 3";
        this.OptionLabels[10].text = "Left Skirt 1";
        this.OptionLabels[11].text = "Left Skirt 2";
        this.OptionLabels[12].text = "Left Skirt 3";
        this.OptionLabels[13].text = "Right Breast";
        this.OptionLabels[14].text = "Right Nipple";
        this.OptionLabels[15].text = "Left Breast";
        this.OptionLabels[16].text = "Left Nipple";
        this.Limit = 16;
      }
    }
    else if (this.Posing)
    {
      this.HeaderLabel.text = "Pose Bone";
      this.OptionLabels[1].text = "Position X";
      this.OptionLabels[2].text = "Position Y";
      this.OptionLabels[3].text = "Position Z";
      this.OptionLabels[4].text = "Rotation X";
      this.OptionLabels[5].text = "Rotation Y";
      this.OptionLabels[6].text = "Rotation Z";
      this.OptionLabels[7].text = "Scale X";
      this.OptionLabels[8].text = "Scale Y";
      this.OptionLabels[9].text = "Scale Z";
      this.OptionLabels[10].text = "Degree of Change: " + this.Degree.ToString();
      this.OptionLabels[11].text = "Reset";
      this.Limit = 11;
    }
    else if (this.Customizing)
    {
      this.HeaderLabel.text = "Customize";
      this.OptionLabels[1].text = "Hairstyle: " + this.Student.Cosmetic.Hairstyle.ToString();
      this.OptionLabels[2].text = "Accessory: " + this.Student.Cosmetic.Accessory.ToString();
      this.OptionLabels[3].text = "Clothing: " + this.Student.Schoolwear.ToString();
      UILabel optionLabel1 = this.OptionLabels[4];
      float num = this.Student.Cosmetic.HairRenderer.material.color.r * (float) byte.MaxValue;
      string str1 = "Hair R: " + num.ToString();
      optionLabel1.text = str1;
      UILabel optionLabel2 = this.OptionLabels[5];
      num = this.Student.Cosmetic.HairRenderer.material.color.g * (float) byte.MaxValue;
      string str2 = "Hair G: " + num.ToString();
      optionLabel2.text = str2;
      UILabel optionLabel3 = this.OptionLabels[6];
      num = this.Student.Cosmetic.HairRenderer.material.color.b * (float) byte.MaxValue;
      string str3 = "Hair B: " + num.ToString();
      optionLabel3.text = str3;
      UILabel optionLabel4 = this.OptionLabels[7];
      num = this.Student.Cosmetic.RightEyeRenderer.material.color.r * (float) byte.MaxValue;
      string str4 = "Eye R: " + num.ToString();
      optionLabel4.text = str4;
      UILabel optionLabel5 = this.OptionLabels[8];
      num = this.Student.Cosmetic.RightEyeRenderer.material.color.g * (float) byte.MaxValue;
      string str5 = "Eye G: " + num.ToString();
      optionLabel5.text = str5;
      UILabel optionLabel6 = this.OptionLabels[9];
      num = this.Student.Cosmetic.RightEyeRenderer.material.color.b * (float) byte.MaxValue;
      string str6 = "Eye B: " + num.ToString();
      optionLabel6.text = str6;
      this.OptionLabels[10].text = "Degree of Change: " + this.Degree.ToString();
      this.OptionLabels[11].text = "Stockings: " + this.Student.Cosmetic.Stockings;
      this.OptionLabels[12].text = "Blood: " + this.Student.LiquidProjector.enabled.ToString();
      this.Limit = 12;
      UILabel optionLabel7 = this.OptionLabels[3];
      UILabel optionLabel8 = this.OptionLabels[11];
      if (!this.Student.Male)
      {
        optionLabel7.color = new Color(optionLabel7.color.r, optionLabel7.color.g, optionLabel7.color.b, 1f);
        optionLabel8.color = new Color(optionLabel8.color.r, optionLabel8.color.g, optionLabel8.color.b, 1f);
      }
      else
        optionLabel8.color = new Color(optionLabel8.color.r, optionLabel8.color.g, optionLabel8.color.b, 0.5f);
    }
    else if (this.Animating)
    {
      this.HeaderLabel.text = "Choose Animation";
      for (int index = 1; index < 19; ++index)
        this.OptionLabels[index].text = "(" + (index + this.Offset).ToString() + "/" + this.AnimID.ToString() + ") " + this.AnimationArray[index + this.Offset];
      this.Limit = 18;
    }
    else if (this.EditingFace)
    {
      this.HeaderLabel.text = "Edit Face";
      this.OptionLabels[1].text = "Smile Mouth (" + this.Student.MyRenderer.GetBlendShapeWeight(0).ToString() + ")";
      this.OptionLabels[2].text = "Angry Eyebrows (" + this.Student.MyRenderer.GetBlendShapeWeight(1).ToString() + ")";
      this.OptionLabels[3].text = "Open Mouth (" + this.Student.MyRenderer.GetBlendShapeWeight(2).ToString() + ")";
      this.OptionLabels[4].text = "Ear Size (" + this.Student.MyRenderer.GetBlendShapeWeight(3).ToString() + ")";
      this.OptionLabels[5].text = "Nose Size (" + this.Student.MyRenderer.GetBlendShapeWeight(4).ToString() + ")";
      this.OptionLabels[6].text = "Close Eyes (" + this.Student.MyRenderer.GetBlendShapeWeight(5).ToString() + ")";
      this.OptionLabels[7].text = "Sad Face (" + this.Student.MyRenderer.GetBlendShapeWeight(6).ToString() + ")";
      UILabel optionLabel9 = this.OptionLabels[8];
      float blendShapeWeight = this.Student.MyRenderer.GetBlendShapeWeight(7);
      string str7 = "(Unavailable) (" + blendShapeWeight.ToString() + ")";
      optionLabel9.text = str7;
      UILabel optionLabel10 = this.OptionLabels[9];
      blendShapeWeight = this.Student.MyRenderer.GetBlendShapeWeight(8);
      string str8 = "Thin Eyes (" + blendShapeWeight.ToString() + ")";
      optionLabel10.text = str8;
      UILabel optionLabel11 = this.OptionLabels[10];
      blendShapeWeight = this.Student.MyRenderer.GetBlendShapeWeight(9);
      string str9 = "Round Eyes (" + blendShapeWeight.ToString() + ")";
      optionLabel11.text = str9;
      UILabel optionLabel12 = this.OptionLabels[11];
      blendShapeWeight = this.Student.MyRenderer.GetBlendShapeWeight(10);
      string str10 = "Evil Face (" + blendShapeWeight.ToString() + ")";
      optionLabel12.text = str10;
      UILabel optionLabel13 = this.OptionLabels[12];
      blendShapeWeight = this.Student.MyRenderer.GetBlendShapeWeight(11);
      string str11 = "Naughty Face (" + blendShapeWeight.ToString() + ")";
      optionLabel13.text = str11;
      UILabel optionLabel14 = this.OptionLabels[13];
      blendShapeWeight = this.Student.MyRenderer.GetBlendShapeWeight(12);
      string str12 = "Gentle Face (" + blendShapeWeight.ToString() + ")";
      optionLabel14.text = str12;
      UILabel optionLabel15 = this.OptionLabels[14];
      blendShapeWeight = this.Student.MyRenderer.GetBlendShapeWeight(13);
      string str13 = "Thick Body (" + blendShapeWeight.ToString() + ")";
      optionLabel15.text = str13;
      UILabel optionLabel16 = this.OptionLabels[15];
      blendShapeWeight = this.Student.MyRenderer.GetBlendShapeWeight(14);
      string str14 = "Slim Body (" + blendShapeWeight.ToString() + ")";
      optionLabel16.text = str14;
      UILabel optionLabel17 = this.OptionLabels[16];
      blendShapeWeight = this.Student.MyRenderer.GetBlendShapeWeight(15);
      string str15 = "Long Skirt (" + blendShapeWeight.ToString() + ")";
      optionLabel17.text = str15;
      UILabel optionLabel18 = this.OptionLabels[17];
      blendShapeWeight = this.Student.MyRenderer.GetBlendShapeWeight(16);
      string str16 = "Short Skirt (" + blendShapeWeight.ToString() + ")";
      optionLabel18.text = str16;
      this.OptionLabels[18].text = "Degree of Change: " + this.Degree.ToString();
      this.Limit = 18;
    }
    else
    {
      if (!this.SavingLoading)
        return;
      this.HeaderLabel.text = "Save / Load";
      this.OptionLabels[1].text = "Save Slot: " + this.SaveSlot.ToString();
      this.OptionLabels[2].text = "Save";
      this.OptionLabels[3].text = "Load";
      this.Limit = 3;
    }
  }

  private void RememberPose()
  {
    PoseModeGlobals.PosePosition = this.Bone.localPosition;
    PoseModeGlobals.PoseRotation = this.Bone.localEulerAngles;
    PoseModeGlobals.PoseScale = this.Bone.localScale;
  }

  private void ResetPose()
  {
    this.Bone.localPosition = PoseModeGlobals.PosePosition;
    this.Bone.localEulerAngles = PoseModeGlobals.PoseRotation;
    this.Bone.localScale = PoseModeGlobals.PoseScale;
  }

  private void CapColors()
  {
    Material material1 = this.Student.Cosmetic.HairRenderer.material;
    if ((double) material1.color.r < 0.0)
      material1.color = new Color(0.0f, material1.color.g, material1.color.b, material1.color.a);
    if ((double) material1.color.g < 0.0)
      material1.color = new Color(material1.color.r, 0.0f, material1.color.b, material1.color.a);
    if ((double) material1.color.b < 0.0)
      material1.color = new Color(material1.color.r, material1.color.g, 0.0f, material1.color.a);
    if ((double) material1.color.r > 1.0)
      material1.color = new Color(1f, material1.color.g, material1.color.b, material1.color.a);
    if ((double) material1.color.g > 1.0)
      material1.color = new Color(material1.color.r, 1f, material1.color.b, material1.color.a);
    if ((double) material1.color.b > 1.0)
      material1.color = new Color(material1.color.r, material1.color.g, 1f, material1.color.a);
    Material material2 = this.Student.Cosmetic.RightEyeRenderer.material;
    if ((double) material2.color.r < 0.0)
      material2.color = new Color(0.0f, material2.color.g, material2.color.b, material2.color.a);
    if ((double) material2.color.g < 0.0)
      material2.color = new Color(material2.color.r, 0.0f, material2.color.b, material2.color.a);
    if ((double) material2.color.b < 0.0)
      material2.color = new Color(material2.color.r, material2.color.g, 0.0f, material2.color.a);
    if ((double) material2.color.r > 1.0)
      material2.color = new Color(1f, material2.color.g, material2.color.b, material2.color.a);
    if ((double) material2.color.g > 1.0)
      material2.color = new Color(material2.color.r, 1f, material2.color.b, material2.color.a);
    if ((double) material2.color.b > 1.0)
      material2.color = new Color(material2.color.r, material2.color.g, 1f, material2.color.a);
    this.Student.Cosmetic.LeftEyeRenderer.material.color = material2.color;
  }

  private void CreateAnimationArray()
  {
    this.AnimID = 1;
    foreach (AnimationState animationState in this.Student.CharacterAnimation)
    {
      this.AnimationArray[this.AnimID] = animationState.name;
      ++this.AnimID;
    }
    --this.AnimID;
  }

  private void CalculateValue()
  {
    if ((double) Input.GetAxis("Horizontal") > 0.5 || (double) Input.GetAxis("Horizontal") < -0.5)
    {
      if ((double) Input.GetAxis("Horizontal") > 0.5)
        this.Value = 1;
      else
        this.Value = -1;
    }
    else if ((double) Input.GetAxis("DpadX") > 0.5 || (double) Input.GetAxis("DpadX") < -0.5)
    {
      if ((double) Input.GetAxis("DpadX") > 0.5)
        this.Value = 1;
      else
        this.Value = -1;
    }
    else
      this.Value = Input.GetKey(KeyCode.RightArrow) ? 1 : -1;
  }

  private void Exit()
  {
    this.PromptBar.ClearButtons();
    this.PromptBar.Show = false;
    this.Yandere.CanMove = true;
    this.Show = false;
    this.Selected = 1;
    this.UpdateHighlight();
  }
}
