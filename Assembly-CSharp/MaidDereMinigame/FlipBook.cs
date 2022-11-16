// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.FlipBook
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
  public class FlipBook : MonoBehaviour
  {
    public SpriteRenderer Cover;
    public SpriteRenderer Ryoba;
    public UnityEngine.Sprite[] CoverSprites;
    public UnityEngine.Sprite[] RyobaSprites;
    private static FlipBook instance;
    public List<FlipBookPage> flipBookPages;
    private int curPage;
    private bool canGoBack;
    private bool stopInputs;
    private bool UpdateRyobaSprite;

    public static FlipBook Instance
    {
      get
      {
        if ((Object) FlipBook.instance == (Object) null)
          FlipBook.instance = Object.FindObjectOfType<FlipBook>();
        return FlipBook.instance;
      }
    }

    private void Awake()
    {
      this.StartCoroutine(this.OpenBook());
      if (GameGlobals.Eighties)
      {
        this.Ryoba.enabled = true;
        this.UpdateRyobaSprite = true;
      }
      else
        this.Ryoba.enabled = false;
    }

    private IEnumerator OpenBook()
    {
      yield return (object) new WaitForSeconds(1f);
      this.FlipToPage(1);
    }

    private void Update()
    {
      if (this.UpdateRyobaSprite)
      {
        if ((Object) this.Cover.sprite == (Object) this.CoverSprites[1])
          this.Ryoba.sprite = this.RyobaSprites[1];
        else if ((Object) this.Cover.sprite == (Object) this.CoverSprites[2])
          this.Ryoba.sprite = this.RyobaSprites[2];
        else if ((Object) this.Cover.sprite == (Object) this.CoverSprites[3])
          this.Ryoba.enabled = false;
      }
      if (this.stopInputs || this.curPage <= 1 || !Input.GetButtonDown("B") || !this.canGoBack)
        return;
      this.FlipToPage(1);
    }

    public void StopInputs() => this.stopInputs = true;

    public void FlipToPage(int page)
    {
      SFXController.PlaySound(SFXController.Sounds.PageTurn);
      this.StartCoroutine(this.FlipToPageRoutine(page));
    }

    private IEnumerator FlipToPageRoutine(int page)
    {
      FlipBook flipBook1 = this;
      bool toOpen = flipBook1.curPage < page;
      flipBook1.canGoBack = false;
      if (toOpen)
      {
        while (flipBook1.curPage < page)
        {
          List<FlipBookPage> flipBookPages = flipBook1.flipBookPages;
          FlipBook flipBook2 = flipBook1;
          int curPage = flipBook1.curPage;
          int num = curPage + 1;
          flipBook2.curPage = num;
          int index = curPage;
          flipBookPages[index].Transition(toOpen);
        }
        yield return (object) new WaitForSeconds(0.4f);
        flipBook1.flipBookPages[flipBook1.curPage].ObjectActive();
      }
      else
      {
        flipBook1.flipBookPages[flipBook1.curPage].ObjectActive(false);
        while (flipBook1.curPage > page)
        {
          List<FlipBookPage> flipBookPages = flipBook1.flipBookPages;
          FlipBook flipBook3 = flipBook1;
          int num1 = flipBook1.curPage - 1;
          int num2 = num1;
          flipBook3.curPage = num2;
          int index = num1;
          flipBookPages[index].Transition(toOpen);
        }
        yield return (object) new WaitForSeconds(0.6f);
        flipBook1.flipBookPages[flipBook1.curPage].ObjectActive();
      }
      flipBook1.canGoBack = true;
    }
  }
}
