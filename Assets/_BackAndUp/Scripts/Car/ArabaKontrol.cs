using System;
using System.Collections.Generic;
using UnityEngine;

public class ArabaKontrol : MonoBehaviour
{

    float InputX, InputY;

    float _Hiz = 500f;
    float _DonusHassasiyeti = 1f;
    float _DonusAcisi = 45f;

    public List<WheelCollider> _Tekerler;
    public List<GameObject> M_Tekerler;
    
    void Start()
    {
        Application.targetFrameRate = 180;
    }

    // Update is called once per frame
    void Update()
    {
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");

        foreach (var item in _Tekerler)
        {
            item.motorTorque = InputY * Time.deltaTime * _Hiz * 1000;
        }

        TekerDondur();
        ElFreni();
    }

    private void TekerDondur()
    {
        _Tekerler[0].steerAngle = InputX * _DonusHassasiyeti * _DonusAcisi;
        _Tekerler[2].steerAngle = InputX * _DonusHassasiyeti * _DonusAcisi;

        for (int i = 0; i < _Tekerler.Count; i++)
        {
            _Tekerler[i].GetWorldPose(out Vector3 _Pos, out Quaternion _Rot);
            M_Tekerler[i].transform.SetPositionAndRotation(_Pos, _Rot);
        }

            // _Tekerler[0].GetWorldPose(out Vector3 _Pos, out Quaternion _Rot);
            // M_Tekerler[0].transform.SetPositionAndRotation(_Pos, _Rot);

            // _Tekerler[1].GetWorldPose(out Vector3 _Pos2, out Quaternion _Rot2);
            // M_Tekerler[1].transform.SetPositionAndRotation(_Pos2, _Rot2);
    }

    void ElFreni()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var item in _Tekerler)
            {
                item.brakeTorque = 4000f;
                
            }
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
                     foreach (var item in _Tekerler)
            {
                item.brakeTorque = 0f;
                
            }   
        }
    }

}
