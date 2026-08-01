using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_STANDALONE_WIN
using System;
using System.Runtime.InteropServices;
#endif

public class EventoEspecial : MonoBehaviour
{
    public Game gameManager;
    public ScriptableObject stateObjetivo;

    public float tiempoEspera = 2f;
    public string nombreArchivo = "mensaje.txt";
    [TextArea] public string contenidoArchivo;

    public string escenaAReabrir;

    private bool iniciado = false;

#if UNITY_STANDALONE_WIN
    private IntPtr ventanaJuego;
#endif

    void Update()
    {
        if (iniciado) return;

        if (gameManager != null && gameManager.GetCurrentState() == stateObjetivo)
        {
            iniciado = true;
            StartCoroutine(Secuencia());
        }
    }

    IEnumerator Secuencia()
    {
        yield return new WaitForSeconds(tiempoEspera);

        string ruta = CrearArchivoEnEscritorio();

        OcultarVentana();

        AbrirArchivo(ruta);

        yield return new WaitForSeconds(5f);

        MostrarVentanaEncima();

        SceneManager.LoadScene(escenaAReabrir);
    }

    string CrearArchivoEnEscritorio()
    {
        string escritorio = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        string ruta = Path.Combine(escritorio, nombreArchivo);

        File.WriteAllText(ruta, contenidoArchivo);
        Debug.Log("Archivo creado: " + ruta);

        return ruta;
    }

    void AbrirArchivo(string ruta)
    {
        System.Diagnostics.Process.Start(ruta);
    }

    void OcultarVentana()
    {
#if UNITY_STANDALONE_WIN
        ventanaJuego = GetActiveWindow();
        ShowWindow(ventanaJuego, 0); // 0 = ocultar completamente
#endif
    }

    void MostrarVentanaEncima()
    {
#if UNITY_STANDALONE_WIN
        if (ventanaJuego != IntPtr.Zero)
        {
            ShowWindow(ventanaJuego, 5); // mostrar

            // ?? Forzar siempre encima
            SetWindowPos(ventanaJuego, HWND_TOPMOST, 0, 0, 0, 0,
                SWP_NOMOVE | SWP_NOSIZE);

            SetForegroundWindow(ventanaJuego);
        }
#endif
    }

#if UNITY_STANDALONE_WIN

    static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

    const uint SWP_NOMOVE = 0x0002;
    const uint SWP_NOSIZE = 0x0001;

    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern bool SetWindowPos(
        IntPtr hWnd,
        IntPtr hWndInsertAfter,
        int X,
        int Y,
        int cx,
        int cy,
        uint uFlags);

#endif
}