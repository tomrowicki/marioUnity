using UnityEngine;

public class SideScrolling : MonoBehaviour
{
    private Transform player;

    private void Awake() 
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // this update takes place after all other updates
    private void LateUpdate() 
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = Mathf.Max(cameraPosition.x, player.position.x); // so camera only moves right
        transform.position = cameraPosition;
    }
}
