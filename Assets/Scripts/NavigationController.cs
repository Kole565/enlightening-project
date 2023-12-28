using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NavigationController : MonoBehaviour {

    private SceneController missionController;

    [SerializeField]
    private RectTransform marker;
    [SerializeField]
    private GameObject navigationMenu;
    [SerializeField]
    private StarsMinigameController minigame;

    [SerializeField]
    public Vector2[] waypoints;
    private int aimWaypointIndex = 0;

    [SerializeField]
    public float navigationDuration;
    private bool isNavigationActive;

    private float routeLength;
    private float markerSpeed;


    void Start () {
        missionController = GetComponent<SceneController>();
        
        CalculateRouteLength();
        CalculateMarkerSpeed();
    }

    void CalculateRouteLength () {
        Vector2 lastWaypoint = waypoints[0];

        foreach (Vector2 waypoint in waypoints) {
            float distance = Vector2.Distance(waypoint, lastWaypoint);

            routeLength += distance;

            lastWaypoint = waypoint;
        }

        routeLength += Vector2.Distance(marker.anchoredPosition, waypoints[0]);
    }

    void CalculateMarkerSpeed () {
        markerSpeed = routeLength / navigationDuration;
    }

    void Update () {
        if (isNavigationActive) {
            MarkerUpdate();
        }
    }

    void MarkerUpdate () {
        if (aimWaypointIndex >= waypoints.Length) {
            End();
            return;
        }

        if (Vector2.Distance(marker.anchoredPosition, waypoints[aimWaypointIndex]) < 1) {
            aimWaypointIndex++;
        }

        if (aimWaypointIndex >= waypoints.Length) {
            End();
            return;
        }

        Vector2 direction = waypoints[aimWaypointIndex] - marker.anchoredPosition;
        
        direction.Normalize();
        direction *= markerSpeed;

        marker.anchoredPosition += direction * Time.deltaTime;
    }

    void End () {
        StartCoroutine(missionController.LoadNextScene());
        navigationMenu.SetActive(false);
    }

    public void StartNavigation () {
        if (!minigame.isSolved) {
            return;
        }

        isNavigationActive = true;
    }

    public void SwitchMenu () {
        navigationMenu.SetActive(!navigationMenu.activeSelf);
    }

}
