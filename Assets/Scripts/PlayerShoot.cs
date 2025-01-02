using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform gunbarrel;
    private ReloadBarUI reloadBarUI;

    private void Start()
    {
        reloadBarUI = GetComponent<ReloadBarUI>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && reloadBarUI.bullet != 0)
        {
            Shoot();
            reloadBarUI.DecreaseBullet();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            reloadBarUI.Reload();
        }
    }

    public void Shoot()
    {
        // �Ѿ� ���� ��ġ�� �⺻ ȸ����
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/bullet") as GameObject, gunbarrel.position, gunbarrel.rotation);

        // ī�޶��� ���� ������ ��������
        Vector3 shootDirection = Camera.main.transform.forward;

        // �Ѿ� ȸ���� 90�� ȸ���� �߰� (Y�� �������� ȸ�� ����)
        Quaternion additionalRotation = Quaternion.Euler(90, 0, 0); // Y�� �������� 90�� ȸ��
        bullet.transform.rotation = gunbarrel.rotation * additionalRotation;

        // �Ѿ˿� �ӵ��� �ο� (velocity ����)
        bullet.GetComponent<Rigidbody>().velocity = shootDirection * 40;
    }
}
