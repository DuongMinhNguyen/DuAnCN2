using UnityEngine;
using Unity.Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineCamera VCam1;
    public CinemachineCamera VCam2;
    public CinemachineCamera VCam3;

    void Start()
    {
        SetActiveCamera(VCam1); // Mặc định chọn VCam1
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetActiveCamera(VCam1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetActiveCamera(VCam2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetActiveCamera(VCam3);
        }
    }

    void SetActiveCamera(CinemachineCamera activeCam)
    {
        VCam1.Priority = (activeCam == VCam1) ? 10 : 5;
        VCam2.Priority = (activeCam == VCam2) ? 10 : 5;
        VCam3.Priority = (activeCam == VCam3) ? 10 : 5;
    }
}