using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpscareSceneChanger : MonoBehaviour
{
    public string nombreEscena;

    void Start()
    {
        StartCoroutine(Cambiar());
    }

    IEnumerator Cambiar()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nombreEscena);
    }
}