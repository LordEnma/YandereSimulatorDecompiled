// Decompiled with JetBrains decompiler
// Type: YouTubeChat
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Threading;
using UnityEngine;

public class YouTubeChat : MonoBehaviour
{
  public static YouTubeChat instance;
  public WebDriver driver;
  public string youtubeChatPopoutUrl;
  private string pathToDriver = Directory.GetCurrentDirectory() + "\\Assets\\Packages\\Selenium.WebDriver.GeckoDriver.0.30.0.1\\driver\\";
  private string defaultPathToDriver = Directory.GetCurrentDirectory() + "\\Assets\\Packages\\Selenium.WebDriver.GeckoDriver.0.30.0.1\\driver\\";
  private FirefoxOptions options;
  private FirefoxDriverService FFDriverService;
  private int previousLength;
  public Queue<YouTubeChatMessage> MessageQueue = new Queue<YouTubeChatMessage>();
  private Thread updateThread;
  private bool hasSetVersion;
  private string _youtubeChatPopoutUrl;
  public bool isValidURL;
  public float Timer;
  public bool TimeBased;

  private void OnEnable()
  {
    YouTubeChat.instance = this;
    this.pathToDriver = Application.dataPath + "/StreamingAssets/Packages/Selenium.WebDriver.GeckoDriver.0.30.0.1/driver/";
    this.defaultPathToDriver = this.pathToDriver;
    this.options = this.getFirefoxOptions();
    if (this.updateThread != null && this.updateThread.IsAlive)
    {
      this.updateThread.Abort();
      this.updateThread = (Thread) null;
    }
    this.StartDriver();
    this._youtubeChatPopoutUrl = this.youtubeChatPopoutUrl;
  }

  private void StartDriver()
  {
    if (this.FFDriverService != null)
      this.FFDriverService = (FirefoxDriverService) null;
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
    this.AssureDriverActivated();
    if (this.isValidURL || this.updateThread == null || !this.updateThread.IsAlive)
      return;
    this.updateThread.Abort();
  }

  public YouTubeChatMessage NextInQueue() => this.MessageQueue.Count != 0 ? this.MessageQueue.Peek() : (YouTubeChatMessage) null;

  public void Dequeue() => this.MessageQueue.Dequeue();

  private void _messageUpdate()
  {
    while (true)
    {
      try
      {
        this.UpdateMessagesList(false);
      }
      catch (Exception ex)
      {
      }
    }
  }

  public void UpdateMessagesList(bool initialRun)
  {
    ReadOnlyCollection<IWebElement> elements = this.driver.FindElements(By.TagName("YT-LIVE-CHAT-TEXT-MESSAGE-RENDERER"));
    if (!initialRun)
    {
      if (this.previousLength > elements.Count)
        this.UpdateMessagesList(true);
      if (this.previousLength < elements.Count)
      {
        for (int previousLength = this.previousLength; previousLength < elements.Count; ++previousLength)
        {
          try
          {
            IWebElement element = elements[previousLength].FindElement(By.Id("message"));
            if (element != null)
            {
              if (element.Text != string.Empty)
              {
                if (element.Text[0] == '!')
                  this.MessageQueue.Enqueue(new YouTubeChatMessage(elements[previousLength].FindElement(By.Id("author-name")).Text, elements[previousLength].GetAttribute("timestampString"), element.Text));
              }
            }
          }
          catch
          {
          }
        }
      }
    }
    this.previousLength = elements.Count;
    if (this.previousLength < 100)
      return;
    this.driver.Navigate().Refresh();
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
    if (this.FFDriverService == null)
    {
      this.FFDriverService = FirefoxDriverService.CreateDefaultService(this.getVersionPath());
      this.FFDriverService.HideCommandPromptWindow = true;
    }
    this.driver = (WebDriver) new FirefoxDriver(this.FFDriverService, this.options);
    if (!string.IsNullOrEmpty(this.youtubeChatPopoutUrl) && this.youtubeChatPopoutUrl.Contains("https://www.youtube.") && this.youtubeChatPopoutUrl.Contains("/live_chat?is_popout="))
    {
      if (this.youtubeChatPopoutUrl.Contains("&v="))
      {
        try
        {
          HttpWebResponse response = (HttpWebResponse) WebRequest.Create(this.youtubeChatPopoutUrl).GetResponse();
          if (response.StatusCode == HttpStatusCode.OK)
          {
            try
            {
              this.driver.Navigate().GoToUrl(this.youtubeChatPopoutUrl);
              this.UpdateMessagesList(true);
              this.isValidURL = true;
              if (this.updateThread != null && this.updateThread.IsAlive)
              {
                this.updateThread.Abort();
                this.updateThread = (Thread) null;
              }
              this.updateThread = new Thread(new ThreadStart(this._messageUpdate));
              this.updateThread.Start();
            }
            catch (Exception ex)
            {
              this.isValidURL = false;
            }
          }
          response.Dispose();
          return;
        }
        catch
        {
          this.isValidURL = false;
          this._youtubeChatPopoutUrl = string.Empty;
          return;
        }
      }
    }
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
    if (this.FFDriverService != null)
    {
      this.FFDriverService.Dispose();
      this.FFDriverService = (FirefoxDriverService) null;
    }
    if (this.updateThread == null)
      return;
    this.updateThread.Abort();
    this.updateThread = (Thread) null;
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
    firefoxOptions.BrowserExecutableLocation = this.defaultPathToDriver + "MozillaFirefox/firefox.exe";
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
