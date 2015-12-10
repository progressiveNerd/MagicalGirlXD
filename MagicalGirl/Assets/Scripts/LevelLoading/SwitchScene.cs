using UnityEngine;
using System.Collections;

public class SwitchScene : MonoBehaviour
{
    public void changeScene(int sceneToChangeTo)
    {
        Application.LoadLevel(sceneToChangeTo);
    }
}
