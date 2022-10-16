// Decompiled with JetBrains decompiler
// Type: YanSave
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class YanSave
{
  public const string SAVE_EXTENSION = "yansave";
  public static System.Action OnLoad;
  public static System.Action OnSave;
  private static Dictionary<System.Type, PropertyInfo[]> PropertyCache = new Dictionary<System.Type, PropertyInfo[]>();
  private static Dictionary<System.Type, FieldInfo[]> FieldCache = new Dictionary<System.Type, FieldInfo[]>();

  public static string SaveDataPath => Path.Combine(Application.streamingAssetsPath, "SaveFiles");

  public static void SaveData(string targetSave)
  {
    YanSaveIdentifier[] objectsOfTypeAll = Resources.FindObjectsOfTypeAll<YanSaveIdentifier>();
    List<SerializedGameObject> serializedGameObjectList = new List<SerializedGameObject>();
    foreach (YanSaveIdentifier yanSaveIdentifier1 in objectsOfTypeAll)
    {
      List<SerializedComponent> serializedComponentList = new List<SerializedComponent>();
      foreach (Component component in yanSaveIdentifier1.gameObject.GetComponents(typeof (Component)))
      {
        if (yanSaveIdentifier1.EnabledComponents.Contains(component))
        {
          SerializedComponent serializedComponent = new SerializedComponent();
          serializedComponent.TypePath = ((object) component).GetType().AssemblyQualifiedName;
          serializedComponent.PropertyReferences = new ReferenceDict();
          serializedComponent.PropertyValues = new ValueDict();
          serializedComponent.FieldReferences = new ReferenceDict();
          serializedComponent.FieldValues = new ValueDict();
          serializedComponent.FieldReferenceArrays = new ReferenceArrayDict();
          serializedComponent.PropertyReferenceArrays = new ReferenceArrayDict();
          if (typeof (MonoBehaviour).IsAssignableFrom(((object) component).GetType()))
          {
            serializedComponent.IsMonoBehaviour = true;
            serializedComponent.IsEnabled = ((Behaviour) component).enabled;
          }
          System.Type type = ((object) component).GetType();
          foreach (PropertyInfo cachedProperty in YanSave.GetCachedProperties(type))
          {
            if (cachedProperty.CanWrite && !cachedProperty.IsDefined(typeof (ObsoleteAttribute), true))
            {
              bool flag1 = false;
              foreach (DisabledYanSaveMember disabledProperty in yanSaveIdentifier1.DisabledProperties)
              {
                if ((UnityEngine.Object) disabledProperty.Component == (UnityEngine.Object) component && disabledProperty.Name == cachedProperty.Name)
                {
                  flag1 = true;
                  break;
                }
              }
              if (!flag1)
              {
                object source = cachedProperty.GetValue((object) component);
                bool flag2 = typeof (Component).IsAssignableFrom(cachedProperty.PropertyType);
                bool flag3 = cachedProperty.PropertyType == typeof (GameObject);
                bool isArray = cachedProperty.PropertyType.IsArray;
                bool flag4 = typeof (Component[]).IsAssignableFrom(cachedProperty.PropertyType);
                bool flag5 = typeof (GameObject[]).IsAssignableFrom(cachedProperty.PropertyType);
                if (source != null)
                {
                  try
                  {
                    if (!flag2 && !flag3)
                      serializedComponent.PropertyValues.Add(cachedProperty.Name, source);
                    else if (isArray)
                    {
                      List<string> stringList = new List<string>();
                      if (flag4)
                        stringList.AddRange(((IEnumerable<Component>) (Component[]) source).Select<Component, string>((Func<Component, string>) (x => !((UnityEngine.Object) x.GetComponent<YanSaveIdentifier>() != (UnityEngine.Object) null) ? string.Empty : x.GetComponent<YanSaveIdentifier>().ObjectID)));
                      else if (flag5)
                        stringList.AddRange(((IEnumerable<GameObject>) (GameObject[]) source).Select<GameObject, string>((Func<GameObject, string>) (x => !((UnityEngine.Object) x.GetComponent<YanSaveIdentifier>() != (UnityEngine.Object) null) ? string.Empty : x.GetComponent<YanSaveIdentifier>().ObjectID)));
                      serializedComponent.PropertyReferenceArrays.Add(cachedProperty.Name, stringList);
                    }
                    else
                    {
                      YanSaveIdentifier yanSaveIdentifier2 = flag2 ? ((Component) source).gameObject.GetComponent<YanSaveIdentifier>() : (flag3 ? ((GameObject) source).GetComponent<YanSaveIdentifier>() : (YanSaveIdentifier) null);
                      if ((UnityEngine.Object) yanSaveIdentifier2 != (UnityEngine.Object) null)
                        serializedComponent.PropertyReferences.Add(cachedProperty.Name, yanSaveIdentifier2.ObjectID);
                      else
                        serializedComponent.PropertyReferences.Add(cachedProperty.Name, (string) null);
                    }
                  }
                  catch
                  {
                  }
                }
              }
            }
          }
          foreach (FieldInfo cachedField in YanSave.GetCachedFields(type))
          {
            if (!cachedField.IsLiteral && !cachedField.IsDefined(typeof (ObsoleteAttribute), true))
            {
              bool flag6 = false;
              foreach (DisabledYanSaveMember disabledField in yanSaveIdentifier1.DisabledFields)
              {
                if ((UnityEngine.Object) disabledField.Component == (UnityEngine.Object) component && disabledField.Name == cachedField.Name)
                {
                  flag6 = true;
                  break;
                }
              }
              if (!flag6)
              {
                object source = cachedField.GetValue((object) component);
                bool flag7 = typeof (Component).IsAssignableFrom(cachedField.FieldType);
                bool flag8 = cachedField.FieldType == typeof (GameObject);
                bool isArray = cachedField.FieldType.IsArray;
                bool flag9 = typeof (Component[]).IsAssignableFrom(cachedField.FieldType);
                bool flag10 = typeof (GameObject[]).IsAssignableFrom(cachedField.FieldType);
                try
                {
                  if (!flag7 && !flag8 && !flag9 && !flag10)
                    serializedComponent.FieldValues.Add(cachedField.Name, source);
                  else if (isArray)
                  {
                    List<string> stringList = new List<string>();
                    if (flag9)
                      stringList.AddRange(((IEnumerable<Component>) (Component[]) source).Select<Component, string>((Func<Component, string>) (x => !((UnityEngine.Object) x.GetComponent<YanSaveIdentifier>() != (UnityEngine.Object) null) ? string.Empty : x.GetComponent<YanSaveIdentifier>().ObjectID)));
                    else if (flag10)
                      stringList.AddRange(((IEnumerable<GameObject>) (GameObject[]) source).Select<GameObject, string>((Func<GameObject, string>) (x => !((UnityEngine.Object) x.GetComponent<YanSaveIdentifier>() != (UnityEngine.Object) null) ? string.Empty : x.GetComponent<YanSaveIdentifier>().ObjectID)));
                    serializedComponent.FieldReferenceArrays.Add(cachedField.Name, stringList);
                  }
                  else
                  {
                    YanSaveIdentifier yanSaveIdentifier3 = flag7 ? ((Component) source).gameObject.GetComponent<YanSaveIdentifier>() : (flag8 ? ((GameObject) source).GetComponent<YanSaveIdentifier>() : (YanSaveIdentifier) null);
                    if ((UnityEngine.Object) yanSaveIdentifier3 != (UnityEngine.Object) null)
                      serializedComponent.FieldReferences.Add(cachedField.Name, yanSaveIdentifier3.ObjectID);
                    else
                      serializedComponent.FieldReferences.Add(cachedField.Name, (string) null);
                  }
                }
                catch
                {
                }
              }
            }
          }
          serializedComponent.OwnerID = yanSaveIdentifier1.ObjectID;
          serializedComponentList.Add(serializedComponent);
        }
      }
      SerializedGameObject serializedGameObject = new SerializedGameObject()
      {
        ActiveInHierarchy = yanSaveIdentifier1.gameObject.activeInHierarchy,
        ActiveSelf = yanSaveIdentifier1.gameObject.activeSelf,
        IsStatic = yanSaveIdentifier1.gameObject.isStatic,
        Layer = yanSaveIdentifier1.gameObject.layer,
        Tag = yanSaveIdentifier1.gameObject.tag,
        Name = yanSaveIdentifier1.gameObject.name,
        SerializedComponents = serializedComponentList.ToArray(),
        ObjectID = yanSaveIdentifier1.ObjectID
      };
      serializedGameObjectList.Add(serializedGameObject);
    }
    YanSaveStaticIdentifier objectOfType = UnityEngine.Object.FindObjectOfType<YanSaveStaticIdentifier>();
    List<SerializedStaticClass> serializedStaticClassList = new List<SerializedStaticClass>();
    ValueDict valueDict = new ValueDict();
    if ((UnityEngine.Object) objectOfType != (UnityEngine.Object) null)
    {
      foreach (string staticTypeName in objectOfType.StaticTypeNames)
      {
        System.Type type = YanSaveHelpers.GrabType(staticTypeName);
        if (type != (System.Type) null && type.IsAbstract && type.IsSealed)
        {
          SerializedStaticClass serializedStaticClass = new SerializedStaticClass();
          serializedStaticClass.TypePath = type.AssemblyQualifiedName;
          serializedStaticClass.PropertyReferences = new ReferenceDict();
          serializedStaticClass.PropertyValues = new ValueDict();
          serializedStaticClass.FieldReferences = new ReferenceDict();
          serializedStaticClass.FieldValues = new ValueDict();
          serializedStaticClass.FieldReferenceArrays = new ReferenceArrayDict();
          serializedStaticClass.PropertyReferenceArrays = new ReferenceArrayDict();
          foreach (PropertyInfo cachedProperty in YanSave.GetCachedProperties(type))
          {
            if (cachedProperty.CanWrite && !cachedProperty.IsDefined(typeof (ObsoleteAttribute), true))
            {
              bool flag11 = false;
              foreach (KeyValuePair<System.Type, string> disabledMember in objectOfType.DisabledMembers)
              {
                if (disabledMember.Value == cachedProperty.Name)
                {
                  flag11 = true;
                  break;
                }
              }
              if (!flag11)
              {
                object source = cachedProperty.GetValue((object) null, (object[]) null);
                bool flag12 = typeof (Component).IsAssignableFrom(cachedProperty.PropertyType);
                bool flag13 = cachedProperty.PropertyType == typeof (GameObject);
                bool isArray = cachedProperty.PropertyType.IsArray;
                bool flag14 = typeof (Component[]).IsAssignableFrom(cachedProperty.PropertyType);
                bool flag15 = typeof (GameObject[]).IsAssignableFrom(cachedProperty.PropertyType);
                if (source != null)
                {
                  try
                  {
                    if (!flag12 && !flag13)
                      serializedStaticClass.PropertyValues.Add(cachedProperty.Name, source);
                    else if (isArray)
                    {
                      List<string> stringList = new List<string>();
                      if (flag14)
                        stringList.AddRange(((IEnumerable<Component>) (Component[]) source).Select<Component, string>((Func<Component, string>) (x => !((UnityEngine.Object) x.GetComponent<YanSaveIdentifier>() != (UnityEngine.Object) null) ? string.Empty : x.GetComponent<YanSaveIdentifier>().ObjectID)));
                      else if (flag15)
                        stringList.AddRange(((IEnumerable<GameObject>) (GameObject[]) source).Select<GameObject, string>((Func<GameObject, string>) (x => !((UnityEngine.Object) x.GetComponent<YanSaveIdentifier>() != (UnityEngine.Object) null) ? string.Empty : x.GetComponent<YanSaveIdentifier>().ObjectID)));
                      serializedStaticClass.PropertyReferenceArrays.Add(cachedProperty.Name, stringList);
                    }
                    else
                    {
                      YanSaveIdentifier yanSaveIdentifier = flag12 ? ((Component) source).gameObject.GetComponent<YanSaveIdentifier>() : (flag13 ? ((GameObject) source).GetComponent<YanSaveIdentifier>() : (YanSaveIdentifier) null);
                      if ((UnityEngine.Object) yanSaveIdentifier != (UnityEngine.Object) null)
                        serializedStaticClass.PropertyReferences.Add(cachedProperty.Name, yanSaveIdentifier.ObjectID);
                      else
                        serializedStaticClass.PropertyReferences.Add(cachedProperty.Name, (string) null);
                    }
                  }
                  catch
                  {
                  }
                }
              }
            }
          }
          foreach (FieldInfo cachedField in YanSave.GetCachedFields(type))
          {
            if (!cachedField.IsLiteral && !cachedField.IsDefined(typeof (ObsoleteAttribute), true))
            {
              bool flag16 = false;
              foreach (KeyValuePair<System.Type, string> disabledMember in objectOfType.DisabledMembers)
              {
                if (disabledMember.Value == cachedField.Name)
                {
                  flag16 = true;
                  break;
                }
              }
              if (!flag16)
              {
                object source = cachedField.GetValue((object) null);
                bool flag17 = typeof (Component).IsAssignableFrom(cachedField.FieldType);
                bool flag18 = cachedField.FieldType == typeof (GameObject);
                bool isArray = cachedField.FieldType.IsArray;
                bool flag19 = typeof (Component[]).IsAssignableFrom(cachedField.FieldType);
                bool flag20 = typeof (GameObject[]).IsAssignableFrom(cachedField.FieldType);
                try
                {
                  if (!flag17 && !flag18 && !flag19 && !flag20)
                    serializedStaticClass.FieldValues.Add(cachedField.Name, source);
                  else if (isArray)
                  {
                    List<string> stringList = new List<string>();
                    if (flag19)
                      stringList.AddRange(((IEnumerable<Component>) (Component[]) source).Select<Component, string>((Func<Component, string>) (x => !((UnityEngine.Object) x.GetComponent<YanSaveIdentifier>() != (UnityEngine.Object) null) ? string.Empty : x.GetComponent<YanSaveIdentifier>().ObjectID)));
                    else if (flag20)
                      stringList.AddRange(((IEnumerable<GameObject>) (GameObject[]) source).Select<GameObject, string>((Func<GameObject, string>) (x => !((UnityEngine.Object) x.GetComponent<YanSaveIdentifier>() != (UnityEngine.Object) null) ? string.Empty : x.GetComponent<YanSaveIdentifier>().ObjectID)));
                    serializedStaticClass.FieldReferenceArrays.Add(cachedField.Name, stringList);
                  }
                  else
                  {
                    YanSaveIdentifier yanSaveIdentifier = flag17 ? ((Component) source).gameObject.GetComponent<YanSaveIdentifier>() : (flag18 ? ((GameObject) source).GetComponent<YanSaveIdentifier>() : (YanSaveIdentifier) null);
                    if ((UnityEngine.Object) yanSaveIdentifier != (UnityEngine.Object) null)
                      serializedStaticClass.FieldReferences.Add(cachedField.Name, yanSaveIdentifier.ObjectID);
                    else
                      serializedStaticClass.FieldReferences.Add(cachedField.Name, (string) null);
                  }
                }
                catch
                {
                }
              }
            }
          }
          serializedStaticClassList.Add(serializedStaticClass);
        }
      }
      foreach (YanSavePlayerPrefTracker prefTracker in objectOfType.PrefTrackers)
      {
        string str = prefTracker.PrefFormat;
        YanSavePlayerPrefsType prefType = prefTracker.PrefType;
        for (int index1 = 0; index1 < prefTracker.RangeMax + 1; ++index1)
        {
          for (int index2 = 0; index2 < prefTracker.PrefFormatValues.Count; ++index2)
          {
            string prefFormatValue = prefTracker.PrefFormatValues[index2];
            int length = prefFormatValue.LastIndexOf('.');
            System.Type type = YanSaveHelpers.GrabType(prefFormatValue.Substring(0, length));
            string empty = string.Empty;
            FieldInfo field = type.GetField(prefFormatValue.Substring(length + 1));
            PropertyInfo property = type.GetProperty(prefFormatValue.Substring(length + 1));
            if (property != (PropertyInfo) null)
              empty = property.GetValue((object) null, (object[]) null).ToString();
            else if (field != (FieldInfo) null)
              empty = field.GetValue((object) null).ToString();
            else
              Debug.Log((object) ("Couldn't grab replacement value of '" + prefFormatValue + "'"));
            str = str.Replace(string.Format("{{{0}}}", (object) index2), empty);
          }
          string key = str.Replace("{i}", index1.ToString());
          switch (prefType)
          {
            case YanSavePlayerPrefsType.Float:
              valueDict.Add(key, (object) PlayerPrefs.GetFloat(key));
              break;
            case YanSavePlayerPrefsType.Int:
              valueDict.Add(key, (object) PlayerPrefs.GetInt(key));
              break;
            case YanSavePlayerPrefsType.String:
              valueDict.Add(key, (object) PlayerPrefs.GetString(key));
              break;
          }
        }
      }
    }
    string contents = JsonConvert.SerializeObject((object) new YanSaveData()
    {
      LoadedLevelName = SceneManager.GetActiveScene().name,
      SerializedGameObjects = serializedGameObjectList.ToArray(),
      SerializedStaticClasses = serializedStaticClassList.ToArray(),
      SerializedPlayerPrefs = valueDict
    }, new JsonSerializerSettings()
    {
      ContractResolver = (IContractResolver) new YanSaveResolver(),
      Error = (EventHandler<Newtonsoft.Json.Serialization.ErrorEventArgs>) ((s, e) => e.ErrorContext.Handled = true)
    });
    if (!Directory.Exists(YanSave.SaveDataPath))
      Directory.CreateDirectory(YanSave.SaveDataPath);
    File.WriteAllText(Path.Combine(YanSave.SaveDataPath, targetSave + ".yansave"), contents);
    System.Action onSave = YanSave.OnSave;
    if (onSave == null)
      return;
    onSave();
  }

  public static void LoadData(string targetSave, bool recreateMissing = false)
  {
    if (!File.Exists(Path.Combine(YanSave.SaveDataPath, targetSave + ".yansave")))
      return;
    YanSaveData yanSaveData = JsonConvert.DeserializeObject<YanSaveData>(File.ReadAllText(Path.Combine(YanSave.SaveDataPath, targetSave + ".yansave")));
    if (SceneManager.GetActiveScene().name != yanSaveData.LoadedLevelName)
      SceneManager.LoadScene(yanSaveData.LoadedLevelName);
    foreach (SerializedGameObject serializedGameObject in yanSaveData.SerializedGameObjects)
    {
      GameObject gameObject = YanSaveIdentifier.GetObject(serializedGameObject);
      if ((UnityEngine.Object) gameObject == (UnityEngine.Object) null)
      {
        if (recreateMissing)
        {
          gameObject = new GameObject();
          gameObject.AddComponent<YanSaveIdentifier>().ObjectID = serializedGameObject.ObjectID;
          gameObject.SetActive(serializedGameObject.ActiveSelf);
        }
        else
          continue;
      }
      gameObject.isStatic = serializedGameObject.IsStatic;
      gameObject.layer = serializedGameObject.Layer;
      gameObject.tag = serializedGameObject.Tag;
      gameObject.name = serializedGameObject.Name;
      gameObject.SetActive(serializedGameObject.ActiveSelf);
      foreach (SerializedComponent serializedComponent in serializedGameObject.SerializedComponents)
      {
        if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
        {
          System.Type type = YanSave.GetType(serializedComponent.TypePath);
          if (recreateMissing && (UnityEngine.Object) gameObject.GetComponent(type) == (UnityEngine.Object) null)
            gameObject.AddComponent(type);
        }
      }
    }
    foreach (SerializedGameObject serializedGameObject in yanSaveData.SerializedGameObjects)
    {
      GameObject gameObject1 = YanSaveIdentifier.GetObject(serializedGameObject);
      if (!((UnityEngine.Object) gameObject1 == (UnityEngine.Object) null))
      {
        foreach (SerializedComponent serializedComponent in serializedGameObject.SerializedComponents)
        {
          System.Type type = YanSave.GetType(serializedComponent.TypePath);
          Component component1 = gameObject1.GetComponent(type);
          gameObject1.GetComponent<YanSaveIdentifier>();
          if (!((UnityEngine.Object) component1 == (UnityEngine.Object) null))
          {
            if (serializedComponent.IsMonoBehaviour)
              ((Behaviour) component1).enabled = serializedComponent.IsEnabled;
            foreach (PropertyInfo cachedProperty in YanSave.GetCachedProperties(type))
            {
              if (cachedProperty.CanWrite)
              {
                bool flag1 = typeof (Component).IsAssignableFrom(cachedProperty.PropertyType);
                if (!flag1 && cachedProperty.PropertyType != typeof (GameObject))
                {
                  if (serializedComponent.PropertyValues.ContainsKey(cachedProperty.Name))
                  {
                    object propertyValue = serializedComponent.PropertyValues[cachedProperty.Name];
                    if (propertyValue == null)
                      cachedProperty.SetValue((object) component1, (object) null);
                    else if (propertyValue.GetType() == typeof (JObject))
                    {
                      try
                      {
                        cachedProperty.SetValue((object) component1, ((JToken) propertyValue).ToObject(cachedProperty.PropertyType));
                      }
                      catch
                      {
                      }
                    }
                    else if (propertyValue.GetType() == typeof (JArray))
                    {
                      try
                      {
                        cachedProperty.SetValue((object) component1, ((JToken) propertyValue).ToObject(cachedProperty.PropertyType));
                      }
                      catch
                      {
                      }
                    }
                    else
                    {
                      bool isEnum = cachedProperty.PropertyType.IsEnum;
                      bool flag2 = typeof (IConvertible).IsAssignableFrom(propertyValue.GetType());
                      cachedProperty.SetValue((object) component1, isEnum ? Enum.ToObject(cachedProperty.PropertyType, propertyValue) : (flag2 ? Convert.ChangeType(propertyValue, cachedProperty.PropertyType) : propertyValue));
                    }
                  }
                }
                else if (serializedComponent.PropertyReferences.ContainsKey(cachedProperty.Name))
                {
                  bool flag3 = cachedProperty.PropertyType == typeof (GameObject);
                  GameObject gameObject2 = YanSaveIdentifier.GetObject(serializedComponent.FieldReferences[cachedProperty.Name]);
                  if (!((UnityEngine.Object) gameObject2 == (UnityEngine.Object) null))
                  {
                    if (flag1)
                      cachedProperty.SetValue((object) component1, (object) gameObject2.GetComponent(cachedProperty.PropertyType));
                    else if (flag3)
                      cachedProperty.SetValue((object) component1, (object) gameObject2);
                  }
                }
                else if (serializedComponent.PropertyReferenceArrays.ContainsKey(cachedProperty.Name))
                {
                  int num = typeof (Component[]).IsAssignableFrom(cachedProperty.PropertyType) ? 1 : 0;
                  bool flag4 = typeof (GameObject[]).IsAssignableFrom(cachedProperty.PropertyType);
                  List<string> propertyReferenceArray = serializedComponent.PropertyReferenceArrays[cachedProperty.Name];
                  System.Type elementType = cachedProperty.PropertyType.GetElementType();
                  if (num != 0)
                  {
                    IList instance = (IList) Array.CreateInstance(elementType, propertyReferenceArray.Count);
                    for (int index = 0; index < propertyReferenceArray.Count; ++index)
                    {
                      GameObject gameObject3 = YanSaveIdentifier.GetObject(propertyReferenceArray[index]);
                      Component component2 = (UnityEngine.Object) gameObject3 != (UnityEngine.Object) null ? gameObject3.GetComponent(elementType) : (Component) null;
                      instance[index] = (object) component2;
                    }
                    cachedProperty.SetValue((object) component1, (object) instance);
                  }
                  else if (flag4)
                  {
                    IList instance = (IList) Array.CreateInstance(elementType, propertyReferenceArray.Count);
                    for (int index = 0; index < propertyReferenceArray.Count; ++index)
                    {
                      GameObject gameObject4 = YanSaveIdentifier.GetObject(propertyReferenceArray[index]);
                      instance[index] = (object) gameObject4;
                    }
                    cachedProperty.SetValue((object) component1, (object) instance);
                  }
                }
              }
            }
            foreach (FieldInfo cachedField in YanSave.GetCachedFields(type))
            {
              bool flag5 = typeof (Component).IsAssignableFrom(cachedField.FieldType);
              bool flag6 = typeof (Component[]).IsAssignableFrom(cachedField.FieldType);
              bool flag7 = typeof (GameObject[]).IsAssignableFrom(cachedField.FieldType);
              if (!flag6 && !flag7 && !flag5 && cachedField.FieldType != typeof (GameObject))
              {
                if (serializedComponent.FieldValues.ContainsKey(cachedField.Name))
                {
                  object fieldValue = serializedComponent.FieldValues[cachedField.Name];
                  if (fieldValue == null)
                    cachedField.SetValue((object) component1, (object) null);
                  else if (fieldValue.GetType() == typeof (JObject))
                  {
                    try
                    {
                      cachedField.SetValue((object) component1, ((JToken) fieldValue).ToObject(cachedField.FieldType));
                    }
                    catch
                    {
                    }
                  }
                  else if (fieldValue.GetType() == typeof (JArray))
                  {
                    try
                    {
                      cachedField.SetValue((object) component1, ((JToken) fieldValue).ToObject(cachedField.FieldType));
                    }
                    catch
                    {
                    }
                  }
                  else
                  {
                    bool isEnum = cachedField.FieldType.IsEnum;
                    bool flag8 = typeof (IConvertible).IsAssignableFrom(fieldValue.GetType());
                    cachedField.SetValue((object) component1, isEnum ? Enum.ToObject(cachedField.FieldType, fieldValue) : (flag8 ? Convert.ChangeType(fieldValue, cachedField.FieldType) : fieldValue));
                  }
                }
              }
              else if (serializedComponent.FieldReferences.ContainsKey(cachedField.Name))
              {
                bool flag9 = cachedField.FieldType == typeof (GameObject);
                GameObject gameObject5 = YanSaveIdentifier.GetObject(serializedComponent.FieldReferences[cachedField.Name]);
                if (!((UnityEngine.Object) gameObject5 == (UnityEngine.Object) null))
                {
                  if (flag5)
                    cachedField.SetValue((object) component1, (object) gameObject5.GetComponent(cachedField.FieldType));
                  else if (flag9)
                    cachedField.SetValue((object) component1, (object) gameObject5);
                }
              }
              else if (serializedComponent.FieldReferenceArrays.ContainsKey(cachedField.Name))
              {
                List<string> fieldReferenceArray = serializedComponent.FieldReferenceArrays[cachedField.Name];
                System.Type elementType = cachedField.FieldType.GetElementType();
                if (flag6)
                {
                  IList instance = (IList) Array.CreateInstance(elementType, fieldReferenceArray.Count);
                  for (int index = 0; index < fieldReferenceArray.Count; ++index)
                  {
                    GameObject gameObject6 = YanSaveIdentifier.GetObject(fieldReferenceArray[index]);
                    Component component3 = (UnityEngine.Object) gameObject6 != (UnityEngine.Object) null ? gameObject6.GetComponent(elementType) : (Component) null;
                    instance[index] = (object) component3;
                  }
                  cachedField.SetValue((object) component1, (object) instance);
                }
                else if (flag7)
                {
                  IList instance = (IList) Array.CreateInstance(elementType, fieldReferenceArray.Count);
                  for (int index = 0; index < fieldReferenceArray.Count; ++index)
                  {
                    GameObject gameObject7 = YanSaveIdentifier.GetObject(fieldReferenceArray[index]);
                    instance[index] = (object) gameObject7;
                  }
                  cachedField.SetValue((object) component1, (object) instance);
                }
              }
            }
          }
        }
      }
    }
    foreach (SerializedStaticClass serializedStaticClass in yanSaveData.SerializedStaticClasses)
    {
      System.Type type = YanSave.GetType(serializedStaticClass.TypePath);
      if (!(type == (System.Type) null))
      {
        foreach (PropertyInfo property in type.GetProperties())
        {
          if (property.CanWrite)
          {
            bool flag10 = typeof (Component).IsAssignableFrom(property.PropertyType);
            if (!flag10 && property.PropertyType != typeof (GameObject))
            {
              if (serializedStaticClass.PropertyValues.ContainsKey(property.Name))
              {
                object propertyValue = serializedStaticClass.PropertyValues[property.Name];
                if (propertyValue == null)
                  property.SetValue((object) null, (object) null);
                else if (propertyValue.GetType() == typeof (JObject))
                {
                  try
                  {
                    property.SetValue((object) null, ((JToken) propertyValue).ToObject(property.PropertyType));
                  }
                  catch
                  {
                  }
                }
                else if (propertyValue.GetType() == typeof (JArray))
                {
                  try
                  {
                    property.SetValue((object) null, ((JToken) propertyValue).ToObject(property.PropertyType));
                  }
                  catch
                  {
                  }
                }
                else
                {
                  bool isEnum = property.PropertyType.IsEnum;
                  bool flag11 = typeof (IConvertible).IsAssignableFrom(propertyValue.GetType());
                  property.SetValue((object) null, isEnum ? Enum.ToObject(property.PropertyType, propertyValue) : (flag11 ? Convert.ChangeType(propertyValue, property.PropertyType) : propertyValue));
                }
              }
            }
            else if (serializedStaticClass.PropertyReferences.ContainsKey(property.Name))
            {
              bool flag12 = property.PropertyType == typeof (GameObject);
              GameObject gameObject = YanSaveIdentifier.GetObject(serializedStaticClass.FieldReferences[property.Name]);
              if (!((UnityEngine.Object) gameObject == (UnityEngine.Object) null))
              {
                if (flag10)
                  property.SetValue((object) null, (object) gameObject.GetComponent(property.PropertyType));
                else if (flag12)
                  property.SetValue((object) null, (object) gameObject);
              }
            }
            else if (serializedStaticClass.PropertyReferenceArrays.ContainsKey(property.Name))
            {
              int num = typeof (Component[]).IsAssignableFrom(property.PropertyType) ? 1 : 0;
              bool flag13 = typeof (GameObject[]).IsAssignableFrom(property.PropertyType);
              List<string> propertyReferenceArray = serializedStaticClass.PropertyReferenceArrays[property.Name];
              System.Type elementType = property.PropertyType.GetElementType();
              if (num != 0)
              {
                IList instance = (IList) Array.CreateInstance(elementType, propertyReferenceArray.Count);
                for (int index = 0; index < propertyReferenceArray.Count; ++index)
                {
                  GameObject gameObject = YanSaveIdentifier.GetObject(propertyReferenceArray[index]);
                  Component component = (UnityEngine.Object) gameObject != (UnityEngine.Object) null ? gameObject.GetComponent(elementType) : (Component) null;
                  instance[index] = (object) component;
                }
                property.SetValue((object) null, (object) instance);
              }
              else if (flag13)
              {
                IList instance = (IList) Array.CreateInstance(elementType, propertyReferenceArray.Count);
                for (int index = 0; index < propertyReferenceArray.Count; ++index)
                {
                  GameObject gameObject = YanSaveIdentifier.GetObject(propertyReferenceArray[index]);
                  instance[index] = (object) gameObject;
                }
                property.SetValue((object) null, (object) instance);
              }
            }
          }
        }
        foreach (FieldInfo field in type.GetFields())
        {
          bool flag14 = typeof (Component).IsAssignableFrom(field.FieldType);
          bool flag15 = typeof (Component[]).IsAssignableFrom(field.FieldType);
          bool flag16 = typeof (GameObject[]).IsAssignableFrom(field.FieldType);
          if (!flag15 && !flag16 && !flag14 && field.FieldType != typeof (GameObject))
          {
            if (serializedStaticClass.FieldValues.ContainsKey(field.Name))
            {
              object fieldValue = serializedStaticClass.FieldValues[field.Name];
              if (fieldValue == null)
                field.SetValue((object) null, (object) null);
              else if (fieldValue.GetType() == typeof (JObject))
              {
                try
                {
                  field.SetValue((object) null, ((JToken) fieldValue).ToObject(field.FieldType));
                }
                catch
                {
                }
              }
              else if (fieldValue.GetType() == typeof (JArray))
              {
                try
                {
                  field.SetValue((object) null, ((JToken) fieldValue).ToObject(field.FieldType));
                }
                catch
                {
                }
              }
              else
              {
                bool isEnum = field.FieldType.IsEnum;
                bool flag17 = typeof (IConvertible).IsAssignableFrom(fieldValue.GetType());
                field.SetValue((object) null, isEnum ? Enum.ToObject(field.FieldType, fieldValue) : (flag17 ? Convert.ChangeType(fieldValue, field.FieldType) : fieldValue));
              }
            }
          }
          else if (serializedStaticClass.FieldReferences.ContainsKey(field.Name))
          {
            bool flag18 = field.FieldType == typeof (GameObject);
            GameObject gameObject = YanSaveIdentifier.GetObject(serializedStaticClass.FieldReferences[field.Name]);
            if (!((UnityEngine.Object) gameObject == (UnityEngine.Object) null))
            {
              if (flag14)
                field.SetValue((object) null, (object) gameObject.GetComponent(field.FieldType));
              else if (flag18)
                field.SetValue((object) null, (object) gameObject);
            }
          }
          else if (serializedStaticClass.FieldReferenceArrays.ContainsKey(field.Name))
          {
            List<string> fieldReferenceArray = serializedStaticClass.FieldReferenceArrays[field.Name];
            System.Type elementType = field.FieldType.GetElementType();
            if (flag15)
            {
              IList instance = (IList) Array.CreateInstance(elementType, fieldReferenceArray.Count);
              for (int index = 0; index < fieldReferenceArray.Count; ++index)
              {
                GameObject gameObject = YanSaveIdentifier.GetObject(fieldReferenceArray[index]);
                Component component = (UnityEngine.Object) gameObject != (UnityEngine.Object) null ? gameObject.GetComponent(elementType) : (Component) null;
                instance[index] = (object) component;
              }
              field.SetValue((object) null, (object) instance);
            }
            else if (flag16)
            {
              IList instance = (IList) Array.CreateInstance(elementType, fieldReferenceArray.Count);
              for (int index = 0; index < fieldReferenceArray.Count; ++index)
              {
                GameObject gameObject = YanSaveIdentifier.GetObject(fieldReferenceArray[index]);
                instance[index] = (object) gameObject;
              }
              field.SetValue((object) null, (object) instance);
            }
          }
        }
      }
    }
    System.Action onLoad = YanSave.OnLoad;
    if (onLoad == null)
      return;
    onLoad();
  }

  public static void LoadPrefs(string targetSave)
  {
    foreach (KeyValuePair<string, object> serializedPlayerPref in (Dictionary<string, object>) JsonConvert.DeserializeObject<YanSaveData>(File.ReadAllText(Path.Combine(YanSave.SaveDataPath, targetSave + ".yansave"))).SerializedPlayerPrefs)
    {
      object obj = serializedPlayerPref.Value;
      System.Type type = obj.GetType();
      if (type == typeof (double) || type == typeof (float))
        PlayerPrefs.SetFloat(serializedPlayerPref.Key, (float) obj);
      else if (type == typeof (string))
        PlayerPrefs.SetString(serializedPlayerPref.Key, (string) obj);
      else if (type == typeof (short) || type == typeof (int) || type == typeof (long))
        PlayerPrefs.SetInt(serializedPlayerPref.Key, Convert.ToInt32(obj));
    }
  }

  public static void LoadAll(string targetSave)
  {
    YanSave.LoadData(targetSave);
    YanSave.LoadPrefs(targetSave);
  }

  public static void RemoveData(string targetSave)
  {
    string path = Path.Combine(YanSave.SaveDataPath, targetSave + ".yansave");
    try
    {
      if (!File.Exists(path))
        return;
      File.Delete(path);
    }
    catch
    {
    }
  }

  private static PropertyInfo[] GetCachedProperties(System.Type type)
  {
    if (YanSave.PropertyCache.ContainsKey(type))
      return YanSave.PropertyCache[type];
    YanSave.PropertyCache.Add(type, type.GetProperties());
    return YanSave.PropertyCache[type];
  }

  private static FieldInfo[] GetCachedFields(System.Type type)
  {
    if (YanSave.FieldCache.ContainsKey(type))
      return YanSave.FieldCache[type];
    FieldInfo[] fields = type.GetFields();
    YanSave.FieldCache.Add(type, fields);
    return fields;
  }

  private static System.Type GetType(string typeName)
  {
    System.Type type = System.Type.GetType(typeName);
    if (type != (System.Type) null)
      return type;
    Assembly assembly = Assembly.Load(typeName.Substring(0, typeName.IndexOf('.')));
    return assembly == (Assembly) null ? (System.Type) null : assembly.GetType(typeName);
  }
}
