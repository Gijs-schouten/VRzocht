using UnityEngine;

public class AroundTargetRotator : MonoBehaviour
{

    [SerializeField] private float _distance = 3;
    [SerializeField] private bool _autoRotate = true;
    private Vector3 _distanceMargin = new Vector3();
    
    public float Distance
    {
        get { return _distance; }
        set { _distance = value; }
    }
    
    [SerializeField] private Transform _target;
    
    public Transform Target 
    {
        get { return _target; }
        set { _target = value; }
    }
    

    void Update()
    {
        if (!_autoRotate)
        {
            return;
        }
        
        RotateAroundTarget();
    }

    public void RotateAroundTarget()
    {
        _distanceMargin = new Vector3(0, 0, Distance);
        transform.position = Target.position + _distanceMargin;
		        
        transform.RotateAround(Target.position, Vector3.up, Target.eulerAngles.y);
		transform.rotation = Target.rotation;
	}
}
