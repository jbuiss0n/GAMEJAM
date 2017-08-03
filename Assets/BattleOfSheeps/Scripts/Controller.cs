using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfSheeps
{
    public class Controller : MonoBehaviour
    {
        public GameObject Mountain1;
        public GameObject Mountain2;
        public GameObject Mountain3;

        public GameObject Tree1;
        public GameObject Tree2;
        public GameObject Tree3;

        public GameObject Ground;

        public float BackgroundSize;

        public float MountainSpeed;
        public float TreeSpeed;

        private GameObject[] m_moutains = new GameObject[3];
        private GameObject[] m_trees = new GameObject[3];

        void Start()
        {
            m_moutains[0] = Mountain1;
            m_moutains[1] = Mountain2;
            m_moutains[2] = Mountain3;

            m_trees[0] = Tree1;
            m_trees[1] = Tree2;
            m_trees[2] = Tree3;
        }

        void Update()
        {
            MoveBackground(m_moutains, MountainSpeed * -1);
            MoveBackground(m_trees, TreeSpeed * -1);

            CheckLeftBoundaries(m_moutains);
            CheckRightBoundaries(m_moutains);
            CheckLeftBoundaries(m_trees);
            CheckRightBoundaries(m_trees);
        }

        private void CheckLeftBoundaries(GameObject[] layers)
        {
            if (layers[2].transform.position.x > BackgroundSize * 1.5)
            {
                layers[2].transform.position = new Vector3(layers[0].transform.position.x - BackgroundSize, layers[0].transform.position.y, layers[0].transform.position.z);

                var offset = layers[2];
                layers[2] = layers[1];
                layers[1] = layers[0];
                layers[0] = offset;
            }
        }

        private void CheckRightBoundaries(GameObject[] layers)
        {
            if (layers[0].transform.position.x + BackgroundSize * 1.5 < 0)
            {
                layers[0].transform.position = new Vector3(layers[2].transform.position.x + BackgroundSize, layers[0].transform.position.y, layers[0].transform.position.z);

                var offset = layers[0];
                layers[0] = layers[1];
                layers[1] = layers[2];
                layers[2] = offset;
            }
        }

        private void MoveBackground(GameObject[] layers, float speed)
        {
            layers[0].transform.position = new Vector3(layers[0].transform.position.x + speed * Time.timeScale, layers[0].transform.position.y, layers[0].transform.position.z);
            layers[1].transform.position = new Vector3(layers[1].transform.position.x + speed * Time.timeScale, layers[1].transform.position.y, layers[1].transform.position.z);
            layers[2].transform.position = new Vector3(layers[2].transform.position.x + speed * Time.timeScale, layers[2].transform.position.y, layers[2].transform.position.z);
        }
    }
}
