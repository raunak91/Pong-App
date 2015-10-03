using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour {
    public float standardForce;
    public float upForce;

    private bool firstForceFlag = true;
    private bool forceRightFlag = false;
    private bool forceLeftFlag = false;

    void Awake() {
        
    }
    
	void Start () {
	}

	void Update () {
        if (firstForceFlag) {
            if (Input.GetKeyDown(KeyCode.Z)) {
                this.gameObject.GetComponent<Rigidbody>().useGravity = true;
                this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, standardForce));
                firstForceFlag = false;
            }
        } else {
            if (forceRightFlag) {
                this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, upForce, 2 * standardForce));
                this.forceRightFlag = false;
            }

            if (forceLeftFlag) {
                this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, upForce, -2 * standardForce));
                this.forceLeftFlag = false;
            }

            if (Input.GetKeyDown(KeyCode.Z)) {
                this.forceRightFlag = true;
            }

            if (Input.GetKeyDown(KeyCode.Period)) {
                this.forceLeftFlag = true;
            }
        }
	}
}
