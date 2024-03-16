using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public void Salir()
    {
        Application.Quit();
    }

    public void Jugar(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void Borrar()
    {
        BlockSpawner.instance.BorrarRecord();
    }
}
