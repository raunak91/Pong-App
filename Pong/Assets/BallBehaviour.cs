using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour {
    public Vector3 startingPosition;

	void Start () {
        this.transform.position = this.startingPosition;
	}
}
