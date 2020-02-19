using UnityEngine;

public class LineRendererPlayer : MonoBehaviour
{
    public Transform player;
    LineRenderer lr;
    Vector3[] positions = new Vector3[2];
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        positions[0] = player.position;
        positions[1] = new Vector3(mousePos.x, mousePos.y);
        lr.SetPositions(positions);
    }
}
