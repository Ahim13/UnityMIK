using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] private GameObject _head;
    [SerializeField] private GameObject _pipe;
    [SerializeField] private GameObject _pipeEnd;

    [SerializeField] private float _headRotateSpeed = 2;
    [SerializeField] private float _pipeRotateSpeed = 2;
    [SerializeField] private float _powerToAdd = 100;
    [SerializeField] private float _maxPower = 100;

    [SerializeField] private GameObject projectile;
    [SerializeField] private float _power = 0.0F;
    
    
    [SerializeField] private float _timeStep = 0.2F;
    [SerializeField] private float _maxTime = 10F;

    private float _rotationX = 0.0f;
    private float _rotationY = 0.0f;

    private LineRenderer _lineRenderer;

    private void Start()
    {
        _rotationY = _pipe.transform.eulerAngles.x;
        _power = 0;

        _lineRenderer = GetComponent<LineRenderer>();
       
    }

    void Update()
    {
        #region Alternative

//        if (Input.GetKey(KeyCode.D))
//        {
//            _head.transform.Rotate(new Vector3(0, _headRotateSpeed, 0), Space.World);
//        }
//
//        if (Input.GetKey(KeyCode.A))
//        {
//            _head.transform.Rotate(new Vector3(0, -_headRotateSpeed, 0), Space.World);
//        }
//
//        if (Input.GetKey(KeyCode.W))
//        {
//            _pipe.transform.Rotate(new Vector3(-_pipeRotateSpeed, 0, 0), Space.Self);
//        }
//
//        if (Input.GetKey(KeyCode.S))
//        {
//            _pipe.transform.Rotate(new Vector3(_pipeRotateSpeed, 0, 0), Space.Self);
//        }

        #endregion

        _rotationX = Mathf.Clamp(_rotationX + Input.GetAxis("Horizontal") * _headRotateSpeed, -25, 25);
        _head.transform.eulerAngles = new Vector3(0.0f, _rotationX, 0f);
        _rotationY = Mathf.Clamp(_rotationY - Input.GetAxis("Vertical") * _pipeRotateSpeed, 20, 90);
        _pipe.transform.eulerAngles = new Vector3(_rotationY, _pipe.transform.eulerAngles.y, _pipe.transform.eulerAngles.z);

        if (Input.GetMouseButton(0))
        {
            _power += Time.deltaTime * _powerToAdd;
            _power = Mathf.Clamp(_power, 0, _maxPower);

            PlotTrajectory(_pipeEnd.transform.position, _pipeEnd.transform.forward * _power, _timeStep, (_maxTime));
        }

        if (Input.GetMouseButtonUp(0))
        {
            GameObject projectileCopy = Instantiate(projectile, _pipeEnd.transform.position, transform.rotation);
            var newForce = _pipeEnd.transform.forward * _power;
//            projectileCopy.GetComponent<Rigidbody>().AddForce(newForce);
            projectileCopy.GetComponent<Rigidbody>().velocity = newForce;
            _power = Time.deltaTime;
            Destroy(projectileCopy, 7);
        }
    }


    public void PlotTrajectory(Vector3 start, Vector3 startVelocity, float timestep, float maxTime)
    {
        Vector3 prev = start;
        List<Vector3> arcArray = new List<Vector3>();
        arcArray.Add(prev);
        for (int i = 1;; i++)
        {
            float t = timestep * i;
            if (t > maxTime) break;
            Vector3 pos = PlotTrajectoryAtTime(start, startVelocity, t);
            if (Physics.Linecast(prev, pos)) break;
            Debug.DrawLine(prev, pos, Color.red);
            arcArray.Add(pos);
            prev = pos;
        }
        _lineRenderer.positionCount = arcArray.Count;
        _lineRenderer.SetPositions(arcArray.ToArray());
    }

    public Vector3 PlotTrajectoryAtTime(Vector3 start, Vector3 startVelocity, float time)
    {
        return start + startVelocity * time + Physics.gravity * time * time * 0.5f;
    }
}