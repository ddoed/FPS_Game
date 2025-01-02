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
        // 총알 생성 위치와 기본 회전값
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/bullet") as GameObject, gunbarrel.position, gunbarrel.rotation);

        // 카메라의 정면 방향을 가져오기
        Vector3 shootDirection = Camera.main.transform.forward;

        // 총알 회전에 90도 회전을 추가 (Y축 기준으로 회전 예제)
        Quaternion additionalRotation = Quaternion.Euler(90, 0, 0); // Y축 기준으로 90도 회전
        bullet.transform.rotation = gunbarrel.rotation * additionalRotation;

        // 총알에 속도를 부여 (velocity 설정)
        bullet.GetComponent<Rigidbody>().velocity = shootDirection * 40;
    }
}
