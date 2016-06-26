using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public float MoveSpeed = 5;

    float zoom=50, zMin=2, zMax=100, zBaze=50;

    bool zOut = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(1)) {
            float h = Input.GetAxis("Mouse X") * MoveSpeed;
            float v = Input.GetAxis("Mouse Y") * MoveSpeed;

            transform.position -= new Vector3(h, v, 0);
        }

        Zoom();
        Camera.main.orthographicSize = zoom;

        if (zOut) {
            if (zoom < zBaze-0.25f) {
                zoom = Mathf.Lerp(zoom, zBaze, Time.deltaTime * 5);
            }
            else {
                zOut = false;
            }
        }
	}

    public void Zoom() {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && zoom>zMin) {
            zoom -= 3;
            //MoveSpeed /= 1.1f;
        }else if (Input.GetAxis("Mouse ScrollWheel") < 0 && zoom<zMax) {
            zoom += 3;
            //MoveSpeed *= 1.1f;
        }
    }

    public void LerpZoom() {
        zoom = Mathf.Lerp(zoom, zMin, Time.deltaTime*5);
    }

    public void zoomOut() {
        zOut = true;
    }
}
