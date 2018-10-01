using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FPS
{
    public class TeammateController : MonoBehaviour
    {
        public static UnityAction<TeammateModel> OnTeammateSelected;

        private TeammateModel _currentTeammate;

        private float maxDistanceTeammateSelect = 10.0f;

        public void FollowThePlayer()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0));

            if (Physics.Raycast(ray, out hit, maxDistanceTeammateSelect))
            {
                TeammateModel teammate = hit.collider.GetComponent<TeammateModel>();

                if (_currentTeammate != teammate)
                {
                    this.SelectTeammate(teammate);
                }

                if (_currentTeammate)
                    _currentTeammate.SwitchFollow();
            }

        }
        
        public void MoveToPosition()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0));

            if(Physics.Raycast(ray, out hit))
            {
                if (_currentTeammate)
                    _currentTeammate.SetDesination(hit.point);
            }
        }

        public void SelectTeammate(TeammateModel teammate)
        {
            _currentTeammate = teammate;
                    if (OnTeammateSelected != null)
                        OnTeammateSelected(_currentTeammate);
        }
    }
}
