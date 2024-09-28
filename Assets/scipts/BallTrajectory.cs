using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrajectory : MonoBehaviour
{
    [SerializeField] private GameObject player, target;
    [SerializeField] private float Launchtime = 2f;  
    [SerializeField] private Rigidbody rb;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchProjectile();
        }
    }   
    private void LaunchProjectile()
    {
        Vector3 V = LaunchVel(player.transform.position, target.transform.position, Launchtime);
        rb.velocity = V;  
    }

    private Vector3 LaunchVel(Vector3 startP, Vector3 targetP, float time)
    {
        Vector3 dis = targetP - startP; 
        Vector3 horizonDis = new Vector3(dis.x, 0, dis.z);
        Vector3 V = horizonDis / time;
        float verticalV = (dis.y + 0.5f * Mathf.Abs(Physics.gravity.y) * time * time) / time;
        V.y = verticalV;
        return V;
    }
}
