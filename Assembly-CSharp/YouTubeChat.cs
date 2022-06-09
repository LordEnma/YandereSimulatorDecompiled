// Decompiled with JetBrains decompiler
// Type: YouTubeChat
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using UnityEngine;

public class YouTubeChat : MonoBehaviour
{
  public static YouTubeChat instance;
  public WebDriver driver;
  public string youtubeChatPopoutUrl = "https://www.youtube.com/live_chat?is_popout=1&v=MZ_JdsAnBag";
  private string pathToDriver = Directory.GetCurrentDirectory() + "\\Assets\\Packages\\Selenium.WebDriver.GeckoDriver.0.30.0.1\\driver\\";
  private string defaultPathToDriver = Directory.GetCurrentDirectory() + "\\Assets\\Packages\\Selenium.WebDriver.GeckoDriver.0.30.0.1\\driver\\";
  private FirefoxOptions options;
  private FirefoxDriverService FFDriverService;
  public List<YouTubeChatMessage> MessagesList = new List<YouTubeChatMessage>();
  private int previousLength;
  public Queue<YouTubeChatMessage> MessageQueue = new Queue<YouTubeChatMessage>();
  private bool hasSetVersion;
  private string _youtubeChatPopoutUrl;
  public bool isValidURL;
  public float Timer;
  public bool TimeBased;
  private int Checks;

  private void Start()
  {
  }

  private void OnEnable()
  {
    YouTubeChat.instance = this;
    this.options = this.getFirefoxOptions();
    this.StartDriver();
    this._youtubeChatPopoutUrl = this.youtubeChatPopoutUrl;
  }

  private void StartDriver()
  {
    this.FFDriverService = FirefoxDriverService.CreateDefaultService(this.getVersionPath());
    this.FFDriverService.HideCommandPromptWindow = true;
    this.ActivateDriver();
  }

  private void OnDisable()
  {
    YouTubeChat.instance = (YouTubeChat) null;
    this.CloseDriver();
  }

  private void Update()
  {
    if (!this.TimeBased)
      return;
    this.Timer += Time.unscaledDeltaTime;
    if ((double) this.Timer < 10.0)
      return;
    this.AssureDriverActivated();
    if (this.isValidURL)
      this.UpdateMessagesList(false);
    this.Timer = 0.0f;
  }

  public YouTubeChatMessage NextInQueue() => this.MessageQueue.Count != 0 ? this.MessageQueue.Peek() : (YouTubeChatMessage) null;

  public void Dequeue() => this.MessageQueue.Dequeue();

  public void UpdateMessagesList(bool initialRun)
  {
    ++this.Checks;
    Debug.Log((object) ("Check #" + this.Checks.ToString()));
    this.MessagesList.Clear();
    ReadOnlyCollection<IWebElement> elements = this.driver.FindElements(By.TagName("YT-LIVE-CHAT-TEXT-MESSAGE-RENDERER"));
    for (int index = 0; index < elements.Count; ++index)
    {
      if (elements[index] != null)
        this.MessagesList.Add(new YouTubeChatMessage(elements[index].FindElement(By.Id("author-name")).Text, elements[index].GetAttribute("timestampString"), elements[index].FindElement(By.Id("message")).Text));
    }
    if (!initialRun)
    {
      if (this.previousLength < this.MessagesList.Count)
      {
        for (int previousLength = this.previousLength; previousLength < this.MessagesList.Count; ++previousLength)
          this.MessageQueue.Enqueue(this.MessagesList[previousLength]);
      }
      if (this.previousLength > this.MessagesList.Count)
        this.UpdateMessagesList(true);
    }
    this.previousLength = this.MessagesList.Count;
  }

  public void AssureDriverActivated()
  {
    if (this.driver != null && !string.IsNullOrEmpty(this.driver.CurrentWindowHandle) && !(this._youtubeChatPopoutUrl != this.youtubeChatPopoutUrl))
      return;
    if (this._youtubeChatPopoutUrl != this.youtubeChatPopoutUrl)
      this.CloseDriver();
    this.ActivateDriver();
    this._youtubeChatPopoutUrl = this.youtubeChatPopoutUrl;
  }

  private void ActivateDriver()
  {
    Debug.Log((object) this.pathToDriver);
    this.driver = (WebDriver) new FirefoxDriver(this.FFDriverService, this.options);
    if (!string.IsNullOrEmpty(this.youtubeChatPopoutUrl) && this.youtubeChatPopoutUrl.Contains("https://www.youtube.") && this.youtubeChatPopoutUrl.Contains("/live_chat?is_popout=") && this.youtubeChatPopoutUrl.Contains("&v="))
    {
      if (((HttpWebResponse) WebRequest.Create(this.youtubeChatPopoutUrl).GetResponse()).StatusCode != HttpStatusCode.OK)
        return;
      try
      {
        this.driver.Navigate().GoToUrl(this.youtubeChatPopoutUrl);
        this.UpdateMessagesList(true);
        this.isValidURL = true;
      }
      catch (Exception ex)
      {
        this.isValidURL = false;
      }
    }
    else
      this.isValidURL = false;
  }

  private void OnApplicationQuit() => this.CloseDriver();

  private void CloseDriver()
  {
    if (this.driver == null)
      return;
    this.driver.Close();
    this.driver.Quit();
    this.driver = (WebDriver) null;
  }

  private string getVersionPath()
  {
    int platform = (int) Application.platform;
    if (!this.hasSetVersion)
    {
      switch (Application.platform)
      {
        case RuntimePlatform.OSXEditor:
          this.pathToDriver += "mac64";
          break;
        case RuntimePlatform.OSXPlayer:
          this.pathToDriver += "mac64";
          break;
        case RuntimePlatform.WindowsPlayer:
          this.pathToDriver += "win32";
          break;
        case RuntimePlatform.WindowsEditor:
          this.pathToDriver += "win32";
          break;
        case RuntimePlatform.LinuxPlayer:
          this.pathToDriver += "linux64";
          break;
        case RuntimePlatform.LinuxEditor:
          this.pathToDriver += "linux64";
          break;
        default:
          Debug.LogError((object) "Unsupported Version for Youtube Chat");
          break;
      }
      this.hasSetVersion = true;
    }
    return this.pathToDriver;
  }

  private FirefoxOptions getFirefoxOptions()
  {
    FirefoxOptions firefoxOptions = new FirefoxOptions();
    firefoxOptions.BrowserExecutableLocation = this.defaultPathToDriver + "MozillaFirefox\\firefox.exe";
    firefoxOptions.AddArguments((IEnumerable<string>) new List<string>()
    {
      "--silent-launch",
      "--no-startup-window",
      "no-sandbox",
      "--disable-gpu",
      "-headless"
    });
    return firefoxOptions;
  }
}
