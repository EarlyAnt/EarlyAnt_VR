using RootMotion;
using UnityEngine;

public class Observer2 : MonoBehaviour
{
    /************************************************属性与变量命名************************************************/
    [SerializeField]
    private Transform camera;
    /************************************************Unity方法与事件***********************************************/
    void Start()
    {
        Input.gyro.enabled = true;//打开陀螺仪权限
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Input.gyro.updateInterval = 0.02f;
    }
    void Update()
    {
        this.camera.transform.localRotation = CameraRotation();
    }
    /************************************************自 定 义 方 法************************************************/
    Quaternion CameraRotation()
    {
        Quaternion input = Input.gyro.attitude;
        input = Quaternion.Euler(90, 0, 0) * (new Quaternion(-input.x, -input.y, input.z, input.w));
        return input;
    }
}
