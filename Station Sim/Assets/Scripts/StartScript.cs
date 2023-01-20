using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public Animator transition;
    public void StartGame()
    {
        StartCoroutine(LoadLevel());
    }

    public IEnumerator LoadLevel() //Dit is helemaal prima, weet dat je ook functies kunt aanroepen vanuit de animator (ik vind dit overigens beter omdat je die calls niet terugziet in code)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}
