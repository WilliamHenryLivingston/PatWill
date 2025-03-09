using System.Runtime.InteropServices;
using UnityEngine;

public class TurretLineRenderer : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform weaponPoint;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Ray laserRay;
    [SerializeField] private RaycastHit hit;
    //[SerializeField] float distanceToHit = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray customRay = new Ray(weaponPoint.position, weaponPoint.forward);
        if (Physics.Raycast(customRay, out RaycastHit tempHit, maxDistance, layerMask))
        {
            if (tempHit.collider.CompareTag("Player"))
            {
                Debug.Log("Player in ray");
            }
            LaserLineRenderer(tempHit.point);
            Debug.DrawLine(weaponPoint.position, tempHit.point, Color.red);
        }
        else
        {
            //LaserLineRenderer(weaponPoint.position + weaponPoint.forward * maxDistance);
            lineRenderer.enabled = false;
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(weaponPoint.position, hit.point);
    }

    public void LaserLineRenderer(Vector3 endPoint)
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, weaponPoint.position);
        lineRenderer.SetPosition(1, endPoint);
    }
}
