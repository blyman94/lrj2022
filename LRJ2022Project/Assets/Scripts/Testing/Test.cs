using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Test",
  fileName = "Tester")]
public class Test : ScriptableObject
{
  public string TestString;
  public void TestFunction()
  {
    Debug.Log(TestString);
  }
}
