using Fusion;
using Unity.Cinemachine;
using UnityEngine;

public class CameraFollow : MonoBehaviour   
{
    //public CinemachineVirtualCamera virtualCamera;
    //Sửa thành CinemachineCamera thay vì CinemachineVirtualCamera
    public CinemachineCamera virtualCamera;
    /*//private CinemachineFramingTransposer cinemachineFramingTransposer;
    //Sửa thành CinemachineFollow (thay cho FramingTransposer trong phiên bản mới)
    //private CinemachineFollow cinemachineFollow;
    private CinemachinePositionComposer positionComposer;*/
    public CinemachineCamera VCam1;
    public CinemachineCamera VCam2;
    public CinemachineCamera VCam3;


    public void AssignCamera(Transform playerTransform)
    {
        // Gán mục tiêu Follow và LookAt cho camera
        virtualCamera.Follow = playerTransform;
        virtualCamera.LookAt = playerTransform;
    }
    
    /*void Start()
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
    }*/

    
    /*
    private void Start()
    {
        //cinemachineFollow = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body) as CinemachineFollow;
        // Lấy component Position Composer từ Virtual Camera
        positionComposer = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body) as CinemachinePositionComposer;

        if (positionComposer == null)
        {
            Debug.LogError("CinemachinePositionComposer không được tìm thấy trong Virtual Camera!");
        }
    }


    private void Update()
    {
        //if (cinemachineFollow == null)
        //    return;

        //float scroll = Input.GetAxis("Mouse ScrollWheel");

        //// 4. Sử dụng property CameraDistance thay vì m_CameraDistance
        //cinemachineFollow.CameraDistance -= scroll * 5f; // Nhân tốc độ zoom
        //cinemachineFollow.CameraDistance = Mathf.Clamp(cinemachineFollow.CameraDistance, 2f, 10f);
        if (positionComposer != null)
        {
            // Lấy giá trị cuộn chuột
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            // Điều chỉnh khoảng cách camera bằng cách thay đổi giá trị Z của TargetOffset
            Vector3 offset = positionComposer.TargetOffset;
            offset.z -= scroll * 5f; // Nhân tốc độ zoom
            offset.z = Mathf.Clamp(offset.z, -10f, -2f); // Giới hạn khoảng cách Z
            positionComposer.TargetOffset = offset; // Gán lại giá trị mới
        }
    }*/
}

