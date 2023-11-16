using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IrParaMenu : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("Menu Inicial", LoadSceneMode.Single);
    }
}
