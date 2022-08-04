// Decompiled with JetBrains decompiler
// Type: Club
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[Serializable]
public class Club
{
  [SerializeField]
  private ClubType type;
  public static readonly ClubTypeAndStringDictionary ClubNames;
  public static readonly IntAndStringDictionary TeacherClubNames;

  public Club(ClubType type) => this.type = type;

  public ClubType Type
  {
    get => this.type;
    set => this.type = value;
  }

  static Club()
  {
    ClubTypeAndStringDictionary stringDictionary1 = new ClubTypeAndStringDictionary();
    stringDictionary1.Add(ClubType.None, "No Club");
    stringDictionary1.Add(ClubType.Cooking, "Cooking");
    stringDictionary1.Add(ClubType.Drama, "Drama");
    stringDictionary1.Add(ClubType.Occult, "Occult");
    stringDictionary1.Add(ClubType.Art, "Art");
    stringDictionary1.Add(ClubType.LightMusic, "Light Music");
    stringDictionary1.Add(ClubType.MartialArts, "Martial Arts");
    stringDictionary1.Add(ClubType.Photography, "Photography");
    stringDictionary1.Add(ClubType.Science, "Science");
    stringDictionary1.Add(ClubType.Sports, "Sports");
    stringDictionary1.Add(ClubType.Gardening, "Gardening");
    stringDictionary1.Add(ClubType.Gaming, "Gaming");
    stringDictionary1.Add(ClubType.Council, "Student Council");
    stringDictionary1.Add(ClubType.Delinquent, "Delinquent");
    stringDictionary1.Add(ClubType.Bully, "No Club");
    stringDictionary1.Add(ClubType.Newspaper, "Newspaper");
    stringDictionary1.Add(ClubType.Nemesis, "?????");
    Club.ClubNames = stringDictionary1;
    IntAndStringDictionary stringDictionary2 = new IntAndStringDictionary();
    stringDictionary2.Add(0, "Gym Teacher");
    stringDictionary2.Add(1, "School Nurse");
    stringDictionary2.Add(2, "Guidance Counselor");
    stringDictionary2.Add(3, "Headmaster");
    stringDictionary2.Add(4, "?????");
    stringDictionary2.Add(11, "Teacher of Class 1-1");
    stringDictionary2.Add(12, "Teacher of Class 1-2");
    stringDictionary2.Add(21, "Teacher of Class 2-1");
    stringDictionary2.Add(22, "Teacher of Class 2-2");
    stringDictionary2.Add(31, "Teacher of Class 3-1");
    stringDictionary2.Add(32, "Teacher of Class 3-2");
    Club.TeacherClubNames = stringDictionary2;
  }
}
