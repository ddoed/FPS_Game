using UnityEngine;

public class Spawner : MonoBehaviour
{
    // 생성할 슬라임 프리팹
    public GameObject slimePrefab;

    // 슬라임 생성 간격 (30초)
    public float spawnInterval = 1f;

    // 내부 타이머
    private float timer;

    void Update()
    {
        // 타이머 업데이트
        timer += Time.deltaTime;

        // 30초가 지나면 슬라임 생성
        if (timer >= spawnInterval)
        {
            SpawnSlime();
            timer = 0f; // 타이머 초기화
        }
    }

    void SpawnSlime()
    {
        // Spawner GameObject의 위치를 spawnPoint로 사용
        Vector3 spawnPosition = transform.position;

        // 슬라임을 Spawner 위치에 생성
        if (slimePrefab != null)
        {
            Instantiate(slimePrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("슬라임 프리팹이 설정되지 않았습니다.");
        }
    }
}
