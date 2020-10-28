using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] m_SpawnPoints;
    public GameObject m_EnemyPrefab;

    public float m_SpawnIntervalMin = 2f;
    public float m_SpawnIntervalMax = 6f;

    public int m_MinSpawnCount = 1;
    public int m_MaxSpawnCount = 4;

    public float m_SpawnCooldown = 0f;

    private void Start()
    {
        m_SpawnCooldown = Random.Range(m_SpawnIntervalMin, m_SpawnIntervalMax);
    }

    void Update()
    {
        if (m_SpawnCooldown <= 0)
        {
            int spawnCout = Random.Range(m_MinSpawnCount, m_MaxSpawnCount);

            List<int> spawnNums = new List<int>();
            for (int i = 0; i < spawnCout; i++)
            {
                int spawnNum;
                do
                {
                    spawnNum = Random.Range(0, m_SpawnPoints.Length);
                }
                while (spawnNums.Contains(spawnNum));

                spawnNums.Add(spawnNum);
            }

            //총알 생성
            //for(int i=0; i < m_FireMuzzles.count; i++)
            foreach (var spawnNum in spawnNums)
            {
                var eulerAngle = m_SpawnPoints[spawnNum].eulerAngles += Vector3.forward * Random.Range(-30f, 30f);

                GameObject bullet = GameObject.Instantiate(m_EnemyPrefab,
                    m_SpawnPoints[spawnNum].position, Quaternion.Euler( eulerAngle));  //불렛 생성.
            }
            m_SpawnCooldown = Random.Range(m_SpawnIntervalMin, m_SpawnIntervalMax);
        }
        m_SpawnCooldown -= Time.deltaTime;

    }
}
