using UnityEngine;

public class Spawner : MonoBehaviour
{
    // ������ ������ ������
    public GameObject slimePrefab;

    // ������ ���� ���� (30��)
    public float spawnInterval = 1f;

    // ���� Ÿ�̸�
    private float timer;

    void Update()
    {
        // Ÿ�̸� ������Ʈ
        timer += Time.deltaTime;

        // 30�ʰ� ������ ������ ����
        if (timer >= spawnInterval)
        {
            SpawnSlime();
            timer = 0f; // Ÿ�̸� �ʱ�ȭ
        }
    }

    void SpawnSlime()
    {
        // Spawner GameObject�� ��ġ�� spawnPoint�� ���
        Vector3 spawnPosition = transform.position;

        // �������� Spawner ��ġ�� ����
        if (slimePrefab != null)
        {
            Instantiate(slimePrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("������ �������� �������� �ʾҽ��ϴ�.");
        }
    }
}
