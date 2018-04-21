using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    ProximityCheck proximityCheck;

    Camera mainCamera;

    private void Awake() {
        mainCamera = Camera.main;
    }

    private void Start() {
        proximityCheck = GameObject.FindObjectOfType<ProximityCheck>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            // Raycast into world
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                GameObject obj = hit.transform.gameObject;

                if (obj.tag == Tags.ITEM) {
                    if (proximityCheck.IsInProximity(obj.transform.position)) {
                        Item item = obj.GetComponent<Item>();

                        if (!item.isInInventory) {
                            EventManager.TriggerEvent(Events.ITEM_ACTION, new ItemActionMessage(item));
                        }
                    } else {
                        EventManager.TriggerEvent(
                            Events.PLAYER_MOVE,
                            new MovementMessage(
                                obj.transform.position.x,
                                proximityCheck.proximityDistance
                            )
                        );
                    }
                }
                // If we would need multiple levels, we would add a tag for the stairs
                // Check if we clicked on stairs, save that to state and check once movement
                // has finished

            } else {
                // Hit nothing, try to move there
                EventManager.TriggerEvent(Events.PLAYER_MOVE);
            }
        }
    }
}
