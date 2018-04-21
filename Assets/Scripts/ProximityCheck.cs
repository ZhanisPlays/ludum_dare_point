using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Utility class for calculating the distance between two objects. Dont like this class though.
/// </summary>
public class ProximityCheck : MonoBehaviour {

	public float proximityDistance = .5f;
    GameObject player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag(Definitions.PLAYER);
    }

    public bool IsInProximity(Vector3 position) {
        return position.x - player.transform.position.x <= proximityDistance;
    }
}
