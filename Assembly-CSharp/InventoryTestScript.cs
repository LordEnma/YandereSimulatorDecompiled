// Decompiled with JetBrains decompiler
// Type: InventoryTestScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class InventoryTestScript : MonoBehaviour
{
  public SimpleDetectClickScript[] Items;
  public Animation SkirtAnimation;
  public Animation GirlAnimation;
  public GameObject Skirt;
  public GameObject Girl;
  public Renderer SkirtRenderer;
  public Renderer GirlRenderer;
  public Transform RightGridHighlightParent;
  public Transform LeftGridHighlightParent;
  public Transform RightGridItemParent;
  public Transform LeftGridItemParent;
  public Transform Highlight;
  public Transform RightGrid;
  public Transform LeftGrid;
  public float Alpha;
  public bool Open = true;
  public int OpenSpace = 1;
  public int UseColumn;
  public int UseGrid;
  public int Column = 1;
  public int Grid = 1;
  public int Row = 1;
  public bool[] LeftSpaces1;
  public bool[] LeftSpaces2;
  public bool[] LeftSpaces3;
  public bool[] LeftSpaces4;
  public bool[] RightSpaces1;
  public bool[] RightSpaces2;
  public bool[] RightSpaces3;
  public bool[] RightSpaces4;

  private void Start()
  {
    this.RightGrid.localScale = new Vector3(0.0f, 0.0f, 0.0f);
    this.LeftGrid.localScale = new Vector3(0.0f, 0.0f, 0.0f);
    Time.timeScale = 1f;
  }

  private void Update()
  {
    if (Input.GetKeyDown("space"))
      this.Open = !this.Open;
    AnimationState animationState1 = this.SkirtAnimation["InverseSkirtOpen"];
    AnimationState animationState2 = this.GirlAnimation["f02_inventory_00"];
    if (this.Open)
    {
      this.RightGrid.localScale = Vector3.MoveTowards(this.RightGrid.localScale, new Vector3(0.9f, 0.9f, 0.9f), Time.deltaTime * 10f);
      this.LeftGrid.localScale = Vector3.MoveTowards(this.LeftGrid.localScale, new Vector3(0.9f, 0.9f, 0.9f), Time.deltaTime * 10f);
      this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Mathf.Lerp(this.transform.position.z, 0.37f, Time.deltaTime * 10f));
      animationState1.time = Mathf.Lerp(animationState2.time, 1f, Time.deltaTime * 10f);
      animationState2.time = animationState1.time;
      this.Alpha = Mathf.Lerp(this.Alpha, 1f, Time.deltaTime * 10f);
      this.SkirtRenderer.material.color = new Color(1f, 1f, 1f, this.Alpha);
      this.GirlRenderer.materials[0].color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
      this.GirlRenderer.materials[1].color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
      if (Input.GetKeyDown("right"))
      {
        ++this.Column;
        this.UpdateHighlight();
      }
      if (Input.GetKeyDown("left"))
      {
        --this.Column;
        this.UpdateHighlight();
      }
      if (Input.GetKeyDown("up"))
      {
        --this.Row;
        this.UpdateHighlight();
      }
      if (Input.GetKeyDown("down"))
      {
        ++this.Row;
        this.UpdateHighlight();
      }
    }
    else
    {
      this.RightGrid.localScale = Vector3.MoveTowards(this.RightGrid.localScale, new Vector3(0.0f, 0.0f, 0.0f), Time.deltaTime * 10f);
      this.LeftGrid.localScale = Vector3.MoveTowards(this.LeftGrid.localScale, new Vector3(0.0f, 0.0f, 0.0f), Time.deltaTime * 10f);
      this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Mathf.Lerp(this.transform.position.z, 1f, Time.deltaTime * 10f));
      animationState1.time = Mathf.Lerp(animationState2.time, 0.0f, Time.deltaTime * 10f);
      animationState2.time = animationState1.time;
      this.Alpha = Mathf.Lerp(this.Alpha, 0.0f, Time.deltaTime * 10f);
      this.SkirtRenderer.material.color = new Color(1f, 1f, 1f, this.Alpha);
      this.GirlRenderer.materials[0].color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
      this.GirlRenderer.materials[1].color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
    }
    for (int index1 = 0; index1 < this.Items.Length; ++index1)
    {
      if (this.Items[index1].Clicked)
      {
        Debug.Log((object) ("Item width is " + this.Items[index1].InventoryItem.Width.ToString() + " and item height is " + this.Items[index1].InventoryItem.Height.ToString() + ". Open space is: " + this.OpenSpace.ToString()));
        if (this.Items[index1].InventoryItem.Height * this.Items[index1].InventoryItem.Width < this.OpenSpace)
        {
          Debug.Log((object) "We might have enough open space to add the item to the inventory.");
          this.CheckOpenSpace();
          if (this.UseGrid == 1)
          {
            this.Items[index1].transform.parent = this.LeftGridItemParent;
            float inventorySize = this.Items[index1].InventoryItem.InventorySize;
            this.Items[index1].transform.localScale = new Vector3(inventorySize, inventorySize, inventorySize);
            this.Items[index1].transform.localEulerAngles = new Vector3(90f, 180f, 0.0f);
            this.Items[index1].transform.localPosition = this.Items[index1].InventoryItem.InventoryPosition;
            int index2 = 1;
            if (this.UseColumn == 1)
            {
              for (; index2 < this.Items[index1].InventoryItem.Height + 1; ++index2)
                this.LeftSpaces1[index2] = true;
            }
            else if (this.UseColumn == 2)
            {
              for (; index2 < this.Items[index1].InventoryItem.Height + 1; ++index2)
                this.LeftSpaces2[index2] = true;
            }
            if (this.UseColumn > 1)
              this.Items[index1].transform.localPosition -= new Vector3(0.05f * (float) (this.UseColumn - 1), 0.0f, 0.0f);
          }
        }
        this.Items[index1].Clicked = false;
      }
    }
  }

  private void CheckOpenSpace()
  {
    this.UseColumn = 0;
    this.UseGrid = 0;
    for (int index = 1; index < this.LeftSpaces1.Length; ++index)
    {
      if (this.UseGrid == 0 && !this.LeftSpaces1[index])
      {
        this.UseColumn = 1;
        this.UseGrid = 1;
      }
    }
    int index1 = 1;
    if (this.UseGrid != 0)
      return;
    for (; index1 < this.LeftSpaces2.Length; ++index1)
    {
      if (this.UseGrid == 0 && !this.LeftSpaces2[index1])
      {
        this.UseColumn = 2;
        this.UseGrid = 1;
      }
    }
  }

  private void UpdateHighlight()
  {
    if (this.Column == 5)
    {
      this.Grid = this.Grid != 1 ? 1 : 2;
      this.Column = 1;
    }
    else if (this.Column == 0)
    {
      this.Grid = this.Grid != 1 ? 1 : 2;
      this.Column = 4;
    }
    if (this.Row == 6)
      this.Row = 1;
    else if (this.Row == 0)
      this.Row = 5;
    if (this.Grid == 1)
      this.Highlight.transform.parent = this.LeftGridHighlightParent;
    else
      this.Highlight.transform.parent = this.RightGridHighlightParent;
    this.Highlight.localPosition = new Vector3((float) this.Column, (float) (this.Row * -1), 0.0f);
  }
}
