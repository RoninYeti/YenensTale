﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YenensTale {
    public class bugFirstMoves : MonoBehaviour {

        private UnityEngine.AI.NavMeshAgent navLook = null;
        public GameObject playerWhere = null;
        public Animator bugJump;
        //public Transform bugStartPoint;
        public Transform bugEndpoint;
        Vector3 heWent;
        Quaternion thataWay;

        void Start() {
            navLook = GetComponent<UnityEngine.AI.NavMeshAgent>();
            //transform.position = bugStartPoint.position;
            bugJump.SetTrigger("Bug Jump");
        }

        void FixedUpdate() {
            navLook.acceleration = 5;
            navLook.speed = 500;
            navLook.SetDestination(bugEndpoint.transform.position);
            //float distance = Vector3.Distance(playerWhere.transform.position, transform.position);
            //heWent was previously direction
            heWent = (bugEndpoint.transform.position - transform.position).normalized;
            //Bug turns and looks at (player's direction)
            thataWay = Quaternion.LookRotation(heWent);
            transform.rotation = Quaternion.Slerp(transform.rotation, thataWay, Time.deltaTime * 5.0f);
        }
    }
}
