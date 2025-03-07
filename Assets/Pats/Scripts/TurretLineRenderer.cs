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
    [SerializeField] float distanceToHit = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        laserRay = new Ray(weaponPoint.position, weaponPoint.forward);
   
        Physics.Raycast(laserRay,out hit, maxDistance,layerMask);
        distanceToHit = hit.distance;

        if (hit.collider.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
        }
        else
        {
            Debug.Log("No Hits Registered");
        }

            lineRenderer.SetPosition(0, laserRay.origin);
        lineRenderer.SetPosition(1, hit.point);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(weaponPoint.position, hit.point);
    }
}
