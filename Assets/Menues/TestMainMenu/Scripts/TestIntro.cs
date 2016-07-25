using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestIntro : MonoBehaviour
{
    SocialManager sm;

    bool nameDone = false;
    bool photoDone = false;
    bool idDone = false;

    void Start()
    {
        sm = FindObjectOfType<SocialManager>();
        sm.getName();
    }

    void Update()
    {
        if (sm.isHaveName && !nameDone)
        {
            nameDone = true;
            sm.getPhoto();
        }
        else if(sm.isHavePhoto && !photoDone)
        {
            photoDone = true;
            sm.getID();
        }
        else if(sm.isHaveID && !idDone)
        {
            idDone = true;
            sm.LoadProfile();
        }
    }
}
