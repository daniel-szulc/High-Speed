using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool optionsactive = false;
   public GameObject _options;
    private Vector3 _options_T;
    public GameObject camera;
    private Vector3 _camera_T;
    public GameObject logo;

    void Start()
    {
        _options_T=new Vector3(_options.transform.localPosition.x, _options.transform.localPosition.y, _options.transform.localPosition.z);
        _camera_T = new Vector3(camera.transform.localPosition.x, camera.transform.localPosition.y,
            camera.transform.localPosition.z);
    }

    public void OptionsClick()
    {
        if (!optionsactive)
        {
            StartCoroutine(Options());
            StartCoroutine(CameraMove());
        }
    }
    
    public void OptionsReturnClick()
    {
        if (optionsactive)
        {
            StartCoroutine(OptionsBack());
            StartCoroutine(CameraMoveBack());
        }
    }

    IEnumerator CameraMove()
    {
        Vector3 start = _camera_T;
        Vector3 des = new Vector3(-6, _camera_T.y, _camera_T.z);
        float fraction = 0;
        float speed = .33f;
        while (fraction < 1)
        {
            fraction += Time.deltaTime * speed;
            camera.transform.localPosition = Vector3.Lerp(start, des, fraction);
            yield return new WaitForSeconds(Time.deltaTime*0.001f);
        }
    }
    
    IEnumerator CameraMoveBack()
    {
        Vector3 start = new Vector3(camera.transform.localPosition.x, camera.transform.localPosition.y,
            camera.transform.localPosition.z);
        Vector3 des = _camera_T;
        float fraction = 0;
        float speed = .33f;
        while (fraction < 1)
        {
            fraction += Time.deltaTime * speed;
            camera.transform.localPosition = Vector3.Lerp(start, des, fraction);
            yield return new WaitForSeconds(Time.deltaTime*0.001f);
        }
    }

        IEnumerator Options()
    {
        optionsactive = true;
        Vector3 start = _options_T;
        Vector3 des = new Vector3(0, _options_T.y, _options_T.z);
        float fraction = 0;
        float speed = .33f;
       while (fraction < 1)
        {
            fraction += Time.deltaTime * speed;
            _options.transform.localPosition = Vector3.Lerp(start, des, fraction);
            yield return new WaitForSeconds(Time.deltaTime*0.001f);
        }
    }
        
        IEnumerator OptionsBack()
        {
            optionsactive = false;
            Vector3 start = new Vector3(_options.transform.localPosition.x, _options.transform.localPosition.y, _options.transform.localPosition.z);
            Vector3 des = _options_T;
            float fraction = 0;
            float speed = .33f;
            while (fraction < 1)
            {
                fraction += Time.deltaTime * speed;
                _options.transform.localPosition = Vector3.Lerp(start, des, fraction);
                yield return new WaitForSeconds(Time.deltaTime*0.001f);
            }
        }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameModeMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
