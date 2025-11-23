using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    private KeyCode _switchKey = KeyCode.C;

    [SerializeField] private List<CinemachineVirtualCamera> _cameras;
    private int _currentCameraIndex;


    private void Start()
    {
        if (_cameras.Count > 0)
        {
            SwitchToCamera(0);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(_switchKey))
        {
            SwitchToNextCamera();
        }
    }

    public void SwitchToNextCamera()
    {
        _currentCameraIndex++;

        if (_currentCameraIndex >= _cameras.Count)
            _currentCameraIndex = 0;

        SwitchToCamera(_currentCameraIndex);
    }

    public void SwitchToCamera(int index)
    {
        for (int i = 0; i < _cameras.Count; i++)
        {
            _cameras[i].gameObject.SetActive(i == index);
        }

        _currentCameraIndex = index;
    }
}
